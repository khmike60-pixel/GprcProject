using GrpcCommonNet.Library.Bank;
using GrpcCommonNet.Library.Common;
using GrpcWinForms.Objects.Banks.Views;
using GrpcWinForms.GrpcUtils;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Banks.Presenters
{
    public class BanksPresenter
    {
        private readonly IBanksView _view;

        public BanksPresenter(IBanksView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public async Task RefreshAsync()
        {
            _view.BeginUpdate();
            try
            {
                var request = new BankFilterRequest()
                {
                    Name = _view.ShortFilter ?? string.Empty,
                    FieldMask = new FieldMask()
                };
                request.FieldMask.Paths.AddRange(new[] { "id", "name", "geolocation", "short", "bank_code" });

                var response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Bank.GetListBankAsync(request).ResponseAsync);

                _view.Banks = new BindingList<Bank>(response.Banks);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при получении данных: " + ex.Message, "Ошибка");
            }
            finally
            {
                _view.EndUpdate();
            }
        }

        public async Task NewAsync()
        {
            try
            {
                using var form = new Forms.BankForm();
                if (_view.ShowBankDialog(form) != DialogResult.OK) return;

                var request = new CreateBankRequest() { Bank = form.Bank };
                var response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Bank.CreateBankAsync(request).ResponseAsync);

                if (response.Result.Status != Status.Ok || response.Bank == null)
                {
                    _view.ShowMessage("Добавить данные не удалось.", "Ошибка");
                    return;
                }

                int insertIndex = Math.Max(0, _view.RowSel - _view.RowsFixed);
                _view.InsertBankAt(insertIndex, response.Bank);
                _view.SetRow(_view.RowSel); // оставить позицию
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при создании: " + ex.Message, "Ошибка");
            }
        }

        public async Task DuplicateAsync()
        {
            try
            {
                var bank = _view.GetBankAtRow(_view.RowSel);
                if (bank == null) return;

                // Копируем объект как в исходном коде
                var copy = new Bank
                {
                    Id = 0,
                    Name = bank.Name + " 1",
                    Short = bank.Short,
                    BankCode = bank.BankCode,
                    Geolocation = bank.Geolocation
                };

                var request = new CreateBankRequest() { Bank = copy };
                var response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Bank.CreateBankAsync(request).ResponseAsync);

                if (response.Result.Status != Status.Ok || response.Bank == null)
                {
                    _view.ShowMessage("Добавить данные не удалось.", "Ошибка");
                    return;
                }

                int insertIndex = Math.Max(0, _view.RowSel - _view.RowsFixed);
                _view.InsertBankAt(insertIndex, response.Bank);
                _view.SetRow(_view.RowSel);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при копировании: " + ex.Message, "Ошибка");
            }
        }

        public async Task EditAsync()
        {
            try
            {
                var bank = _view.GetBankAtRow(_view.RowSel);
                if (bank == null) return;

                using var form = new Forms.BankForm() { Bank = bank };
                if (_view.ShowBankDialog(form) != DialogResult.OK) return;

                var request = new UpdateBankRequest() { Bank = form.Bank };
                var response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Bank.UpdateBankAsync(request).ResponseAsync);

                if (response.Result.Status != Status.Ok || response.Bank == null)
                {
                    _view.ShowMessage("Изменить данные не удалось.", "Ошибка");
                    return;
                }

                int idx = _view.RowSel - _view.RowsFixed;
                _view.ReplaceBankAt(idx, response.Bank);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при изменении: " + ex.Message, "Ошибка");
            }
        }

        public async Task DeleteAsync()
        {
            try
            {
                if (_view.SelectedRows == null || _view.SelectedRows.Count == 0)
                {
                    var dr = MessageBox.Show("Удалить текущую строку данных?", "Удаление", MessageBoxButtons.OKCancel);
                    if (dr != DialogResult.OK) return;

                    int id = _view.GetIdAtRow(_view.RowSel);
                    var request = new DeleteBankRequest() { Id = id };
                    var response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Bank.DeleteBankAsync(request).ResponseAsync);

                    int i = _view.RowSel - _view.RowsFixed;
                    if (response.Result.Status == Status.Ok)
                    {
                        _view.RemoveAt(i);
                    }
                    else
                    {
                        _view.ShowMessage("Ошибка при удалении: " + response.Result.Message, "Ошибка");
                    }
                }
                else
                {
                    var dr = MessageBox.Show($"Вы отметили {_view.SelectedRows.Count} строк.\nУдалить отмеченные строки?", "Удаление", MessageBoxButtons.OKCancel);
                    if (dr != DialogResult.OK) return;

                    var ids = new List<int>();
                    foreach (var idx in _view.SelectedRows) ids.Add(_view.GetIdAtRow(idx));

                    var request = new DeleteIdsBankRequest();
                    request.Ids.AddRange(ids);

                    var response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Bank.DeleteIdsBankAsync(request).ResponseAsync);

                    if (response.Result.Status != Status.Ok)
                    {
                        _view.ShowMessage("Ошибка при удалении: " + response.Result.Message, "Ошибка");
                        return;
                    }

                    var undeleted = response.UndeletedIds.Select(i => Convert.ToInt32(i)).ToList();
                    var removed = ids.Except(undeleted).ToList();
                    _view.RemoveBanksByIds(removed);

                    if (undeleted.Count > 0)
                        _view.ShowMessage("Данные, которые не удалось удалить остались выделенными.", "Внимание");
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при удалении: " + ex.Message, "Ошибка");
            }
        }
    }
}
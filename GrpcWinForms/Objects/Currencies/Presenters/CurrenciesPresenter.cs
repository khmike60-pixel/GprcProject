using GrpcWinForms.Objects.Currencies.Views;
using GrpcCommonNet.Library.Currency;
using Google.Protobuf.WellKnownTypes;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using GrpcCommonNet.Library.Common;

namespace GrpcWinForms.Objects.Currencies.Presenters
{
    public class CurrenciesPresenter
    {
        private readonly ICurrenciesView _view;

        public CurrenciesPresenter(ICurrenciesView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public async Task RefreshAsync()
        {
            try
            {
                var request = new ListCurrencyRequest
                {
                    IncludeInvisible = _view.IncludeInvisible,
                    CurrencyAbbrev = string.IsNullOrWhiteSpace(_view.CurrencyAbbrev) ? string.Empty : _view.CurrencyAbbrev,
                    FieldMask = new FieldMask()
                };
                request.FieldMask.Paths.Add("name");
                request.FieldMask.Paths.Add("code");
                request.FieldMask.Paths.Add("id");
                request.FieldMask.Paths.Add("abbrev");
                request.FieldMask.Paths.Add("order_number");
                request.FieldMask.Paths.Add("is_visible");

                ListCurrencyResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Currency.GetListCurrencyAsync(request).ResponseAsync
                );

                _view.Currencies = new BindingList<Currency>(response.Currencies);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при получении данных: " + ex.Message, "Ошибка");
            }
        }

        public async Task NewAsync()
        {
            using (var form = new GrpcWinForms.Objects.Currencies.Forms.CurrencyForm())
            {
                form.IsNew = true;
                form.Currency = new Currency();

                if (_view.ShowCurrencyDialog(form) == DialogResult.OK)
                {
                    try
                    {
                        var request = new CreateCurrencyRequest { Currency = form.Currency };
                        CurrencyResponse response = await GrpcRetry.CallAsync(() =>
                            GrpcClients.GrpcClients.Currency.CreateCurrencyAsync(request).ResponseAsync
                        );

                        if (response.Result.Status != Status.Ok || response.Currency == null)
                        {
                            _view.ShowMessage("Добавить данные не удалось.", "Ошибка");
                            return;
                        }

                        // Вставляем в существующий BindingList, если он есть
                        if (_view.Currencies != null)
                        {
                            int insertIndex = Math.Max(0, _view.RowSel - /*Rows.Fixed*/ 1); // Rows.Fixed проксируется в View, упрощение
                            _view.Currencies.Insert(insertIndex, response.Currency);
                        }
                        else
                        {
                            await RefreshAsync();
                        }
                    }
                    catch (Exception ex)
                    {
                        _view.ShowMessage("Ошибка при создании: " + ex.Message, "Ошибка");
                    }
                }
            }
        }

        public async Task EditAsync()
        {
            if (_view.Currencies == null || _view.RowSel < 1) return;

            var existing = _view.Currencies[_view.RowSel - 1];
            using (var form = new GrpcWinForms.Objects.Currencies.Forms.CurrencyForm())
            {
                form.IsNew = false;
                form.Currency = existing;

                if (_view.ShowCurrencyDialog(form) == DialogResult.OK)
                {
                    try
                    {
                        var request = new UpdateCurrencyRequest { Currency = form.Currency };
                        CurrencyResponse response = await GrpcRetry.CallAsync(() =>
                            GrpcClients.GrpcClients.Currency.UpdateCurrencyAsync(request).ResponseAsync
                        );

                        if (response.Result.Status != Status.Ok || response.Currency == null)
                        {
                            _view.ShowMessage("Изменить данные не удалось.", "Ошибка");
                            return;
                        }

                        _view.Currencies[_view.RowSel - 1] = response.Currency;
                    }
                    catch (Exception ex)
                    {
                        _view.ShowMessage("Ошибка при обновлении: " + ex.Message, "Ошибка");
                    }
                }
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

                    int id = Convert.ToInt32(_view.Currencies[_view.RowSel - 1].Id);
                    var request = new DeleteCurrencyRequest { Id = id };
                    var response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Currency.DeleteCurrencyAsync(request).ResponseAsync
                    );

                    if (response.Result.Status == Status.Ok)
                    {
                        _view.Currencies.RemoveAt(_view.RowSel - 1);
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
                    foreach (var idx in _view.SelectedRows)
                    {
                        ids.Add(Convert.ToInt32(_view.Currencies[idx - 1].Id));
                    }

                    var request = new DeleteIdsCurrencyRequest();
                    request.Ids.AddRange(ids);

                    UndeletedIdsCurrencyResponse response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Currency.DeleteIdsCurrencyAsync(request).ResponseAsync
                    );

                    if (response.Result.Status != Status.Ok)
                    {
                        _view.ShowMessage("Ошибка при удалении: " + response.Result.Message, "Ошибка");
                        // Обновим список для консистентности
                        await RefreshAsync();
                        return;
                    }

                    // Обновим представление: перезагрузим список (упрощённо)
                    await RefreshAsync();

                    if (response.UndeletedIds.Count > 0)
                    {
                        _view.ShowMessage("Данные, которые не удалось удалить, остались.", "Информация");
                    }
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при удалении: " + ex.Message, "Ошибка");
            }
        }

        public void OnItemDoubleClicked()
        {
            if (!_view.DialogMode) return;
            if (_view.RowSel < 1) return;

            var selected = _view.Currencies[_view.RowSel - 1];
            _view.CloseWithResult(selected);
        }
    }
}
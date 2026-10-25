using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Currency;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Models;
using GrpcWinForms.Objects.Currencies.Repositories;
using GrpcWinForms.Objects.Currencies.Views.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                _view.SetBusy(true);

                BindingList<Currency> currencies = await CurrencyRepository.GetCurrenciesAsync(_view.IncludeInvisible, _view.CurrencyAbbrev ?? string.Empty);
                _view.Currencies = currencies;
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при получении данных: " + ex.Message, "Ошибка");
            }
            finally { _view.SetBusy(false); }
        }

        public async Task NewAsync()
        {
            using (var form = new GrpcWinForms.Objects.Currencies.Views.CurrencyForm())
            {
                form.IsNew = true;
                form.Currency = new Currency();

                if (_view.ShowCurrencyDialog(form) == DialogResult.OK)
                {
                    try
                    {
                        _view.SetBusy(true);
                        Currency currency = await CurrencyRepository.CreateCurrencyAsync(form.Currency);
                        // Вставляем в существующий BindingList, если он есть
                        if (_view.Currencies != null)
                        {
                            int insertIndex = Math.Max(0, _view.RowSel - 1);
                            _view.Currencies.Insert(insertIndex, currency);
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
                    finally { _view.SetBusy(false); };
                }
            }
        }

        public async Task EditAsync()
        {
            if (_view.Currencies == null || _view.RowSel < 1) return;

            var existing = _view.Currencies[_view.RowSel - 1];
            using (var form = new GrpcWinForms.Objects.Currencies.Views.CurrencyForm())
            {
                form.IsNew = false;
                form.Currency = existing;

                if (_view.ShowCurrencyDialog(form) == DialogResult.OK)
                {
                    try
                    {
                        _view.SetBusy(true);
                        _view.Currencies[_view.RowSel - 1] =
                            await CurrencyRepository.UpdateCurrencyAsync(form.Currency);


                        //var request = new UpdateCurrencyRequest { Currency = form.Currency };
                        //CurrencyResponse response = await GrpcRetry.CallAsync(() =>
                        //    GrpcClients.GrpcClients.Currency.UpdateCurrencyAsync(request).ResponseAsync
                        //);

                        //if (response.Result.Status != Status.Ok || response.Currency == null)
                        //{
                        //    _view.ShowMessage("Изменить данные не удалось.", "Ошибка");
                        //    return;
                        //}

                        //_view.Currencies[_view.RowSel - 1] = response.Currency;
                    }
                    catch (Exception ex)
                    {
                        _view.ShowMessage("Ошибка при обновлении: " + ex.Message, "Ошибка");
                    }
                    finally { _view.SetBusy(false); }
                    }
            }
        }

        public async Task DeleteAsync()
        {
            try
            {
                _view.SetBusy(true);
                if (_view.SelectedRows == null || _view.SelectedRows.Count == 0)
                {
                    var dr = MessageBox.Show("Удалить текущую строку данных?", "Удаление", MessageBoxButtons.OKCancel);
                    if (dr != DialogResult.OK) return;

                    int id = Convert.ToInt32(_view.Currencies[_view.RowSel - 1].Id);
                    bool deletedOk = await CurrencyRepository.DeleteCurrencyAsync(id);
                    if (deletedOk)
                    {
                        _view.Currencies.RemoveAt(_view.RowSel - 1);
                    }
                    else
                    {
                        _view.ShowMessage("Ошибка при удалении.", "Ошибка");
                    }
                }
                else
                {
                    var dr = MessageBox.Show($"Вы отметили {_view.SelectedRows.Count} строк.\nУдалить отмеченные строки?", "Удаление", MessageBoxButtons.OKCancel);
                    if (dr != DialogResult.OK) return;

                    var ids = new List<int>();
                    var indxs = new List<int>();
                    foreach (var idx in _view.SelectedRows)
                    {
                        ids.Add(Convert.ToInt32(_view.Currencies[idx - 1].Id));
                        indxs.Add(idx - 1);
                    }
                    indxs.Sort();

                    List<int> undeletedIds = await CurrencyRepository.DeleteCurrenciesAsync(ids);

                    // Удаляем из BindingList только те, которые были успешно удалены
                    List<int> idx_undeleted = new();
                    for (int i = indxs.Count - 1; i >= 0; i--)
                    {
                        int index = indxs[i];
                        int id = Convert.ToInt32(_view.Currencies[index].Id);
                        if (!undeletedIds.Contains(id))
                        {
                            _view.Currencies.RemoveAt(index);
                            //_view.SelectedRows.Remove(index + 1);
                        }
                        else idx_undeleted.Add(index);
                    }

                    if (undeletedIds.Count > 0)
                    {
                        _view.SelectedRows = idx_undeleted;
                        _view.ShowMessage("Данные, которые не удалось удалить, остались помеченными.", "Информация");
                    }

                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при удалении: " + ex.Message, "Ошибка");
            }
            finally { _view.SetBusy(false); }
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
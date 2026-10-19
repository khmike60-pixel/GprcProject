using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Currency;
using GrpcWinForms.Objects.Currencies.Views.Interfaces;
using GrpcWinForms.Objects.Currencies.Repositories;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Currencies.Presenters
{
    public class RatesPresenter
    {
        private readonly IRatesView _view;

        public RatesPresenter(IRatesView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public async Task RefreshCurrencyRatesAsync()
        {
            try
            {
                _view.SetBusy(true);
                // Используем единый репозиторий
                _view.CurrencyRates = await CurrencyRepository.GetCurrencyRatesByDateAsync(
                    _view.IncludeInvisible,
                    string.IsNullOrWhiteSpace(_view.Abbrev) ? string.Empty : _view.Abbrev,
                    _view.DateRates
                );
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при получении списка валют: " + ex.Message, "Ошибка");
            }
            finally {  _view.SetBusy(false); }
        }

        public async Task RefreshRatesAsync()
        {
            var currencyRate = _view.GetSelectedCurrencyRate();
            if (currencyRate == null)
            {
                _view.Rates = new BindingList<Rate>();
                return;
            }

            try
            {
                _view.SetBusy(true);

                // Через репозиторий: передаём интервал (по умолчанию от UnixEpoch до выбранной даты)
                _view.Rates = await CurrencyRepository.GetRatesAsync(
                    currencyRate.Id,
                    DateTime.UnixEpoch,
                    _view.DateRates
                );
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при получении курсов: " + ex.Message, "Ошибка");
                _view.Rates = new BindingList<Rate>();
            }
            finally
            {
                _view.SetBusy(false);
            }
        }

        public async Task NewAsync()
        {
            try
            {
                _view.SetBusy(true);
                Rate curRate = _view.GetSelectedRate();
                Rate newRate = await CurrencyRepository.CreateRateAsync(curRate);
                if (newRate != null)
                {
                    int insertIndex = Math.Max(0, _view.RowCol);
                    _view.Rates.Insert(insertIndex, newRate);
                }
                else
                    _view.ShowMessage("Ошибка при создании новой строки", "Ошибка");
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при создании новой строки: " + ex.Message, "Ошибка");
            }
            finally { _view.SetBusy(false); }
        }

        public async Task EditAsync(Rate rate)
        {
            try
            {
                _view.SetBusy(true);

                Rate newRate = await CurrencyRepository.UpdateRateAsync(rate);
                if(newRate != null) 
                    _view.Rates[_view.Row] = newRate;
                else
                    _view.ShowMessage("Ошибка при редактировании строки", "Ошибка");
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при редактировании строки: " + ex.Message, "Ошибка");
            }
            finally { _view.SetBusy(false); }
        }

        public async Task DeleteAsync(List<int> selectedRows)
        {
            try
            {
                _view.SetBusy(true);

                List<int> ids = new List<int>();
                foreach (Rate rate in _view.SelectedRates)
                    ids.Add(rate.RateId);

                List<int> undeletedIds = new List<int>();
                undeletedIds = await CurrencyRepository.DeleteRatesAsync(ids);

                _view.SelectedRows.Sort();

                // Удаляем из BindingList только те записи, которые были успешно удалены
                List<int> newSelectedRows = new List<int>();
                for (int i = _view.SelectedRows.Count - 1; i >= 0; i--)
                {
                    int index = _view.SelectedRows[i];
                    int rateId = _view.GetRateId(index);
                    if (!undeletedIds.Contains(rateId))
                    {
                        _view.Rates.RemoveAt(index);
                    }
                    else { newSelectedRows.Add(index); }
                }

                if (undeletedIds.Count > 0)
                {
                    _view.SelectedRows = newSelectedRows;
                    _view.ShowMessage("Данные, которые не удалось удалить, остались помеченными.", "Информация");
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при удалении строк: " + ex.Message, "Ошибка");
            }
            finally { _view.SetBusy(false); }

        }
    }
}
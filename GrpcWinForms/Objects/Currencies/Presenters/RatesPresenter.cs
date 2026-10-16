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
                    int insertIndex = Math.Max(0, _view.RowSel);
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

        public async Task EditAsync()
        {
            try
            {
                _view.SetBusy(true);
                Rate editedRate = _view.GetSelectedRate();
                Rate newRate = await CurrencyRepository.UpdateRateAsync(editedRate);
                if(newRate != null) 
                    _view.Rates[_view.RowSel] = newRate;
                else
                    _view.ShowMessage("Ошибка при редактировании строки", "Ошибка");
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при редактировании строки: " + ex.Message, "Ошибка");
            }
            finally { _view.SetBusy(false); }
        }
    }
}
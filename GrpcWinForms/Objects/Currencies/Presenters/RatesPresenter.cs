using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Currency;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Objects.Currencies.Views;
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
                var request = new GetListCurrencyRateDateRequest
                {
                    IncludeInvisible = _view.IncludeInvisible,
                    Abbrev = string.IsNullOrWhiteSpace(_view.Abbrev) ? string.Empty : _view.Abbrev,
                    Date = _view.DateRates.ToLocalTime().ToUniversalTime().ToTimestamp()
                };

                var response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Currency.GetListCurrencyRateDateAsync(request).ResponseAsync
                );

                _view.CurrencyRates = new BindingList<CurrencyRate>(response.CurrencyRates);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при получении списка валют: " + ex.Message, "Ошибка");
            }
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
                _view.ShowLoader();

                var request = new ListCurrencyRateRequest
                {
                    CurrencyId = currencyRate.Id,
                    StartDate = Timestamp.FromDateTime(DateTime.UnixEpoch),
                    EndDate = _view.DateRates.ToLocalTime().ToUniversalTime().ToTimestamp()
                };

                var response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Currency.GetListCurrencyRateAsync(request).ResponseAsync
                );

                _view.Rates = new BindingList<Rate>(response.Rates);
            }
            catch (Exception ex)
            {
                _view.ShowMessage("Ошибка при получении курсов: " + ex.Message, "Ошибка");
                _view.Rates = new BindingList<Rate>();
            }
            finally
            {
                _view.HideLoader();
            }
        }
    }
}
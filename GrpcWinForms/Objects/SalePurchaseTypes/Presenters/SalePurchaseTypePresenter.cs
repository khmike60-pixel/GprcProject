using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.SalePurchaseType;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Objects.Currencies.Views;
using GrpcWinForms.Objects.SalePurchaseTypes.Models;
using GrpcWinForms.Objects.SalePurchaseTypes.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.SalePurchaseTypes.Presenters
{
    public class SalePurchaseTypePresenter
    {
        private readonly ISalePurchaseTypesView _view;

        public SalePurchaseTypePresenter(ISalePurchaseTypesView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public async Task RefreshSalePurchaseTypesAsync()
        {
            ListSalePurchaseTypeRequest request = new ListSalePurchaseTypeRequest()
            {
                Name = ""
            };
            var response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.SalePurchaseType.ListSalePurchaseTypeAsync(request).ResponseAsync);

            _view.SalePurchaseTypes = new BindingList<SalePurchaseType>(response.SalePurchaseTypes);

        }

        public async Task RefreshSalePurchaseGridRateAsync()
        {
            ListSalePurchaseRateRequest request = new ListSalePurchaseRateRequest()
            {
                DateStart = null,
                DateEnd = null
            };
            var response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.SalePurchaseType.ListSalePurchaseRateAsync(request).ResponseAsync);
            List<SalePurchaseGridRate> rates = new List<SalePurchaseGridRate>();
            foreach(SalePurchaseRate rate in response.Rates)
            {
                SalePurchaseGridRate rowRate = new SalePurchaseGridRate();
                rowRate.Id = rate.Id;
                rowRate.Date = rate.Date.ToDateTime();
                rates.Add(rowRate); 
            }

            _view.SalePurchaseGridRates = new BindingList<SalePurchaseGridRate>(rates);

        }

    }
}

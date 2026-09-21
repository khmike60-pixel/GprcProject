using Google.Protobuf;
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
using System.Text.Json.Nodes;
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

        public async Task RefreshSalePurchaseCurrenciesAsync(SalePurchaseType type)
        {
            string jsonString = JsonFormatter.Default.Format(type.Data);

            // 2. Десериализуем строку в список объектов C#
            List<SalePurchaseCurrency> currencies = 
                JsonSerializer.Deserialize<List<SalePurchaseCurrency>>(jsonString, 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
            _view.SalePurchaseCurrencies = new BindingList<SalePurchaseCurrency>(currencies);
        }


    }
}

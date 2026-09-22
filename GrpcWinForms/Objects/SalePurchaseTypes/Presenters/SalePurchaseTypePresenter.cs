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
        private readonly SPType _model;

        public SalePurchaseTypePresenter(ISalePurchaseTypesView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public async Task<BindingList<SalePurchaseType>> RefreshSalePurchaseTypesAsync()
        {
            ListSalePurchaseTypeRequest request = new ListSalePurchaseTypeRequest();
            var response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.SalePurchaseType.ListSalePurchaseTypeAsync(request).ResponseAsync);
            
            
            _view.SalePurchaseTypes = new BindingList<SalePurchaseType>(response.SalePurchaseTypes);

            return _view.SalePurchaseTypes;
        }

        public async Task<BindingList<Currency>> RefreshSalePurchaseCurrenciesAsync(SalePurchaseType type)
        {
            string jsonString = JsonFormatter.Default.Format(type.Data);

            // 2. Десериализуем строку в список объектов C#
            var parser = new Google.Protobuf.JsonParser(Google.Protobuf.JsonParser.Settings.Default.WithIgnoreUnknownFields(true));
            
            var structObject = parser.Parse<Google.Protobuf.WellKnownTypes.Struct>(jsonString);

            var currencyList = parser.Parse<Google.Protobuf.WellKnownTypes.Struct>(jsonString).Fields["currency_in_use"].ListValue;
            List<Currency> currencies = new List<Currency>();
            foreach (var item in currencyList.Values)
            {
                var fields = item.StructValue.Fields;

                currencies.Add(new Currency
                {
                    Id = (int)fields["id"].NumberValue,
                    Abbrev = fields["code"].StringValue
                });
            }


            _view.Currencies = new BindingList<Currency>(currencies);
            return _view.Currencies;
        }




    }
}

using Google.Protobuf;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.SalePurchaseType;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Objects.Currencies.Views;
using GrpcWinForms.Objects.SalePurchaseTypes.Models;
using GrpcWinForms.Objects.SalePurchaseTypes.Views;
using SmartLib;
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

        public async Task OnClick_NewAsync()
        {
            //CreateSalePurchaseTypeRequest request = new CreateSalePurchaseTypeRequest()
            //{
            //    SalePurchaseType = new SalePurchaseType()
            //    {
                    
            //    }
            //};
            //SalePurchaseTypeResponse response = new SalePurchaseTypeResponse();
            //response = await GrpcRetry.CallAsync(() =>
            //        GrpcClients.GrpcClients.SalePurchaseType.CreateSalePurchaseTypeAsync(request).ResponseAsync);
            //return;
        }

        public async Task<SalePurchaseType> OnClick_EditAsync()
        {
            UpdateSalePurchaseTypeRequest request = new UpdateSalePurchaseTypeRequest()
            {
                SalePurchaseType = new SalePurchaseType()
                {

                }
            };
            SalePurchaseTypeResponse response = new SalePurchaseTypeResponse();
            response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.SalePurchaseType.UpdateSalePurchaseTypeAsync(request).ResponseAsync);
            return response.SalePurchaseType;
        }

        public async Task OnClick_DeleteAsync(List<int> selectedRows)
        {
            List<int> deleteIds= new List<int>();   
            int fixedRows = _view.GridTypes.Rows.Fixed;
            selectedRows.Sort();

            foreach (int row in selectedRows)
            {
                SalePurchaseType type = _view.GridTypes.Rows[row - fixedRows + 1].DataSource as SalePurchaseType;
                deleteIds.Add(type.Id ?? 0);
            }

            DeleteSalePurchaseTypeRequest request = new DeleteSalePurchaseTypeRequest();
            request.Ids.AddRange(deleteIds);

            DeleteSalePurchaseTypeResponse response = new DeleteSalePurchaseTypeResponse();
            response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.SalePurchaseType.DeleteSalePurchaseTypeAsync(request).ResponseAsync);
            
            List<int> undeletedIds = new List<int>();
            undeletedIds.AddRange(response.UndeletedIds);

            for (int i = selectedRows.Count - 1; i >= 0; i--)
            {
                SalePurchaseType type = _view.GridTypes.Rows[i].DataSource as SalePurchaseType;
                for (int j = 0; j < undeletedIds.Count; j++)
                {
                    if (undeletedIds[j] != type.Id)
                    {
                        _view.GridTypes.Rows.Remove(i);
                        _view.GridTypes.SelectedRows.Remove(i);
                        break;
                    }
                }
            }
            return;
        }

    }
}

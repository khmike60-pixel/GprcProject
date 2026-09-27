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
    public class SalePurchaseTypesPresenter
    {
        private readonly ISalePurchaseTypesView _view;

        public SalePurchaseTypesPresenter(ISalePurchaseTypesView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));

            // Подписываемся на события View
            _view.OnLoadTypesAsync += HandleLoadTypesAsync;
            _view.OnAppendTypesAsync += HandleAppendTypesAsync;
            _view.OnDeleteTypesAsync += HandleDeleteTypesAsync;
            _view.OnRefreshTypesAsync += HandleRefreshTypesAsync;

        }

        public async Task<BindingList<SalePurchaseType>> RefreshSalePurchaseTypesAsync()
        {
            ListSalePurchaseTypeRequest request = new ListSalePurchaseTypeRequest();
            var response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.SalePurchaseType.ListSalePurchaseTypeAsync(request).ResponseAsync);
            
            
            _view.SalePurchaseTypes = new BindingList<SalePurchaseType>(response.SalePurchaseTypes);

            return _view.SalePurchaseTypes;
        }

        public async Task HandleLoadTypesAsync(CancellationToken ct)
        {

        }

        private async Task HandleAppendTypesAsync(SalePurchaseType model, CancellationToken ct)
        {
            CreateSalePurchaseTypeRequest request = new CreateSalePurchaseTypeRequest()
            {
                SalePurchaseType = new SalePurchaseType()
                {
                }
            };
            SalePurchaseTypeResponse response = new SalePurchaseTypeResponse();
            response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.SalePurchaseType.CreateSalePurchaseTypeAsync(request).ResponseAsync).ConfigureAwait(false);
            return;
        }

        private async Task HandleDeleteTypesAsync(IReadOnlyList<int> ids, CancellationToken ct)
        {

        }

        private async Task HandleRefreshTypesAsync(CancellationToken ct)
        {
            await RefreshAsync(ct).ConfigureAwait(false);
        }

        public async Task<BindingList<CurrencyUsing>> RefreshSalePurchaseCurrenciesAsync(SalePurchaseType type)
        {
            _view.Currencies = new BindingList<CurrencyUsing>(type.CurrenciesUsing);
            return _view.Currencies;
        }

        public async Task RefreshAsync(CancellationToken ct)
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

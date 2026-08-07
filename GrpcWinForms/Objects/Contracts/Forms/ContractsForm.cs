using Google.Protobuf.WellKnownTypes;
using GrapeCity.Documents.Common;
using Grpc.Core;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contract;
using GrpcCommonNet.Library.Contragent;
using GrpcCommonNet.Proto.Utils;
using GrpcWinForms.Controls.CompanyDropDown;
using GrpcWinForms.Forms;
using GrpcWinForms.Models;
using GrpcWinForms.Objects.Contracts.Forms.ContractViews;
using GrpcWinForms.Objects.Contracts.Models;
using GrpcWinForms.GrpcUtils;
using SmartGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Line = GrpcCommonNet.Library.Contract.Line;

namespace GrpcWinForms.Objects.Contracts.Forms
{
    public partial class ContractsForm : Form
    {
        private static ContractServices.ContractServicesClient _service;
        private Loader loaderContracts = new Loader();
        private Loader loaderLines = new Loader();
        private BindingList<Contract> contracts;


        public ContractsForm()
        {
            InitializeComponent();
            loaderContracts.Parent = smartGridContracts;
            loaderLines.Parent = smartGridLines;

            //smartGridContracts.Headers = new string[]
            //{
            //    "...\tId\tКонтракт\tКонтракт\tКонтракт\tКонтракт\tКонтрагенты\tКонтрагенты\tТип\tОперации\tОперации\tДействует до",
            //    "...\tId\tДата\tНомер\tСумма\tСумма\tПокупатель\tПродавец\tТип\tОплачено\tОтгружено\tДействует до"
            //};

            //smartGridLines.Headers = new string[]
            //{
            //    "...\t№\tНаименование\tИКПУ\tЕд.изм.\tКол-во\tРеализация\tРеализация\tНДС\tНДС\tСумма с НДС",
            //    "...\t№\tНаименование\tИКПУ\tЕд.изм.\tКол-во\tЦена\tСумма\t%\tСумма\tСумма с НДС"
            //};

            companyBuyer.GetDataSourceFunc = CompanyFilterLoad;
            companySeller.GetDataSourceFunc = CompanyFilterLoad;

        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiParent.MdiChildren)
            {
                if (child is ContractSaleStandartForm && ((ContractSaleStandartForm)child).ContractId == 0) { child.Activate(); return; }
            }
            var f = new ContractSaleStandartForm(0) { MdiParent = this.MdiParent };
            f.Show();

        }

        private async void RefreshContract()
        {
            loaderContracts.ShowLoader();
            try
            {
                ListContractsRequest request = new ListContractsRequest()
                {
                    StartDate = period.StartDate.ToUniversalTime().ToTimestamp(),
                    EndDate = period.EndDate.ToUniversalTime().ToTimestamp()
                };
                request.FieldMask = new Google.Protobuf.WellKnownTypes.FieldMask()
                {
                    Paths = { "id", "seller", "buyer", "number", "date", "expiration_date", "currency", "department", "data", "sum", "type_contract" }
                };
                // Вызов через обёртку, которая сама обрабатывает RpcException(Unathenticated) и повторную авторизацию
                ListContractsResponse response = await GrpcRetry.CallAsync(() => 
                    GrpcClients.GrpcClients.Contract.GetListContractsAsync(request).ResponseAsync
                );

                contracts = new BindingList<Contract>(response.Contracts);
                smartGridContracts.DataSource = contracts;
            }
            catch (Exception ex)
            {
                loaderContracts.HideLoader();
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loaderContracts.HideLoader();
            return;

        }

        private void ContractsForm_Load(object sender, EventArgs e)
        {
            try
            {
                period.StartDate = new DateTime(DateTime.Now.Year, 1, 1);
                period.EndDate = new DateTime(DateTime.Now.Year + 1, 1, 1).AddSeconds(-1);

                RefreshContract();
            } catch (RpcException ex) 
            {
                MessageBox.Show("Ошибка gRPC. \n" + ex.Message);
            }
        }


        /// <summary>
        /// Метод заполнения вычисляемых полей грида
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smartGridContracts_GetUnboundValue(object sender, C1.Win.FlexGrid.UnboundValueEventArgs e)
        {
            Contract contract = (Contract)smartGridContracts.Rows[e.Row].DataSource;
            switch (smartGridContracts.Cols[e.Col].Name)
            {
                case "colSeller":
                    {
                        e.Value = contract.Seller == null ? "" : contract.Seller.Name;
                        break;
                    }
                case "colBuyer":
                    {
                        e.Value = contract.Buyer == null ? "" : contract.Buyer.Name;
                        break;
                    }
                case "colAbbrev":
                    {
                        e.Value = contract.Currency == null ? "" : contract.Currency.Abbrev;
                        break;
                    }
                case "colDepartment":
                    {
                        e.Value = "";
                        break;
                    }
                case "colSum":
                    {
                        e.Value = contract.Sum == null || contract.Sum.Units == 0 ? "" : MyConvert.ToDecimal(contract.Sum);
                        break;
                    }
                case "colDate":
                    {
                        e.Value = contract.Date == null ? "" : contract.Date.ToDateTime();
                        break;
                    }
                case "colExpirationDate":
                    {
                        e.Value = contract.ExpirationDate == null ? "" : contract.ExpirationDate.ToDateTime();
                        break;
                    }
                case "colType":
                    {
                        e.Value = contract.TypeContract == null ? "" : contract.TypeContract.Name ?? "";
                        break;
                    }
            }
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshContract();
        }

        private async void smartGridContracts_AfterSelChange(object sender, C1.Win.FlexGrid.RangeEventArgs e)
        {
            // Считать строки контракта
            BindingList<Line> lines = new BindingList<Line>();
            try
            {
                loaderLines.ShowLoader();
                if (smartGridContracts.Row >= smartGridContracts.Rows.Fixed)
                {
                    Contract contract = (Contract)smartGridContracts.Rows[smartGridContracts.Row].DataSource;

                    ContractLineRequest request = new ContractLineRequest()
                    {
                        Id = contract.Id
                    };
                    ListContractLinesResponse response = await GrpcRetry.CallAsync(() => 
                        GrpcClients.GrpcClients.Contract.GetListContractLinesAsync(request).ResponseAsync
                    );

                    //ListContractLinesResponse response = GrpcClients.GrpcClients.Contract.GetListContractLines(request);
                    lines = new BindingList<Line>(response.Lines);
                }
                smartGridLines.DataSource = lines;
                loaderLines.HideLoader();
            }
            catch (Exception ex)
            {
                loaderLines.HideLoader();
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            smartGridContracts_DoubleClick(sender, e);

        }

        private void smartGridLines_GetUnboundValue(object sender, C1.Win.FlexGrid.UnboundValueEventArgs e)
        {
            Line line = (Line)smartGridLines.Rows[e.Row].DataSource;
            switch (smartGridLines.Cols[e.Col].Name)
            {
                case "colUnitShort":
                    {
                        e.Value = line.Unit == null ? "" : line.Unit.Short;
                        break;
                    }
                case "colQty":
                    {
                        e.Value = line.Qty == null || line.Qty.Units == 0 ? "" : MyConvert.ToDecimal(line.Qty);
                        break;
                    }
                case "colPrice":
                    {
                        e.Value = line.Price == null || line.Price.Units == 0 ? "" : MyConvert.ToDecimal(line.Price);
                        break;
                    }
                case "colAmount":
                    {
                        e.Value = line.Amount == null || line.Amount.Units == 0 ? "" : MyConvert.ToDecimal(line.Amount);
                        break;
                    }
                case "colVatPrc":
                    {
                        e.Value = line.VatPrc == null || line.VatPrc.Units == 0 ? "" : MyConvert.ToDecimal(line.VatPrc);
                        break;
                    }
                case "colSumVat":
                    {
                        e.Value = line.SumVat == null || line.SumVat.Units == 0 ? "" : MyConvert.ToDecimal(line.SumVat);
                        break;
                    }
                case "colSum":
                    {
                        e.Value = line.Sum == null || line.Sum.Units == 0 ? "" : MyConvert.ToDecimal(line.Sum);
                        break;
                    }
            }

        }

        private void smartGridContracts_DoubleClick(object sender, EventArgs e)
        {
            var row = smartGridContracts.Rows[smartGridContracts.Row].DataSource;
            Contract _contract = row as Contract;
            ViewContract(sender, _contract);
        }

        private void ViewContract(object sender, Contract contract)
        {
            string nameSpace = "GrpcWinForms.Objects.Contracts.Forms.ContractViews";
            string nameForm = "ContractSaleStandartForm";
            string fullTypeContract = $"{nameSpace}.{nameForm}";
            try
            {
                int contractId = ((Contract)smartGridContracts.Rows[smartGridContracts.Row].DataSource).Id;
                var contractType_Name = ((Contract)smartGridContracts.Rows[smartGridContracts.Row].DataSource).TypeContract?.Name;
                var contractType_Code = ((Contract)smartGridContracts.Rows[smartGridContracts.Row].DataSource).TypeContract?.Code;
                var contractType_Form = ((Contract)smartGridContracts.Rows[smartGridContracts.Row].DataSource).TypeContract?.Form;
                fullTypeContract = $"{nameSpace}.{contractType_Form}";
                string contractType = fullTypeContract;

                // Попытка получить Type по строке имени
                System.Type formType = System.Type.GetType(contractType);

                // Локальная функция: читать ContractId с РЕАЛЬНОГО типа через рефлексию, fallback на базовое свойство
                int? GetContractIdFrom(Form f)
                {
                    var prop = f.GetType().GetProperty("ContractId", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                    if (prop != null && prop.PropertyType == typeof(int))
                    {
                        try
                        {
                            return (int)prop.GetValue(f);
                        }
                        catch
                        {
                            return null;
                        }
                    }

                    if (f is ContractFormClass baseForm)
                        return baseForm.ContractId;

                    return null;
                }

                // Если Type найден — проверим, есть ли уже открыт экземпляр того же типа с таким ContractId,
                // читая значение ContractId именно с реального типа экземпляра.
                if (formType != null)
                {
                    foreach (Form child in MdiParent.MdiChildren)
                    {
                        if (child.GetType() != formType) continue;

                        int? existingId = GetContractIdFrom(child);
                        if (existingId.HasValue && existingId.Value == contractId)
                        {
                            child.Activate();
                            return;
                        }
                    }
                }

                // Создаём форму и передаём contractId фабрике
                var form = Utils.CreateForm(contractType, contractId);
                if (form == null) return;

                // Ещё одна проверка — на случай, если Type не резолвился ранее; читаем ContractId с реального типа
                foreach (Form child in MdiParent.MdiChildren)
                {
                    if (child.GetType() != form.GetType()) continue;

                    int? existingId = GetContractIdFrom(child);
                    if (existingId.HasValue && existingId.Value == contractId)
                    {
                        child.Activate();
                        form.Dispose();
                        return;
                    }
                }

                form.MdiParent = this.MdiParent;
                form.ContractChanged += UpdateContract;
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void UpdateContract(object sender, Contract contract)
        {
            if (contract == null) return;
            // Найти контракт в списке по Id
            var existingContract = contracts.FirstOrDefault(c => c.Id == contract.Id);
            if (existingContract != null)
            {
                // Обновить существующий контракт
                int index = contracts.IndexOf(existingContract);
                contracts[index] = contract;
            }
        }

        #region Методы для companyDropDown
        private BindingList<Company> CompanyFilterLoad(string filter)
        {
            SearchRequest searchRequest = new SearchRequest()
            {
                Search = filter,
                Paging = new Paging() { PageNumber = 1, PageSize = 10 }
            };

            searchRequest.FieldMask =
                new Google.Protobuf.WellKnownTypes.FieldMask() { Paths = { "id", "name", "taxno" } };

            ListContragentResponse searchResponse = GrpcClients.GrpcClients.Contragent.SearchListContragent(searchRequest);

            BindingList<Company> _contragents = new BindingList<Company>();
            foreach (Contragent item in searchResponse.Contragents)
            {
                _contragents.Add(new Company()
                {
                    Id = item.Id,
                    Name = item.Name,
                    TaxNo = item.Taxno
                });
            }
            return _contragents;
        }

        #endregion


    }
}

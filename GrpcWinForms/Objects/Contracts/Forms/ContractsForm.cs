using C1.Win.Command;
using C1.Win.FlexGrid;
using Google.Protobuf.WellKnownTypes;
using GrapeCity.Documents.Common;
using Grpc.Core;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contract;
using GrpcCommonNet.Library.Contragent;
using GrpcCommonNet.Proto.Utils;
using GrpcWinForms.Controls.CompanyDropDown;
using GrpcWinForms.Forms;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Models;
using GrpcWinForms.Objects.Contracts.Forms.ContractViews;
using GrpcWinForms.Objects.Contracts.Models;
using SmartLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
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
            loaderContracts.Parent = smartGridContracts1;
            loaderLines.Parent = smartGridLines1;

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
                    StartDate = period1.Period.From.ToUniversalTime().ToTimestamp(),
                    EndDate = period1.Period.To.ToUniversalTime().ToTimestamp()
                };
                if (companySeller.SelectedItem.Id != 0)
                    request.Seller = new Contragent() { Id = companySeller.SelectedCompany.Id };
                if (companyBuyer.SelectedItem.Id != 0)
                    request.Buyer = new Contragent() { Id = companyBuyer.SelectedCompany.Id };
                request.WithAdd = true;

                request.FieldMask = new Google.Protobuf.WellKnownTypes.FieldMask()
                {
                    Paths = { "id", "root_id", "seller", "buyer", "number", "date", "expiration_date", "currency", "department", "data", "sum", "type_contract" }
                };
                // Вызов через обёртку, которая сама обрабатывает RpcException(Unathenticated) и повторную авторизацию
                ListContractsResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Contract.GetListContractsAsync(request).ResponseAsync
                );

                List<TreeContract> treeContracts = new List<TreeContract>();
                foreach (Contract contract in response.Contracts)
                {
                    treeContracts.Add(new TreeContract()
                    { 
                        Id = contract.Id,
                        ParentId = contract.RootId,
                        Name = (contract.RootId > 0 ? "Допсоглашение" : "Контракт") + " " + contract.Number,
                        Buyer =  contract.Buyer.Entity != null ? contract.Buyer.Entity.EntityName :
                                 contract.Buyer.Person != null ? contract.Buyer.Person.PersonName : "",
                        Seller = contract.Seller.Entity != null ? contract.Seller.Entity.EntityName : 
                                 contract.Seller.Person != null ? contract.Seller.Person.PersonName : "",
                        Date = contract.Date.ToDateTime(),
                        Number = contract.Number,
                        Currency = contract.Currency.Abbrev,
                        DateExpiried = contract.ExpirationDate == null ? null : contract.ExpirationDate.ToDateTime(),
                        Paid = 0,
                        Shipped = 0,
                        Sum = MyConvert.ToDecimal(contract.Sum),
                        Type = contract.TypeContract.Name
                    }
                    );
                }
                smartGridContracts1.BuildTree(treeContracts, false);

                ProcessNodes(smartGridContracts1.Nodes);
                var x = smartGridContracts1.Nodes[3];
                var y = smartGridContracts1.Nodes[3].Nodes[0];

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
                period1.Period.From = new DateTime(DateTime.Now.Year, 1, 1);
                period1.Period.To = new DateTime(DateTime.Now.Year + 1, 1, 1).AddSeconds(-1);

                RefreshContract();
            }
            catch (RpcException ex)
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
            Contract contract = (Contract)smartGridContracts1.Rows[e.Row].DataSource;
            TreeContract treeContract = smartGridContracts1.Rows[e.Row].Node.Key as TreeContract;


            switch (smartGridContracts1.Cols[e.Col].Name)
            {
                case "colSeller":
                    {
                        e.Value = treeContract.Seller;
                        break;
                    }
                case "colBuyer":
                    {
                        e.Value = treeContract.Buyer;
                        break;
                    }
                case "colAbbrev":
                    {
                        e.Value = treeContract.Currency;
                        break;
                    }
                case "colDepartment":
                    {
                        e.Value = "";
                        break;
                    }
                case "colSum":
                    {
                        e.Value = treeContract.Sum;
                        break;
                    }
                case "colDate":
                    {
                        e.Value = treeContract.Date == null ? "" : treeContract.Date;
                        break;
                    }
                case "colExpirationDate":
                    {
                        e.Value = treeContract.DateExpiried == null ? "" : treeContract.DateExpiried;
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
                if (smartGridContracts1.Row < smartGridContracts1.Rows.Fixed) return;
                if (smartGridContracts1.Rows[smartGridContracts1.Row].Node == null) return;
                loaderLines.ShowLoader();
                if (smartGridContracts1.Row >= smartGridContracts1.Rows.Fixed)
                {
                    //Contract contract = (Contract)smartGridContracts1.Rows[smartGridContracts1.Row].DataSource;
                    TreeContract _obj = smartGridContracts1.Rows[smartGridContracts1.Row].Node.Key as TreeContract;
                    
                    //treeContract = smartGridContracts1.Rows[smartGridContracts1.Row].Node.Key as TreeContract;

                    ContractLineRequest request = new ContractLineRequest()
                    {
                        Id = _obj.Id
                    };
                    ListContractLinesResponse response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Contract.GetListContractLinesAsync(request).ResponseAsync
                    );

                    lines = new BindingList<Line>(response.Lines);
                }
                smartGridLines1.DataSource = lines;
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
            Line line = (Line)smartGridLines1.Rows[e.Row].DataSource;
            switch (smartGridLines1.Cols[e.Col].Name)
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
            Point pt = smartGridContracts1.PointToClient(Control.MousePosition);
            HitTestInfo hit = smartGridContracts1.HitTest(pt);

            if (hit.Row + 1 > smartGridContracts1.Rows.Count - smartGridContracts1.Footers.Descriptions.Count) return;
            if (hit.Row - 1 < smartGridContracts1.Rows.Fixed) return;

            var row = smartGridContracts1.Rows[smartGridContracts1.Row].DataSource;
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
                int contractId = ((Contract)smartGridContracts1.Rows[smartGridContracts1.Row].DataSource).Id;
                var contractType_Name = ((Contract)smartGridContracts1.Rows[smartGridContracts1.Row].DataSource).TypeContract?.Name;
                var contractType_Code = ((Contract)smartGridContracts1.Rows[smartGridContracts1.Row].DataSource).TypeContract?.Code;
                var contractType_Form = ((Contract)smartGridContracts1.Rows[smartGridContracts1.Row].DataSource).TypeContract?.Form;
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

            ListContragentResponse searchResponse = GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Contragent.SearchListContragentAsync(searchRequest).ResponseAsync
            ).GetAwaiter().GetResult();

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

        /// <summary>
        /// Метод формирует Nodes[] с учетом первичного контракта и допсоглашений
        /// </summary>
        /// <param name="nodes"></param>
        public static void ProcessNodes(Node[] nodes)
        {
            if (nodes == null) return;

            // Итерируем по копии списка, так как будем изменять его во время обхода
            var originalNodes = new List<Node>(nodes);

            foreach (var node in originalNodes)
            {
                if (node.Nodes != null && node.Nodes.Length > 0)
                {
                    // Вставляем данные самого нода в начало списка детей
                    node.AddNode(NodeTypeEnum.FirstChild, node.Data.ToString() + " (первичный) ", node.Key, null );

                    // Рекурсивно обрабатываем детей (начиная со 2-го элемента, чтобы пропустить копию)
                    // Либо передаем весь список, но внутри метода копия отфильтруется, так как у нее нет детей
                    ProcessNodes(node.Nodes);
                }
            }
        }


        private void smartGridContracts1_GridChanged(object sender, C1.Win.FlexGrid.GridChangedEventArgs e)
        {
            
        }
    }

}

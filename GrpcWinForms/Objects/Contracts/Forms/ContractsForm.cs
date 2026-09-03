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
using GrpcWinForms.Objects.Contracts.ContractViews;
using GrpcWinForms.Objects.Contracts.Models;
using GrpcWinForms.Objects.DocumentTypes.Forms;
using GrpcWinForms.Properties;
using SmartLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static C1.Util.Win.Win32;
using Line = GrpcCommonNet.Library.Contract.Line;

namespace GrpcWinForms.Objects.Contracts.Forms
{
    public partial class ContractsForm : Form
    {
        private static ContractServices.ContractServicesClient _service;
        private Loader loaderContracts = new Loader();
        private Loader loaderLines = new Loader();
        private BindingList<Contract> contracts;
        private int rowCurrentContract;

        public ContractsForm()
        {
            InitializeComponent();

            if (DesignMode) return;
            // В конструкторе не выполняем runtime-логику при загрузке в дизайнере VS.
            // DesignMode в конструкторе ненадёжен, используем LicenseManager.UsageMode.
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;


            loaderContracts.Parent = smartGridContracts1;
            loaderLines.Parent = smartGridLines1;

            companyBuyer.GetDataSourceFunc = CompanyFilterLoad;
            companySeller.GetDataSourceFunc = CompanyFilterLoad;

            // Подписываемся на событие изменения контракта
            ContractEventService.Instance.ContractChanged += OnContractChanged;

        }

        #region Refresh списка контрактов и списка строк

        private async void RefreshContract()
        {
            if (DesignMode) return;
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
                request.WithAdd = chWithAdd.Checked;

                request.FieldMask = new Google.Protobuf.WellKnownTypes.FieldMask()
                {
                    Paths = {  "node_id", "parent_node_id", "tree_level", "node_type",
                        "contract.id", "contract.root_id",
                        "contract.seller", "contract.buyer",
                        "contract.number", "contract.date", "contract.expiration_date", "contract.currency",
                        "contract.department", "contract.sum", "contract.type_contract",
                        "contract.state", "doc_name"
                    }
                };
                // Вызов через обёртку, которая сама обрабатывает RpcException(Unathenticated) и повторную авторизацию
                TreeNodeResponse response = await GrpcRetry.CallAsync(() =>
                   GrpcClients.GrpcClients.Contract.GetTreeContractsAsync(request).ResponseAsync
               );

                List<TreeContract> treeContracts = new List<TreeContract>();
                foreach (NodeContract node in response.NodeContracts)
                {
                    TreeContract treeContract = new TreeContract();
                    treeContract = treeContract.FromNodeContract(node);

                    if (!string.IsNullOrEmpty(node.Contract.DocName))
                        treeContract.Name = node.Contract.DocName + " " + node.Contract.Number;
                    treeContracts.Add(treeContract);
                }
                smartGridContracts1.BuildTree(treeContracts, false);
                foreach (Node node in smartGridContracts1.Nodes)
                    node.Collapsed = true;

                smartGridContracts1.Row = 0;
                smartGridContracts1.Row = smartGridContracts1.Rows.Fixed;

            }
            catch (Exception ex)
            {
                loaderContracts.HideLoader();
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loaderContracts.HideLoader();
            return;

        }

        private async void RefreshLines()
        {
            if (DesignMode) return;
            // Считать строки контракта
            BindingList<Line> lines = new BindingList<Line>();
            try
            {
                if (smartGridContracts1.Row < smartGridContracts1.Rows.Fixed) return;
                if (smartGridContracts1.Rows[smartGridContracts1.Row].Node == null)
                {
                    smartGridLines1.DataSource = new BindingList<Line>();
                    return;
                }
/*
                loaderLines.ShowLoader();
                if (smartGridContracts1.Row >= smartGridContracts1.Rows.Fixed)
                {
                    //Contract contract = (Contract)smartGridContracts1.Rows[smartGridContracts1.Row].DataSource;
                    TreeContract _obj = smartGridContracts1.Rows[smartGridContracts1.Row].Node.Key as TreeContract;

                    ContractLineRequest request = new ContractLineRequest()
                    {
                        Id = _obj.ContractId,
                        All = false
                    };
                    ListContractLinesResponse response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Contract.GetListContractLinesAsync(request).ResponseAsync
                    );

                    lines = new BindingList<Line>(response.Lines);
                }
                smartGridLines1.DataSource = lines;
                loaderLines.HideLoader();
*/
            }
            catch (Exception ex)
            {
                loaderLines.HideLoader();
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
        }

        private void ContractsForm_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            try
            {
                period1.Period.From = new DateTime(DateTime.Now.Year, 1, 1);
                period1.Period.To = new DateTime(DateTime.Now.Year + 1, 1, 1).AddSeconds(-1);

                RefreshContract();

                smartGridContracts1.AddSeparator();
                smartGridContracts1.AddItemToContextMenu("Новый контракт",
                    Properties.Resources.icons8_документ_50, toolStripButtonNew_Click);
                smartGridContracts1.AddItemToContextMenu("Новое допсоглашение",
                    Properties.Resources.icons8_agreement_50, toolStripButtonNew_Click);

            }
            catch (RpcException ex)
            {
                MessageBox.Show("Ошибка gRPC. \n" + ex.Message);
            }
        }


        #endregion


        #region Обработка событий общих кнопок контракта

        private void ToolStripMenuItemNewContract_Click(object sender, EventArgs e)
        {
            // Добавить новый контракт
            toolStripButtonNew_Click(sender, e);
        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            DocumentTypesForm form = new DocumentTypesForm();
            form.DialogMode = true;
            form.HeadCode = "ContractSale";

            if (form.ShowDialog() == DialogResult.OK)
            {
                DocumentType documentType = form.DocumentType;
                Contract _contract = new Contract()
                {
                    Id = 0,
                    Number = "",
                    Date = DateTime.Now.ToUniversalTime().ToTimestamp(),
                    RootId = 0,
                    TypeContract = new DocumentType() { Id = documentType.Id, Code = documentType.Code, Form = documentType.Form, Name = documentType.Name }
                };

                ViewContract viewContract = new ViewContract(_contract);
                viewContract.ViewMode = ViewMode.New;

                viewContract.Show();
            }

        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            int row = smartGridContracts1.Row;

            TreeContract rowNode = smartGridContracts1.Rows[row].Node.Key as TreeContract;
            Contract _contract = new Contract()
            {
                Id = rowNode.ContractId,
                Number = rowNode.Number,
                Date = rowNode.Date.ToUniversalTime().ToTimestamp(),
                RootId = rowNode.Contract_RootId ?? 0,
                TypeContract = new DocumentType() { Id = rowNode.TypeId, Code = rowNode.TypeCode, Form = rowNode.TypeForm, Name = rowNode.Type }
            };

            ViewContract viewContract = new ViewContract(_contract, smartGridContracts1.Rows[smartGridContracts1.Row].Node.Children > 0);
            viewContract.ViewMode = ViewMode.Edit;

            viewContract.Show();

            //smartGridContracts_DoubleClick(sender, e);

        }
        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshContract();
        }


        private void smartGridContracts_DoubleClick(object sender, EventArgs e)
        {
            Point pt = smartGridContracts1.PointToClient(Control.MousePosition);
            HitTestInfo hit = smartGridContracts1.HitTest(pt);

            if (hit.Row + 1 > smartGridContracts1.Rows.Count - smartGridContracts1.Footers.Descriptions.Count) return;
            if (hit.Row < smartGridContracts1.Rows.Fixed) return;

            TreeContract rowNode = smartGridContracts1.Rows[smartGridContracts1.Row].Node.Key as TreeContract;

            Contract _contract = new Contract()
            {
                Id = rowNode.ContractId,
                Number = rowNode.Number,
                Date = rowNode.Date.ToUniversalTime().ToTimestamp(),
                RootId = rowNode.Contract_RootId ?? 0,
                TypeContract = new DocumentType() { Id = rowNode.TypeId, Code = rowNode.TypeCode, Form = rowNode.TypeForm, Name = rowNode.Type }
            };

            ViewContract viewContract = new ViewContract(_contract, smartGridContracts1.Rows[smartGridContracts1.Row].Node.Children > 0);
            viewContract.ViewMode = ViewMode.View;

            viewContract.Show();

        }

        private void ToolStripMenuItemNewAgreement_Click(object sender, EventArgs e)
        {
            // Добавить дополнительное соглашение
            toolStripButtonNew_Click(sender, e);
        }

        #endregion


        #region Методы грида Контрактов

        /// <summary>
        /// Метод не работает, так как работа идет с нодами. Метод заполнения вычисляемых полей грида
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
                case "colState":
                    {
                        e.Value = contract.State == ContractState.Draft        ? "":
                                  contract.State == ContractState.SentToClient ? "на подписании":
                                  contract.State == ContractState.Signed       ? "подписан" :
                                  contract.State == ContractState.Active       ? "активен" :
                                  contract.State == ContractState.Complited    ? "исполнен" : "";
                        break;
                    }
            }
        }

        private async void smartGridContracts_AfterSelChange(object sender, C1.Win.FlexGrid.RangeEventArgs e)
        {
            if (rowCurrentContract == smartGridContracts1.Row) return;
            else rowCurrentContract = smartGridContracts1.Row;

                RefreshLines();
            // Считать строки контракта
            BindingList<Line> lines = new BindingList<Line>();
            try
            {
                if (smartGridContracts1.Row < smartGridContracts1.Rows.Fixed) return;
                if (smartGridContracts1.Rows[smartGridContracts1.Row].Node == null)
                {
                    smartGridLines1.DataSource = new BindingList<Line>();
                    return;
                }
                loaderLines.ShowLoader();
                if (smartGridContracts1.Row >= smartGridContracts1.Rows.Fixed)
                {
                    //Contract contract = (Contract)smartGridContracts1.Rows[smartGridContracts1.Row].DataSource;
                    TreeContract _obj = smartGridContracts1.Rows[smartGridContracts1.Row].Node.Key as TreeContract;

                    //treeContract = smartGridContracts1.Rows[smartGridContracts1.Row].Node.Key as TreeContract;

                    ContractLineRequest request = new ContractLineRequest()
                    {
                        Id = _obj.ContractId
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

        #endregion


        #region Методы грида строк Контрактов

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

        private void smartGridContracts1_GridChanged(object sender, C1.Win.FlexGrid.GridChangedEventArgs e)
        {

        }



        #endregion


        #region Методы для работы с контролами зоны фильтрации companyDropDown (желательно избавиться)

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

        #region Обработка внешнего события об изменении данных
        private void OnContractChanged(object sender, ContractChangedEventArgs e)
        {
            // Проверяем, что изменение относится к текущему списку
            // Используем Invoke для безопасного обновления UI из другого потока
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => HandleContractChange(e)));
            }
            else
            {
                HandleContractChange(e);
            }
        }

        private void HandleContractChange(ContractChangedEventArgs e)
        {
            int row = 0;

            TreeContract newTreeContract = new TreeContract() { ContractId = e.Contract.Id };

            // Запускаем поиск нужного нода и его замену на новый объект TreeContract
            Node foundNode = FindAndReplace(smartGridContracts1.Nodes, newTreeContract);
            TreeContract newtreeContract = new TreeContract();

            switch (e.ChangeType)
            {
                case ContractChangeType.Updated:
                    if (foundNode == null) return; // ?????? Если нод не найден
                    newtreeContract = foundNode.Key as TreeContract;
                    newtreeContract.Currency = e.Contract.Currency?.Abbrev;
                    newtreeContract.Date = e.Contract.Date.ToDateTime();
                    newtreeContract.ContractDate = e.Contract.Date.ToDateTime();
                    newtreeContract.DateExpiried = e.Contract.ExpirationDate?.ToDateTime();
                    newtreeContract .Number = e.Contract.Number;
                    newtreeContract.Seller = e.Contract.Seller?.Name;
                    newtreeContract.Buyer = e.Contract.Buyer?.Name;
                    newtreeContract.Sum = MyConvert.ToDecimal(e.Contract.Sum);
                    newtreeContract.State = e.Contract.State == ContractState.Draft ? "" :                // Новый
                                      e.Contract.State == ContractState.SentToClient ? "передан клиенту" : // В работе
                                      e.Contract.State == ContractState.Signed       ? "подписан" :        // Есть операции
                                      e.Contract.State == ContractState.Active       ? "активен" :         // Активен, есть операции
                                      e.Contract.State == ContractState.Complited    ? "исполнен" :        // Исполнен / Завершен
                                      "";

                    row = foundNode.Row.Index;
                    break;
                case ContractChangeType.Created:
                    // Для нового контракта создаем новый нод

                    newtreeContract.Id = e.Contract.Id * 1000 + 1;
                    newtreeContract.ParentId = 0;
                    newtreeContract.Number = e.Contract.Number;
                    newtreeContract.Sum = MyConvert.ToDecimal(e.Contract.Sum);
                    newtreeContract.Buyer = e.Contract.Buyer?.Name;
                    newtreeContract.ContractDate = e.Contract.Date.ToDateTime();
                    newtreeContract.ContractId = e.Contract.Id;
                    newtreeContract.Contract_RootId = e.Contract.RootId;
                    newtreeContract.Currency = e.Contract.Currency?.Abbrev;
                    newtreeContract.Date = e.Contract.Date.ToDateTime();
                    newtreeContract.ContractDate = e.Contract.Date.ToDateTime();
                    newtreeContract.DateExpiried = e.Contract.ExpirationDate?.ToDateTime();
                    newtreeContract.Name = string.IsNullOrEmpty(e.Contract.Name) ? "Контракт " + e.Contract.Number : e.Contract.Name + " " + e.Contract.Number;
                    newtreeContract.Seller = e.Contract.Seller?.Name;
                    newtreeContract.State = "";
                    newtreeContract.Type = e.Contract.TypeContract?.Name;
                    newtreeContract.TypeCode = e.Contract.TypeContract?.Code;
                    newtreeContract.TypeForm = e.Contract.TypeContract?.Form;
                    newtreeContract.TypeId = e.Contract.TypeContract.Id;

                    row = smartGridContracts1.Row;
                    smartGridContracts1.Rows.InsertNode(row, 0);
                    smartGridContracts1.Rows[row].Node.Data = newtreeContract.Name; // А рамочный контракт?
                    smartGridContracts1.Rows[row].Node.Key = newtreeContract;
                    smartGridContracts1.Row -= 1;

                    break;
            }

            // Обновляем данные
            smartGridContracts1.Rows[row]["State"] = newtreeContract.State;
            smartGridContracts1.Rows[row]["Date"] = newtreeContract.Date;
            smartGridContracts1.Rows[row]["Sum"] = newtreeContract.Sum;
            smartGridContracts1.Rows[row]["Currency"] = newtreeContract.Currency;
            smartGridContracts1.Rows[row]["Seller"] = newtreeContract.Seller;
            smartGridContracts1.Rows[row]["Buyer"] = newtreeContract.Buyer;
            smartGridContracts1.Rows[row]["Type"] = newtreeContract.Type;
            smartGridContracts1.Rows[row]["Paid"] = newtreeContract.Paid;
            smartGridContracts1.Rows[row]["Shipped"] = newtreeContract.Shipped;
            smartGridContracts1.Rows[row]["DateExpiried"] = newtreeContract.DateExpiried;
        }


        // Не забываем отписаться от события при закрытии формы
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ContractEventService.Instance.ContractChanged -= OnContractChanged;
            base.OnFormClosed(e);
        }

        #endregion


        #endregion


        /// <summary>
        /// Не используется. Метод формирует Nodes[] с учетом первичного контракта и допсоглашений
        /// </summary>
        /// <param name="nodes"></param>
        public void ProcessNodes(Node[] nodes)
        {
            if (nodes == null) return;

            // Итерируем по копии списка, так как будем изменять его во время обхода
            var originalNodes = new List<Node>(nodes);

            foreach (var node in originalNodes)
            {
                if (node.Nodes != null && node.Nodes.Length > 0)
                {
                    // Вставляем в начало списка детей
                    var newNode = node.AddNode(NodeTypeEnum.LastChild, node.Data);

                    // Попытка получить модель из родительского узла (Key хранит модель, использованную BuildTree)
                    var model = node.Key;
                    if (model != null)
                    {
                        // Устанавливаем модель в новый узел и заполняем значения колонок через свойства модели
                        newNode.Key = model;
                        var props = model.GetType().GetProperties();
                        foreach (var prop in props)
                        {
                            try
                            {
                                // Проверяем существование колонки и записываем значение
                                if (smartGridContracts1?.Cols != null && smartGridContracts1.Cols[prop.Name] != null)
                                {
                                    newNode.Row[prop.Name] = prop.GetValue(model);
                                }
                            }
                            catch
                            {
                                // Игнорируем несопоставимые свойства
                            }
                        }
                        newNode.Data += " (первичный контракт)";

                    }


                    // Рекурсивно обрабатываем детей
                    ProcessNodes(node.Nodes);
                }
            }
        }


        // Рекурсивный метод для поиска и замены node
        private Node FindAndReplace(Node[] nodes, TreeContract target)
        {
            foreach (Node node in nodes)
            {
                // Проверяем текущий узел
                if (node.Key is TreeContract key && key.ContractId == target.ContractId)
                {
                    return node;
                }

                // Рекурсивно проверяем дочерние узлы
                if (node.Nodes != null && node.Nodes.Length > 0)
                {
                    Node n = FindAndReplace(node.Nodes, target);
                    if (n != null) return n;
                }
            }
            return null;
        }


    }

}

using C1.Win.FlexGrid;
using C1.Win.Input;
using C1.Win.Input.MultiColumnCombo;
using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contract;
using GrpcCommonNet.Library.Contragent;
using GrpcCommonNet.Proto.Utils;
using GrpcWinForms.Controls.CompanyDropDown;
using GrpcWinForms.Controls.PeriodControl;
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
using System.Xml;

namespace GrpcWinForms.Objects.Test
{
    public partial class TestLookup : Form
    {
        private BindingList<Company> _contragents = new BindingList<Company>();
        Company selectedItem = new Company();

        private DateTime startDate = DateTime.Now.AddDays(-90);
        private DateTime endDate = DateTime.Now;


        public TestLookup()
        {
            InitializeComponent();

        }

        private void buttonCancel_Click(object sender, EventArgs e) // Cancel
        {
            this.Close();
        }

        private void buttonSaveExit_Click(object sender, EventArgs e)
        {

        }

        public void ProcessNodes(Node[] nodes)
        {
            if (nodes == null) return;

            // Итерируем по копии списка, так как будем изменять его во время обхода
            var originalNodes = new List<Node>(nodes);

            foreach (var node in originalNodes)
            {
                if (node.Nodes != null && node.Nodes.Length > 0)
                {


                    // Вставляем данные самого нода в начало списка детей
                    TreeContract dataForNew;
                    dataForNew = node.Key as TreeContract;
                    dataForNew.Name = dataForNew.Name + " (первичный)";

                    Node new_node = node.AddNode(NodeTypeEnum.FirstChild, dataForNew);
                    new_node.Key = node.Key;

                    // Рекурсивно обрабатываем детей (начиная со 2-го элемента, чтобы пропустить копию)
                    // Либо передаем весь список, но внутри метода копия отфильтруется, так как у нее нет детей
                    ProcessNodes(node.Nodes);
                }
            }
        }



        private async void TestLookup_Load(object sender, EventArgs e)
        {
            periodBox1.Period.From = new DateTime(2025, 1, 1);
            periodBox1.Period.To   = new DateTime(2027, 1, 1).AddSeconds(-1);

            ListContractsRequest request = new ListContractsRequest()
            {
                StartDate = periodBox1.Period.From.ToUniversalTime().ToTimestamp(),
                EndDate   = periodBox1.Period.To.ToUniversalTime().ToTimestamp(),
                WithAdd = true
            };
            request.FieldMask = new Google.Protobuf.WellKnownTypes.FieldMask()
            {
                Paths = { "id", "root_id", "seller", "buyer", "number", "date", "expiration_date", "currency", "department", "data", "sum", "type_contract" }
            };

            ListContractsResponse response = new ListContractsResponse();
            response = await GrpcClients.GrpcClients.Contract.GetListContractsAsync(request);
            List<TreeContract> treeContracts = new List<TreeContract>();

            foreach(Contract contract in response.Contracts)
            {
                treeContracts.Add(new TreeContract()
                {
                    Id = contract.Id,
                    ParentId = contract.RootId,
                    Name = (contract.RootId > 0 ? "Допсоглашение" : "Контракт") + " " + contract.Number,
                    Buyer = contract.Buyer.Entity != null ? contract.Buyer.Entity.EntityName :
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

            smartGrid1.BuildTree(treeContracts, false); // Создается структура Nodes
            
            ProcessNodes(smartGrid1.Nodes);
        }
    }
    
}

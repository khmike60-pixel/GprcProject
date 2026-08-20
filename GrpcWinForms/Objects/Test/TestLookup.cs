using C1.Win.FlexGrid;
using C1.Win.Input;
using C1.Win.Input.MultiColumnCombo;
using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contract;
using GrpcCommonNet.Library.Contragent;
using GrpcWinForms.Controls.CompanyDropDown;
using GrpcWinForms.Controls.PeriodControl;
using Microsoft.VisualBasic.ApplicationServices;
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
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
        }

        private async void TestLookup_Load(object sender, EventArgs e)
        {
            Refresh();
            periodBox1.Period.From = DateTime.Parse("01.01.2025");
            periodBox1.Period.To = DateTime.Now;

        }

        private async void Refresh()
        {
            try
            {
                ListContractsRequest request = new ListContractsRequest();
                request.StartDate = periodBox1.Period.From.ToUniversalTime().ToTimestamp();
                request.EndDate = periodBox1.Period.To.ToUniversalTime().ToTimestamp();

                ListContractsResponse response = new ListContractsResponse();
                response = await GrpcClients.GrpcClients.Contract.GetListContractsAsync(request);

                List<Tree> contractsTree = new List<Tree>();
                foreach (Contract contract in response.Contracts)
                {
                    contractsTree.Add(
                        new Tree
                        {
                            Id = contract.Id,
                            ParentId = contract.RootId,
                            Name = contract.RootId > 0 ? "Допсоглашение" : contract.TypeContract.Name,
                            Date = contract.Date.ToDateTime(),
                            Number = contract.Number,
                            TypeDocument = contract.TypeContract.Name
                        }
                    );
                };

                smartGrid1.BuildTree(contractsTree, false);

                ProcessNodes(smartGrid1.Nodes);
                

            }
            catch { }
        }

        public static void ProcessNodes(Node[] nodes)
        {
            if (nodes == null) return;

            // Итерируем по копии списка, так как будем изменять его во время обхода
            var originalNodes = new List<Node>(nodes);

            foreach (var node in originalNodes)
            {
                if (node.Nodes != null && node.Nodes.Length > 0)
                {
                    // Вставляем в начало списка детей (или в конец, используя .Add)
                    node.AddNode(NodeTypeEnum.FirstChild, node.Data);

                    // 3. Рекурсивно обрабатываем детей (начиная со 2-го элемента, чтобы пропустить копию)
                    // Либо передаем весь список, но внутри метода копия отфильтруется, так как у нее нет детей
                    ProcessNodes(node.Nodes);
                }
            }
        }
               
    }

    public class Tree : ITreeData
    {
        public int Id { get; set ; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Number { get; set; }
        public string TypeDocument { get; set; }
    }
}

using C1.Framework;
using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Contract;
using GrpcCommonNet.Proto.Utils;
using GrpcWinForms.Objects.Contracts.Forms.SaleStandart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Contracts.Forms.SaleStandart
{
    public partial class ContractStandartForm : Form
    {
        private int contractId = 0;
        public int ContractId
        {
            get { return contractId; }
            set { contractId = value; }
        }

        public ContractStandartForm()
        {
            InitializeComponent();
        }

        public ContractStandartForm(int id)
        {
            InitializeComponent();
            ContractId = id;
        }

        private void toolStripButtonSetupSpecification_Click(object sender, EventArgs e)
        {
            using (var setupSpecificationForm = new SetupSpecificationForm())
            {
                if (setupSpecificationForm.ShowDialog() == DialogResult.OK)
                {
                    var str = setupSpecificationForm.StringJson;
                    // Handle OK result if needed
                }
            }
        }

        private void ContractStandartForm_Load(object sender, EventArgs e)
        {
            if (contractId == 0)
            {
                return;
            }   
            GetContractRequest request = new GetContractRequest { ContractId = contractId};
            ContractResponse response = GrpcClients.GrpcClients.Contract.GetContract(request);
            headContractControl.SetControls(response.Contract);

            var properties = response.Contract.Data;
            if (properties != null)
            {
                var root = properties.Fields["Контракт"];

                DataNode nodes = MyConvert.ProtoConverter.ToNodeTree(properties, "Контракт");
                propertiesControl1.SetTreeNodes(nodes);
            }

            GetContractByRootRequest requestRoot = new GetContractByRootRequest()
            {
                RootId = response.Contract.RootId,
                FieldMask = new FieldMask
                {
                    Paths = { "id", "root_id", "type_contract", "date", "number", "name", "sum", "amount", "sum_vat", "currency.abbrev" }
                }
            };

            ContractIerarchResponse responseChange = GrpcClients.GrpcClients.Contract.GetContractIerarch(requestRoot);

            historyContractControl.smartGridHistory.DataSource = responseChange.Contracts;
        }
    }

    public class Specification
    {
        public int Order { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
    }
}

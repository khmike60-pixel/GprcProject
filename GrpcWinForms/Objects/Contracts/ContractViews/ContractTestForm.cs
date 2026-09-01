using GrpcCommonNet.Library.Contract;
using GrpcWinForms.Objects.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Contracts.ContractViews
{
    public partial class ContractTestForm : ContractFormClass
    {
        private Contract contract;
        public ContractTestForm()
        {
            InitializeComponent();

        }

        public ContractTestForm(Contract _contract)
        {
            InitializeComponent();
            contract = _contract;

        }

    }
}

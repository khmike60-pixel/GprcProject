using GrpcCommonNet.Library.Contract;
using GrpcCommonNet.Proto.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Contracts.Forms.Controls
{
    public partial class SumContractControl : UserControl
    {
        public SumContractControl()
        {
            InitializeComponent();
        }

        public void SetControls(Contract contract)
        {
            if (contract == null) return;
            textBoxSumContract.Value = MyConvert.ToDecimal(contract.Sum);
            textBoxSumPayed.Value = 0;
            textBoxSumDeliveried.Value = 0;
            textBoxSumSaldo.Value = 0;
        }
    }
}

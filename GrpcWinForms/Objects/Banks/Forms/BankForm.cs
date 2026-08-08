using GrpcCommonNet.Library.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Banks.Forms
{
    public partial class BankForm : Form
    {
        private Bank _bank = new Bank();
        public Bank Bank {  get => _bank; set => _bank = value; }

        public BankForm()
        {
            InitializeComponent();
        }
    }
}

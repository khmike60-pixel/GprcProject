using C1.Win.Input;
using C1.Win.Input.MultiColumnCombo;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contragent;
using GrpcWinForms.Controls.CompanyDropDown;
using GrpcWinForms.Controls.PeriodControl;
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

        #region Методы c1DropDownControl1 не контрол

        #endregion

        private void buttonCancel_Click(object sender, EventArgs e) // Cancel
        {
            this.Close();
        }

        private void ShowPeriod()
        {
            MessageBox.Show("");
        }

        private void buttonSaveExit_Click(object sender, EventArgs e)
        {
            ShowPeriod();
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ShowPeriod();
        }
    }
}

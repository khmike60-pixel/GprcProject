using C1.Win.Input;
using C1.Win.Input.MultiColumnCombo;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contragent;
using GrpcWinForms.Objects.Contragents.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Test
{
    public partial class TestLookup : Form
    {
        private BindingList<ShortContragent> _contragents = new BindingList<ShortContragent>();
        ShortContragent selectedItem = new ShortContragent();

        public TestLookup()
        {
            InitializeComponent();
            c1DropDownControl1.Control = new DropDownUserControl();

        }

        private void ConfigDropDownControl()
        {
            c1DropDownControl1.Control = new DropDownUserControl();

        }

        private void c1DropDownControl1_TextChanged(object sender, EventArgs e)
        {
            SmartGrid.SmartGrid grid = ((DropDownUserControl)c1DropDownControl1.Control).smart;

            DropDownUserControl userControl = ((DropDownUserControl)c1DropDownControl1.Control);
            grid.DataSource = userControl.GetData(c1DropDownControl1.Text);
            
        }

        private void c1DropDownControl1_CustomButtonClick(object sender, EventArgs e)
        {
            c1DropDownControl1.Text = "";
            selectedItem = new ShortContragent();
        }

        private void c1DropDownControl1_Leave(object sender, EventArgs e)
        {
            DropDownUserControl userControl = ((DropDownUserControl)c1DropDownControl1.Control);

            if (c1DropDownControl1.Text == "") return;
            if (userControl.contragentSelected == null || userControl.contragentSelected.Id != 0)
            {
                _contragents = userControl.GetData(c1DropDownControl1.Text);
                if (_contragents.Count == 1)
                {
                    userControl.contragentSelected = _contragents[0];
                    c1DropDownControl1.Text = _contragents[0].Name;
                    return;
                }
            }

            MessageBox.Show(this, "Такой контрагент не найден!");
            c1DropDownControl1.Focus();
        }
    }

    public class ShortContragent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaxNo { get; set; }
    }
}

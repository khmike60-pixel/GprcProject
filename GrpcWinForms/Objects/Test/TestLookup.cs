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
        private BindingList<Company> _contragents = new BindingList<Company>();
        Company selectedItem = new Company();

        public TestLookup()
        {
            InitializeComponent();
            c1DropDownControl1.Control = new DropDownUserControl();
            companyDropDown1.GetDataSourceFunc = Load;

        }

        #region Методы c1DropDownControl1 не контрол

        private void ConfigDropDownControl()
        {
            c1DropDownControl1.Control = new DropDownUserControl();

        }

        private void c1DropDownControl1_TextChanged(object sender, EventArgs e)
        {
            SmartGrid.SmartGrid grid = ((DropDownUserControl)c1DropDownControl1.Control).smart;

            DropDownUserControl userControl = ((DropDownUserControl)c1DropDownControl1.Control);

            companyDropDown1.GetDataSourceFunc = Load;
        }

        private void c1DropDownControl1_CustomButtonClick(object sender, EventArgs e)
        {
            c1DropDownControl1.Text = "";
            selectedItem = new Company();
        }

        private void c1DropDownControl1_Leave(object sender, EventArgs e)
        {
            DropDownUserControl userControl = ((DropDownUserControl)c1DropDownControl1.Control);

            if (c1DropDownControl1.Text == "") return;
            if (userControl.ContragentSelected == null || userControl.ContragentSelected.Id != 0)
            {
                _contragents = userControl.GetData(c1DropDownControl1.Text);
                if (_contragents.Count == 1)
                {
                    userControl.ContragentSelected = _contragents[0];
                    c1DropDownControl1.Text = _contragents[0].Name;
                    return;
                }
            }

            MessageBox.Show(this, "Такой контрагент не найден!");
            c1DropDownControl1.Focus();
        }

        private void c1DropDownControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Если нажата клавиша Enter
            if (e.KeyChar == (char)Keys.Enter)
                this.SelectNextControl(this.ActiveControl, forward: true,
                       tabStopOnly: true, nested: true, wrap: true);

        }
        #endregion

        private BindingList<Company> Load(string filter)
        {
            SearchRequest searchRequest = new SearchRequest()
            {
                Search = filter,
                Paging = new Paging() { PageNumber = 1, PageSize = 10 }
            };

            searchRequest.FieldMask =
                new Google.Protobuf.WellKnownTypes.FieldMask() { Paths = { "id", "name", "taxno" } };

            ListContragentResponse searchResponse = GrpcClients.GrpcClients.Contragent.SearchListContragent(searchRequest);

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

        private void buttonCancel_Click(object sender, EventArgs e) // Cancel
        {
            this.Close();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                $"Будет сохранен следующий контрагент"                  + Environment.NewLine +
                $"Идентификатор : {companyDropDown1.SelectedItem.Id}"   + Environment.NewLine +
                $"Наименование  : {companyDropDown1.SelectedItem.Name}" + Environment.NewLine +
                $"ИНН / ПИНФЛ   : {companyDropDown1.SelectedItem.TaxNo}"
                );
        }
    }
}

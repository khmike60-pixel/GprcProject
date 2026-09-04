using C1.Win.FlexGrid;
using C1.Win.Input;
using C1.Win.Input.MultiColumnCombo;
using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contract;
using GrpcCommonNet.Library.Contragent;
using GrpcCommonNet.Library.Currency;
using GrpcCommonNet.Library.Department;
using GrpcCommonNet.Proto.Utils;
using GrpcWinForms.Controls.CompanyDropDown;
using GrpcWinForms.Controls.PeriodControl;
using GrpcWinForms.Controls.SmartBox;
using GrpcWinForms.Forms;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Objects.Contracts.Forms;
using GrpcWinForms.Objects.Contracts.Models;
using GrpcWinForms.Objects.Departaments;
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
using Currency = GrpcCommonNet.Library.Common.Currency;

namespace GrpcWinForms.Objects.Test
{
    public partial class TestLookup : Form
    {

        public TestLookup()
        {
            InitializeComponent();

        }

        private void buttonCancel_Click(object sender, EventArgs e) // Cancel
        {
            MessageBox.Show(string.Join(Environment.NewLine,
                $"Валюта smartBoxCurrency  : Id = {smartBoxCurrency.SelectedItemBox.Id}, Name = {smartBoxCurrency.SelectedItemBox.Name}",
                $"Валюта smartBoxDepartment: Id = {smartBoxDepartment.SelectedItemBox.Id}, Name = {smartBoxDepartment.SelectedItemBox.Name}"
                ));
        }

        private async void TestLookup_Load(object sender, EventArgs e)
        {
            // Читаем данные для smartBoxCurrency
            ListCurrencyRequest request = new ListCurrencyRequest()
            {
                IncludeInvisible = false,
            };
            request.FieldMask = new FieldMask() { Paths = { "id", "abbrev" } };
            ListCurrencyResponse response = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Currency.GetListCurrencyAsync(request).ResponseAsync);

            // Передаем данные в smartBoxCurrency
            Currency curr = new Currency() { Id = 31, Name = "UZS" };
            smartBoxCurrency.DataSourceList(response.Currencies, "Abbrev");
            smartBoxCurrency.SetSelectedItemBox(curr, "Id");
            smartBoxCurrency.AutoSuggestMode = AutoSuggestMode.StartsWith;
            smartBoxCurrency.SetModalForm(new CurrenciesForm() { DialogMode = true });

            // Читаем данные для smartBoxDepartment
            ListDepartmentRequest requstDep = new ListDepartmentRequest()
            { FieldMask = new FieldMask() { Paths = { "id", "symbol" } } };
            ListDepartmentResponse responseDep = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Department.GetListDepartmentAsync(requstDep).ResponseAsync);

            // Передаем данные в smartBoxDepartment
            Department dep = new Department() { };
            smartBoxDepartment.DataSourceList(responseDep.Departments, "symbol");
            smartBoxDepartment.SetSelectedItemBox(dep, "Id");
            smartBoxDepartment.AutoSuggestMode = AutoSuggestMode.StartsWith;
            smartBoxDepartment.SetModalForm(new DepartamentsForm() { DialogMode = true });
        }

        private void c1Button1_Click(object sender, EventArgs e)
        {
            StateForm form = new StateForm();
            if (form.ShowDialog() == DialogResult.OK)
            { }

        }
    }

    public class CurrencyItemBox : IItemBox
    {
        public int Id { get; set; }
        public string Name { get; set ; }
    }

}

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
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Objects.Contracts.Forms;
using GrpcWinForms.Objects.Contracts.Models;
using GrpcWinForms.Objects.Contragents.Forms;
using GrpcWinForms.Objects.Currencies.Views;
using GrpcWinForms.Objects.Departaments;
using GrpcWinForms.Objects.Departaments.Forms;
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
                $"Отдел  smartBoxDepartment: Id = {smartBoxDepartment.SelectedItemBox.Id}, Name = {smartBoxDepartment.SelectedItemBox.Name}",
                $"Компания  companyDropDowm: Id = {companyDropDown.SelectedCompany.Id}, Name = {companyDropDown.SelectedCompany.Name}"
                ));
        }

        private async void TestLookup_Load(object sender, EventArgs e)
        {
            // ---- Выбор валюты 
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

            // ---- Выбор департамента 
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


            // ---- Выбор Контрагента
            companyDropDown.GetDataSourceFunc = LoadCompanies;
            //companyDropDown.Value = 4676;
            companyDropDown.Text = "MICROS UCD";

        }

        private BindingList<Company> LoadCompanies(string name)
        {
            SearchRequest searchRequest = new() 
            { 
                Search = name, Paging = new() { PageNumber = 1, PageSize = 10 } ,
                FieldMask = new() { Paths = { "id", "name", "taxno" } }
            };

            ListContragentResponse searchResponse = GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Contragent.SearchListContragentAsync(searchRequest).ResponseAsync).GetAwaiter().GetResult();

            BindingList<Company> _companies = new BindingList<Company>();
            foreach (Contragent item in searchResponse.Contragents)
            {
                _companies.Add(new Company()
                {
                    Id = item.Id,
                    Name = item.Name,
                    TaxNo = item.Taxno
                });
            }
            return _companies;
        }
       
    }

    public class CurrencyItemBox : IItemBox
    {
        public int Id { get; set; }
        public string Name { get; set ; }
    }

}

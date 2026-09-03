using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contract;
using GrpcCommonNet.Library.Contragent;
using GrpcCommonNet.Library.Currency;
using GrpcWinForms.Controls.CompanyDropDown;
using GrpcWinForms.Forms;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Objects.Contragents.Forms;
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

    public partial class HeadContractControl : UserControl, ISupportInitialize
    {
        private Contragent _selectedSeller = new Contragent();
        private Contragent _selectedBuyer =  new Contragent();
        private bool _initializing;
        private Currency _selectedCurrency =  new Currency();

        private bool readOnly = false;

        public bool ReadOnly
        {
            get => readOnly;
            set
            {
                readOnly = value;
                companyBuyer.ReadOnly = readOnly;
                companySeller.ReadOnly = readOnly;
                textBoxNumber.ReadOnly = readOnly;
                dateEditStart.ReadOnly = readOnly;
                dateEditStop.ReadOnly = readOnly;
                textBoxTaxnoBuyer.ReadOnly = readOnly;
                textBoxTaxnoSeller.ReadOnly = readOnly;
                comboBoxContractType.ReadOnly = readOnly;
                smartBoxCurrency.ReadOnly = readOnly;
            }
        }

        public HeadContractControl()
        {
            InitializeComponent();

        }

        public void BeginInit()
        {
            _initializing = true;
            this.SuspendLayout();
        }

        public void EndInit()
        {
            _initializing = false;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public async Task SetControls(Contract contract)
        {
            this.SuspendLayout();
            try
            {
                if (contract.Id == 0) // Новый контракт?
                {

                }
                textBoxNumber.Text = contract.Number ?? "1";                    // Номер договора

                if (contract.Date != null)                                      // Дата начала договора
                    dateEditStart.Value = contract.Date.ToDateTime();
                else
                    dateEditStart.Value = DateTime.Now;
                if (contract.ExpirationDate != null)                            // Дата окончания договора
                    dateEditStop.Value = contract.ExpirationDate.ToDateTime();
                else
                    dateEditStop.Value = string.Empty;

                textBoxTaxnoBuyer.Text = contract.Buyer?.Taxno;                  // ИНН покупателя
                companyBuyer.Text = contract.Buyer?.Name;                        // Контрагент покупатель
                companyBuyer.Value = contract.Buyer?.Id;                         // Идентификатор контрагента покупателя

                textBoxTaxnoSeller.Text = contract.Seller?.Taxno;                // ИНН продавца
                companySeller.Text = contract.Seller?.Name;                      // Контрагент продавец
                companySeller.Value = contract.Seller?.Id;                       // Идентификатор контрагента продавца

                comboBoxContractType.Text = contract.TypeContract.Name.ToString();   // Тип договора

                // Работа с валютой контракта
                Currency curr = new Currency() { Id = contract.Currency.Id, Name = contract.Currency?.Abbrev };
                smartBoxCurrency.SetSelectedItemBox(curr);

                companySeller.Text = contract.Seller?.Name;
                companyBuyer.Text = contract.Buyer?.Name;
                tbDocName.Text = contract.DocName;

            }
            finally
            {
                this.ResumeLayout(false);
                this.PerformLayout();
            }

        }

        #region Методы для companyDropDown
        private BindingList<Company> LoadCompany(string filter)
        {
            SearchRequest searchRequest = new SearchRequest()
            {
                Search = filter,
                Paging = new Paging() { PageNumber = 1, PageSize = 10 }
            };

            searchRequest.FieldMask =
                new Google.Protobuf.WellKnownTypes.FieldMask() { Paths = { "id", "name", "taxno" } };

            ListContragentResponse searchResponse = GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Contragent.SearchListContragentAsync(searchRequest).ResponseAsync).GetAwaiter().GetResult();

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

        #endregion

        private void companyBuyer_ModalButtonClick(object sender, EventArgs e)
        {
            ContragentsForm form = new ContragentsForm();
            form.ModeEdit = true;
            if (form.ShowDialog() == DialogResult.OK)
            {
                _selectedBuyer = form.SelectedContragent;
                companyBuyer.Text = _selectedBuyer.Name;
                //companyBuyer.Value = _selectedBuyer.Id;
                textBoxTaxnoBuyer.Text = _selectedBuyer.Taxno;

            }

        }

        private void companySeller_ModalButtonClick(object sender, EventArgs e)
        {
            ContragentsForm form = new ContragentsForm();
            form.ModeEdit = true;
            if (form.ShowDialog() == DialogResult.OK)
            {
                _selectedSeller = form.SelectedContragent;
                companySeller.Text = _selectedSeller.Name;
                //companySeller.Value = _selectedSeller.Id;
                textBoxTaxnoSeller.Text = _selectedSeller.Taxno;
            }
        }

        private async void HeadContractControl_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            companyBuyer.GetDataSourceFunc = LoadCompany;
            companySeller.GetDataSourceFunc = LoadCompany;

            CurrencyLoad();
        }

        private async void CurrencyLoad()
        {
            if(DesignMode) return;
            // Работа с валютой контракта
            ListCurrencyRequest currencyRequest = new ListCurrencyRequest()
            { IncludeInvisible = false };
            ListCurrencyResponse response = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Currency.GetListCurrencyAsync(currencyRequest).ResponseAsync);

            smartBoxCurrency.DataSourceList(response.Currencies, "Abbrev");
            smartBoxCurrency.AutoSuggestMode = C1.Win.Input.AutoSuggestMode.StartsWith;
            smartBoxCurrency.SetModalForm(new CurrenciesForm() { DialogMode = true });
        }
    }


}

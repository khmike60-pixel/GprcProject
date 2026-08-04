using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contract;
using GrpcCommonNet.Library.Contragent;
using GrpcWinForms.Controls.CompanyDropDown;
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

    public partial class HeadContractControl : UserControl
    {
        private Company SelectedSeller;
        private Company SelectedBuyer;

        public HeadContractControl()
        {
            InitializeComponent();
            companyBuyer.GetDataSourceFunc = Load;
            companySeller.GetDataSourceFunc = Load;

        }

        public void SetControls(Contract contract)
        {
            textBoxNumber.Text = contract.Number ?? "1";                    // Номер договора

            if (contract.Date != null)                                      // Дата начала договора
                dateTimePickerStart.Value = contract.Date.ToDateTime();
            else
                dateTimePickerStart.Value = DateTime.Now;
            if (contract.ExpirationDate != null)                            // Дата окончания договора
                dateTimePickerStop.Value = contract.ExpirationDate.ToDateTime();
            else
                dateTimePickerStop.Text = string.Empty;

            textBoxTaxnoBuyer.Text = contract.Buyer.Taxno;                  // ИНН покупателя
            companyBuyer.Text = contract.Buyer.Name;                        // Контрагент покупатель
            companyBuyer.Value = contract.Buyer.Id;                         // Идентификатор контрагента покупателя

            textBoxTaxnoSeller.Text = contract.Seller.Taxno;                // ИНН продавца
            companySeller.Text = contract.Seller.Name;                      // Контрагент продавец
            companySeller.Value = contract.Seller.Id;                       // Идентификатор контрагента продавца

            comboBoxContractType.Text = contract.TypeContract.ToString();   // Тип договора
            comboBoxCurrency.Text = contract.Currency.Abbrev;               // Валюта договора

            companySeller.Text = contract.Seller.Name;
            companyBuyer.Text = contract.Buyer.Name;

        }

        #region Методы для companyDropDown
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

        #endregion

        private BindingList<Currency> LoadCurrency(string filter)
        {
            BindingList<Currency> _currencies = new BindingList<Currency>();


            return _currencies;
        }
    }
}

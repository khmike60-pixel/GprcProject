using GrpcCommonNet.Library.Contract;
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
        public HeadContractControl()
        {
            InitializeComponent();
           
        }

        public void SetControls(Contract contract)
        {
            textBoxNumber.Text = contract.Number ?? "1";                           // Номер договора
            
            if (contract.Date != null)                                      // Дата начала договора
                dateTimePickerStart.Value = contract.Date.ToDateTime();
            else
                dateTimePickerStart.Value = DateTime.Now;
            if (contract.ExpirationDate != null)                            // Дата окончания договора
                dateTimePickerStop.Value = contract.ExpirationDate.ToDateTime();
            else
                dateTimePickerStop.Text = string.Empty;
            
            textBoxTaxnoBuyer.Text = contract.Buyer.Taxno;                  // ИНН покупателя
            lookupContragentBuyer.Value = contract.Buyer.Name;              // Контрагент покупатель
            textBoxTaxnoSeller.Text = contract.Seller.Taxno;                // ИНН продавца
            lookupContragentSeller.Value = contract.Seller.Name;            // Контрагент продавец
            comboBoxContractType.Text = contract.TypeContract.ToString();   // Тип договора
            comboBoxCurrency.Text = contract.Currency.Abbrev;               // Валюта договора

        }
    }
}

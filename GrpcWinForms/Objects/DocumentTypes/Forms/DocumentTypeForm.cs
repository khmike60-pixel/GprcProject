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

namespace GrpcWinForms.Objects.DocumentTypes.Forms
{
    public partial class DocumentTypeForm : Form
    {
        public DocumentType DocumentType { get; set; } = new DocumentType();
        public bool EditMode { get; set; } = false;

        public DocumentTypeForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void DocumentTypeForm_Load(object sender, EventArgs e)
        {
            // Инициализация ComboBox для выбора типа валюты
            cbCurrency.Items.Add(new C1.Win.Input.ComboBoxItem { DisplayText = "Базовая", Value = 0 });
            cbCurrency.Items.Add(new C1.Win.Input.ComboBoxItem { DisplayText = "Иная", Value = 1 });
            cbCurrency.Items.Add(new C1.Win.Input.ComboBoxItem { DisplayText = "УЕ/ЦБ", Value = 2 });
            cbCurrency.Items.Add(new C1.Win.Input.ComboBoxItem { DisplayText = "Другое", Value = 3 });
            cbCurrency.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbCurrency.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbCurrency.AutoSuggestMode = C1.Win.Input.AutoSuggestMode.StartsWith;
            cbCurrency.SelectedItem = cbCurrency.Items[DocumentType.CurrencyType];

            // Инициализация ComboBox для выбора валюты страны
            if (DocumentType.CountryCurrencyId == 0) DocumentType.CountryCurrencyId = 1; // Установка значения по умолчанию, если оно равно 0
            cbCountryCurrency.SelectedItem = cbCountryCurrency.Items[DocumentType.CountryCurrencyId - 1 ];

            // Установка значений полей формы на основе объекта documentType
            tbName.Text = DocumentType.Name.ToString();
            tbCode.Text = DocumentType.Code.ToString();
            tbForm.Text = DocumentType.Form.ToString();
            tbViewDetail.Text = DocumentType.ViewDetail.ToString();
            tbViewMaster.Text = DocumentType.ViewMaster.ToString();
            tbParent.Text = DocumentType.Parent.Name.ToString();

            // Установка значения флажка по умолчанию
            chkDefault.Checked = DocumentType.IsDefault;

            if (!EditMode)
            {
                tbName.ReadOnly = tbCode.ReadOnly = tbForm.ReadOnly = tbViewDetail.ReadOnly = tbViewMaster.ReadOnly = true;
                cbCurrency.ReadOnly = cbCountryCurrency.ReadOnly = true;
                chkDefault.Enabled = false;
                btnOk.Enabled = false;
            }

        }

        private void cbCurrency_SelectedItemChanged(object sender, EventArgs e)
        {
            cbCurrency.Text = cbCurrency.SelectedItem.DisplayText;
            DocumentType.CurrencyType = Convert.ToInt32(cbCurrency.SelectedItem.Value);

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DocumentType.Name = tbName.Text;
            DocumentType.Code = tbCode.Text;
            DocumentType.Form = tbForm.Text;
            DocumentType.ViewDetail = tbViewDetail.Text;
            DocumentType.ViewMaster = tbViewMaster.Text;
            DocumentType.CurrencyType = Convert.ToInt32(cbCurrency.SelectedItem.Value);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

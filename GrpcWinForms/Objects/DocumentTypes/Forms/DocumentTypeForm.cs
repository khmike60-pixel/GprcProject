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
        public DocumentType documentType { get; set; } = new DocumentType();
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
            cbCurrency.Items.Add(new C1.Win.Input.ComboBoxItem { DisplayText = "Базовая", Value = 0 });
            cbCurrency.Items.Add(new C1.Win.Input.ComboBoxItem { DisplayText = "Иная", Value = 0 });
            cbCurrency.Items.Add(new C1.Win.Input.ComboBoxItem { DisplayText = "УЕ/ЦБ", Value = 0 });
            cbCurrency.Items.Add(new C1.Win.Input.ComboBoxItem { DisplayText = "Другое", Value = 0 });
            cbCurrency.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbCurrency.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbCurrency.AutoSuggestMode = C1.Win.Input.AutoSuggestMode.StartsWith;
            //cbCurrency.SelectedItem = cbCurrency.Items[0];


            tbName.Text = documentType.Name.ToString();
            tbCode.Text = documentType.Code.ToString();
            tbViewDetail.Text = documentType.ViewDetail.ToString();
            tbViewMaster.Text = documentType.ViewMaster.ToString();
            cbCurrency.SelectedItem = cbCurrency.Items[documentType.CurrencyType];
            cddParent.Text = documentType.Parent.ToString();
            chkDefault.Checked = documentType.IsDefault;

            if (!EditMode)
            {
                tbName.ReadOnly = tbCode.ReadOnly = tbViewDetail.ReadOnly = tbViewMaster.ReadOnly = true;
                cbCurrency.ReadOnly = cddParent.ReadOnly = cbCountryCurrency.ReadOnly = true;
                chkDefault.Enabled = false;
                btnOk.Enabled = false;
            }

        }
    }
}

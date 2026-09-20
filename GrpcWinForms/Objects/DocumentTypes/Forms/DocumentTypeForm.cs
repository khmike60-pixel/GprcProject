using GrpcCommonNet.Library.Common;
using GrpcWinForms.Objects.DocumentTypes.Presenters;
using GrpcWinForms.Objects.DocumentTypes.Views;
using System;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.DocumentTypes.Forms
{
    public partial class DocumentTypeForm : Form, IDocumentTypeView
    {
        private readonly DocumentTypePresenter _presenter;

        public DocumentType DocumentType { get; set; } = new DocumentType();
        public bool EditMode { get; set; } = false;

        public DocumentTypeForm()
        {
            InitializeComponent();
            _presenter = new DocumentTypePresenter(this);
        }

        #region IDocumentTypeView реализация (связь с контролами формы)

        public string NameText
        {
            get => tbName.Text;
            set => tbName.Text = value;
        }

        public string CodeText
        {
            get => tbCode.Text;
            set => tbCode.Text = value;
        }

        public string FormText
        {
            get => tbForm.Text;
            set => tbForm.Text = value;
        }

        public string ViewDetailText
        {
            get => tbViewDetail.Text;
            set => tbViewDetail.Text = value;
        }

        public string ViewMasterText
        {
            get => tbViewMaster.Text;
            set => tbViewMaster.Text = value;
        }

        public int CurrencyTypeValue
        {
            get
            {
                try
                {
                    if (cbCurrency.SelectedItem != null)
                        return Convert.ToInt32(cbCurrency.SelectedItem.Value);
                }
                catch { }
                return 0;
            }
            set
            {
                try
                {
                    // попытка выбрать по индексу как в исходном коде
                    if (value >= 0 && value < cbCurrency.Items.Count)
                    {
                        cbCurrency.SelectedItem = cbCurrency.Items[value];
                        return;
                    }
                    // иначе — искать по Value
                    for (int i = 0; i < cbCurrency.Items.Count; i++)
                    {
                        var item = cbCurrency.Items[i];
                        try
                        {
                            if (Convert.ToInt32(item.Value) == value)
                            {
                                cbCurrency.SelectedItem = item;
                                return;
                            }
                        }
                        catch { }
                    }
                }
                catch { }
            }
        }

        public int CountryCurrencyIndex
        {
            get => cbCountryCurrency.SelectedIndex;
            set
            {
                if (value >= 0 && value < cbCountryCurrency.Items.Count)
                    cbCountryCurrency.SelectedIndex = value;
            }
        }

        public bool IsDefault
        {
            get => chkDefault.Checked;
            set => chkDefault.Checked = value;
        }

        public bool IsContract
        {
            get => chkIsContract.Checked;
            set => chkIsContract.Checked = value;
        }

        public DialogResult ShowDocumentTypeDialog(Form form) => form.ShowDialog(this);

        public void ShowMessage(string text, string caption = "", MessageBoxButtons buttons = MessageBoxButtons.OK)
        {
            MessageBox.Show(text, caption, buttons);
        }

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void DocumentTypeForm_Load(object sender, EventArgs e)
        {
            // Заполняем список типов валют — UI-деталь оставлена в форме
            cbCurrency.Items.Add(new C1.Win.Input.ComboBoxItem { DisplayText = "Базовая", Value = 0 });
            cbCurrency.Items.Add(new C1.Win.Input.ComboBoxItem { DisplayText = "Иная", Value = 1 });
            cbCurrency.Items.Add(new C1.Win.Input.ComboBoxItem { DisplayText = "УЕ/ЦБ", Value = 2 });
            cbCurrency.Items.Add(new C1.Win.Input.ComboBoxItem { DisplayText = "Другое", Value = 3 });
            cbCurrency.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbCurrency.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbCurrency.AutoSuggestMode = C1.Win.Input.AutoSuggestMode.StartsWith;

            // Инициализация представления через презентер
            _presenter.Initialize();

            // Установка ReadOnly/Enabled в зависимости от EditMode
            if (!EditMode)
            {
                tbName.ReadOnly = tbCode.ReadOnly = tbForm.ReadOnly = tbViewDetail.ReadOnly = tbViewMaster.ReadOnly = true;
                cbCurrency.ReadOnly = cbCountryCurrency.ReadOnly = true;
                chkDefault.Enabled = chkIsContract.Enabled = false;
                btnOk.Enabled = false;
            }
        }

        private void cbCurrency_SelectedItemChanged(object sender, EventArgs e)
        {
            // синхронизируем выбор с моделью через свойство
            try
            {
                if (cbCurrency.SelectedItem != null)
                    CurrencyTypeValue = Convert.ToInt32(cbCurrency.SelectedItem.Value);
            }
            catch { }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_presenter.ApplyChanges())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
using GrpcCommonNet.Library.Common;
using GrpcWinForms.Objects.Currencies.Presenters;
using GrpcWinForms.Objects.Currencies.Views;
using System;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Currencies.Forms
{
    public partial class CurrencyForm : Form, ICurrencyView
    {
        private readonly CurrencyPresenter _presenter;

        public Currency Currency { get; set; } = new Currency();
        public bool IsNew { get; set; } = false;

        // ICurrencyView mapped to контролы формы
        public string IdText
        {
            get => textBoxId.Text;
            set => textBoxId.Text = value;
        }

        public string Code
        {
            get => textBoxCode.Text;
            set => textBoxCode.Text = value;
        }

        public string Name
        {
            get => textBoxName.Text;
            set => textBoxName.Text = value;
        }

        public string Abbrev
        {
            get => textBoxSymbol.Text;
            set => textBoxSymbol.Text = value;
        }

        public bool IsVisible
        {
            get => checkBoxIsVisible.Checked;
            set => checkBoxIsVisible.Checked = value;
        }

        public CurrencyForm()
        {
            InitializeComponent();
            _presenter = new CurrencyPresenter(this);
        }

        private void CurrencyForm_Load(object sender, EventArgs e)
        {
            _presenter.OnLoad();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (_presenter.OnOk())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            // при ошибке OnOk показывает сообщение и диалог не закрывается
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public void ShowMessage(string text, string caption = "")
        {
            MessageBox.Show(this, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
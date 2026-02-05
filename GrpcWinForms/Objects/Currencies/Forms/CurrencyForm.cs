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

namespace GrpcWinForms.Objects.Currencies.Forms
{
    public partial class CurrencyForm : Form
    {
        public Currency Currency { get; set; } = new Currency();
        public bool IsNew { get; set; } = false;

        public CurrencyForm()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!IsNew) Currency.Id = Convert.ToInt32(textBoxId.Text);
            else Currency.Id = 0;

            Currency.Abbrev = textBoxSymbol.Text;
            Currency.Code = textBoxCode.Text;
            Currency.Name = textBoxName.Text;
            Currency.IsVisible = checkBoxIsVisible.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CurrencyForm_Load(object sender, EventArgs e)
        {
            textBoxCode.Text = Currency.Code?? string.Empty;
            textBoxId.Text = Currency.Id.ToString();
            textBoxName.Text = Currency.Name ?? string.Empty;
            textBoxSymbol.Text = Currency.Abbrev ?? string.Empty;
            checkBoxIsVisible.Checked = Currency.IsVisible;

        }
    }
}

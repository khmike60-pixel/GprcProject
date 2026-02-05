using GrpcCommonNet.Library.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application =  GrpcCommonNet.Library.Common.Application;

namespace GrpcWinForms.Objects.Applications.Forms
{
    public partial class ApplicationForm : Form
    {
        public bool IsTypeInsert { get; set; } = false;
        public Application Application { get; set; } = new Application();

        public ApplicationForm()
        {
            InitializeComponent();
        }

        private void ApplicationForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EventArgs arg = new EventArgs();
                buttonOk_Click(sender, arg); // вызвать нажатие ОК
                e.Handled = true;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Application.Name = textBoxName.Text;
            Application.Db = textBoxDb.Text;
            Application.Product = textBoxProduct.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ApplicationForm_Load(object sender, EventArgs e)
        {
            if (IsTypeInsert) Application = new Application();

            textBoxId.Text = Application.Id.ToString();
            textBoxName.Text = Application.Name;
            textBoxDb.Text = Application.Db;
            textBoxProduct.Text = Application.Product;

        }
    }
}

using System;
using System.Windows.Forms;
using GrpcWinForms.Objects.Applications.Views;
using GrpcWinForms.Objects.Applications.Presenters;
using Application = GrpcCommonNet.Library.Common.Application;

namespace GrpcWinForms.Objects.Applications.Forms
{
    public partial class ApplicationForm : Form, IApplicationView
    {
        public bool IsTypeInsert { get; set; } = false;
        public Application Application { get; set; } = new Application();

        private readonly ApplicationPresenter _presenter;

        public ApplicationForm()
        {
            InitializeComponent();
            _presenter = new ApplicationPresenter(this);
        }

        // IApplicationView
        public bool IsNew => IsTypeInsert;

        public string IdText
        {
            get => textBoxId.Text;
            set => textBoxId.Text = value;
        }

        public string AppName
        {
            get => textBoxName.Text;
            set => textBoxName.Text = value;
        }

        public string Db
        {
            get => textBoxDb.Text;
            set => textBoxDb.Text = value;
        }

        public string Product
        {
            get => textBoxProduct.Text;
            set => textBoxProduct.Text = value;
        }

        public void ShowMessage(string text, string caption = "") => MessageBox.Show(text, caption);

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
            if (_presenter.OnOk())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            // при ошибке валидации — оставляем окно открытым
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ApplicationForm_Load(object sender, EventArgs e)
        {
            if (IsTypeInsert) Application = new Application();
            _presenter.OnLoad();
        }
    }
}
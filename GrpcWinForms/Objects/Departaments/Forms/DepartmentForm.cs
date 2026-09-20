using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Department;
using GrpcWinForms.Objects.Departaments.Presenters;
using GrpcWinForms.Objects.Departaments.Views;
using System;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Departaments.Forms
{
    public partial class DepartmentForm : Form, IDepartmentView
    {
        private Department _department;
        private readonly DepartmentPresenter _presenter;

        public event EventHandler LoadView;
        public event EventHandler OkClicked;
        public event EventHandler CancelClicked;

        public Department Department
        {
            get => _department;
            set => _department = value ?? new Department();
        }

        public string IdText
        {
            get => tId.Text;
            set => tId.Text = value;
        }

        public string NameText
        {
            get => tName.Text;
            set => tName.Text = value;
        }

        public string ShortText
        {
            get => tShort.Text;
            set => tShort.Text = value;
        }

        public string CodeText
        {
            get => tCode.Text;
            set => tCode.Text = value;
        }

        public DepartmentForm()
        {
            InitializeComponent();
            _department = new Department();
            _presenter = new DepartmentPresenter(this);
        }

        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            LoadView?.Invoke(this, EventArgs.Empty);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            OkClicked?.Invoke(this, EventArgs.Empty);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke(this, EventArgs.Empty);
            Close();
        }

        public void ShowMessage(string message) => MessageBox.Show(message);

        public void CloseWithOk()
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
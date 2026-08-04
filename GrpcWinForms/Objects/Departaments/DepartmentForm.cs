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

namespace GrpcWinForms.Objects.Departaments
{
    public partial class DepartmentForm : Form
    {
        private Department _department;
        public Department Department { get => _department; set => _department = value; }

        public DepartmentForm()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            _department = new Department();
            _department.Id = String.IsNullOrEmpty(tId.Text) ? 0 : Convert.ToInt32(tId.Text);
            _department.Name = tName.Text;
            _department.Short = tShort.Text;
            _department.Symbol = tCode.Text;
            _department.Id = String.IsNullOrEmpty(tId.Text)? 0 : Convert.ToInt32(tId.Text);
            DialogResult = DialogResult.OK;
            Close();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            tId.Text = Department.Id.ToString();
            tName.Text = Department.Name;
            tShort.Text = Department.Short;
            tCode.Text = Department.Symbol;
        }
    }
}

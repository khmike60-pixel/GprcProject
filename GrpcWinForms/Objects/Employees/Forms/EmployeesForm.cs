using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Employee;
using GrpcWinForms.GrpcUtils;
using SmartLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Employees.Forms
{
    public partial class EmployeesForm : Form
    {
        private BindingList<Employee> employees = new BindingList<Employee>();

        public bool DialogMode { get; set; } = false;

        public EmployeesForm()
        {
            InitializeComponent();
        }

        private async void RefreshEmployees()
        {
            try
            {
                ListEmployeeRequest request = new ListEmployeeRequest()
                {
                    FieldMask = new FieldMask { Paths = { "id", "contragent.name", "user.user_symbol" } }
                };
                ListEmployeeResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Employee.ListEmployeeAsync(request).ResponseAsync);

                employees = new BindingList<Employee>(response.Employees);
                smartGrid.DataSource = employees;
            }
            catch (Exception ex)
            {

            }
        }

        private void EmployeesForm_Load(object sender, EventArgs e)
        {
            RefreshEmployees();
        }

        private void smartGrid_GetUnboundValue(object sender, C1.Win.FlexGrid.UnboundValueEventArgs e)
        {
            int row = e.Row;
            Employee emp = smartGrid.Rows[row].DataSource as Employee;
            if (e.Row < smartGrid.Rows.Fixed || e.Row >= smartGrid.Rows.Count)
                return;
            switch (smartGrid.Cols[e.Col].Name)
            {
                case "Abbrev":
                    e.Value = emp.User.UserSymbol;
                    break;
                case "Name":
                    e.Value = emp.Contragent.Name;
                    break;
            }
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshEmployees();
        }

        private void smartGrid_DoubleClick(object sender, EventArgs e)
        {
            if (!DialogMode) return;
            int row = smartGrid.Row;
            Employee employee = smartGrid.Rows[row].DataSource as Employee;
            DialogResult = DialogResult.OK;
            Close();

        }
    }
}

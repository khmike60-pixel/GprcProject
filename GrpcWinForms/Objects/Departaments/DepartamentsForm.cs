using C1.Win.FlexGrid;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Currency;
using GrpcCommonNet.Library.Department;
using GrpcWinForms.Models;
using GrpcWinForms.Objects.Currencies.Forms;
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
    public partial class DepartamentsForm : Form
    {
        private BindingList<Department> departments;
        public DepartamentsForm()
        {
            InitializeComponent();
        }

        private async Task RefreshDepartments(object sender, EventArgs e)
        {
            ListDepartmentRequest request = new ListDepartmentRequest()
            {
                DepartmentShort = tShort.Text,
                Symbol = "",
                FieldMask = new Google.Protobuf.WellKnownTypes.FieldMask() { Paths = { "id", "name", "short", "symbol" } }

            };

            ListDepartmentResponse response = new ListDepartmentResponse();
            response = await GrpcClients.GrpcClients.Department.GetListDepartmentAsync(request);

            departments = new BindingList<Department>(response.Departments);
            smartGrid.DataSource = departments;
        }

        private void DepartamentsForm_Load(object sender, EventArgs e)
        {
            RefreshDepartments(sender, e);
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshDepartments(sender, e);
        }

        private async void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new DepartmentForm())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        CreateDepartmentRequest request = new CreateDepartmentRequest
                        {
                            Department = form.Department
                        };

                        DepartmentResponse response = await GrpcClients.GrpcClients.Department.CreateDepartmentAsync(request);
                        if (response.Result.Status != Status.Ok || response.Department == null)
                        {
                            MessageBox.Show("Добавить данные не удалось.");
                            return;
                        }
                        else
                        {
                            int rowsel = smartGrid.RowSel;
                            departments.Insert(smartGrid.RowSel - smartGrid.Rows.Fixed, response.Department);
                            smartGrid.Row = rowsel;
                        }

                    }
                }
            }
            catch (Exception ex) { }

        }

        private void toolStripButtonDouble_Click(object sender, EventArgs e)
        {
            Department department = new Department();
            department = smartGrid.Rows[smartGrid.Row].DataSource as Department;
            CreateDepartmentRequest request = new CreateDepartmentRequest()
            {
                Department = department
            };
            department.Name += " 1";

            DepartmentResponse response = new DepartmentResponse();
            response = GrpcClients.GrpcClients.Department.CreateDepartment(request);

            if (response.Result.Status != Status.Ok || response.Department == null)
            {
                MessageBox.Show("Добавить данные не удалось.");
                return;
            }
            else
            {
                int rowsel = smartGrid.RowSel;
                departments.Insert(smartGrid.RowSel - smartGrid.Rows.Fixed, response.Department);
                smartGrid.Row = rowsel;
            }
        }

        private async void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            using (var form = new DepartmentForm())
            {
                form.Department = departments[smartGrid.RowSel - smartGrid.Rows.Fixed];

                if (form.ShowDialog() == DialogResult.OK)
                {
                    UpdateDepartmentRequest request = new UpdateDepartmentRequest
                    {
                        Department = form.Department
                    };

                    DepartmentResponse response = await GrpcClients.GrpcClients.Department.UpdateDepartmentAsync(request);
                    if (response.Result.Status != Status.Ok || response.Department == null)
                    {
                        MessageBox.Show("Изменить данные не удалось.");
                        return;
                    }
                    else
                    {
                        int rowsel = smartGrid.RowSel;
                        departments[rowsel - smartGrid.Rows.Fixed] = response.Department;
                    }

                }
            }
        }

        private async void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();
            List<int> oldList = new List<int>();
            List<int> newMarked = new List<int>();
            if (smartGrid.SelectedRows.Count == 0)
            { // Удаляется одна запись
                DialogResult result = MessageBox.Show("Удалить текущую строку данных?", "Удаление", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    DeleteDepartmentRequest request = new DeleteDepartmentRequest()
                    {
                        Id = (int)smartGrid.Rows[smartGrid.RowSel]["Id"]
                    };
                    DeleteDepartmentResponse response = await GrpcClients.GrpcClients.Department.DeleteDepartmentAsync(request);
                    int i = smartGrid.RowSel - smartGrid.Rows.Fixed;
                    if (response.Result.Status == Status.Ok)
                    {
                        smartGrid.BeginUpdate();
                        departments.RemoveAt(i);
                        smartGrid.EndUpdate();
                    }
                    else
                        MessageBox.Show("Ошибка при удалении: " + response.Result.Message);
                }
            }
            else
            { // Был режим выделения

                DialogResult result = MessageBox.Show($"Вы отметили {smartGrid.SelectedRows.Count} строк." + Environment.NewLine + "Удалить отмеченные строки?", "Удаление", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {

                    oldList.AddRange(smartGrid.SelectedRows);
                    newMarked.AddRange(smartGrid.SelectedRows);

                    foreach (var index in oldList) ids.Add(Convert.ToInt32(smartGrid.Rows[index]["Id"]));

                    DeleteIdsDepartmentRequest request = new DeleteIdsDepartmentRequest();
                    request.Ids.AddRange(ids);

                    UndeletedIdsDepartmentResponse response = new UndeletedIdsDepartmentResponse();
                    response = await GrpcClients.GrpcClients.Department.DeleteIdsDepartmentAsync(request);

                    List<int> undelIds = new List<int>();
                    foreach (var item in response.UndeletedIds) undelIds.Add(Convert.ToInt32(item));

                    smartGrid.BeginUpdate();
                    List<int> testList = Utils.UndeleteList<Department>((C1FlexGrid)smartGrid, departments, undelIds, smartGrid.SelectedRows, "Id");
                    smartGrid.SelectedRows = testList;
                    smartGrid.EndUpdate();

                    if (response.Result.Status != Status.Ok)
                        MessageBox.Show("Ошибка при удалении: " + response.Result.Message);
                    else if (response.UndeletedIds.Count > 0)
                        MessageBox.Show("Данные, которые не удалось удалить остались выделенными.");
                }
            }
            return;
        }

        private void smartGrid_DoubleClick(object sender, EventArgs e)
        {
            toolStripButtonEdit_Click(sender, e);
        }
    }
}

using C1.Win.FlexGrid;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Currency;
using GrpcCommonNet.Library.Department;
using GrpcWinForms.GrpcUtils;
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
        public bool DialogMode { get; set; } = false;
        private Department selectedItem;
        public Department SelectedItem { get => selectedItem; }

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
            response = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Department.GetListDepartmentAsync(request).ResponseAsync);

            departments = new BindingList<Department>(response.Departments);
            smartGrid1.DataSource = departments;
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

                        DepartmentResponse response = await GrpcRetry.CallAsync(() =>
                            GrpcClients.GrpcClients.Department.CreateDepartmentAsync(request).ResponseAsync);
                        if (response.Result.Status != Status.Ok || response.Department == null)
                        {
                            MessageBox.Show("Добавить данные не удалось.");
                            return;
                        }
                        else
                        {
                            int rowsel = smartGrid1.RowSel;
                            departments.Insert(smartGrid1.RowSel - smartGrid1.Rows.Fixed, response.Department);
                            smartGrid1.Row = rowsel;
                        }

                    }
                }
            }
            catch (Exception ex) { }

        }

        private async void toolStripButtonDouble_Click(object sender, EventArgs e)
        {
            Department department = new Department();
            department = smartGrid1.Rows[smartGrid1.Row].DataSource as Department;
            CreateDepartmentRequest request = new CreateDepartmentRequest()
            {
                Department = department
            };
            department.Name += " 1";

            DepartmentResponse response = new DepartmentResponse();
            response = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Department.CreateDepartmentAsync(request).ResponseAsync);

            if (response.Result.Status != Status.Ok || response.Department == null)
            {
                MessageBox.Show("Добавить данные не удалось.");
                return;
            }
            else
            {
                int rowsel = smartGrid1.RowSel;
                departments.Insert(smartGrid1.RowSel - smartGrid1.Rows.Fixed, response.Department);
                smartGrid1.Row = rowsel;
            }
        }

        private async void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            using (var form = new DepartmentForm())
            {
                form.Department = departments[smartGrid1.RowSel - smartGrid1.Rows.Fixed];

                if (form.ShowDialog() == DialogResult.OK)
                {
                    UpdateDepartmentRequest request = new UpdateDepartmentRequest
                    {
                        Department = form.Department
                    };

                    DepartmentResponse response = await GrpcRetry.CallAsync(() => 
                        GrpcClients.GrpcClients.Department.UpdateDepartmentAsync(request).ResponseAsync);
                    if (response.Result.Status != Status.Ok || response.Department == null)
                    {
                        MessageBox.Show("Изменить данные не удалось.");
                        return;
                    }
                    else
                    {
                        int rowsel = smartGrid1.RowSel;
                        departments[rowsel - smartGrid1.Rows.Fixed] = response.Department;
                    }

                }
            }
        }

        private async void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();
            List<int> oldList = new List<int>();
            List<int> newMarked = new List<int>();
            if (smartGrid1.SelectedRows.Count == 0)
            { // Удаляется одна запись
                DialogResult result = MessageBox.Show("Удалить текущую строку данных?", "Удаление", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    DeleteDepartmentRequest request = new DeleteDepartmentRequest()
                    {
                        Id = (int)smartGrid1.Rows[smartGrid1.RowSel]["Id"]
                    };
                    DeleteDepartmentResponse response = await GrpcRetry.CallAsync(() => 
                        GrpcClients.GrpcClients.Department.DeleteDepartmentAsync(request).ResponseAsync);
                    int i = smartGrid1.RowSel - smartGrid1.Rows.Fixed;
                    if (response.Result.Status == Status.Ok)
                    {
                        smartGrid1.BeginUpdate();
                        departments.RemoveAt(i);
                        smartGrid1.EndUpdate();
                    }
                    else
                        MessageBox.Show("Ошибка при удалении: " + response.Result.Message);
                }
            }
            else
            { // Был режим выделения

                DialogResult result = MessageBox.Show($"Вы отметили {smartGrid1.SelectedRows.Count} строк." + Environment.NewLine + "Удалить отмеченные строки?", "Удаление", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {

                    oldList.AddRange(smartGrid1.SelectedRows);
                    newMarked.AddRange(smartGrid1.SelectedRows);

                    foreach (var index in oldList) ids.Add(Convert.ToInt32(smartGrid1.Rows[index]["Id"]));

                    DeleteIdsDepartmentRequest request = new DeleteIdsDepartmentRequest();
                    request.Ids.AddRange(ids);

                    UndeletedIdsDepartmentResponse response = new UndeletedIdsDepartmentResponse();
                    response = await GrpcRetry.CallAsync(() => 
                        GrpcClients.GrpcClients.Department.DeleteIdsDepartmentAsync(request).ResponseAsync);

                    List<int> undelIds = new List<int>();
                    foreach (var item in response.UndeletedIds) undelIds.Add(Convert.ToInt32(item));

                    smartGrid1.BeginUpdate();
                    List<int> testList = Utils.UndeleteList<Department>((C1FlexGrid)smartGrid1, departments, undelIds, smartGrid1.SelectedRows, "Id");
                    smartGrid1.SelectedRows = testList;
                    smartGrid1.EndUpdate();

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
            if (!DialogMode)
            {
                toolStripButtonEdit_Click(sender, e); return;
            }
            int row = smartGrid1.Row;
            if (row < smartGrid1.Rows.Fixed) return;
            selectedItem = smartGrid1.Rows[row].DataSource as Department;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

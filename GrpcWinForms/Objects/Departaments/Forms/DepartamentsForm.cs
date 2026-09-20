using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Department;
using GrpcWinForms.Objects.Departaments.Presenters;
using GrpcWinForms.Objects.Departaments.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Departaments.Forms
{
    public partial class DepartamentsForm : Form, IDepartamentsView
    {
        // локальная коллекция для привязки
        private BindingList<Department> departments;
        private Department selectedItem;
        private readonly DepartamentsPresenter _presenter;

        public event EventHandler LoadView;

        public DepartamentsForm()
        {
            InitializeComponent();
            _presenter = new DepartamentsPresenter(this);
        }

        // IDepartamentsView реализация
        public string ShortFilter => tShort.Text;
        public bool DialogMode { get; set; } = false;
        public BindingList<Department> Departments
        {
            set
            {
                departments = value;
                gridDepartments.DataSource = departments;
            }
        }

        public Department SelectedItem
        {
            get => selectedItem;
            set => selectedItem = value;
        }

        public int RowSel => gridDepartments.RowSel;
        public IList<int> SelectedRows => gridDepartments.SelectedRows;

        public void InsertDepartmentAt(int index, Department department)
        {
            if (departments == null) departments = new BindingList<Department>();
            if (index < 0) index = 0;
            if (index > departments.Count) index = departments.Count;
            departments.Insert(index, department);
            gridDepartments.Row = gridDepartments.RowSel;
        }

        public void RemoveDepartmentAt(int index)
        {
            if (departments == null) return;
            if (index >= 0 && index < departments.Count)
                departments.RemoveAt(index);
        }

        public void ReplaceDepartmentAt(int index, Department department)
        {
            if (departments == null) return;
            if (index >= 0 && index < departments.Count)
                departments[index] = department;
        }

        public void BeginUpdate() => gridDepartments.BeginUpdate();
        public void EndUpdate() => gridDepartments.EndUpdate();
        public void ShowMessage(string message) => MessageBox.Show(message);

        public void CloseWithOk()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // UI события — делегируем в презентер
        private void DepartamentsForm_Load(object sender, EventArgs e)
        {
            LoadView?.Invoke(this, EventArgs.Empty);
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            _ = _presenter.RefreshAsync();
        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            _ = _presenter.NewAsync();
        }

        private void toolStripButtonDouble_Click(object sender, EventArgs e)
        {
            _ = _presenter.DoubleAsync();
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            _ = _presenter.EditAsync();
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            _ = _presenter.DeleteAsync();
        }

        private void smartGrid_DoubleClick(object sender, EventArgs e)
        {
            // определяем выбранную запись
            int row = gridDepartments.Row;
            if (row >= gridDepartments.Rows.Fixed)
                selectedItem = gridDepartments.Rows[row].DataSource as Department;

            _presenter.OnGridDoubleClick();
        }
    }
}

using GrpcCommonNet.Library.Application;
using GrpcCommonNet.Library.Common;
using GrpcWinForms.Objects.Applications.Forms;
using GrpcWinForms.Objects.Applications.Presenters;
using GrpcWinForms.Objects.Applications.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Application = GrpcCommonNet.Library.Common.Application;

namespace GrpcWinForms.Objects.Applications
{
    public partial class ApplicationsForm : Form, IApplicationsView
    {
        private BindingList<Application> applications = new BindingList<Application>();
        private readonly ApplicationsPresenter _presenter;

        public bool IsChoiceMode { get; set; } = false;

        public ApplicationsForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            _presenter = new ApplicationsPresenter(this);
        }

        // Обратно добавленные свойства для совместимости с UsersAppForm
        public Application SelectedApplication
        {
            get
            {
                if (smartGrid1.RowSel >= smartGrid1.Rows.Fixed)
                    return (Application)smartGrid1.Rows[smartGrid1.Row].DataSource;
                else
                    return null;
            }
        }

        public List<Application> SelectedApps
        {
            get
            {
                if (smartGrid1.SelectedRows.Count == 0) return null;
                var list = new List<Application>();
                foreach (int i in smartGrid1.SelectedRows)
                {
                    list.Add((Application)smartGrid1.Rows[i].DataSource);
                }
                return list;
            }
        }

        // IApplicationsView реализация
        public string NameFilter => textBoxAppName.Text;

        public BindingList<Application> Applications
        {
            get => applications;
            set
            {
                applications = value ?? new BindingList<Application>();
                smartGrid1.DataSource = applications;
            }
        }

        public int RowSel => smartGrid1.RowSel;
        public int RowsFixed => smartGrid1.Rows.Fixed;

        public IList<int> SelectedRows
        {
            get
            {
                var list = new List<int>();
                if (smartGrid1.SelectedRows == null) return list;
                list.AddRange(smartGrid1.SelectedRows);
                return list;
            }
        }

        public Application GetApplicationAtRow(int row)
        {
            if (row < smartGrid1.Rows.Fixed || row >= smartGrid1.Rows.Count) return null;
            return smartGrid1.Rows[row].DataSource as Application;
        }

        public int GetIdAtRow(int row)
        {
            if (row < smartGrid1.Rows.Fixed || row >= smartGrid1.Rows.Count) return 0;
            return Convert.ToInt32(smartGrid1.Rows[row]["Id"]);
        }

        public void BeginUpdate() => smartGrid1.BeginUpdate();
        public void EndUpdate() => smartGrid1.EndUpdate();

        public DialogResult ShowApplicationDialog(ApplicationForm form) => form.ShowDialog();

        public void SetRow(int row) => smartGrid1.Row = row;

        public void InsertApplicationAt(int index, Application app)
        {
            if (index < 0) index = 0;
            if (index > applications.Count) index = applications.Count;
            applications.Insert(index, app);
        }

        public void ReplaceApplicationAt(int index, Application app)
        {
            if (index < 0 || index >= applications.Count) return;
            applications[index] = app;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= applications.Count) return;
            applications.RemoveAt(index);
        }

        public void RemoveApplicationsByIds(IList<int> ids)
        {
            if (ids == null || ids.Count == 0) return;
            var toRemove = applications.Where(a => ids.Contains(a.Id)).ToList();
            foreach (var item in toRemove) applications.Remove(item);
        }

        public void ShowMessage(string text, string caption = "") => MessageBox.Show(text, caption);

        // События формы пересылают действия в презентер
        private async void ApplicationsForm_Load(object sender, EventArgs e)
        {
            await _presenter.RefreshAsync();
        }

        private async void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            await _presenter.RefreshAsync();
        }

        private async void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            await _presenter.NewAsync();
        }

        private async void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            await _presenter.EditAsync();
        }

        private async void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            await _presenter.DeleteAsync();
        }

        private void ApplicationsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                _ = _presenter.RefreshAsync();
                e.Handled = true;
            }
            if (IsChoiceMode && e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                e.Handled = true;
            }
            if (IsChoiceMode && e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                e.Handled = true;
            }
        }

        private void smartGrid_DoubleClick(object sender, EventArgs e)
        {
            if (IsChoiceMode && smartGrid1.Row >= smartGrid1.Rows.Fixed)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                toolStripButtonEdit_Click(sender, e);
            }
        }
    }
}
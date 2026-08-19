using C1.Win.FlexGrid;
using GrpcCommonNet.Library.Application;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Proto.Utils;
using GrpcWinForms.Forms;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Models;
using GrpcWinForms.Objects.Applications.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = GrpcCommonNet.Library.Common.Application;

namespace GrpcWinForms.Objects.Applications
{
    public partial class ApplicationsForm : Form
    {
        private BindingList<Application> applications = new BindingList<Application>();
        public bool IsChoiceMode { get; set; } = false;
        public Application? SelectedApplication
        {
            get
            {
                if (smartGrid1.RowSel >= smartGrid1.Rows.Fixed)
                    return (Application)smartGrid1.Rows[smartGrid1.Row].DataSource;
                else return null;
            }
        }
        public List<Application> SelectedApps
        {
            get
            {
                if (smartGrid1.SelectedRows.Count == 0) return null;
                else
                {
                    List<Application> applications = new List<Application>();
                    foreach(int i in smartGrid1.SelectedRows)
                    {
                        applications.Add((Application)smartGrid1.Rows[i].DataSource);
                    }
                    
                    return applications;
                }
            }
        }

        public ApplicationsForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void ApplicationsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                RefreshApplication();
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

        private void ApplicationsForm_Load(object sender, EventArgs e)
        {
            RefreshApplication();
        }

        private async void RefreshApplication()
        {

            ApplicationFilterRequest request = new ApplicationFilterRequest()
            {
                Name = textBoxAppName.Text,
                Product = textBoxAppName.Text,
                Db = textBoxAppName.Text
            };

            ListApplicationResponse response = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Application.GetListApplicationAsync(request).ResponseAsync
            );
            applications = new BindingList<Application>(response.Applications);
            smartGrid1.DataSource = applications;
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshApplication();
        }

        private async void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            using (var form = new ApplicationForm())
            {
                form.IsTypeInsert = true;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    CreateApplicationRequest request = new CreateApplicationRequest
                    {
                        Name = form.Application.Name,
                        Db = form.Application.Db,
                        Product = form.Application.Product
                    };

                    ApplicationResponse response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Application.CreateApplicationAsync(request).ResponseAsync
                    );
                    if (response.Result.Status != Status.Ok || response.Application == null)
                    {
                        MessageBox.Show("Добавить данные не удалось.");
                        return;
                    }
                    else
                    {
                        int rowsel = smartGrid1.RowSel;
                        applications.Insert(smartGrid1.RowSel - smartGrid1.Rows.Fixed, response.Application);
                        smartGrid1.Row = rowsel;
                    }

                }
            }

        }

        private async void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            using (var form = new ApplicationForm())
            {

                form.IsTypeInsert = false;

                var row = smartGrid1.Rows[smartGrid1.RowSel];
                Application app = new Application()
                {
                    Id = (int)row["Id"],
                    Name = row["Name"] == null ? string.Empty : row["Name"].ToString(),
                    Db = row["Db"] == null ? string.Empty : row["Db"].ToString(),
                    Product = row["Product"] == null ? string.Empty : row["Product"].ToString()
                };
                form.Application = app;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    UpdateApplicationRequest request = new UpdateApplicationRequest
                    {
                        Name = form.Application.Name,
                        Db = form.Application.Db,
                        Product = form.Application.Product,
                        Id = form.Application.Id
                    };

                    ApplicationResponse response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Application.UpdateApplicationAsync(request).ResponseAsync
                    );
                    if (response.Application != null)
                    {
                        applications[smartGrid1.RowSel - smartGrid1.Rows.Fixed] = response.Application;
                        //smartGrid1.Rows[smartGrid1.RowSel]["Id"] = response.Application.Id;
                        //smartGrid1.Rows[smartGrid1.RowSel]["Name"] = response.Application.Name;
                        //smartGrid1.Rows[smartGrid1.RowSel]["Db"] = response.Application.Db;
                        //smartGrid1.Rows[smartGrid1.RowSel]["Product"] = response.Application.Product;
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
                    DeleteApplicationRequest request = new DeleteApplicationRequest()
                    {
                        Id = (int)smartGrid1.Rows[smartGrid1.RowSel]["Id"]
                    };
                    DeleteApplicationResponse response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Application.DeleteApplicationAsync(request).ResponseAsync
                    );
                    int i = smartGrid1.RowSel - smartGrid1.Rows.Fixed;
                    if (response.Result.Status == Status.Ok)
                    {
                        smartGrid1.BeginUpdate();
                        applications.RemoveAt(i);
                        smartGrid1.EndUpdate();
                    }
                    else
                        MessageBox.Show("Ошибка при удалении: " + response.Result.Message);
                }
            }
            else
            { // Был режим выделения

                DialogResult result = MessageBox.Show($"Вы отметили {smartGrid1.SelectedRows} строк." + Environment.NewLine + "Удалить отмеченные строки?", "Удаление", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {

                    oldList.AddRange(smartGrid1.SelectedRows);
                    newMarked.AddRange(smartGrid1.SelectedRows);

                    foreach (var index in oldList) ids.Add(Convert.ToInt32(smartGrid1.Rows[index]["Id"]));

                    DeleteIdsApplicationRequest request = new DeleteIdsApplicationRequest();
                    request.Ids.AddRange(ids);

                    UndeleteIdsApplicationResponse response = new UndeleteIdsApplicationResponse();
                    response = await GrpcRetry.CallAsync(() => 
                        GrpcClients.GrpcClients.Application.DeleteIdsApplicationAsync(request).ResponseAsync
                    );

                    List<int> undelIds = new List<int>();
                    foreach (var item in response.UndeletedIds) undelIds.Add(Convert.ToInt32(item));

                    smartGrid1.BeginUpdate();
                    List<int> testList = Utils.UndeleteList<Application>((C1FlexGrid)smartGrid1, applications, undelIds, smartGrid1.SelectedRows, "Id");
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

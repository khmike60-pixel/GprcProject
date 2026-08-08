using C1.Win.FlexGrid;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Unit;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Models;
using GrpcWinForms.Objects.Units.Forms;
using SmartGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Forms
{
    public partial class UnitsForm : Form
    {
        private BindingList<Unit> units;

        public UnitsForm()
        {
            InitializeComponent();
        }

        private async void UnitsForm_Load(object sender, EventArgs e)
        {
            bool result = await RefreshUnit(sender, e);

        }

        private async Task<bool> RefreshUnit(object sender, EventArgs e)
        {
            try
            {
                ListUnitRequest request = new ListUnitRequest()
                {
                    Short = textBoxName.Text,
                    IsArchive = checkBoxAll.Checked ? true : false
                };
                ListUnitResponse response = await GrpcRetry.CallAsync(() => 
                    GrpcClients.GrpcClients.Unit.GetListUnitAsync(request).ResponseAsync);
                units = new BindingList<Unit>(response.Units);
                smartGrid.DataSource = units;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка получения данных: " + ex.Message);
                return false;
            }

        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshUnit(sender, e);
        }

        private async void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            using (var form = new UnitForm())
            {
                form.IsTypeInsert = true;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    CreateUnitRequest request = new CreateUnitRequest()
                    {
                        Unit = new Unit()
                        {
                            Id = form.EditUnit.Id,
                            Short = form.EditUnit.Short,
                            IsArchive = form.EditUnit.IsArchive,
                            Code = form.EditUnit.Code,
                            Comment = form.EditUnit.Comment,
                            Rem = form.EditUnit.Rem,
                            RwsCode = form.EditUnit.RwsCode,
                            RwsMcode = form.EditUnit.RwsMcode
                        }
                    };
                    UnitResponse response = await GrpcRetry.CallAsync(() => 
                        GrpcClients.GrpcClients.Unit.CreateUnitAsync(request).ResponseAsync);
                    if (response.Result.Status != Status.Ok || response.Unit == null)
                    {
                        MessageBox.Show("Добавить данные не удалось.");
                        return;
                    }
                    else
                    {
                        int rowsel = smartGrid.RowSel;
                        units.Insert(smartGrid.RowSel - smartGrid.Rows.Fixed, response.Unit);
                        smartGrid.Row = rowsel;
                    }
                }
                else form.Close();

            }
        }

        private async void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            Unit unit = units[smartGrid.RowSel - smartGrid.Rows.Fixed];
            using (var form = new UnitForm())
            {
                form.IsTypeInsert = false;

                form.EditUnit = unit;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    UpdateUnitRequest request = new UpdateUnitRequest()
                    {
                        Unit = new Unit()
                        {
                            Id = form.EditUnit.Id,
                            Short = form.EditUnit.Short,
                            IsArchive = form.EditUnit.IsArchive,
                            Code = form.EditUnit.Code,
                            Comment = form.EditUnit.Comment,
                            Rem = form.EditUnit.Rem,
                            RwsCode = form.EditUnit.RwsCode,
                            RwsMcode = form.EditUnit.RwsMcode
                        }
                    };
                    UnitResponse response = await GrpcRetry.CallAsync(() => 
                        GrpcClients.GrpcClients.Unit.UpdateUnitAsync(request).ResponseAsync);
                    if (response.Result.Status != Status.Ok || response.Unit == null)
                    {
                        MessageBox.Show("Добавить данные не удалось.");
                        return;
                    }
                    else
                    {
                        int rowsel = smartGrid.RowSel - smartGrid.Rows.Fixed;
                        units[rowsel] = response.Unit;
                    }
                }
                else form.Close();
            }
        }

        private async void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            Unit unit = units[smartGrid.RowSel - smartGrid.Rows.Fixed];

            List<int> ids = new List<int>();
            List<int> oldList = new List<int>();
            List<int> newMarked = new List<int>();

            if (smartGrid.SelectedRows.Count == 0)
            {
                var result = MessageBox.Show("Удалить запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DeleteUnitRequest request = new DeleteUnitRequest()
                    {
                        Id = unit.Id
                    };
                    DeleteUnitResponse response = await GrpcRetry.CallAsync(() => 
                        GrpcClients.GrpcClients.Unit.DeleteUnitAsync(request).ResponseAsync);
                    if (response.Result.Status != Status.Ok)
                    {
                        MessageBox.Show("Удалить данные не удалось.");
                        return;
                    }
                    else
                    {
                        int rowsel = smartGrid.RowSel;
                        units.RemoveAt(smartGrid.RowSel - smartGrid.Rows.Fixed);
                        if (smartGrid.Rows.Count - 1 - smartGrid.Footers.Descriptions.Count > rowsel)
                            smartGrid.Row = rowsel;
                        else
                            smartGrid.Row = smartGrid.Rows.Count - 1 - smartGrid.Footers.Descriptions.Count;
                    }
                }
            }
            else
            { 
                var result = MessageBox.Show($"Удалить все отмеченные записи ({smartGrid.SelectedRows.Count})?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    oldList.AddRange(smartGrid.SelectedRows);
                    newMarked.AddRange(smartGrid.SelectedRows);

                    foreach (var index in oldList) ids.Add(Convert.ToInt32(smartGrid.Rows[index]["Id"]));

                    DeleteIdsUnitRequest request = new DeleteIdsUnitRequest();
                    request.Ids.AddRange(ids);

                    UndeleteIdsUnitResponse response = new UndeleteIdsUnitResponse();
                    response = await GrpcRetry.CallAsync(() => 
                        GrpcClients.GrpcClients.Unit.DeleteIdsUnitAsync(request).ResponseAsync);

                    List<int> undelIds = new List<int>();
                    foreach (var item in response.UndeletedIds) undelIds.Add(Convert.ToInt32(item));

                    smartGrid.BeginUpdate();
                    List<int> testList = Utils.UndeleteList<Unit>((C1FlexGrid)smartGrid, units, undelIds, smartGrid.SelectedRows, "Id");
                    smartGrid.SelectedRows = testList;
                    smartGrid.EndUpdate();

                    if (response.Result.Status != Status.Ok)
                        MessageBox.Show("Ошибка при удалении: " + response.Result.Message);
                    else if (response.UndeletedIds.Count > 0)
                        MessageBox.Show("Данные, которые не удалось удалить остались выделенными.");

                }
            }
        }


    }
}

using C1.Win.FlexGrid;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Unit;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Models;
using GrpcWinForms.Objects.Units.Forms;
using GrpcWinForms.Objects.Units.Presenters;
using GrpcWinForms.Objects.Units.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Units.Forms
{
    public partial class UnitsForm : Form, IUnitsView
    {
        private BindingList<Unit> units;
        private readonly UnitsPresenter _presenter;

        public UnitsForm()
        {
            InitializeComponent();
            _presenter = new UnitsPresenter(this);
        }

        private async void UnitsForm_Load(object sender, EventArgs e)
        {
            await _presenter.RefreshUnitAsync();
        }

        public string FilterName => textBoxName.Text;
        public bool ShowAll => checkBoxAll.Checked;

        public BindingList<Unit> Units
        {
            get => units;
            set => units = value;
        }

        public void SetUnitsSource(BindingList<Unit> units)
        {
            this.units = units;
            smartGrid.DataSource = units;
        }

        public void ShowMessage(string message) => MessageBox.Show(message);

        public int GetCurrentRowSelRaw() => smartGrid.RowSel;
        public int GetRowsFixed() => smartGrid.Rows.Fixed;
        public IList<int> GetSelectedRows()
        {
            var list = new List<int>();
            foreach (var i in smartGrid.SelectedRows) list.Add(Convert.ToInt32(i));
            return list;
        }
        public void BeginGridUpdate() => smartGrid.BeginUpdate();
        public void EndGridUpdate() => smartGrid.EndUpdate();
        public void SetSelectedRows(IList<int> rows) => smartGrid.SelectedRows = rows is List<int> list ? list : new List<int>(rows);
        public void RemoveAt(int index) => units.RemoveAt(index);
        public void InsertAt(int index, Unit unit) => units.Insert(index, unit);
        public void UpdateAt(int index, Unit unit) => units[index] = unit;

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            _ = _presenter.RefreshUnitAsync();
        }

        private async void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            using (var form = new UnitForm())
            {
                form.IsTypeInsert = true;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    int insertIndex = smartGrid.RowSel - smartGrid.Rows.Fixed;
                    await _presenter.CreateUnitAsync(form.EditUnit, insertIndex);
                    // восстановление выбора
                    smartGrid.Row = smartGrid.RowSel;
                }
                else form.Close();
            }
        }

        private async void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            int rowselIndex = smartGrid.RowSel - smartGrid.Rows.Fixed;
            Unit unit = units[rowselIndex];

            using (var form = new UnitForm())
            {
                form.IsTypeInsert = false;
                form.EditUnit = unit;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    await _presenter.UpdateUnitAsync(form.EditUnit, rowselIndex);
                }
                else form.Close();
            }
        }

        private async void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            int rowselIndex = smartGrid.RowSel - smartGrid.Rows.Fixed;
            Unit unit = units[rowselIndex];

            if (smartGrid.SelectedRows.Count == 0)
            {
                var result = MessageBox.Show("Удалить запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var response = await _presenter.DeleteUnitAsync(unit.Id, rowselIndex);
                    if (response == null || response.Result.Status != Status.Ok)
                    {
                        // сообщение уже показывается презентером
                        return;
                    }

                    // скорректировать позицию курсора
                    int rowsel = smartGrid.RowSel;
                    if (smartGrid.Rows.Count - 1 - smartGrid.Footers.Descriptions.Count > rowsel)
                        smartGrid.Row = rowsel;
                    else
                        smartGrid.Row = smartGrid.Rows.Count - 1 - smartGrid.Footers.Descriptions.Count;
                }
            }
            else
            {
                var result = MessageBox.Show($"Удалить все отмеченные записи ({smartGrid.SelectedRows.Count})?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var oldList = new List<int>();
                    oldList.AddRange(smartGrid.SelectedRows);
                    var ids = new List<int>();
                    foreach (var index in oldList) ids.Add(Convert.ToInt32(smartGrid.Rows[index]["Id"]));

                    var response = await _presenter.DeleteIdsUnitAsync(ids);
                    if (response == null)
                        return;

                    var undelIds = new List<int>();
                    foreach (var item in response.UndeletedIds) undelIds.Add(Convert.ToInt32(item));

                    BeginGridUpdate();
                    List<int> testList = Utils.UndeleteList<Unit>((C1FlexGrid)smartGrid, units, undelIds, smartGrid.SelectedRows, "Id");
                    SetSelectedRows(testList);
                    EndGridUpdate();

                    if (response.Result.Status != Status.Ok)
                        ShowMessage("Ошибка при удалении: " + response.Result.Message);
                    else if (response.UndeletedIds.Count > 0)
                        ShowMessage("Данные, которые не удалось удалить остались выделенными.");
                }
            }
        }
    }
}
using C1.Win.FlexGrid;
using C1.Win.Input;
using GrpcWinForms.Objects.Contragents.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LookupSample.Controls
{
    public class LookupDropDownControl : C1DropDownControl
    {
        private Panel dropPanel;
        private C1FlexGrid grid;

        public Func<string, IEnumerable<LookupItem>> DataProvider { get; set; }

        public object SelectedValue { get; private set; }

        public LookupDropDownControl()
        {
            InitializeDropDown();

            this.TextChanged += LookupDropDownControl_TextChanged;
            grid.DoubleClick += Grid_DoubleClick;
        }

        private void InitializeDropDown()
        {
            dropPanel = new Panel();
            dropPanel.Height = 200;

            grid = new C1FlexGrid();
            grid.Dock = DockStyle.Fill;

            grid.Rows.Count = 1;
            grid.Cols.Count = 2;

            grid.Cols[0].Caption = "Value";
            grid.Cols[1].Caption = "Name";

            dropPanel.Controls.Add(grid);

            // ВАЖНО
            this.Control = dropPanel;
        }

        private void LookupDropDownControl_TextChanged(object sender, EventArgs e)
        {
            if (DataProvider == null)
                return;

            var text = this.Text;

            var data = DataProvider(text)
                .Take(10)
                .ToList();

            FillGrid(data);

            
            //if (data.Count > 0 && !this.DroppedDown)
            //    this.DroppedDown = true;
        }

        private void FillGrid(List<LookupItem> data)
        {
            grid.Rows.Count = 1;

            foreach (var item in data)
            {
                int r = grid.Rows.Count;
                grid.Rows.Add();

                grid[r, 0] = item.Value;
                grid[r, 1] = item.DisplayValue;
            }
        }

        private void Grid_DoubleClick(object sender, EventArgs e)
        {
            if (grid.Row < 1)
                return;

            SelectedValue = grid[grid.Row, 0];
            this.Text = grid[grid.Row, 1]?.ToString();

            this.DroppedDown = false;
        }
    }
}
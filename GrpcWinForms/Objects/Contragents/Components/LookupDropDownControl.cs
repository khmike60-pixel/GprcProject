using C1.Win.FlexGrid;
using C1.Win.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Contragents.Components
{
    public class LookupDropDownControl : C1DropDownControl
    {
        C1FlexGrid grid;
        System.Windows.Forms.Timer debounceTimer;

        public List<LookupColumn> Columns { get; } = new();

        public Func<string, Task<IEnumerable<LookupRow>>> DataProviderAsync { get; set; }

        public int MaxRows { get; set; } = 10;

        public string ValueMember { get; set; }

        public string DisplayMember { get; set; }

        public object SelectedValue { get; private set; }

        public LookupDropDownControl()
        {
            InitializeGrid();
            InitializeTimer();

            this.TextChanged += Lookup_TextChanged;
            this.KeyDown += Lookup_KeyDown;
        }

        void InitializeGrid()
        {
            grid = new C1FlexGrid();

            grid.Dock = DockStyle.Fill;

            grid.AllowEditing = false;


            grid.Rows.Count = 1;

            grid.SelectionMode = SelectionModeEnum.Row;

            grid.TabStop = false;

            grid.Click += (s, e) => SelectCurrentRow();
            grid.DoubleClick += (s, e) => SelectCurrentRow();

            grid.Enter += (s, e) => KeepCursor();

            this.Control = grid;
        }

        void InitializeColumns()
        {
            grid.Cols.Count = Columns.Count;

            for (int i = 0; i < Columns.Count; i++)
            {
                var col = Columns[i];

                grid.Cols[i].Name = col.Name;
                grid.Cols[i].Caption = col.Caption;
                grid.Cols[i].Width = col.Width;
                grid.Cols[i].Visible = col.Visible;
            }
        }

        void InitializeTimer()
        {
            debounceTimer = new System.Windows.Forms.Timer();
            debounceTimer.Interval = 300;

            debounceTimer.Tick += async (s, e) =>
            {
                debounceTimer.Stop();
                await PerformSearch();
            };
        }

        void Lookup_TextChanged(object sender, EventArgs e)
        {
            debounceTimer.Stop();
            debounceTimer.Start();
        }

        async Task PerformSearch()
        {
            if (DataProviderAsync == null)
                return;

            var text = this.Text;

            var data = (await DataProviderAsync(text))
                .Take(MaxRows)
                .ToList();

            FillGrid(data);

            if (data.Count > 0)
            {
                if (!DroppedDown)
                    DroppedDown = true;

                grid.Row = 1;
            }

            KeepCursor();
        }

        void FillGrid(List<LookupRow> rows)
        {
            if (grid.Cols.Count == 0)
                InitializeColumns();

            grid.Rows.Count = 1;

            foreach (var row in rows)
            {
                int r = grid.Rows.Count;
                grid.Rows.Add();

                for (int c = 0; c < Columns.Count; c++)
                {
                    var col = Columns[c];

                    if (row.Values.TryGetValue(col.Name, out var value))
                        grid[r, c] = value;
                }
            }

            grid.AutoSizeCols();
        }

        void Lookup_KeyDown(object sender, KeyEventArgs e)
        {
            if (grid.Rows.Count <= 1)
                return;

            if (e.KeyCode == Keys.Down)
            {
                if (grid.Row < grid.Rows.Count - 1)
                    grid.Row++;

                e.Handled = true;
            }

            if (e.KeyCode == Keys.Up)
            {
                if (grid.Row > 1)
                    grid.Row--;

                e.Handled = true;
            }

            if (e.KeyCode == Keys.Enter)
            {
                SelectCurrentRow();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                DroppedDown = false;
            }

            KeepCursor();
        }

        void SelectCurrentRow()
        {
            if (grid.Row < 1)
                return;

            var valueCol = grid.Cols[ValueMember];
            var displayCol = grid.Cols[DisplayMember];

            SelectedValue = grid[grid.Row, valueCol.Index];

            this.Text = grid[grid.Row, displayCol.Index]?.ToString();

            DroppedDown = false;

            KeepCursor();
        }

        void KeepCursor()
        {
            BeginInvoke(new Action(() =>
            {
                this.Focus();
                this.SelectionStart = this.Text.Length;
                this.SelectionLength = 0;
            }));
        }
    }
}
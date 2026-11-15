using C1.Win.FlexGrid;
using GrpcCommonNet.Library.Common;
using GrpcWinForms.Controls.PermissionManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.PermissionManager.PermissionHandler
{
    internal class C1FlexGridPermissionHandler : BasePermissionHandler
    {
        private readonly Dictionary<C1FlexGrid, HashSet<string>> _editableColumnsByGrid = new();

        public override void SetupComponentPermission(object component, Permission permission, PermissionMetaData permissionMetaData) { }

        public void SetupGridColumnPermission(object component, Permission permission, PermissionGridMetadata gridMetaData)
        {
            if (component is not C1FlexGrid grid) return;
            if (gridMetaData?.Columns == null) return;

            if (!_editableColumnsByGrid.ContainsKey(grid))
                _editableColumnsByGrid[grid] = new HashSet<string>();

            foreach (var columnName in gridMetaData.Columns)
            {
                var col = FindColumn(grid, columnName);
                if (col == null) continue;

                switch (permission.Value)
                {
                    case PermissionValue.Edit:
                        col.Visible = true;
                        col.AllowEditing = true;
                        _editableColumnsByGrid[grid].Add(columnName);
                        grid.StartEdit -= OnStartEdit;
                        grid.StartEdit += OnStartEdit;
                        grid.Disposed -= OnGridDisposed;
                        grid.Disposed += OnGridDisposed;
                        break;

                    case PermissionValue.View:
                    case PermissionValue.Select:
                        col.Visible = true;
                        col.AllowEditing = false;
                        _editableColumnsByGrid[grid].Remove(columnName);
                        break;

                    case PermissionValue.None:
                        col.Visible = false;
                        _editableColumnsByGrid[grid].Remove(columnName);
                        break;
                }
            }
        }

        private void OnStartEdit(object sender, RowColEventArgs e)
        {
            if (sender is not C1FlexGrid grid) return;
            if (!e.Cancel) return;
            if (e.Col < 0 || e.Col >= grid.Cols.Count) return;

            if (!_editableColumnsByGrid.TryGetValue(grid, out var columns)) return;

            var colName = grid.Cols[e.Col].Name;
            if (!columns.Contains(colName)) return;

            e.Cancel = false;

            grid.BeginInvoke(new Action(() =>
            {
                if (grid.IsDisposed) return;
                if (grid.Editor is TextBox tb)
                    tb.SelectAll();
            }));
        }

        private void OnGridDisposed(object sender, EventArgs e)
        {
            if (sender is not C1FlexGrid grid) return;
            _editableColumnsByGrid.Remove(grid);
            grid.Disposed -= OnGridDisposed;
            grid.StartEdit -= OnStartEdit;
        }

        private Column FindColumn(C1FlexGrid grid, string name)
        {
            foreach (Column col in grid.Cols)
                if (col.Name == name) return col;
            return null;
        }

    }
}

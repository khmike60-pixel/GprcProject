using C1.Win.FlexGrid;
using GrpcCommonNet.Library.Common;
using GrpcWinForms.Controls.UserPermissionsUI.Models;
using SmartLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Controls.UserPermissionsUI.Views.Components
{
    public partial class RoleRightsGrid : UserControl
    {
        public SmartGrid Grid => _rightsGrid;

        public RoleRightTreeModel CurrentModel => _rightsGrid.GetCurrentObj<RoleRightTreeModel>();


        public RoleRightsGrid()
        {
            InitializeComponent();

            _rightsGrid.Cols["Value"].Editor = _rightValuesCombo;
            _rightValuesCombo.Visible = false;
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

        }

        public void SetRightValuesData(List<RightValueValue> items)
        {
            _rightValuesCombo.Items.Clear();

            _rightValuesCombo.ItemsDataSource = items;

            _rightValuesCombo.ItemsDisplayMember = "Name";
            _rightValuesCombo.ItemsValueMember = "Value";
        }

        public void SetRightsData(IEnumerable<RoleRightTreeModel> data, RoleRightTreeModel selectedModel = null)
        {
            _rightsGrid.BeginUpdate();
            {
                _rightsGrid.BuildTree(data);

                var nullStyle = _rightsGrid.Styles.Add("null");
                nullStyle.DataType = typeof(string);
                nullStyle.Display = DisplayEnum.None;

                for (int row = _rightsGrid.Rows.Fixed; row < _rightsGrid.Rows.Count; ++row)
                {
                    var canCheckOrApprove = _rightsGrid[row, "CheckAndApproveEnable"];
                    if (canCheckOrApprove != null && (bool)canCheckOrApprove == false)
                    {
                        var checkCell = _rightsGrid.GetCellRange(row, 2);
                        var approveCell = _rightsGrid.GetCellRange(row, 3);

                        checkCell.Style = nullStyle;
                        approveCell.Style = nullStyle;
                    }
                }
            }
            _rightsGrid.EndUpdate();

        }
    }
}

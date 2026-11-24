using C1.Win.Command;
using C1.Win.FlexGrid;
using GrpcCommonNet.Library.Common;
using GrpcWinForms.Controls.UserPermissionsUI.Models;
using GrpcWinForms.Controls.UserPermissionsUI.Views.Components;
using GrpcWinForms.Controls.UserPermissionsUI.Views.Interfaces;
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

namespace GrpcWinForms.Controls.UserPermissionsUI.Views.Forms
{
    public partial class RolesManagerForm : Form, IRolesManagerView
    {
        public RolesManagerViewMode ViewMode { get; private set; }

        private List<RightValueValue> _rightValues = null;


        public event Action OnLoad;
        public event Action OnAddRole;
        public event Action<int> OnDuplicateRole;
        public event Action<RoleModel> OnEditRole;
        public event Action<RoleModel> OnDeleteRole;
        public event Action<RoleModel> OnRefreshRoles;
        public event Action<RoleRightTreeModel> OnRefreshRoleRights;
        public event Action OnRoleSelChange;
        public event Action<int, RoleRightTreeModel, int> OnEditRoleRight;
        public PermissionManager.PermissionManager PermissionManager { get; private set; }

        /// <summary> Вернет true если текущая позиция таблице ролей находится на валидной записи. </summary>
        private bool _isRoleModelSelected => RolesGrid.DataSource != null && RolesGrid.Row > 0;

        /// <summary> Возвращает текущую выбранную модель роли из таблицы ролей, или null в противном случае. </summary>
        private RoleModel _currentRoleModel =>
            _isRoleModelSelected ? RolesGrid.Rows[RolesGrid.Row].Node.Key as RoleModel : null;

        /// <summary> Возвращает ID модели выбранной роли, или -1 в противном случае. </summary>
        public int CurrentRoleModelId
        {
            get
            {
                var selectedRole = _currentRoleModel;
                return selectedRole != null ? selectedRole.Id : -1;
            }
        }

        public RolesManagerForm(string tagName, RolesManagerViewMode viewMode = RolesManagerViewMode.Default)
        {
            ViewMode = viewMode;

            InitializeComponent();
            InitializeViewMode();

            PermissionManager = new PermissionManager.PermissionManager(this);

            // Role rights grid configuration.
            _roleRightsGrid.Grid.StartEdit += _roleRightsGrid_OnStartEdit;
            _roleRightsGrid.Grid.BeforeEdit += _roleRightsGrid_OnBeforeEdit;
            _roleRightsGrid.Grid.AfterEdit += _roleRightsGrid_OnAfterEdit;

            this.Tag = "{\"name\": \"" + tagName + "\"}";
            AddRole.Tag = "{\"name\": \"" + tagName + "\"}";
            DuplicateRole.Tag = "{\"name\": \"" + tagName + "\"}";
            DeleteRole.Tag = "{\"name\": \"" + tagName + "\"}";
            ApproveRole.Tag = "{\"name\": \"" + tagName + "\", \"canApprove\": true}";
            CheckRole.Tag = "{\"name\": \"" + tagName + "\", \"canCheck\": true}";
        }

        private void InitializeViewMode()
        {
            if (ViewMode == RolesManagerViewMode.SelectRole)
            {
                RolesGrid.AllowEditing = false;

                // Disable right objects view.
                c1SplitterPanel2.Collapsible = false;
                c1SplitterPanel2.Enabled = false;
                c1SplitterPanel2.Visible = false;

                // Disable command links
                foreach (ToolStripButton button in tsRoles.Items)
                {
                    if (button.Name != "RefreshRoles")
                        button.Enabled = false;
                }
            }
        }

        public DialogResult ShowAsDialog() =>
            this.ShowDialog();

        public void RefreshRolesData(IEnumerable<RoleModel> data, RoleModel selectedModel = null)
        {
            RolesGrid.BeginUpdate();
            RolesGrid.DataSource = data;
            RolesGrid.EndUpdate();

            //if (selectedModel != null)
            //    RolesGrid.Row = RolesGrid.FindModel(selectedModel);
        }

        public void RefreshRoleRightsData(IEnumerable<RoleRightTreeModel> data, RoleRightTreeModel selectedModel = null) =>
            _roleRightsGrid.SetRightsData(data, selectedModel);

        public void InitializeRightValues(List<RightValueValue> data)
        {
            _rightValues = data;
            _roleRightsGrid.SetRightValuesData(_rightValues);
        }

        #region Form events
        private void RolesManagerForm_Load(object sender, EventArgs e)
        {
            PermissionManager.Initialize();
            OnLoad?.Invoke();
        }

        private void AddRole_Click(object sender, EventArgs e) =>
            OnAddRole?.Invoke();

        private void DuplicateRole_Click(object sender, EventArgs e)
        {
            if (_isRoleModelSelected)
                OnDuplicateRole?.Invoke(_currentRoleModel.Id);
        }

        private void DeleteRole_Click(object sender, EventArgs e)
        {
            if (_isRoleModelSelected)
                OnDeleteRole?.Invoke(GetModelRow(RolesGrid, RolesGrid.Row));
        }

        private void RefreshRoles_Click(object sender, EventArgs e) =>
            OnRefreshRoles?.Invoke(_currentRoleModel);

        private void RefreshRoleRights_Click(object sender, ClickEventArgs e) =>
            OnRefreshRoleRights?.Invoke(_roleRightsGrid.CurrentModel);

        private void ApproveRole_Click(object sender, EventArgs e)
        {
            var newRole = _currentRoleModel;
            newRole.IsApproved = !_currentRoleModel.IsApproved;
            OnEditRole?.Invoke(newRole);
        }

        private void CheckRole_Click(object sender, EventArgs e)
        {
            if (_currentRoleModel.IsApproved)
            {
                MessageBox.Show("Роль уже утверждена!", "Ошибка редактирования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newRole = _currentRoleModel;
            newRole.IsChecked = !_currentRoleModel.IsChecked;
            OnEditRole?.Invoke(newRole);
        }

        private void RolesGrid_SelChange(object sender, EventArgs e) =>
            OnRoleSelChange?.Invoke();

        private void RolesGrid_StartEdit(object sender, RowColEventArgs e)
        {
            // Почему проверка происходит здесь а не в BeforeEdit?
            // Потому что BeforeEdit вызывается не только при пользовательском редактировании, но и при рендеринге.
            // Remarks:
            // This event doesn't fire only when the grid is about to enter edit mode.
            // It also fires while painting cells, in order to support drawing the editor's drop-down buttons.
            // The C1FlexGridBase.StartEdit event fires only when the grid is about to enter edit mode.

            if (_currentRoleModel.IsApproved || _currentRoleModel.IsChecked)
            {
                MessageBox.Show("Роль проверена или утверждена!", "Ошибка редактирования",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void RolesGrid_AfterEdit(object sender, RowColEventArgs e)
        {
            OnEditRole?.Invoke(_currentRoleModel);
        }

        private void RolesGrid_DoubleClick(object sender, EventArgs e)
        {
            if (ViewMode == RolesManagerViewMode.SelectRole && _isRoleModelSelected)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void _roleRightsGrid_OnStartEdit(object sender, RowColEventArgs e)
        {
            // Почему проверка происходит здесь а не в BeforeEdit?
            // Потому что BeforeEdit вызывается не только при пользовательском редактировании, но и при рендеринге.
            // Remarks:
            // This event doesn't fire only when the grid is about to enter edit mode.
            // It also fires while painting cells, in order to support drawing the editor's drop-down buttons.
            // The C1FlexGridBase.StartEdit event fires only when the grid is about to enter edit mode.

            if (_currentRoleModel.IsApproved || _currentRoleModel.IsChecked)
            {
                MessageBox.Show("Роль проверена или утверждена!", "Ошибка редактирования",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void _roleRightsGrid_OnBeforeEdit(object sender, RowColEventArgs e)
        {
            var currentNode = _roleRightsGrid.Grid.Rows[_roleRightsGrid.Grid.Row].Node;
            if (currentNode == null || currentNode.Key == null || currentNode.Parent == null)
            {
                e.Cancel = true;
                return;
            }

            var canCheckOrApprove = _roleRightsGrid.Grid[e.Row, "CheckAndApproveEnable"];
            if (canCheckOrApprove != null && (bool)canCheckOrApprove == false && (e.Col == 2 || e.Col == 3))
                e.Cancel = true;
        }

        private void _roleRightsGrid_OnAfterEdit(object sender, RowColEventArgs e)
        {
            var currentModel = _roleRightsGrid.CurrentModel;

            currentModel.CheckValue = Convert.ToBoolean(_roleRightsGrid.Grid[e.Row, "CheckValue"]);
            currentModel.ApproveValue = Convert.ToBoolean(_roleRightsGrid.Grid[e.Row, "ApproveValue"]);


            var rightValueRow = _rightValues.First(row => Convert.ToInt32(row.Value).ToString() == _roleRightsGrid.Grid[e.Row, "Value"].ToString());

            int rightValue = Convert.ToInt32(rightValueRow.Value);

            OnEditRoleRight?.Invoke(CurrentRoleModelId, currentModel, rightValue);
        }
        #endregion

        private RoleModel GetModelRow(SmartGrid grid, int row)
        {
            return grid.Rows[row].Node.Key as RoleModel;
        }

    }
}

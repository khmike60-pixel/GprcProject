using GrpcCommonNet.Library.Common;
using GrpcWinForms.Controls.UserPermissionsUI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.UserPermissionsUI.Views.Interfaces
{
    /// <summary> Режим, в котором будет работать форма ролей. </summary>
    public enum RolesManagerViewMode
    {
        /// <summary> Обычный режим. </summary>
        Default,
        /// <summary> Режим выбора роли. </summary>
        SelectRole
    }

    public interface IRolesManagerView
    {
        RolesManagerViewMode ViewMode { get; }

        event Action OnLoad;
        event Action OnAddRole;
        event Action<RoleModel> OnEditRole;
        event Action<int> OnDuplicateRole;
        event Action<RoleModel> OnDeleteRole;
        event Action<RoleModel> OnRefreshRoles;
        event Action<RoleRightTreeModel> OnRefreshRoleRights;
        event Action OnRoleSelChange;
        event Action<int, RoleRightTreeModel, int> OnEditRoleRight;

        /// <summary>
        /// Возвращает ID модели роли, на которой стоит позиция в гриде. Вернет -1 если нет выбранной роли.
        /// </summary>
        int CurrentRoleModelId { get; }

        void InitializeRightValues(List<RightValueValue> data);
        void Show();
        DialogResult ShowAsDialog();
        void RefreshRolesData(IEnumerable<RoleModel> data, RoleModel selectedModel = null);
        void RefreshRoleRightsData(IEnumerable<RoleRightTreeModel> data, RoleRightTreeModel selectedModel = null);
    }
}

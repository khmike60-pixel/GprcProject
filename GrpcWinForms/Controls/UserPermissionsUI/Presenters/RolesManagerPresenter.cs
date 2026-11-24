using GrpcWinForms.Controls.UserPermissionsUI.Models;
using GrpcWinForms.Controls.UserPermissionsUI.Services.Interfaces;
using GrpcWinForms.Controls.UserPermissionsUI.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.UserPermissionsUI.Presenters
{
    public class RolesManagerPresenter
    {
        private IRolesManagerView _view;
        private IRolesService _rolesService;
        private IRolesManagerService _rolesManagerService;

        public RolesManagerPresenter(IRolesManagerView view, IRolesService rolesService, IRolesManagerService rolesManagerService)
        {
            _view = view;
            _view.OnLoad += View_OnLoad;
            _view.OnAddRole += View_OnAddRole;
            _view.OnEditRole += View_OnEditRole;
            _view.OnDuplicateRole += View_OnDuplicateRole;
            _view.OnDeleteRole += View_OnDeleteRole;
            _view.OnRefreshRoles += View_RefreshRolesData;
            _view.OnRefreshRoleRights += View_RefreshRoleRightsData;
            _view.OnRoleSelChange += View_OnRoleSelChange;
            _view.OnEditRoleRight += View_OnEditRoleRight;

            _rolesService = rolesService;
            _rolesManagerService = rolesManagerService;
        }

        public void ShowView() =>
            _view.Show();

        public DialogResult ShowViewAsDialog() =>
            _view.ShowAsDialog();

        private async void View_RefreshRolesData(RoleModel selectedModel = null) =>
            _view.RefreshRolesData(await  _rolesService.Get(), selectedModel);

        private void View_RefreshRoleRightsData(RoleRightTreeModel selectedModel = null)
        {
            var currentRoleId = _view.CurrentRoleModelId;
            if (currentRoleId != -1)
                _view.RefreshRoleRightsData(_rolesManagerService.GetRights(currentRoleId), selectedModel);
            else
                _view.RefreshRoleRightsData(new List<RoleRightTreeModel>());
        }

        private void View_OnLoad()
        {
            _view.InitializeRightValues(_rolesManagerService.GetRightValues());

            View_RefreshRolesData();
            View_RefreshRoleRightsData();
        }

        private async void View_OnAddRole() =>
            View_RefreshRolesData(await _rolesService.Add());

        private void View_OnEditRole(RoleModel role)
        {
            if (_rolesService.IsNameExists(role.Name, role.Id))
                MessageBox.Show("Роль с таким именем уже существует!", "Ошибка редактирования",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (role.IsDefault && _rolesService.IsDefaultRoleExists(role.Id))
                MessageBox.Show("Роль по умолчанию уже существует. В системе может быть только одна роль по умолчанию!",
                    "Ошибка редактирования", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                _rolesService.Edit(role);

            View_RefreshRolesData(role);
        }

        private async void View_OnDuplicateRole(int roleId) =>
            View_RefreshRolesData(await _rolesService.Duplicate(roleId));

        private void View_OnDeleteRole(RoleModel role)
        {
            if (MessageBox.Show("Вы действительно хотите удалить роль?", "Подтвердить удаление",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;

            if (!_rolesService.CanDeleteRole(role.Id))
            {
                MessageBox.Show("Роль не может быть удалена, потому что она проверена или утверждена!",
                    "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _rolesService.Delete(role);
            View_RefreshRolesData();
        }

        private void View_OnRoleSelChange() =>
            View_RefreshRoleRightsData();

        private void View_OnEditRoleRight(int roleId, RoleRightTreeModel model, int value)
        {
            if ((model.CheckValue || model.ApproveValue) && !model.CheckAndApproveEnable)
                MessageBox.Show("Указанный объект права не может иметь право на проверку/утверждение!",
                    "Ошибка редактирования", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                _rolesManagerService.EditRoleRight(roleId, model, value);

            View_RefreshRoleRightsData(model);
        }

    }
}

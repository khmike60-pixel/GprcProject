using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contract;
using GrpcCommonNet.Library.Permission;
using GrpcWinForms.Controls.UserPermissionsUI.Models;
using GrpcWinForms.Controls.UserPermissionsUI.Services.Interfaces;
using GrpcWinForms.GrpcUtils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.UserPermissionsUI.Services.Implementaions
{
    public class RolesService : IRolesService
    {
        private readonly string _sourceDbName;

        private readonly string _func_IsRoleExists = "IsRoleExists"; // Возвращает true если роль с указанным именем уже существует.
        private readonly string _func_IsDefaultRoleExists = "IsDefaultRoleExists"; // Возвращает true если роль по умолчанию существует.
        private readonly string _func_CanDelteRole = "CanDeleteRole";
        private readonly string _proc_GetRoles = "GetRoles"; // Возвращает список всех ролей.
        private readonly string _proc_Add = "AddNewRole"; // Добавление новой роли.
        private readonly string _proc_Edit = "EditRole"; // Редактирование роли.
        private readonly string _proc_Delete = "DeleteRole"; // Удаление роли.
        private readonly string _proc_CopyRights = "CopyRoleRights"; // Копирует права указанной роли источника в роль назначения.

        public RolesService(string sourceDbName)
        {

            _sourceDbName = sourceDbName;
        }

        /// <summary> Возвращает список всех ролей. </summary>
        public async Task<IEnumerable<RoleModel>>  Get()
        {
            GetRolesRequest request = new GetRolesRequest() { DbName = _sourceDbName };
            GetRolesResponse response = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Permission.GetRolesAsync(request));

            List<RoleModel> roles = new();
            foreach (var role in response.Roles)
            {
                roles.Add(new RoleModel {
                    Id = role.Id,
                    Name = role.Name,
                    IsDefault = role.Default,
                    IsChecked = role.Checked,
                    CheckedBy = role.CheckBy,
                    IsApproved = role.Approved,
                    ApprovedBy = role.ApproveBy
                });
            }
            return roles;
        }


        /// <summary>
        /// Добавление новой роли с пустым именем.
        /// </summary>
        /// <returns>Добавленная модель, или null в случае неудачи.</returns>
        public async Task<RoleModel> Add()
        {
            RoleRequest request = new RoleRequest
            {
                DbName = _sourceDbName,
                Role = new Role()
                {
                    Name = GenerateUniqueRoleName()
                }
            };
            RoleResponse response = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Permission.AddRoleAsync(request));
            RoleModel role = new()
            {
                Id = response.Role.Id,
                Name = response.Role.Name,
                IsDefault = response.Role.Default,
                IsChecked = response.Role.Checked,
                IsApproved = response.Role.Approved,
                CheckedBy = response.Role.CheckBy,
                ApprovedBy= response.Role.ApproveBy
            };
            return role;
        }

        /// <summary> Редактирование роли. </summary>
        public async Task<RoleModel> Edit(RoleModel role)
        {
            RoleRequest request = new RoleRequest();
            request.DbName = _sourceDbName;
            request.Role = new Role()
            {
                Id = role.Id,
                Name = role.Name,
                Default = role.IsDefault,
                Checked = role.IsChecked,
                CheckBy = role.CheckedBy,
                Approved = role.IsApproved,
                ApproveBy = role.ApprovedBy
            };
            
            RoleResponse response = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Permission.AddRoleAsync(request));
            RoleModel edit_role = new()
            {
                Id = response.Role.Id,
                Name = response.Role.Name,
                IsDefault = response.Role.Default,
                IsChecked = response.Role.Checked,
                IsApproved = response.Role.Approved,
                CheckedBy = response.Role.CheckBy,
                ApprovedBy = response.Role.ApproveBy
            };
            return edit_role;
        }

        /// <summary> Удаление указанной роли. </summary>
        public async Task<List<int>> Delete(RoleModel role)
        {
            List<int> undeleted = new List<int>();

            DeleteRoleRequest request = new DeleteRoleRequest();
            request.DbName = _sourceDbName;
            request.Ids.Add(role.Id);

            UndeleteRoleResponse response = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Permission.DeleteRoleAsync(request));

            if (response.Result.Status == Status.Ok)
                undeleted.AddRange(response.UndeletedIds);
            return undeleted;
        }

        /// <summary> Дублирование существующей роли. </summary>
        public async Task<RoleModel> Duplicate(int roleId)
        {
            RoleModel newRole = new();
            newRole = await Add();

            Role sourceRole = new() { Id = roleId };
            Role destinationRole = new() { Id = newRole.Id };

            DuplicateRoleRequest request = new DuplicateRoleRequest()
            {
                SourceRole = sourceRole,
                DestinationRole = destinationRole
            };
            RoleResponse response = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Permission.DuplicateRoleAsync(request));
            if (response.Result.Status == Status.Ok)
            {
                newRole.Id = response.Role.Id;
                newRole.Name = response.Role.Name;
                newRole.IsDefault = response.Role.Default;
                newRole.IsChecked = response.Role.Checked;
                newRole.CheckedBy = response.Role.CheckBy;
                newRole.IsApproved = response.Role.Approved;
                newRole.ApprovedBy = response.Role.ApproveBy;
            };

            return newRole;
        }

        /// <summary> Проверка имени роли на существование. </summary>
        /// <param name="name">Имя для проверки.</param>
        /// <param name="excludeId">ID записи для исключения. -1 для игнорирования</param>
        /// <returns>true если существует</returns>
        public bool IsNameExists(string name, int excludeId = -1) =>
            (bool)CallService.GetValueFromFunc(
                $"{_sourceDbName}.{_func_IsRoleExists}",
                new Dictionary<string, object>()
                {
                    { "_Name", name },
                    { "_ExcludeId", excludeId }
                });


        /// <summary> Проверка на сущетсования роли по умолчанию. </summary>
        /// <param name="excludeId">ID записи для исключения. -1 для игнорирования</param>
        /// <returns>true если существует.</returns>
        public bool IsDefaultRoleExists(int excludeId = -1) =>
            (bool)CallService.GetValueFromFunc(
                $"{_sourceDbName}.{_func_IsDefaultRoleExists}",
                new Dictionary<string, object>()
                {
                    { "_ExcludeId", excludeId }
                });

        public bool CanDeleteRole(int id) =>
            (bool)CallService.GetValueFromFunc(
                $"{_sourceDbName}.{_func_CanDelteRole}",
                new Dictionary<string, object>()
                {
                    { "_Id", id }
                });

        private string GenerateUniqueRoleName()
        {
            for (int cx = 1; cx < 2048; cx++)
            {
                string roleName = string.Format("Новая роль {0}", cx);
                if (!IsNameExists(roleName))
                    return roleName;
            }

            return String.Empty;
        }

    }
}

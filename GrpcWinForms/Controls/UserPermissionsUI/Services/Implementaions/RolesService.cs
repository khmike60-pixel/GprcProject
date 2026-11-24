using GrpcWinForms.Controls.UserPermissionsUI.Models;
using GrpcWinForms.Controls.UserPermissionsUI.Services.Interfaces;
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
        public IEnumerable<RoleModel> Get()
        {
            var rolesTable = CallService.CallProcedureDT(
                $"{_sourceDbName}.{_proc_GetRoles}",
                new Dictionary<string, object>());

            return rolesTable.AsEnumerable().Select(r => _roleMapper.Map(r));
        }

        /// <summary>
        /// Добавление новой роли с пустым именем.
        /// </summary>
        /// <returns>Добавленная модель, или null в случае неудачи.</returns>
        public RoleModel Add()
        {
            var newRole = CallService.CallProcedureDT(
                $"{_sourceDbName}.{_proc_Add}",
                new Dictionary<string, object>()
                {
                    { "_Name", GenerateUniqueRoleName() }
                });

            return _roleMapper.Map(newRole.AsEnumerable().First());
        }

        /// <summary> Редактирование роли. </summary>
        public void Edit(RoleModel role)
        {
            CallService.CallProcedureNonQuery(
                $"{_sourceDbName}.{_proc_Edit}",
                new Dictionary<string, object>()
                {
                    { "_Id", role.Id },
                    { "_Name", role.Name },
                    { "_IsDefault", role.IsDefault },
                    { "_IsChecked", role.IsChecked },
                    { "_IsApproved", role.IsApproved },
                    { "_UserId", CallService.UserInfo.UserId }
                }, out string _error);

            if (_error.Length > 0)
                throw new ApplicationException(_error);
        }

        /// <summary> Удаление указанной роли. </summary>
        public void Delete(RoleModel role)
        {
            CallService.CallProcedureNonQuery(
                $"{_sourceDbName}.{_proc_Delete}",
                new Dictionary<string, object>()
                {
                    { "_Id", role.Id }
                }, out string _error);

            if (_error.Length > 0)
                throw new ApplicationException(_error);
        }

        /// <summary> Дублирование существующей роли. </summary>
        public RoleModel Duplicate(int roleId)
        {
            var newRole = Add();

            CallService.CallProcedureNonQuery(
                $"{_sourceDbName}.{_proc_CopyRights}",
                new Dictionary<string, object>()
                {
                    { "_SourceId", roleId },
                    { "_DestId", newRole.Id }
                }, out string _error);

            if (_error.Length > 0)
                throw new ApplicationException(_error);

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

using GrpcWinForms.Controls.UserPermissionsUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.UserPermissionsUI.Services.Interfaces
{
    public interface IRolesService
    {
        /// <summary> Возвращает список всех ролей. </summary>
        IEnumerable<RoleModel> Get();

        /// <summary>
        /// Добавление новой роли с пустым именем.
        /// </summary>
        /// <returns>Добавленная модель, или null в случае неудачи.</returns>
        RoleModel Add();

        /// <summary> Редактирование роли. </summary>
        void Edit(RoleModel role);

        /// <summary> Удаление указанной роли. </summary>
        void Delete(RoleModel role);

        /// <summary> Дублирование существующей роли. </summary>
        RoleModel Duplicate(int roleId);

        /// <summary> Проверка имени роли на существование. </summary>
        /// <param name="name">Имя для проверки.</param>
        /// <param name="excludeId">ID записи для исключения. -1 для игнорирования</param>
        /// <returns>true если существует</returns>
        bool IsNameExists(string name, int excludeId = -1);

        /// <summary> Проверка на сущетсования роли по умолчанию. </summary>
        /// <param name="excludeId">ID записи для исключения. -1 для игнорирования</param>
        /// <returns>true если существует.</returns>
        bool IsDefaultRoleExists(int excludeId = -1);

        bool CanDeleteRole(int id);
    }
}

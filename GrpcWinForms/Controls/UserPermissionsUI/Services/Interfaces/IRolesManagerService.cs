using GrpcCommonNet.Library.Common;
using GrpcWinForms.Controls.UserPermissionsUI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.UserPermissionsUI.Services.Interfaces
{
    public interface IRolesManagerService
    {
        /// <summary>
        /// Возвращает список прав конкретной роли.
        /// </summary>
        /// <param name="roleId">ID роли.</param>
        IEnumerable<RoleRightTreeModel> GetRights(int roleId);

        /// <summary>
        /// Возращает список возможных значений для любого права. 
        /// TODO: перенести в отдельный сервис.
        /// </summary>
        List<RightValueValue> GetRightValues();

        /// <summary>
        /// Редактирования прав роли.
        /// </summary>
        /// <param name="roleId">ID роли.</param>
        /// <param name="model">Модель для редактирования</param>
        /// <param name="value">Одно из значений возвращаемый методом GetRightValues.</param>
        void EditRoleRight(int roleId, RoleRightTreeModel model, int value);
    }
}

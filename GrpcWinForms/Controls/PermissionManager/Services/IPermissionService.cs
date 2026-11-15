using GrpcCommonNet.Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.PermissionManager.Services
{
    internal interface IPermissionService
    {
        /// <summary> Получение прав на указанный объект. </summary>
        /// <param name="name"> Имя объекта. </param>
        Permission GetPermission(string name);
    }
}

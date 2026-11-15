using GrpcCommonNet.Library.Permission;
using GrpcWinForms.Controls.PermissionManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.PermissionManager.Initializers
{
    internal interface IFormInitializer
    {
        IPermissionService PermissionService { get; set; }

        /// <summary> Иинциализация формы. </summary>
        /// <param name="form"> Ссылка на форму для инициализации. </param>
        /// <exception cref="FormNoAccessException"> Если на форму нет прав. </exception>
        void InitializeForm(Form form);
    }
}

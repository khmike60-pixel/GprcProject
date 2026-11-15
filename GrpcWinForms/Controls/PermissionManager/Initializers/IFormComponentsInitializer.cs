using GrpcWinForms.Controls.PermissionManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.PermissionManager.Initializers
{
    internal interface IFormComponentsInitializer
    {
        IPermissionService PermissionService { get; set; }

        /// <summary> Инициализация списка компонентов и их потомков. </summary>
        /// <remarks> В случае какой-либо ошибки, форма будет закрыта </remarks>
        /// <param name="form"> Ссылка на форму для инициализации. </param>
        void InitializeComponents(Form form);
    }
}

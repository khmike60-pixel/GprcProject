using GrpcCommonNet.Library.Common;
using GrpcWinForms.Controls.PermissionManager.Exceptions;
using GrpcWinForms.Controls.PermissionManager.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.PermissionManager.Initializers
{
    internal class FormInitializer : IFormInitializer
    {
        public IPermissionService PermissionService { get; set; }

        public FormInitializer(IPermissionService permissionService)
        {
            PermissionService = permissionService;
        }

        /// <summary> Иинциализация формы. </summary>
        /// <param name="form"> Ссылка на форму для инициализации. </param>
        /// <exception cref="FormNoAccessException"> Если на форму нет прав. </exception>
        public void InitializeForm(Form form)
        {
            if (!GlobalConfig.Enabled || string.IsNullOrEmpty(form.Tag?.ToString()))
                return;

            try
            {
                var permissionMetaData = JsonConvert.DeserializeObject<PermissionMetaData>(form.Tag?.ToString());
                if (string.IsNullOrEmpty(permissionMetaData.Name))
                    return;

                var permission = PermissionService.GetPermission(permissionMetaData.Name);
                if (permission == null)
                    throw new FormTagNotFound();

                if (!permission.IsAdmin && permission.Value == PermissionValue.None)
                    throw new FormNoAccessException();
            }
            catch
            {
                throw new FormNoAccessException();
            }
        }
    }
}

using GrpcCommonNet.Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.PermissionManager.PermissionHandler
{
    internal class ButtonPermissionHandler : BasePermissionHandler
    {
        /// <summary> Инциализация прав на указанный компонент. </summary>
        /// <param name="component"> Компонент для инициализации. </param>
        /// <param name="permission"> Права. </param>
        /// <param name="permissionMetaData"> Мета-данные прав компонента. </param>
        public override void SetupComponentPermission(object component, Permission permission, PermissionMetaData permissionMetaData)
        {
            PropertyInfo componentProperty = component.GetType().GetProperty("Enabled");
            if (componentProperty != null)
            {
                var enabled = false;

                RemoveAllDisableEvents(component);
                {
                    if (permissionMetaData.CanCheck != null || permissionMetaData.CanApprove != null)
                        enabled = permissionMetaData.CanCheck != null && (bool)permissionMetaData.CanCheck && permission.CanCheck ||
                                  permissionMetaData.CanApprove != null && (bool)permissionMetaData.CanApprove && permission.CanApprove;
                    else
                        enabled = permission.Value >= PermissionValue.Edit;

                    componentProperty.SetValue(component, enabled);
                }
                if (!enabled) AddDisableEvents(component);
            }
        }
    }
}

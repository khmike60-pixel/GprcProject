using GrpcCommonNet.Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.PermissionManager.PermissionHandler
{
    internal class DefaultPermissionHandler : BasePermissionHandler
    {
        /// <summary> Инциализация прав на указанный компонент. </summary>
        /// <param name="component"> Компонент для инициализации. </param>
        /// <param name="permission"> Права. </param>
        /// <param name="permissionMetaData"> Мета-данные прав компонента. </param>
        public override void SetupComponentPermission(object component, Permission permission, PermissionMetaData permissionMetaData)
        {
            PropertyInfo componentProperty;
            bool enabled = permission.Value >= PermissionValue.Edit;

            RemoveAllDisableEvents(component);
            {
                if ((componentProperty = component.GetType().GetProperty("ReadOnly")) != null)
                    componentProperty.SetValue(component, enabled);
                else if ((componentProperty = component.GetType().GetProperty("Enabled")) != null)
                    componentProperty.SetValue(component, enabled);
            }
            if (!enabled) AddDisableEvents(component);
        }
    }
}

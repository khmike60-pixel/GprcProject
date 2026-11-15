using C1.Win.Command;
using GrpcCommonNet.Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.PermissionManager.PermissionHandler
{
    internal class CommandLinkPermissionHandler  : BasePermissionHandler
    {
        /// <summary> Инциализация прав на указанный компонент. </summary>
        /// <param name="component"> Компонент для инициализации. </param>
        /// <param name="permission"> Права. </param>
        /// <param name="permissionMetaData"> Мета-данные прав компонента. </param>
        public override void SetupComponentPermission(object component, Permission permission, PermissionMetaData permissionMetaData)
        {
            if (component is C1CommandLink commandLink)
            {
                var enabled = false;

                RemoveAllDisableEvents(commandLink.Command);
                {
                    if (permissionMetaData.CanCheck != null || permissionMetaData.CanApprove != null)
                        enabled = permissionMetaData.CanCheck != null && (bool)permissionMetaData.CanCheck && permission.CanCheck ||
                                  permissionMetaData.CanApprove != null && (bool)permissionMetaData.CanApprove && permission.CanApprove;
                    else
                        enabled = permission.Value >= PermissionValue.Edit;

                    commandLink.Command.Enabled = enabled;
                }
                if (!enabled) AddDisableEvents(commandLink.Command);
            }
        }
    }
}

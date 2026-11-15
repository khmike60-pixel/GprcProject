using C1.Win.Input;
using GrpcCommonNet.Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.PermissionManager.PermissionHandler
{
    internal class DropDownControlPermissionHandler : BasePermissionHandler
    {
        public override void SetupComponentPermission(object component, Permission permission, PermissionMetaData permissionMetaData)
        {
            if (component is C1DropDownControl dropDownControl)
            {
                bool enabled = permission.Value >= PermissionValue.Select;

                RemoveAllDisableEvents(component);
                {
                    dropDownControl.Enabled = permission.Value >= PermissionValue.Select;
                }
                if (!enabled) AddDisableEvents(component);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.PermissionManager
{
    internal class PermissionMetaData
    {
        public string Name { get; set; }
        public bool? CanCheck { get; set; }
        public bool? CanApprove { get; set; }
    }
}

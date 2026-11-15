using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.PermissionManager.Models
{
    internal class PermissionGridMetadata
    {
        public string? Name { get; set; }
        public List<string>? Columns { get; set; }
    }
}

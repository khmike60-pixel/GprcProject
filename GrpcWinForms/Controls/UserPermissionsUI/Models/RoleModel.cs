using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.UserPermissionsUI.Models
{
    public class RoleModel : IEquatable<object>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public bool IsChecked { get; set; }
        public bool IsApproved { get; set; }
        public string CheckedBy { get; set; }
        public string ApprovedBy { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            return Id == ((RoleModel)obj).Id;
        }
    }
}

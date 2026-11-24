using SmartLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.UserPermissionsUI.Models
{
    public class RoleRightTreeModel : ITreeData, IEquatable<object>
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool CheckValue { get; set; }
        public bool ApproveValue { get; set; }
        public bool CheckAndApproveEnable { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            return Id == ((RoleRightTreeModel)obj).Id;
        }
    }
}

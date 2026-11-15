using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartLib;

namespace GrpcWinForms.Objects.Rights.Models
{
    public class RightObjectTreeModel : ITreeData, IEquatable<object>
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool CheckAndApproveEnable { get; set; }

        public override bool Equals(object obj)
        {
            return obj == null || !(obj is RightObjectTreeModel)
                ? false
                : Id == ((RightObjectTreeModel)obj).Id;
        }
    }
}

using GrpcCommonNet.Library.Common;
using SmartLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Locations.Models
{
    public class TreeLocation : ITreeData
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }

    }
}

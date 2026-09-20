using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.DocumentTypes.Models
{
    public class TreeDocumentType : SmartLib.ITreeData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Form { get; set; }
        public int ParentId { get; set; }
        public Tree Parent { get; set; }
        public string ParentIds { get; set; }
        public string ParentNames { get; set; }
        public string ViewMaster { get; set; }
        public string ViewDetail { get; set; }
        public Struct Data { get; set; }
        public bool IsDefault { get; set; }
        public bool IsContract { get; set; }
        public int CurrencyType_Id { get; set; }
        public int CountryCurrency_Id { get; set; }
        public int KindId { get; set; }
    }
}

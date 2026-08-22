using GrpcCommonNet.Library.Common;
using SmartLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Contracts.Models
{
    public class TreeContract : ITreeData
    {
        public int Id { get ; set ; }  // node_id
        public int ParentId { get ; set ; } // parent_node_id
        public string Name { get; set; } // 
        public DateTime Date { get; set; }
        public int ContractId { get; set; }
        public DateTime ContractDate { get; set; }
        public string Number {  get; set; }
        public string Seller {  get; set; }
        public string Buyer { get; set; }
        public string Type { get; set; }
        public int TypeId { get; set; }
        public string TypeCode { get; set; }
        public string TypeForm { get; set; }
        public decimal Sum {  get; set; }
        public string Currency { get; set; }
        public decimal Paid { get; set; }
        public decimal Shipped { get; set; }
        public DateTime? DateExpiried {  get; set; }
    }
}

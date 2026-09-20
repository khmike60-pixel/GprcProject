using GrpcCommonNet.Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.SalePurchaseTypes.Models
{
    public class SalePurchaseGridRate
    {
        public int? Id {  get; set; }
        public DateTime Date { get; set; }
        public int Rate { get; set; }
        public Currency Currency { get; set; }

    }
}

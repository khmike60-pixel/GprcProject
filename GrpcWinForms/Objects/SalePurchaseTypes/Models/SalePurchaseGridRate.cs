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
        public string Status {  get; set; } 
        public DateTime Date { get; set; }
        public decimal CurrencyRate {  get; set; }
        public decimal RatePL { get; set; }
        public decimal RateConvert { get; set; }
    }
}

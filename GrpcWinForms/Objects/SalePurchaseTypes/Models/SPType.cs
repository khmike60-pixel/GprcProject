using GrpcCommonNet.Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.SalePurchaseTypes.Models
{
    public class SPType
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public Currency Currency { get; set; }
        public Geolocation Geolocation { get; set; }
        public Currency CurrencyMain { get; set; }
        public Currency CurrencySalary { get; set; }
        public Currency CurrencyCross { get; set; }
        public List<Currency> ListCurrencies { get; set; } = [];
        public bool Confirmed { get; set; }
        public MetaConfirm MetaConfirm { get; set; }

        public SPType() { }

    }

}

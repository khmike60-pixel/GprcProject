using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Locations.Models
{
    public class CountryLocation
    {
        public string Code2 { get; set; }
        public string Code3 { get; set; }
        public string CodeDigit { get; set; }
        public string PhoneCode { get; set; }

        public CountryLocation() { }

        public string ToString()
        {
            return  JsonSerializer.Serialize(this);
        }
    }
}

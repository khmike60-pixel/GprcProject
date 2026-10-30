using GrpcCommonNet.Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Stocks.Views
{
    public interface IStock
    {
        string NameStock { get; }
        int PlaceId { get; }
        public Stock Stock { get; set; }
    }
}

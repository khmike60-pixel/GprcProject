using GrpcCommonNet.Library.Common;
using GrpcWinForms.Objects.SalePurchaseTypes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.SalePurchaseTypes.Views
{
    public interface ISalePurchaseTypesView
    {
        BindingList<SalePurchaseType> SalePurchaseTypes { get; set; }
        BindingList<SalePurchaseGridRate> SalePurchaseGridRates { get; set; }

        SalePurchaseGridRate GetSelectedSalePurchaseRate();


    }
}

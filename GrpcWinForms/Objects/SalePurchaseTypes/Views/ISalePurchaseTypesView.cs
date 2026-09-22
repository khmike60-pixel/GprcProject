using GrpcCommonNet.Library.Common;
using GrpcWinForms.Objects.SalePurchaseTypes.Models;
using SmartLib;
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
        List<int> SelectedIds { get; set; }
        BindingList<SalePurchaseType> SalePurchaseTypes { get; set; }
        BindingList<Currency> Currencies {  get; set; }

        SmartGrid GridTypes { get; set; }
        SmartGrid GridCurrencies { get; set; }

    }
}

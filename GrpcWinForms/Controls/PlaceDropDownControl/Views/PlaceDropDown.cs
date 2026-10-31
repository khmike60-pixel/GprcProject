using C1.Win.Input;
using GrpcCommonNet.Library.Common;
using GrpcWinForms.Controls.PlaceDropDownControl.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.PlaceDropDownControl
{
    public partial class PlaceDropDown : C1DropDownControl, IPlaceDropDown
    {
        private Place _place;
        public Place SelectPlace { get => _place; set => _place = value; }

        public PlaceDropDown()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

        }

        public PlaceDropDown(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

        }

    }
}

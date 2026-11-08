using GrpcCommonNet.Library.Common;
using SmartLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Geolocations.Views.Interfaces
{
    public interface ILocations
    {
        bool DialogMode { get; set; }
        Location CurrentLocation { get; set; }
        BindingList<Location> Locations { get; set; }
        SmartGrid GridLocation { get; set; }

        LocationType Type { get; }
        string TextString {  get; }


    }
}

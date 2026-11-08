using GrpcCommonNet.Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GrpcWinForms.Objects.Locations.Views
{
    public interface ILocation
    {
        Location CurrentLocation { get; set; }

        LocationType Type { get; }
        Location LocationParent { get; }
        string LocationParentName { get; set; }
        string LocationTypeString { get; set; }
        string LocationName { get; set; }
        string LocationNameLat { get; set; }
        string LocationCode2 { get; set; }
        string LocationCode3 { get; set; }
        string LocationCodeDigit { get; set; }
        string LocationSOATO { get; set; }
        string LocationPhoneCode { get; set; }
    }
}

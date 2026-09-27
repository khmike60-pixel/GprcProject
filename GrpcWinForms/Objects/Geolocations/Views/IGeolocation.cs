using GrpcCommonNet.Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Geolocations.Views
{
    public interface IGeolocation
    {
        Geolocation Geolocation { get; set; }
        Geolocation GeoParentObject { get; set; }

        #region Поля формы
        
        string GeoName {  get; set; }
        string GeoNameLat {  get; set; }
        string GeoParentName {  get; set; }
        bool GeoIsCountry {  get; set; }
        string GeoCode2 {  get; set; }
        string GeoCode3 { get; set; }
        string GeoDigit {  get; set; }
        string GeoPhone {  get; set; }


        #endregion

        #region События, которые view только вызывает

        event Func<Geolocation, Task> OnClick_OkAsync;

        #endregion
    }
}

using GrpcCommonNet.Library.Common;
using GrpcWinForms.Objects.Currencies.Views;
using GrpcWinForms.Objects.Geolocations.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Geolocations.Presenters
{
    public class GeolocationPresenter
    {
        private readonly IGeolocation _view;

        public GeolocationPresenter(IGeolocation view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));

            // Подписываемся на события View
            _view.OnClick_OkAsync += HandleClick_OkAsync;
        }

        public async Task HandleClick_OkAsync(Geolocation geolocation)
        {
            _view.Geolocation.Name = _view.GeoName;
            _view.Geolocation.NameLat = _view.GeoNameLat;
            if (_view.Geolocation.Parent == null) _view.Geolocation.Parent = new Geolocation();
            _view.Geolocation.Parent.Id = _view.GeoParentObject.Id;
            _view.Geolocation.Parent.Name = _view.GeoParentObject.Name;
            _view.Geolocation.IsCountry = _view.GeoIsCountry ? 1 : 0;
            _view.Geolocation.Code2 = _view.GeoCode2;
            _view.Geolocation.PhoneCode = _view.GeoPhone;
            if (_view.Geolocation.IsCountry == 1)
                _view.Geolocation.CountryJson = new CountryJson()
                {
                    Code2 = _view.GeoCode2,
                    Code3 = _view.GeoCode3,
                    CodeDigit = _view.GeoDigit
                };
            else
                _view.Geolocation.RegionJson = new RegionJson()
                {
                    Code2 = _view.GeoCode2,
                    SOATO = _view.GeoCode3
                };

        }

    }
}

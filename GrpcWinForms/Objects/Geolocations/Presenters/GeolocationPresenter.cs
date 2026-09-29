using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Geolocation;
using GrpcWinForms.GrpcUtils;
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

        public async Task HandleClick_OkAsync()
        {
            Geolocation newGeo = new Geolocation();
            newGeo.Name = _view.GeoName;
            newGeo.NameLat = _view.GeoNameLat;
            if (_view.Geolocation.Parent == null) newGeo.Parent = new Geolocation();
            newGeo.Parent.Id = _view.GeoParentObject.Id;
            newGeo.Parent.Name = _view.GeoParentObject.Name;
            newGeo.IsCountry = _view.GeoIsCountry ? 1 : 0;
            newGeo.Code2 = _view.GeoCode2;
            newGeo.PhoneCode = _view.GeoPhone;
            if (newGeo.IsCountry == 1)
                newGeo.CountryJson = new CountryJson()
                {
                    Code2 = _view.GeoCode2,
                    Code3 = _view.GeoCode3,
                    CodeDigit = _view.GeoDigit
                };
            else
                newGeo.RegionJson = new RegionJson()
                {
                    Code2 = _view.GeoCode2,
                    SOATO = _view.GeoCode3
                };

            CreateGeoRequest request = new CreateGeoRequest() { Geolocation = newGeo };
            GeoResponse response = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Geolocation.CreateGeoAsync(request).ResponseAsync).ConfigureAwait(false);
            if (response.Result.Status == Status.Ok)
                _view.Geolocation = newGeo;
            else _view.Geolocation = null;

        }

    }
}

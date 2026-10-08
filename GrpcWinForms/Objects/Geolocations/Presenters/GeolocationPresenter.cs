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

        public bool HandleClick_OkAsync()
        {
            // Создаем новый объект Geolocation и заполняем его данными из View
            Geolocation newGeo = new Geolocation();
            newGeo.Name = _view.GeoName;
            newGeo.NameLat = _view.GeoNameLat;

            newGeo.Parent = new Geolocation()
            {
                Id = _view.Geolocation.Parent.Id,
                Name = _view.Geolocation.Parent.Name
            };

            newGeo.ParentId = _view.Geolocation.Parent.Id;
            newGeo.IsCountry = newGeo.Parent.Id == 0 ? 1 : 0;

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

            // Создаем или обновляем геолокацию в зависимости от режима редактирования
            if (_view.ModeEdit == ModeEdit.Add)
            {
                // Создаем новую геолокацию
                CreateGeoRequest request = new CreateGeoRequest() { Geolocation = newGeo };
                GeoResponse response = GrpcClients.GrpcClients.Geolocation.CreateGeo(request);
                if (response.Result.Status == Status.Ok)
                    newGeo = response.Geolocation;

                _view.Geolocation = newGeo;
            }
            else if (_view.ModeEdit == ModeEdit.Edit)
            {
                // Обновляем существующую геолокацию
                UpdateGeoRequest request = new UpdateGeoRequest() { Geolocation = newGeo };
                GeoResponse response = GrpcClients.GrpcClients.Geolocation.UpdateGeo(request);
                if (response.Result.Status == Status.Ok)
                    _view.Geolocation = newGeo;
                else _view.Geolocation = null;

            }
            return true;    
        }

    }
}

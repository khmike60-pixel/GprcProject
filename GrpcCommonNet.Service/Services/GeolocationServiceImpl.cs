using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Geolocation;
using GrpcCommonNet.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Result = GrpcCommonNet.Library.Common.Result;
using Status = GrpcCommonNet.Library.Common.Status;

[Authorize]
public class GeolocationServiceImpl : GeolocationServices.GeolocationServicesBase
{
    private readonly GeolocationRepository _repo;
    private readonly ILogger<GeolocationServiceImpl> _logger;

    public GeolocationServiceImpl(GeolocationRepository repo, ILogger<GeolocationServiceImpl> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    #region  Методы работы с Георафией (страны, города, районы)
    public override async Task<GeoResponse> GetGeo(GeoRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetGeo called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            GeoResponse response = new GeoResponse();
            response.Geolocation = new Geolocation();

            Geolocation? geo = await _repo.GetByIdAsync(request.Id);
            if (geo == null || geo.Id == 0) 
                return new GeoResponse { Result = new Result { Status = Status.NotFound} };
            if (request.FieldMask == null || request.FieldMask.Paths.Count == 0)
                response.Geolocation = geo;
            else
                request.FieldMask.Merge(geo, response.Geolocation);

            response.Result = new Result() { Status = Status.Ok };

            return response;
        }
        catch (Exception ex) {
            _logger.LogError(ex, ex.Message);
            return new GeoResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    public override async Task<TreeGeoResponse> GetTreeGeo(TreeGeoRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetTreeGeo called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        
        try
        {
            TreeGeoResponse response = new TreeGeoResponse();
            List<Geolocation> geo = await _repo.GetTreeGeoAsync(request.Id);
            if (geo == null) return new TreeGeoResponse { Result = new Result { Status = Status.NotFound} };

            if(request.FieldMask != null && request.FieldMask.Paths.Count > 0)
            {
                foreach (var item in geo)
                {
                    Geolocation maskedGeo = new Geolocation();
                    request.FieldMask.Merge(item, maskedGeo);
                    response.Geolocations.Add(maskedGeo);
                }
            }
            else
                response.Geolocations.AddRange(geo);
            response.Result = new Result { Status = Status.Ok };

            return response;
        }
        catch (Exception ex) {
            _logger.LogError(ex, ex.Message);
            return new TreeGeoResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    public override async Task<GeoResponse> CreateGeo(CreateGeoRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"CreateGeo called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            GeoResponse response = new GeoResponse();
            Geolocation geo = await _repo.CreateGelocationAsync(request.Geolocation);
            if (geo == null) return new GeoResponse { Result = new Result { Status = Status.NotFound } };
            response.Geolocation = geo;
            response.Result = new Result {  Status = Status.Ok };

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new GeoResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }

    }

    public override async Task<GeoResponse> UpdateGeo(UpdateGeoRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"UpdateGeoAsync called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            GeoResponse response = new GeoResponse();
            Geolocation geo = await _repo.UpdateGeolocationAsync(request.Geolocation);
            if (geo == null) return new GeoResponse { Result = new Result { Status = Status.NotFound } };
            response.Geolocation = geo;
            response.Result = new Result { Status = Status.Ok };

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new GeoResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }


    #endregion

}

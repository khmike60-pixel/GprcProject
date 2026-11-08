using Grpc.Core;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Location;
using GrpcCommonNet.Service.Models;
using GrpcCommonNet.Service.Repository;
using Status = GrpcCommonNet.Library.Common.Status;

namespace GrpcCommonNet.Service.Services
{
    public class LocationServiceImpl: LocationServices.LocationServicesBase
    {
        private readonly LocationRepository _repo;
        private readonly ILogger<LocationServiceImpl> _logger;

        public LocationServiceImpl(LocationRepository repo, ILogger<LocationServiceImpl> logger) 
        {
            _repo = repo;
            _logger = logger;

        }

        #region Методы работы с объединенными местами хранения (Location)

        public override async Task<LocationResponse> GetLocation(LocationRequest request, ServerCallContext context)
        {
            UserData userData = new UserData().GetUserData(context);
            _logger.LogDebug($"GetLocation called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

            try
            {
                LocationResponse response = new();

                Location location = await _repo.GetLocationAsync(request, userData);
                if (location == null || location.Id == 0) response.Result = new Result { Status = Status.NotFound };
                else response.Result = new Result { Status = Status.Ok };

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new LocationResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
            }
        }

        public override async Task<ListLocationResponse> GetListLocation(ListLocationRequest request, ServerCallContext context)
        {
            UserData userData = new UserData().GetUserData(context);
            _logger.LogDebug($"GetListLocation called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

            try
            {
                ListLocationResponse response = new();

                List<Location> locations = await _repo.ListLocationAsync(request, userData);
                if (locations == null || locations.Count == 0) response.Result = new Result { Status = Status.NotFound };
                else
                {
                    response.Locations.AddRange(locations); 
                    response.Result = new Result { Status = Status.Ok };
                }

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new ListLocationResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
            }

        }

        public override async Task<LocationResponse> UpdateLocation(UpdateLocationRequest request,   ServerCallContext context)
        {
            UserData userData = new UserData().GetUserData(context);
            _logger.LogDebug($"UpdateLocation called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

            try
            {
                LocationResponse response = new();
                Location location = await _repo.UpdateLocationAsync(request, userData);
                if(location  == null) response.Result = new Result { Status = Status.NotFound };
                else
                {
                    response.Location = location;
                    response.Result = new Result {Status = Status.Ok };
                }

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new LocationResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
            }
        }

        #endregion
    }
}

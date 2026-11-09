using Google.Protobuf;
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

        /// <summary>
        /// Получить локацию по Id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Получить список локаций по фильтру
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Обновить локацию. Возможно изменение имени, родителя или иных данных.
        /// Учитывается перестройка путей у вех дочених записей
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Создание новой локации и построение новых путей.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task<LocationResponse> CreateLocation(CreateLocationRequest request, ServerCallContext context)
        {
            UserData userData = new UserData().GetUserData(context);
            _logger.LogDebug($"CreateLocation called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

            try
            {
                LocationResponse response = new();
                Location location = await _repo.CreateLocationAsync(request, userData);
                if (location == null) response.Result = new Result { Status = Status.NotFound };
                else
                {
                    response.Location = location;
                    response.Result = new Result { Status = Status.Ok };
                }

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new LocationResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
            }
        }

        /// <summary>
        /// Удаление записей по списку.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task<UndeletedLocationResponse> DeleteLocation(DeleteLocationRequest request, ServerCallContext context)
        {
            UserData userData = new UserData().GetUserData(context);
            _logger.LogDebug($"CreateLocation called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

            try
            {
                UndeletedLocationResponse response = new();
                List<int> undeleted = new List<int>();
                undeleted = await _repo.DeleteLocationAsync(request, userData);
                if (undeleted == null || undeleted.Count == 0)
                {
                    response.Result = new Result { Status = Status.Ok};
                    response.Undeleted.AddRange(new List<int>());
                }
                else
                {
                    response.Result = new Result { Status = Status.BadRequest };
                    response.Undeleted.AddRange(undeleted);
                }

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new UndeletedLocationResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
            }

        }


        #endregion
    }
}

using Grpc.Core;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Location;
using GrpcCommonNet.Library.Permission;
using GrpcCommonNet.Service.Models;
using GrpcCommonNet.Service.Repository;
using Status = GrpcCommonNet.Library.Common.Status;

namespace GrpcCommonNet.Service.Services
{
    public class PermissionServiceImpl : PermissionServices.PermissionServicesBase
    {
        private readonly PermissionRepository _repo;
        private readonly ILogger<PermissionServiceImpl> _logger;

        public PermissionServiceImpl(PermissionRepository repo, ILogger<PermissionServiceImpl> logger)
        {
            _repo = repo;
            _logger = logger;

        }

        public override async Task<GetPermissionResponse> GetPermission(GetPermissionRequest request, ServerCallContext context)
        {
            UserData userData = new UserData().GetUserData(context);
            _logger.LogDebug($"GetLocation called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

            try
            {
                GetPermissionResponse response = new();

                Permission permission = await _repo.GetPermissionAsync(request, userData);

                if (permission == null) response.Result = new Result { Status = Status.NotFound };
                else response.Result = new Result { Status = Status.Ok };

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new GetPermissionResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };

            }
        }
    }
}

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
                else
                {
                    response.Permission = permission;
                    response.Result = new Result { Status = Status.Ok };
                }
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new GetPermissionResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };

            }
        }

        public override async Task<GetRightObjectsResponse> GetRightObjects(GetRightObjectsRequest request, ServerCallContext context)
        {
            UserData userData = new UserData().GetUserData(context);
            _logger.LogDebug($"GetRightObjects called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

            try
            {
                GetRightObjectsResponse response = new GetRightObjectsResponse();
                List<RightObject> rights = await _repo.GetRightObjectsAsync(request, userData);
                if (rights == null) response.Result = new Result { Status = Status.NotFound };
                else
                {
                    response.RightObjects.AddRange(rights);
                    response.Result = new Result {Status = Status.Ok };
                }
                return response;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new GetRightObjectsResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };

            }
        }

        public override async Task<RightObjectResponse> AddRightObject(RightObjectRequest request, ServerCallContext context)
        {
            UserData userData = new UserData().GetUserData(context);
            _logger.LogDebug($"AddRightObject called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

            try
            {
                RightObjectResponse response = new RightObjectResponse();
                RightObject right = await _repo.AddRightObjectAsync(request, userData);
                if (right == null) response.Result = new Result { Status = Status.NotFound };
                else
                {
                    response.RightObject = right;
                    response.Result = new Result { Status = Status.Ok };
                }
                return response;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new RightObjectResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };

            }
        }

        public override async Task<RightObjectResponse> EditRightObject(RightObjectRequest request, ServerCallContext context)
        {
            RightObjectResponse response = new RightObjectResponse();


            return response;
        }

        public override async Task<DeleteRightObjectResponse> DeleteRightObject(DeleteRightObjectRequest request, ServerCallContext context)
        {
            DeleteRightObjectResponse response = new DeleteRightObjectResponse();


            return response;
        }

        public override async Task<BoolResponse> MoveRightObject(MoveRightObjectRequest request, ServerCallContext context)
        {
            BoolResponse response = new BoolResponse();

            return response;
        }

        public override async Task<BoolResponse> IsRightObjectNameExists(IsRightObjectNameExistsRequest request, ServerCallContext context)
        {
            BoolResponse response = new BoolResponse();

            return response;
        }

        public override async Task<BoolResponse> IsRightObjectCodeExists(IsRightObjectCodeExistsRequest request, ServerCallContext context)
        {
            BoolResponse response = new BoolResponse();

            return response;
        }

        public override async Task<BoolResponse> IsRightObjectHasForeignKey(IsRightObjectHasForeignKeyRequest request, ServerCallContext context)
        {
            BoolResponse response = new BoolResponse();

            return response;
        }

        public override async Task<BoolResponse> IsRightObjectHasChilds(IsRightObjectHasChildsRequest request, ServerCallContext context)
        {
            BoolResponse response = new BoolResponse();

            return response;
        }





    }
}

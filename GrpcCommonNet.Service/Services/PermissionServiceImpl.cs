using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Location;
using GrpcCommonNet.Library.Permission;
using GrpcCommonNet.Service.Models;
using GrpcCommonNet.Service.Repository;
using Org.BouncyCastle.Asn1.Ocsp;
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

        #region Объекты прав
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

        public override async Task<GetSubjectsResponse> GetSubjects(GetSubjectsRequest request, ServerCallContext context)
        {
            UserData userData = new UserData().GetUserData(context);
            _logger.LogDebug($"GetSubjects called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

            try
            {
                GetSubjectsResponse response = new();

               int subject_id = await _repo.GetSubjectsAsync(request, userData);

                if (subject_id == 0) response.Result = new Result { Status = Status.NotFound };
                else
                {
                    response.Subject = new Subject() { Id = subject_id };
                    response.Result = new Result { Status = Status.Ok };
                }
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new GetSubjectsResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };

            }
        }

        public override async Task<GetRightValuesResponse> GetRightValues(GetRightValuesRequest request, ServerCallContext context)
        {
            UserData userData = new UserData().GetUserData(context);
            _logger.LogDebug($"GetRightValues called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

            try
            {
                GetRightValuesResponse response = new();

                List<RightValueValue> rightValues = await _repo.GetRightValuesAsync(request, userData);

                if (rightValues == null || rightValues.Count == 0) response.Result = new Result { Status = Status.NotFound };
                else
                {
                    response.RightValueValues.AddRange(rightValues);
                    response.Result = new Result { Status = Status.Ok };
                }
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new GetRightValuesResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };

            }
        }

        #endregion

        #region Роли

        public override async Task<GetRolesResponse> GetRoles(GetRolesRequest request, ServerCallContext context)
        {
            UserData userData = new UserData().GetUserData(context);
            _logger.LogDebug($"GetRoles called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

            try
            {
                GetRolesResponse response = new();
                List<Role> roles = await _repo.GetRolesAsync(request, userData);
                if (roles == null || roles.Count == 0) response.Result = new Result { Status = Status.NotFound };
                else
                {
                    if (request.FieldMask == null || request.FieldMask.Paths.Count == 0)
                        response.Roles.AddRange(roles);
                    else
                    {
                        foreach (Role role in roles)
                        {
                            Role new_role = new Role();
                            request.FieldMask.Merge(role, new_role);
                            response.Roles.Add(new_role);
                        }
                    }
                    response.Result = new Result { Status = Status.Ok };
                }
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new GetRolesResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
            }
        }

        public override async Task<RoleResponse> AddRole(RoleRequest request, ServerCallContext context)
        {
            UserData userData = new UserData().GetUserData(context);
            _logger.LogDebug($"AddRole called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

            try
            {
                RoleResponse response = new RoleResponse();
                Role role = await _repo.AddRoleAsync(request, userData);

                if (role != null && role.Id != 0)
                {
                    response.Role = role;
                    response.Result = new Result { Status= Status.Ok };
                }
                return response;
            }
            catch (Exception ex) {
                _logger.LogError(ex, ex.Message);
                return new RoleResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
            }
        }

        public override async Task<RoleResponse> EditRole(RoleRequest request, ServerCallContext context)
        {
            UserData userData = new UserData().GetUserData(context);
            _logger.LogDebug($"EditRole called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

            try
            {
                RoleResponse response = new RoleResponse();
                Role role = await _repo.EditRoleAsync(request, userData);
                if (role != null && role.Id != 0)
                {
                    response.Role = role;
                    response.Result = new Result { Status = Status.Ok };
                }

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new RoleResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
            }
        }

        public override async Task<UndeleteRoleResponse> DeleteRole(DeleteRoleRequest request, ServerCallContext context)
        {
            UserData userData = new UserData().GetUserData(context);
            _logger.LogDebug($"DeleteRole called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

            try
            {
                UndeleteRoleResponse response = new UndeleteRoleResponse();

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new UndeleteRoleResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
            }
        }

        public override async Task<RoleResponse> DuplicateRole(DuplicateRoleRequest request, ServerCallContext context)
        {
            UserData userData = new UserData().GetUserData(context);
            _logger.LogDebug($"DuplicateRole called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

            try
            {
                RoleResponse response = new RoleResponse();
                Role role = await _repo.DuplicateRoleAsync(request, userData);
                if (role != null && role.Id != 0)
                {
                    response.Role = role;
                    response.Result = new Result { Status = Status.Ok };
                }

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new RoleResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
            }
        }


        #endregion

    }
}

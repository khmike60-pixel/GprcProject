using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.User;
using GrpcCommonNet.Service.Models;
using GrpcCommonNet.Service.Repository;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography.Xml;

[Authorize]
public class UserServiceImpl : UserServices.UserServicesBase
{
    private readonly UserRepository _repo;
    private readonly ILogger<UserServiceImpl> _logger;

    public UserServiceImpl(UserRepository repo, ILogger<UserServiceImpl> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    #region  Методы работы  с пользователями
    public override async Task<UserResponse> GetUser(UserRequest request, Grpc.Core.ServerCallContext context)
    {
        _logger.LogDebug($"GetUser called: {request}");
        UserData userData = new UserData().GetUserData(context);

        try 
        {
            var user = await _repo.GetUserByIdAsync(request.UserId, userData);
            return new UserResponse
            {
                Result = new Result() { Status = Status.Ok },
                User = user
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetUser");
            return new UserResponse
            {
                Result = new Result()
                {
                    Status = Status.BadRequest,
                    Message = ex.Message
                }
            };
        }
    }

    public override async Task<ListUserResponse> GetListUser(UserFilterRequest request, Grpc.Core.ServerCallContext context)
    {
        _logger.LogDebug($"GetListUser called: {request}");
        UserData userData = new UserData().GetUserData(context);

        try
        {
            List<User> users = await _repo.GetListAsync(request, userData);
            ListUserResponse response = new ListUserResponse();
            foreach (var user in users)
            {
                User maskedUser  = new User();
                if (request.FieldMask == null) 
                    maskedUser = user;
                else 
                    request.FieldMask.Merge(user, maskedUser);
                response.Users.Add(maskedUser); 
            }
            response.Result = new Result() { Status = Status.Ok };
            return response;
       }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetListUser");
            return new ListUserResponse
            {
                Result = new Result()
                {
                    Status = Status.BadRequest,
                    Message = ex.Message
                }
            };
        }
    }

    public override async Task<UserResponse> CreateUser(CreateUserRequest request, Grpc.Core.ServerCallContext context)
    {
        _logger.LogDebug($"CreateUser called: {request}");
        UserData userData = new UserData().GetUserData(context);
        try
        {
            UserResponse response = new UserResponse();
            User user = new User()
            {
                UserId = 0,
                UserAccess = request.UserAccess,
                UserIsBlocked = request.UserIsBlocked,
                UserLogin = request.UserLogin,
                UserPassword = request.UserPassword,
                UserSymbol = request.UserSymbol
            };
            User newUser = await _repo.CreateUserAsync(user, userData);
            response.User = newUser;
            response.Result = new Result() { Status = Status.Ok };
            return response;
        }
        catch (Exception ex) {
            _logger.LogError(ex, "Error in CreateUser");
            return new UserResponse { Result = new Result() { Status = Status.BadRequest, Message = ex.Message}};
        }
    }

    public override async Task<UserResponse> UpdateUser(UpdateUserRequest request, Grpc.Core.ServerCallContext context)
    {
        _logger.LogDebug($"UpdateUser called: {request}");
        UserData userData = new UserData().GetUserData(context);
        try
        {
            UserResponse response = new UserResponse();
            User user = new User()
            {
                UserId = request.UserId,
                Contragent = new Contragent() { CountryId = request.ContragentId },
                UserAccess = request.UserAccess,
                UserIsBlocked = request.UserIsBlocked,
                UserLogin = request.UserLogin,
                UserPassword = request.UserPassword,
                UserSymbol = request.UserSymbol
            };
            User newUser = await _repo.UpdateUserAsync(user, userData);
            response.User = newUser;
            if (newUser.UserId == 0) 
                response.Result = new Result { Status = Status.NotFound, Message = "Объект не найден." };
            else 
                response.Result = new Result() { Status = Status.Ok };
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in UpdateUser");
            return new UserResponse { Result = new Result() { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    public override async Task<DeleteUserResponse> DeleteUser(DeleteUserRequest request, Grpc.Core.ServerCallContext context)
    {
        _logger.LogDebug($"DeleteUser called: {request}");
        UserData userData = new UserData().GetUserData(context);
        
        bool result = await _repo.DeleteUserAsync(request.UserId, userData);
        
        return new DeleteUserResponse
        {
            Result = new Result() { Status = result ? Status.Ok : Status.InternalServerError}
        };
    }

    public override async Task<UndeleteIdsUserResponse> DeleteIdsUser(DeleteIdsUserRequest request, Grpc.Core.ServerCallContext context)
    {
        _logger.LogDebug($"DeleteIdsUser called: {request}");
        UserData userData = new UserData().GetUserData(context);

        try
        {
            List<int> undeleted = new List<int>();

            undeleted = await _repo.DeleteIdsUserAsync(request.Ids.ToList(), userData);
            UndeleteIdsUserResponse response = new UndeleteIdsUserResponse();
            foreach (int id in undeleted)
                response.UndeletedIds.Add(id);
            response.Result = new Result() { Status = Status.Ok };
            return response;    
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in CreateUser");
            return new UndeleteIdsUserResponse { Result = new Result() { Status = Status.BadRequest, Message = ex.Message } };


        }
    }

    #endregion
}


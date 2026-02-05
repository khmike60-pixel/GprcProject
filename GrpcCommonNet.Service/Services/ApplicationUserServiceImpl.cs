
using Grpc.Core;
using GrpcCommonNet.Library.Application;
using GrpcCommonNet.Library.ApplicationUser;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Service.Repository;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Status = GrpcCommonNet.Library.Common.Status;

[Authorize]
public class ApplicationUserServiceImpl : ApplicationUserServices.ApplicationUserServicesBase
{
    private readonly ApplicationUserRepository _repo;
    private readonly ILogger<ApplicationUserServiceImpl> _logger;

    public ApplicationUserServiceImpl(ILogger<ApplicationUserServiceImpl> logger, ApplicationUserRepository repo)
    {
        _logger = logger;
        _repo = repo;
    }

    #region Методы получения данных о приложениях пользователей
    public override async Task<ListApplicationUserResponse> GetListApplicationUser(ApplicationUserFilterRequest request, ServerCallContext context)
    {
        var response = new ListApplicationUserResponse();
        try
        {
            List<ApplicationUser> application_users = await _repo.GetListApplicationUserAsync(request);
            if (application_users != null)
            {
                foreach (ApplicationUser app_user in application_users)
                {
                    ApplicationUser maskedApplicationUser = new ApplicationUser();
                    if (request.FieldMask == null)
                        maskedApplicationUser = app_user;
                    else
                        request.FieldMask.Merge(app_user, maskedApplicationUser);
                    response.ApplicationUsers.Add(maskedApplicationUser);
                }
                response.Result = new Result { Status = Status.Ok };
            }
            else
            {
                response.Result = new Result { Status = Status.NotFound};
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в GetListApplicationUser: " + ex.Message);
        }
        return response;
    }

    public override async Task<AddApplicationUserResponse> AddApplicationUser(AddApplicationUserRequest request, ServerCallContext context)
    {
        var response = new AddApplicationUserResponse();
        try
        {
            ApplicationUser app = await _repo.AddApplicationUserAsync(request);
            response.ApplicationUser = app;
            response.Result = new Result { Status = Status.Ok };
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в AddApplicationUser: " + ex.Message);
        }
        return response;
    }

    public override async Task<AddIdsApplicationUserResponse> AddIdsApplicationUser(AddIdsApplicationUserRequest request, ServerCallContext context)
    {
        var response = new AddIdsApplicationUserResponse();
        try
        {
            List<ApplicationUser> addedIds = await _repo.AddIdsApplicationUserAsync(request);
            response.ApplicationUsers.AddRange(addedIds);
            response.Result = new Result { Status = Status.Ok };
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в AddIdsApplicationUser: " + ex.Message);
        }
        return response;
    }

    public override async Task<DeleteApplicationUserResponse> DeleteApplicationUser(DeleteApplicationUserRequest request, ServerCallContext context)
    {
        var response = new DeleteApplicationUserResponse();
        try
        {
            bool isDeleted = await _repo.DeleteApplicationUserAsync(request);
            if (isDeleted)
            {
                response.Result = new Result { Status = Status.Ok };
            }
            else
            {
                response.Result = new Result { Status = Status.NotFound };
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в DeleteApplicationUser: " + ex.Message);
        }
        return response;
    }

    public override async Task<UndeleteIdsApplicationUserResponse> DeleteIdsApplicationUser(DeleteIdsApplicationUserRequest request, ServerCallContext context)
    {
        var response = new UndeleteIdsApplicationUserResponse();
        try
        {
            List<int> undeletedIds = await _repo.DeleteIdsApplicationUserAsync(request);
            response.UndeletedApplicationUserIds.AddRange(undeletedIds);
            response.Result = new Result { Status = Status.Ok };
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в UndeleteIdsApplicationUser: " + ex.Message);
        }
        return response;
    }
    #endregion  

}

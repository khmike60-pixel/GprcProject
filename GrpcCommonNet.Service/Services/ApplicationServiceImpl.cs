using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcCommonNet.Library.Application;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Result = GrpcCommonNet.Library.Common.Result;
using Status = GrpcCommonNet.Library.Common.Status;


[Authorize]
public class ApplicationServiceImpl : ApplicationServices.ApplicationServicesBase
{
    private readonly ApplicationRepository _repo;
    private readonly ILogger<ApplicationServiceImpl> _logger;

    public ApplicationServiceImpl(ApplicationRepository repo, ILogger<ApplicationServiceImpl> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    #region  Методы работы с приложениями
    public override async Task<ApplicationResponse> GetApplication(ApplicationRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"ListApplication called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            Application application = await _repo.GetByIdAsync(request.Id);
            if (application != null)
            {
                ApplicationResponse response = new ApplicationResponse();
                Application maskedApplication = new Application();
                request.FieldMask.Merge(application, maskedApplication);
                response.Application = maskedApplication;
                response.Result = new Result { Status = Status.Ok };
                return response;
            }
            else return new ApplicationResponse { Result = new Result { Status = Status.NotFound } };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ApplicationResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    public override async Task<ListApplicationResponse> GetListApplication(ApplicationFilterRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"ListApplication called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            var list = await _repo.GetListAsync(request.Name, request.Db, request.Product);
            ListApplicationResponse response = new ListApplicationResponse();
            foreach (Application app in list) {
                Application maskedApplication  = new Application();
                if (request.FieldMask == null) 
                    maskedApplication = app;
                else 
                    request.FieldMask.Merge(app, maskedApplication);
                response.Applications.Add(maskedApplication);
            };
            response.Result = new Result { Status = Status.Ok };

            return response;
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ListApplicationResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    //public override async Task<ListApplicationUserResponse> GetListApplicationUser(ApplicationFilterRequest request, ServerCallContext context)
    //{
    //    UserData userData = new UserData().GetUserData(context);
    //    _logger.LogDebug($"CountApplication called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
    //    try
    //    {
    //        ListApplicationResponse response = new ListApplicationResponse();
    //        var list = await _repo.GetListByUserAsync(request);

    //        foreach (Application app in list)
    //        {
    //            Application maskedApplication = new Application();
    //            if (request.FieldMask == null)
    //                maskedApplication = app;
    //            else
    //                request.FieldMask.Merge(app, maskedApplication);
    //            response.Applications.Add(maskedApplication);
    //        }
    //        response.Result = new Result { Status = Status.Ok };
    //        return response;
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, ex.Message);
    //        return new ListApplicationResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
    //    }
    //}

    public override async Task<ApplicationResponse> CreateApplication(CreateApplicationRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"CreateApplication called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            Application application = await _repo.CreateAsync(request.Product, request.Db, request.Name);
            if (application == null)
            {
                return new ApplicationResponse { Result = new Result { Status = Status.BadRequest} };
            }
            ApplicationResponse response = new ApplicationResponse()
            {
                Application = application,
                Result = new Result { Status = Status.Ok }
            };
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ApplicationResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    public override async Task<ApplicationResponse> UpdateApplication(UpdateApplicationRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"UpdateApplication called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            Application application = await _repo.UpdateAsync( request.Id, request.Product, request.Db, request.Name);
            if (application == null)
            {
                return new ApplicationResponse { Result = new Result { Status = Status.NotFound } };
            }
            ApplicationResponse response = new ApplicationResponse()
            {
                Application = application,
                Result = new Result { Status = Status.Ok }
            };
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ApplicationResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    public  override  async Task<DeleteApplicationResponse> DeleteApplication(DeleteApplicationRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"DeleteApplication called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            bool deleted = await _repo.DeleteAsync(request.Id);
            if (deleted)
            {
                return new DeleteApplicationResponse { Result = new Result { Status = Status.Ok } };
            }
            else
            {
                return new DeleteApplicationResponse { Result = new Result { Status = Status.BadRequest, Message = "Удаление невозможно" } };
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new DeleteApplicationResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }   

    public override async Task<UndeleteIdsApplicationResponse> DeleteIdsApplication( DeleteIdsApplicationRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"DeleteApplications called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            List<int> list = await _repo.DeleteIdsAsync(request.Ids.ToList());
            UndeleteIdsApplicationResponse response = new UndeleteIdsApplicationResponse();
            response.UndeletedIds.AddRange(list);
            response.Result = new Result { Status = Status.Ok };
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new UndeleteIdsApplicationResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    //public override async Task<AddApplicationOfUserResponse> AddApplicationOfUser(AddApplicationOfUserRequest request, ServerCallContext context)
    //{
    //    UserData userData = new UserData().GetUserData(context);
    //    _logger.LogDebug($"AddApplicationForUser called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
    //    try
    //    {
    //        ApplicationOfUser app_user = await _repo.AddApplicationOfUserAsync(request.UserId, request.ApplicationId);
    //        if (app_user != null)
    //        {
    //            return new AddApplicationOfUserResponse { ApplicationOfUser = app_user, Result = new Result { Status = Status.Ok } };
    //        }
    //        else
    //        {
    //            return new AddApplicationOfUserResponse { Result = new Result { Status = Status.BadRequest, Message = "Добавление невозможно" } };
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, ex.Message);
    //        return new AddApplicationOfUserResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
    //    }
    //}

    //public override async Task<DeleteApplicationOfUserResponse> DeleteApplicationOfUser(DeleteApplicationOfUserRequest request, ServerCallContext context)
    //{
    //    UserData userData = new UserData().GetUserData(context);
    //    _logger.LogDebug($"DeleteApplicationForUser called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
    //    try
    //    {
    //        bool deleted = await _repo.DeleteApplicationOfUserAsync(request.ApplicationOfUserId);
    //        if (deleted)
    //        {
    //            return new DeleteApplicationOfUserResponse { Result = new Result { Status = Status.Ok } };
    //        }
    //        else
    //        {
    //            return new DeleteApplicationOfUserResponse { Result = new Result { Status = Status.BadRequest, Message = "Удаление невозможно" } };
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, ex.Message);
    //        return new DeleteApplicationOfUserResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
    //    }
    //}

    //public override async Task<UndeleteIdsApplicationOfUserResponse> DeleteIdsApplicationOfUser(DeleteIdsApplicationOfUserRequest request, ServerCallContext context)
    //{
    //    UserData userData = new UserData().GetUserData(context);
    //    _logger.LogDebug($"DeleteApplicationsOfUser called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
    //    try
    //    {
    //        List<int> list = await _repo.DeleteIdsApplicationOfUserAsync(request.ApplicationOfUserIds.ToList());
    //        UndeleteIdsApplicationOfUserResponse response = new UndeleteIdsApplicationOfUserResponse();
    //        response.UndeletedApplicationOfUserIds.AddRange(list);
    //        response.Result = new Result { Status = Status.Ok };
    //        return response;
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, ex.Message);
    //        return new UndeleteIdsApplicationOfUserResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
    //    }
    //}

    #endregion


}

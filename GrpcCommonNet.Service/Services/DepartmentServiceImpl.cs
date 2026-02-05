using Grpc.Core;
using GrpcCommonNet.Library.Department;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Service.Models;
using GrpcCommonNet.Service.Repository;
using Microsoft.AspNetCore.Authorization;
using Status = GrpcCommonNet.Library.Common.Status;

[Authorize]
public class DepartmentServiceImpl :  DepartmentServices.DepartmentServicesBase   
{
    private readonly DepartmentRepository _repo;
    private readonly ILogger<DepartmentServiceImpl> _logger;

    public DepartmentServiceImpl(DepartmentRepository repo, ILogger<DepartmentServiceImpl> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public override async Task<DepartmentResponse> GetDepartment(DepartmentRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetDepartmentById called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            Department department = await _repo.GetByIdAsync(request.Id);
            if (department == null) 
                return new DepartmentResponse { Department = { }, Result = new Result { Status = Status.NotFound } };
            else
                return new DepartmentResponse { Department = department, Result = new Result { Status = Status.Ok } };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new DepartmentResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    public override async Task<ListDepartmentResponse> GetListDepartment(ListDepartmentRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetListDepartment called. UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            string filterInfo = string.Empty;
            if (request.FilterCase == ListDepartmentRequest.FilterOneofCase.Symbol) 
                filterInfo =  request.Symbol;
            else if (request.FilterCase == ListDepartmentRequest.FilterOneofCase.DepartmentShort) 
                filterInfo = request.DepartmentShort;
            else 
                filterInfo = string.Empty;

            List<Department> departments = await _repo.GetListAsync(filterInfo);

            if (departments == null) return new ListDepartmentResponse { Result = new Result { Status = Status.NotFound} };

            var response = new ListDepartmentResponse();
            response.Departments.AddRange(departments);
            response.Result = new Result { Status = Status.Ok };
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ListDepartmentResponse { Result = new Result { Status = Status.BadRequest,  Message = ex.Message } };
        }
    }   

    public override async Task<DepartmentResponse> CreateDepartment(CreateDepartmentRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetCountDepartment called. UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            DepartmentResponse response = new DepartmentResponse();

            response.Department = await _repo.CreatetAsync(request.Department);  
            if (response.Department == null) 
                return new DepartmentResponse { Result = new Result { Status = Status.BadRequest } };
            else 
                return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new DepartmentResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    public override async Task<DepartmentResponse> UpdateDepartment(UpdateDepartmentRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"UpdateDepartment called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            DepartmentResponse response = new DepartmentResponse();
            response.Department = await _repo.UpdateAsync(request.Department);  
            if (response.Department == null) 
                return new DepartmentResponse { Result = new Result { Status = Status.BadRequest } };
            else 
                return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new DepartmentResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    public override async Task<DeleteDepartmentResponse> DeleteDepartment(DeleteDepartmentRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"DeleteDepartment called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            bool isDeleted = await _repo.DeleteAsync(request.Id);
            if (isDeleted) 
                return new DeleteDepartmentResponse { Result = new Result { Status = Status.Ok } };
            else 
                return new DeleteDepartmentResponse { Result = new Result { Status = Status.BadRequest } };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new DeleteDepartmentResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    public  override async Task<UndeletedIdsDepartmentResponse> DeleteIdsDepartment(DeleteIdsDepartmentRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"UndeletedIdsDepartment called. UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            List<int> undeletedIds = await _repo.DeleteIdsAsync(request.Ids.ToList());
            var response = new UndeletedIdsDepartmentResponse();
            response.UndeletedIds.AddRange(undeletedIds);
            response.Result = new Result { Status = Status.Ok };
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new UndeletedIdsDepartmentResponse { Result = new Result { Status = Status.BadRequest,  Message = ex.Message } };
        }
    }


}

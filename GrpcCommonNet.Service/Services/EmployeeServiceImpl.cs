using Grpc.Core;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Currency;
using GrpcCommonNet.Library.Employee;
using GrpcCommonNet.Service.Models;
using GrpcCommonNet.Service.Repository;
using Microsoft.AspNetCore.Authorization;
using Status = GrpcCommonNet.Library.Common.Status;

[Authorize]
public class EmployeeServiceImpl: EmployeeServices.EmployeeServicesBase
{
    private readonly EmployeeRepository _repo;
    private readonly ILogger<EmployeeServiceImpl> _logger;

    public EmployeeServiceImpl(EmployeeRepository repo, ILogger<EmployeeServiceImpl> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public override async Task<EmployeeResponse> GetEmployee(EmployeeRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetEmployee called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            var resp = new EmployeeResponse
            {
                Employee = new Employee(),
                Result = new Result { Status = Status.Ok }
            };

            Employee? c = await _repo.GetEmployeeAsync(request);
            if (c != null)
            {
                Employee maskedCurrency = new Employee();
                request.FieldMask.Merge(c, maskedCurrency);
                resp.Employee = maskedCurrency;
                resp.Result = new Result { Status = Status.Ok };
            }
            else
                resp.Result = new Result { Status = Status.NotFound };

            return resp;
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new EmployeeResponse { Result = new Result { Status = Status.BadRequest } };
        }
    }

    public override async Task<ListEmployeeResponse> ListEmployee(ListEmployeeRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"ListEmployee called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            ListEmployeeResponse response = new ListEmployeeResponse();
            List<Employee> list = await _repo.ListEmployeeAsync(request);

            foreach (Employee emp in list)
            {
                Employee maskedEmployee = new Employee();
                if (request.FieldMask == null) maskedEmployee = emp;
                else request.FieldMask.Merge(emp, maskedEmployee);
                response.Employees.Add(maskedEmployee);
            }
            response.Result = new Result { Status = Status.Ok };
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ListEmployeeResponse { Result = new Result { Status = Status.BadRequest } };
        }
    }

    public override async Task<EmployeeResponse> CreateEmployee(CreateEmployeeRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"CreateEmployee called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            EmployeeResponse resp = new EmployeeResponse();
            var created = await _repo.CreateEmployeeAsync(request);

            if (created == null) throw new Exception("Employee not created");
            else
                resp = new EmployeeResponse { Employee = created, Result = new Result { Status = Status.Ok } };
            return resp;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new EmployeeResponse { Result = new Result { Status = Status.BadRequest } };
        }
    }

    public override async Task<EmployeeResponse> UpdateEmployee(UpdateEmployeeRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"UpdateEmployee called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            EmployeeResponse resp = new EmployeeResponse();
            var created = await _repo.UpdateEmployeeAsync(request);

            if (created == null) throw new Exception("Employee not updated");
            else
                resp = new EmployeeResponse { Employee = created, Result = new Result { Status = Status.Ok } };
            return resp;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new EmployeeResponse { Result = new Result { Status = Status.BadRequest } };
        }

    }

    public override async Task<DeleteEmployeeResponse> DeleteEmployee(DeleteEmployeeRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"DeleteEmployee called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            DeleteEmployeeResponse resp = new DeleteEmployeeResponse();

            var ok = await _repo.DeleteEmployeeAsync(request);
            resp = new DeleteEmployeeResponse
            {
                Result = ok ? new Result { Status = Status.Ok } : new Result { Status = Status.NotFound }
            };
            return resp;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new DeleteEmployeeResponse { Result = new Result { Status = Status.BadRequest } };
        }
    }

    public override async Task<UndeleteIdsEmployeeResponse> DeleteIdsEmployee(DeleteIdsEmployeeRequest request, ServerCallContext context )
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"DeleteIdsEmployee called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            List<int> affected = await _repo.DeleteIdsAsync(request.Ids);
            var resp = new UndeleteIdsEmployeeResponse();
            resp.UndeletedIds.AddRange(affected);
            resp.Result = new Result { Status = Status.Ok };
            return resp;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new UndeleteIdsEmployeeResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }

    }
}

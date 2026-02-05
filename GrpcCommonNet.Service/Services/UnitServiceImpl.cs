using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Unit;
using GrpcCommonNet.Service.Models;
using GrpcCommonNet.Service.Repository;
using Microsoft.AspNetCore.Authorization;
using Result = GrpcCommonNet.Library.Common.Result;
using Status = GrpcCommonNet.Library.Common.Status;

[Authorize] // либо [Authorize(Roles = "admin")] при роли
public class UnitServiceImpl : UnitServices.UnitServicesBase
{
    private readonly UnitRepository _repo;
    private readonly ILogger<UnitServiceImpl> _logger;

    public UnitServiceImpl(UnitRepository repo, ILogger<UnitServiceImpl> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    #region Методы работы с ед.измерения
    public override async Task<UnitResponse> GetUnit(UnitRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetUnitById called: {request}");
        try
        {
            UnitResponse response = new UnitResponse();
            Unit unit = await _repo.GetUnitByIdAsync(request.Id, userData);
            if (unit.Id == 0)
                response = new UnitResponse { Result = new Result { Status = Status.NotFound } };
            else
                response = new UnitResponse { Unit = unit, Result = new Result { Status = Status.Ok } };
            return response;
        }
        catch (Exception  ex)
        {
            _logger.LogError(ex, ex.Message);
            return new UnitResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    public override async Task<ListUnitResponse> GetListUnit(ListUnitRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetListUnit called: {request} MainClass: " + "{" + "User = {MainClass.User}, Application = {MainClass.Application}" + "}");
        try
        {
            ListUnitResponse rest = new ListUnitResponse();
            var list = await _repo.GetListAsync(request.Id, request.Short, request.IsArchive);
            foreach (Unit unit in list)
            {
                Unit maskedUnit = new Unit();
                if (request.FieldMask != null)
                {
                    request.FieldMask.Merge(unit, maskedUnit);
                    rest.Units.Add(maskedUnit);
                }
                else
                    rest.Units.Add(unit);
            }
            rest.Result = new Result() { Status = Status.Ok };
            return rest;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ListUnitResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    public override async Task<UnitResponse> CreateUnit(CreateUnitRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"CreateUnit called: {request}");

        try
        {
            UnitResponse response = new UnitResponse();
            Unit unit = await _repo.CreateAsync(request.Unit, userData);
            if (unit.Id == 0) return new UnitResponse { Result = new Result { Status = Status.BadRequest } };
            response.Unit = unit;
            response.Result = new Result { Status = Status.Ok };
            return response;    
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new UnitResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    public override async Task<UnitResponse> UpdateUnit(UpdateUnitRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"UpdateUnit called: {request}");

        try
        {
            UnitResponse response = new UnitResponse();
            Unit unit = await _repo.UpdateAsync(request.Unit, userData);
            if (unit.Id == 0) return new UnitResponse { Result = new Result { Status = Status.BadRequest } };
            response.Unit = unit;
            response.Result = new Result { Status = Status.Ok };
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new UnitResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    public override async Task<DeleteUnitResponse> DeleteUnit(DeleteUnitRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"DeleteUnitById called: {request}");

        try
        {
            DeleteUnitResponse response = new DeleteUnitResponse();
            bool retval = await _repo.DeleteByIdAsync(request.Id, userData);
            response.Result = new Result { Status = retval ? Status.Ok : Status.NotFound };
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new DeleteUnitResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    public override async Task<UndeleteIdsUnitResponse> DeleteIdsUnit(DeleteIdsUnitRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"DeleteUnitByIds called: {request}");

        try
        {
            UndeleteIdsUnitResponse response = new UndeleteIdsUnitResponse();
            List<int> undeleted_list = await _repo.DeleteIdsAsync(request.Ids.ToList(), userData);
            
            if(undeleted_list.Count > 0) response.UndeletedIds.AddRange(undeleted_list); 
            response.Result = new Result { Status= Status.Ok }; 
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new UndeleteIdsUnitResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    #endregion

}


using Grpc.Core;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.SalePurchaseType;
using GrpcCommonNet.Service.Models;
using GrpcCommonNet.Service.Repository;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics.Contracts;

[Authorize]
public class SalePurchaseTypeServiceImpl : SalePurchaseTypeServices.SalePurchaseTypeServicesBase
{
    private readonly SalePurchaseTypeRepository _repo;
    private readonly ILogger<SalePurchaseTypeServiceImpl> _logger;

    public SalePurchaseTypeServiceImpl(SalePurchaseTypeRepository repo, ILogger<SalePurchaseTypeServiceImpl> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public override async Task<SalePurchaseTypeResponse> GetSalePurchaseType(SalePurchaseTypeRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetSalePurchaseType called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            SalePurchaseTypeResponse response = new SalePurchaseTypeResponse();
            response.SalePurchaseType = await _repo.GetSalePurchaseTypeAsync(request, userData);
            if (response.SalePurchaseType == null || response.SalePurchaseType.Id == 0)
            {
                SalePurchaseType maskSalePurchaseType = new SalePurchaseType();
                if (request.FieldMask == null || request.FieldMask.Paths.Count == 0)
                    maskSalePurchaseType = response.SalePurchaseType;
                else
                    request.FieldMask.Merge(response.SalePurchaseType, maskSalePurchaseType);
                return new SalePurchaseTypeResponse() { Result = { Status = GrpcCommonNet.Library.Common.Status.NotFound } };
            }

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetSalePurchaseType: " + ex.Message);
            throw;
        }
    }

    public override async Task<ListSalePurchaseTypeResponse> ListSalePurchaseType(ListSalePurchaseTypeRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetSalePurchaseType called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            List<SalePurchaseType> salePurchaseTypes = await _repo.ListSalePurchaseTypeAsync(request, userData);

            ListSalePurchaseTypeResponse response = new ListSalePurchaseTypeResponse
            {
                Result = new Result { Status =  GrpcCommonNet.Library.Common.Status.Ok }
            };
            foreach (var salePurchaseType in response.SalePurchaseTypes)
            {
                SalePurchaseType maskSalePurchaseType = new SalePurchaseType();
                if (request.FieldMask == null || request.FieldMask.Paths.Count == 0)
                    maskSalePurchaseType = salePurchaseType;
                else
                    request.FieldMask.Merge(salePurchaseType, maskSalePurchaseType);
                response.SalePurchaseTypes.Add(maskSalePurchaseType);
            }
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in ListSalePurchaseType: " + ex.Message);
            throw;
        }
    }

    public override async Task<SalePurchaseTypeResponse> CreateSalePurchaseType(CreateSalePurchaseTypeRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"CreateSalePurchaseType called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            SalePurchaseTypeResponse response = new SalePurchaseTypeResponse();
            response.SalePurchaseType = await _repo.CreateSalePurchaseTypeAsync(request, userData);
            if (response.SalePurchaseType == null || response.SalePurchaseType.Id == 0)
            {
                SalePurchaseType maskSalePurchaseType = new SalePurchaseType();
                if (request.FieldMask == null || request.FieldMask.Paths.Count == 0)
                    maskSalePurchaseType = response.SalePurchaseType;
                else
                    request.FieldMask.Merge(response.SalePurchaseType, maskSalePurchaseType);
                return new SalePurchaseTypeResponse() { Result = { Status = GrpcCommonNet.Library.Common.Status.NotFound } };
            }

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in CreateSalePurchaseType: " + ex.Message);
            throw;

        }
    }

    public override async Task<SalePurchaseTypeResponse> UpdateSalePurchaseType(UpdateSalePurchaseTypeRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"UpdateSalePurchaseType called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            SalePurchaseTypeResponse response = new SalePurchaseTypeResponse();
            response.SalePurchaseType = await _repo.UpdateSalePurchaseTypeAsync(request, userData);
            if (response.SalePurchaseType == null || response.SalePurchaseType.Id == 0)
            {
               return new SalePurchaseTypeResponse() { Result = { Status = GrpcCommonNet.Library.Common.Status.NotFound } };
            }

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in UpdateSalePurchaseType: " + ex.Message);
            throw;

        }
    }

    public override async Task<DeleteSalePurchaseTypeResponse> DeleteSalePurchaseType(DeleteSalePurchaseTypeRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"DeleteSalePurchaseType called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            DeleteSalePurchaseTypeResponse response = new DeleteSalePurchaseTypeResponse();
            List<int> undeletedIds = await _repo.DeleteSalePurchaseTypeAsync(request, userData);
            response.UndeletedIds.AddRange(undeletedIds);
            response.Result = new Result { Status = GrpcCommonNet.Library.Common.Status.Ok };
            return response;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in DeleteSalePurchaseTypeResponse: " + ex.Message);
            throw;
        }

    }
}
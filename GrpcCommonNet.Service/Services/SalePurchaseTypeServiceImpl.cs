using Grpc.Core;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.SalePurchaseType;
using GrpcCommonNet.Service.Models;
using GrpcCommonNet.Service.Repository;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics.Contracts;
using Status = GrpcCommonNet.Library.Common.Status;

[Authorize]
public class SalePurchaseTypeServiceImpl : SalePurchaseTypeServices.SalePurchaseTypeServicesBase
{
    private readonly SalePurchaseTypeRepository _repo;
    private readonly ILogger<SalePurchaseTypeServiceImpl> _logger;

    #region Методы типов продаж/покупок

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
            _logger.LogError(ex, "Error in DeleteSalePurchaseType: " + ex.Message);
            throw;
        }

    }

    #endregion

    #region Методы курсов валют в типах продаж/покупок

    public override async Task<SalePurchaseRateResponse> GetSalePurchaseRate(SalePurchaseRateRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetSalePurchaseRate called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            SalePurchaseRateResponse response = new SalePurchaseRateResponse();
            response.Rate = await _repo.GetSalePurchaseRateAsync(request, userData);
            if (response.Rate == null || response.Rate.Id == null || response.Rate.Id == 0)
                return new SalePurchaseRateResponse() { 
                    Result = { Status = Status.NotFound } 
                };

            response.Result = new Result { Status = Status.Ok};
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetSalePurchaseRate: " + ex.Message);
            throw;
        }
    }

    public override async Task<ListSalePurchaseRateResponse> ListSalePurchaseRate(ListSalePurchaseRateRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"ListSalePurchaseRate called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            ListSalePurchaseRateResponse response = new ListSalePurchaseRateResponse();

            List<SalePurchaseRate> rates = await _repo.ListSalePurchaseRateAsync(request, userData);
            if (rates == null )
                return new ListSalePurchaseRateResponse() { Result = { Status = Status.NotFound } };

            response.Rates.AddRange(rates);
            response.Result = new Result { Status = Status.Ok };
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in ListSalePurchaseRate: " + ex.Message);
            throw;
        }
    }

    public override async Task<SalePurchaseRateResponse> CreateSalePurchaseRate(CreateSalePurchaseRateRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetSalePurchaseRate called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            SalePurchaseRateResponse response = new SalePurchaseRateResponse();
            SalePurchaseRate rate = await _repo.CreateSalePurchaseRateAsync(request, userData);
            if (rate == null || rate.Id == null || rate.Id == 0)
                return new SalePurchaseRateResponse() { Result = { Status = Status.NotFound } };

            response.Rate = rate;
            response.Result = new Result { Status = Status.Ok };
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetSalePurchaseRate: " + ex.Message);
            throw;
        }
    }

    public override async Task<SalePurchaseRateResponse> UpdateSalePurchaseRate(UpdateSalePurchaseRateRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"UpdateSalePurchaseRate called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            SalePurchaseRateResponse response = new SalePurchaseRateResponse();
            SalePurchaseRate rate = await _repo.UpdateSalePurchaseRateAsync(request, userData);
            if (rate == null || rate.Id == null || rate.Id == 0)
                return new SalePurchaseRateResponse() { Result = { Status = Status.NotFound } };

            response.Rate = rate;
            response.Result = new Result { Status = Status.Ok };
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in UpdateSalePurchaseRate: " + ex.Message);
            throw;
        }
    }

    public override async Task<UndeletedSalePurchaseRateResponse> DeleteSalePurchaseRate(DeleteSalePurchaseRateRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"DeleteSalePurchaseRate called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            UndeletedSalePurchaseRateResponse response = new UndeletedSalePurchaseRateResponse();
            List<int> undeleted_ids = await _repo.DeleteSalePurchaseRateAsync(request, userData);

            response.UndeletedIds.AddRange(undeleted_ids);
            response.Result = new Result { Status = Status.Ok };
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in DeleteSalePurchaseRate: " + ex.Message);
            throw;
        }
    }


    #endregion
}
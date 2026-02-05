using Grpc.Core;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Currency;
using GrpcCommonNet.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Result = GrpcCommonNet.Library.Common.Result;
using Status = GrpcCommonNet.Library.Common.Status;


[Authorize] // либо [Authorize(Roles = "admin")] при роли
public class CurrencyServiceImpl : CurrencyServices.CurrencyServicesBase
{
    private readonly CurrencyRepository _repo;
    private readonly ILogger<CurrencyServiceImpl> _logger;

    #region Методы работы  с валютой
    public CurrencyServiceImpl(CurrencyRepository repo, ILogger<CurrencyServiceImpl> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public override async Task<CurrencyResponse> GetCurrency(CurrencyRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetCurrency called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            var resp = new CurrencyResponse
            {
                Currency = new Currency(),
                Result = new Result { Status = Status.Ok }
            };

            Currency? c = await _repo.GetByIdAsync(request.Id);
            if (c != null)
            {
                Currency maskedCurrency = new Currency();
                request.FieldMask.Merge(c, maskedCurrency);
                resp.Currency = maskedCurrency;
                resp.Result = new Result { Status = Status.Ok };
            } else
                resp.Result = new Result { Status = Status.NotFound };

            return resp;
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new CurrencyResponse { Result = new  Result { Status = Status.BadRequest } };
        }

    }

    public override async Task<ListCurrencyResponse> GetListCurrency(ListCurrencyRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetListCurrency called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            var resp = new ListCurrencyResponse();
            string? codeFilter = null;
            string? abbrevFilter = null;
            if (request.FilterCase == ListCurrencyRequest.FilterOneofCase.CurrencyCode) codeFilter = request.CurrencyCode;
            if (request.FilterCase == ListCurrencyRequest.FilterOneofCase.CurrencyAbbrev) abbrevFilter = request.CurrencyAbbrev;

            var list = await _repo.GetListAsync(request.IncludeInvisible, request.OrderBy, codeFilter, abbrevFilter);

            foreach (Currency c in list)
            {
                Currency maskedCurrency = new Currency();
                if (request.FieldMask == null) maskedCurrency = c;
                else request.FieldMask.Merge(c, maskedCurrency); 
                resp.Currencies.Add(maskedCurrency);
            }
            resp.Result =  new Result {  Status = Status.Ok};
            return resp;
        }
        catch (System.Exception ex)
        {                               
            _logger.LogError(ex, ex.Message);
            return new ListCurrencyResponse { Result = new Result { Status = Status.BadRequest } };
        }
    }

    public override async Task<CurrencyResponse> CreateCurrency(CreateCurrencyRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"CreateCurrency called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            CurrencyResponse resp = new CurrencyResponse();
            if (request.Currency.Abbrev.Equals(""))
            {
                resp.Result = new Result { Status = Status.BadRequest };
                return resp;
            }
            var created = await _repo.CreateAsync(request.Currency);

            if (created == null)  throw new Exception("Currency not created");
            else
                resp = new CurrencyResponse { Currency = created, Result = new Result { Status = Status.Ok } };
            return resp;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new CurrencyResponse { Result = new Result { Status = Status.BadRequest } };
        }
    }

    public override async Task<CurrencyResponse> UpdateCurrency(UpdateCurrencyRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"UpdateCurrency called: {request} UserData: " + "{ " + $"User = {userData.User}, Application = {userData.Application} " + "}");

        try
        {
            CurrencyResponse resp = new CurrencyResponse();
            List<string> fields = new List<string>(); // Все поля;
            if (request.FieldMask != null && request.FieldMask.Paths.Count != 0)
                fields = request.FieldMask.Paths.ToList();
            var updated = await _repo.UpdateAsync(request.Currency, fields);

            if (updated == null) throw new Exception("Currency not updated");
            else
                resp = new CurrencyResponse { Currency = updated, Result = new Result { Status = Status.Ok } };
            return resp;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new CurrencyResponse { Result = new Result { Status = Status.BadRequest } };
        }
    }


    public override async Task<DeleteCurrencyResponse> DeleteCurrency(DeleteCurrencyRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"DeleteCurrency called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            DeleteCurrencyResponse resp = new DeleteCurrencyResponse();

            var ok = await _repo.DeleteByIdAsync(request.Id);
            resp = new DeleteCurrencyResponse
            {
                Result = ok ? new Result { Status = Status.Ok } : new Result { Status = Status.NotFound }
            };
            return resp;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new DeleteCurrencyResponse { Result = new Result { Status = Status.BadRequest } };
        }
    }

    public override async Task<UndeletedIdsCurrencyResponse> DeleteIdsCurrency(DeleteIdsCurrencyRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"DeleteIdsCurrency called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            List<int> affected = await _repo.DeleteByIdsAsync(request.Ids);
            var resp = new UndeletedIdsCurrencyResponse();
            resp.UndeletedIds.AddRange(affected);
            resp.Result = new Result { Status = Status.Ok };
            return resp;
        } catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new UndeletedIdsCurrencyResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }

    }

    #endregion

    #region Методы  работы  с курсами  валют
    public override async Task<CurrencyRateResponse> GetCurrencyRate(CurrencyRateRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetCurrencyRate called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            string? filter = null;
            if (request.FilterCase == CurrencyRateRequest.FilterOneofCase.CurrencyCode) filter = request.CurrencyCode;
            if (request.FilterCase == CurrencyRateRequest.FilterOneofCase.CurrencyAbbrev) filter = request.CurrencyAbbrev;
            if (request.FilterCase == CurrencyRateRequest.FilterOneofCase.CurrencyId) filter = request.CurrencyId.ToString();
            var rate = await _repo.GetRateAsync(filter ?? string.Empty, request.Date);
            return new CurrencyRateResponse { 
                Rate = rate ?? new Rate(), 
                Result = new Result { Status = Status.Ok }
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new CurrencyRateResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    public override async Task<ListCurrencyRateResponse> GetListCurrencyRate(ListCurrencyRateRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetListRate called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            string? filter = null;
            if (request.FilterCase == ListCurrencyRateRequest.FilterOneofCase.CurrencyCode) filter = request.CurrencyCode;
            if (request.FilterCase == ListCurrencyRateRequest.FilterOneofCase.CurrencyAbbrev) filter = request.CurrencyAbbrev;
            if (request.FilterCase == ListCurrencyRateRequest.FilterOneofCase.CurrencyId) filter = request.CurrencyId.ToString();
            var list = await _repo.GetRatesAsync(filter, request.StartDate.ToDateTime().ToShortDateString(), request.EndDate.ToDateTime().ToShortDateString());
            var resp = new ListCurrencyRateResponse();

            foreach (Rate rate in list)
            {
                Rate maskedRate = new Rate();
                if (request.FieldMask != null)
                    request.FieldMask.Merge(rate, maskedRate);
                else maskedRate = rate;
                resp.Rates.Add(maskedRate);
            }
            resp.Result = new Result { Status = Status.Ok };
            return resp;
        }  catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ListCurrencyRateResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }

    }

    public override async Task<GetListCurrencyRateDateResponse> GetListCurrencyRateDate(GetListCurrencyRateDateRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetListRate called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            var list = await _repo.GetListRatesDateAsync(request.Abbrev, request.IncludeInvisible, request.Name, request.Date.ToDateTime().ToLocalTime());
            var resp = new GetListCurrencyRateDateResponse();

            resp.CurrencyRates.AddRange(list);
            resp.Result = new Result { Status = Status.Ok };
            return resp;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new GetListCurrencyRateDateResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    public override async Task<CurrencyRateResponse> CreateCurrencyRate(CreateCurrencyRateRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"CreateCurrencyRate called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            var created = await _repo.CreateRateAsync(request.Rate);
            return new CurrencyRateResponse
            {
                Rate = created ?? new Rate(),
                Result = new Result { Status = Status.Ok }
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new CurrencyRateResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    public override async Task<CurrencyRateResponse> UpdateCurrencyRate(UpdateCurrencyRateRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"UpdateCurrencyRate called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            var updated = await _repo.UpdateRateAsync(request.Rate.RateId, request.Rate.Date, request.Rate.Rate_);
            return new CurrencyRateResponse
            {
                Rate = updated ?? new Rate(),
                Result = new Result { Status = Status.Ok }
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new CurrencyRateResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }   

    public override async Task<DeleteCurrencyRateResponse> DeleteCurrencyRate(DeleteCurrencyRateRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"DeleteCurrencyRate called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            var ok = await _repo.DeleteRateAsync(request.RateId);
            return new DeleteCurrencyRateResponse
            {
                Result = new Result { Status = ok ? Status.Ok : Status.NotFound }
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new DeleteCurrencyRateResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    public override async Task<UndeleteIdsCurrencyRateResponse> DeleteIdsCurrencyRate(DeleteIdsCurrencyRateRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"DeleteIdsCurrencyRate called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            var affected = await _repo.DeleteIdsRatesAsync(request.RateIds);
            return new UndeleteIdsCurrencyRateResponse
            {
                UndeletedRateIds = { affected },
                Result = new Result { Status = Status.Ok }
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new UndeleteIdsCurrencyRateResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    #endregion
}

using Grpc.Core;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contragent;
using GrpcCommonNet.Service.Models;
using Microsoft.AspNetCore.Authorization;
using System.Drawing.Printing;
using Result = GrpcCommonNet.Library.Common.Result;
using Status = GrpcCommonNet.Library.Common.Status;

[Authorize]
public class ContragentServiceImpl : ContragentServices.ContragentServicesBase
{
    private readonly ContragentRepository _repo;
    private readonly ILogger<ContragentServiceImpl> _logger;

    #region Mетоды работы с контрагентами
    public ContragentServiceImpl(ContragentRepository repo, ILogger<ContragentServiceImpl> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public override async Task<ContragentResponse> GetContragent(ContragentRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetContragent called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            Contragent contragent = await _repo.GetByIdAsync(request.Id, userData);
            if (contragent != null && !contragent.ToString().Equals("{ }"))
            {
                ContragentResponse response = new ContragentResponse
                {
                    Contragent = new Contragent(),
                    Result = new Result { Status = Status.Ok }
                };
                if (request.FieldMask == null || request.FieldMask.Paths.Count == 0)
                    response.Contragent = contragent;
                else  
                request.FieldMask.Merge(contragent, response.Contragent);
                return response;
            }
            else return new ContragentResponse { Result = new Result { Status = Status.NotFound } };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ContragentResponse { Result = new Result { Status = Status.BadRequest } };
        }
    }

    public override async Task<ListContragentResponse> GetListContragent(ContragentFilterRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetListContragent called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            int page_number = request.Paging == null ? 0 : request.Paging.PageNumber;
            int page_size = request.Paging == null ? 0 : request.Paging.PageSize;
            if (!request.HasTypeFilter) request.TypeFilter = ContragentTypeFilter.All;

            List<Contragent> contragents = await _repo.ListAsync(
                request.Name ?? string.Empty,
                request.Taxno ?? string.Empty,
                request.TypeFilter, 
                request.CountrySymbol ?? string.Empty,
                page_number, page_size, 
                userData);
            ListContragentResponse response = new ListContragentResponse
            {
                Result = new Result { Status = Status.Ok }
            };
            if (request.Paging != null)
                response.Paging = new Paging { PageNumber = request.Paging.PageNumber,  PageSize  = request.Paging.PageSize };

            foreach (var contragent in contragents)
            {
                Contragent maskContragent = new Contragent();
                if (request.FieldMask == null || request.FieldMask.Paths.Count == 0)
                    maskContragent = contragent;
                else
                    request.FieldMask.Merge(contragent, maskContragent);
                response.Contragents.Add(maskContragent);
            }
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ListContragentResponse { Result = new Result { Status = Status.BadRequest } };
        }
    }

    public override async Task<ListContragentResponse> ShortListContragent(ContragentFilterRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetListByIdsContragent called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            int page_number = request.Paging == null ? 0 : request.Paging.PageNumber;
            int page_size = request.Paging == null ? 0 : request.Paging.PageSize;
            if (!request.HasTypeFilter) request.TypeFilter = ContragentTypeFilter.All;
            //bool PrefixNotEmpty = request.PrefixNotEmpty;

            List<Contragent> contragents = await _repo.ShortListAsync(
                request.Name ?? string.Empty,
                request.Taxno ?? string.Empty,
                request.TypeFilter,
                request.CountrySymbol ?? string.Empty,
                request.PrefixNotEmpty,
                request.Prefix,
                page_number, page_size,
                userData);

            ListContragentResponse response = new ListContragentResponse
            {
                Result = new Result { Status = Status.Ok }
            };
            foreach (var contragent in contragents)
            {
                Contragent maskContragent = new Contragent();
                if (request.FieldMask == null || request.FieldMask.Paths.Count == 0)
                    maskContragent = contragent;
                else
                    request.FieldMask.Merge(contragent, maskContragent);
                response.Contragents.Add(maskContragent);
            }
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ListContragentResponse { Result = new Result { Status = Status.BadRequest } };
        }
    }

    public override async Task<ListContragentResponse> SearchListContragent(SearchRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"SearchListContragent called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            List<Contragent> contragents = _repo.SearchList(request.Search ?? string.Empty, request.Paging.PageNumber, request.Paging.PageSize, userData);
            ListContragentResponse response = new ListContragentResponse
            {
                Result = new Result { Status = Status.Ok }
            };
            foreach (var contragent in contragents)
            {
                Contragent maskContragent = new Contragent();
                if (request.FieldMask == null || request.FieldMask.Paths.Count == 0)
                    maskContragent = contragent;
                else
                    request.FieldMask.Merge(contragent, maskContragent);
                response.Contragents.Add(maskContragent);
            }
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ListContragentResponse { Result = new Result { Status = Status.BadRequest } };
        }
    }

    public override async Task<CountListContragentResponse> CountListContragent(ContragentFilterRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"CountListContragent called. UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            if (!request.HasTypeFilter) request.TypeFilter = ContragentTypeFilter.All;
            long count = await _repo.CountAllAsync(
                request.Name,
                request.Taxno,
                request.TypeFilter,
                request.CountrySymbol,
                userData);
            CountListContragentResponse response = new CountListContragentResponse
            {
                Count = count,
                Result = new Result { Status = Status.Ok }
            };
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new CountListContragentResponse { Result = new Result { Status = Status.BadRequest } };
        }
    }

    public override async Task<ContragentResponse> CreateContragent(CreateContragentRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"CreateContragent called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            Contragent contragent = await _repo.CreateAsync(request.Contragent, userData);
            if (contragent != null)
            {
                ContragentResponse response = new ContragentResponse()
                {
                    Contragent = contragent,
                    Result = new Result { Status = Status.Ok }
                };
                return response;
            }
            else return new ContragentResponse { Result = new Result { Status = Status.NotFound } };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ContragentResponse { Result = new Result { Status = Status.BadRequest,  Message = ex.Message } };
        }
    }

    public override async Task<ContragentResponse> UpdateContragent(UpdateContragentRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"UpdateContragent called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            Contragent contragent = await _repo.UpdateAsync(request.Contragent, userData);
            if (contragent != null)
            {
                ContragentResponse response = new ContragentResponse()
                {
                    Contragent = contragent,
                    Result = new Result { Status = Status.Ok }
                };
                return response;
            }
            else return new ContragentResponse { Result = new Result { Status = Status.NotFound } };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ContragentResponse { Result = new Result { Status = Status.BadRequest } };
        }
    }

    public override async Task<DeleteContragentResponse> DeleteContragent(DeleteContragentRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"DeleteContragent called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            bool deleted = await _repo.DeleteAsync(request.Id, userData);
            if (deleted)
            {
                return new DeleteContragentResponse { Result = new Result { Status = Status.Ok } };
            }
            else return new DeleteContragentResponse { Result = new Result { Status = Status.NotFound } };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new DeleteContragentResponse { Result = new Result { Status = Status.BadRequest } };
        }
    }

    public override async Task<UndeletedIdsContragentResponse> DeleteIdsContragent(DeleteIdsContragentRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"UndeleteContragent called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            List<int> undeleted = await _repo.DeleteIdsAsync(request.Ids.ToList(), userData);
            return new UndeletedIdsContragentResponse { 
                UndeletedIds = { undeleted }, 
                Result = new Result { Status = Status.Ok } };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new UndeletedIdsContragentResponse { Result = new Result { Status = Status.BadRequest } };
        }
    }

    #endregion

    #region Методы работы со своими организациями (OurCompanies)

    public override async Task<ContragentResponse> GetOurCompany(ContragentRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetContragent called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            Contragent contragent = await _repo.GetOurCompanyAsync(request.Id, userData);
            if (contragent != null && !contragent.ToString().Equals("{ }"))
            {
                ContragentResponse response = new ContragentResponse
                {
                    Contragent = new Contragent(),
                    Result = new Result { Status = Status.Ok }
                };
                if (request.FieldMask == null || request.FieldMask.Paths.Count == 0)
                    response.Contragent = contragent;
                else
                    request.FieldMask.Merge(contragent, response.Contragent);
                return response;
            }
            else return new ContragentResponse { Result = new Result { Status = Status.NotFound } };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ContragentResponse { Result = new Result { Status = Status.BadRequest } };
        }
    }

    public override async Task<ListContragentResponse> GetListOurCompany(ContragentFilterRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetListOurCompanies called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            List<Contragent> contragents = await _repo.ListOurCompanyAsync(
                request.Name ?? string.Empty,
                request.Taxno ?? string.Empty,
                request.TypeFilter,
                request.CountrySymbol ?? string.Empty,
                request.Paging?.PageNumber ?? 0,
                request.Paging?.PageSize ?? 0,
                userData);
            ListContragentResponse response = new ListContragentResponse
            {
                Result = new Result { Status = Status.Ok }
            };
            foreach (var contragent in contragents)
            {
                Contragent maskContragent = new Contragent();
                if (request.FieldMask == null || request.FieldMask.Paths.Count == 0)
                    maskContragent = contragent;
                else
                    request.FieldMask.Merge(contragent, maskContragent);
                response.Contragents.Add(maskContragent);
            }
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ListContragentResponse { Result = new Result { Status = Status.BadRequest } };
        }
    }

    #endregion
}

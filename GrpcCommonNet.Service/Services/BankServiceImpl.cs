using Google.Protobuf.Collections;
using Grpc.Core;
using GrpcCommonNet.Library.Bank;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Status = GrpcCommonNet.Library.Common.Status;

[Authorize]
public class BankServiceImpl : BankServices.BankServicesBase
{
    private readonly BankRepository _repo;
    private readonly ILogger<BankServiceImpl> _logger;

    public BankServiceImpl(BankRepository repo, ILogger<BankServiceImpl> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    #region

    public override async Task<BankResponse> GetBank(BankRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetBank called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            Bank bank = await _repo.GetByIdAsync(request.Id);
            if (bank != null)
            {
                BankResponse response = new BankResponse();
                Bank maskedBank = new Bank();
                if (request.FieldMask != null)
                {
                    request.FieldMask.Merge(bank, maskedBank);
                    response.Bank = maskedBank;
                }
                else response.Bank = bank;
                response.Result = new Result { Status = Status.Ok };
                return response;
            }
            else return new BankResponse { Result = new Result { Status = Status.NotFound } };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new BankResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    public override async Task<ListBankResponse> GetListBank(BankFilterRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"ListBanks called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            List<Bank> banks = await _repo.GetListAsync(request);
            ListBankResponse response = new ListBankResponse();
            if (request.FieldMask != null)
            {
                RepeatedField<Bank> maskedBanks = new RepeatedField<Bank>();
                foreach (var bank in banks)
                {
                    Bank maskedBank = new Bank();
                    request.FieldMask.Merge(bank, maskedBank);
                    maskedBanks.Add(maskedBank);
                }
                response.Banks.AddRange(maskedBanks);
            }
            else
                response.Banks.AddRange(banks);
            response.Result = new Result { Status = Status.Ok };
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ListBankResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    public override async Task<ListBankResponse> GetPagedListBank(BankFilterRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetPagedListBank called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            PagedResult<Bank> pagedBanks = await _repo.GetPagedListAsync(request);
            ListBankResponse response = new ListBankResponse();
            if (request.FieldMask != null)
            {
                RepeatedField<Bank> maskedBanks = new RepeatedField<Bank>();
                foreach (var bank in pagedBanks.Items)
                {
                    Bank maskedBank = new Bank();
                    request.FieldMask.Merge(bank, maskedBank);
                    maskedBanks.Add(maskedBank);
                }
                response.Banks.AddRange(maskedBanks);
            }
            else
                response.Banks.AddRange(pagedBanks.Items);
            response.Paging = new Paging
            {
                TotalCount = pagedBanks.TotalCount,
                PageNumber = pagedBanks.PageNumber,
                PageSize = pagedBanks.PageSize
            };
            response.Result = new Result { Status = Status.Ok };
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ListBankResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    public override async Task<BankResponse> CreateBank(CreateBankRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetPagedListBank called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            Bank bank = await _repo.CreateAsync(request);
            if (bank.Id != 0)
            {
                BankResponse response = new BankResponse();
                response.Bank = bank;
                response.Result = new Result { Status = Status.Ok };
                return response;
            }
            else
                return new BankResponse { Result = new Result { Status = Status.BadRequest, Message = "Добавить не удалось." } };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new BankResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };

        }
    }

    public override async Task<BankResponse> UpdateBank(UpdateBankRequest request, ServerCallContext  context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetPagedListBank called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            Bank bank = await _repo.UpdateAsync(request);
            if (bank != null)
            {
                BankResponse response = new BankResponse();
                response.Bank = bank;
                response.Result = new Result { Status = Status.Ok };
                return response;
            }
            else
                return new BankResponse { Result = new Result { Status = Status.BadRequest, Message = "Обновить  не удалось." } };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new BankResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };

        }
    }

    public override async Task<DeleteBankResponse> DeleteBank(DeleteBankRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"DeleteBank called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            bool deleted = await _repo.DeleteAsync(request.Id);
            if (deleted)
            {
                return new DeleteBankResponse { Result = new Result { Status = Status.Ok } };
            }
            else
                return new DeleteBankResponse { Result = new Result { Status = Status.BadRequest, Message = "Удалить не удалось." } };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new DeleteBankResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    public override async Task<UndeleteIdsBankResponse> DeleteIdsBank(DeleteIdsBankRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"DeleteBanks called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            List<int> undeletedList = await _repo.DeleteByIdsAsync(request.Ids);
            return new UndeleteIdsBankResponse
            {
                UndeletedIds =  { undeletedList },
                Result = new Result { Status = Status.Ok }
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new UndeleteIdsBankResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    #endregion

}

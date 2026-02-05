using Grpc.Core;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contract;
using GrpcCommonNet.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Status = GrpcCommonNet.Library.Common.Status;



[Authorize]
public class ContractServiceImpl : ContractServices.ContractServicesBase
{
    private readonly ContractRepository _repo;
    private readonly ILogger<ContractServiceImpl> _logger;

    #region Методы работы  с контрактами
    public ContractServiceImpl(ContractRepository repo, ILogger<ContractServiceImpl> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public override async Task<ContractResponse> GetContract(GetContractRequest request, ServerCallContext context)
    {

        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetCurrency called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            Contract contract = await _repo.GetByIdAsync(request.ContractId);
            if (contract == null || contract.Id == 0)
            {
                return new ContractResponse() { Result = { Status = Status.NotFound } };
            }
            return new ContractResponse()
            {
                Contract = contract,
                Result = new Result { Status = Status.Ok }
            };

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetContractByIdAsync: " + ex.Message);
            throw;
        }
    }

    public override async Task<ListContractsResponse> GetListContracts(ListContractsRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetListContracts called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            var contracts = await _repo.GetListAsync(request);
            ListContractsResponse response = new ListContractsResponse();
            if (contracts == null || contracts.Count == 0)
            {
                response.Result = new Result { Status = Status.NotFound };
                return response;
            }
            response.Contracts.AddRange(contracts);
            response.Result = new Result { Status = Status.Ok };
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetListContracts: " + ex.Message);
            throw;
        }
    }

    public override async Task<ListContractLinesResponse> GetListContractLines(ContractLineRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetListContractLines called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            var contractLines = await _repo.GetListLinesAsync(request);
            ListContractLinesResponse response = new ListContractLinesResponse();
            if (contractLines == null || contractLines.Count == 0)
            {
                response.Result = new Result { Status = Status.NotFound };
                return response;
            }
            response.Lines.AddRange(contractLines);
            response.Result = new Result { Status = Status.Ok };
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetListContractLines: " + ex.Message);
            throw;
        }

    }

    #endregion
}

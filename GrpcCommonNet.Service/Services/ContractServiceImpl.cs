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

    public override async Task<ContractResponse> GetContractFull(GetContractRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetCurrency called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            Contract contract = await _repo.GetContractFullAsync(request);
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
            _logger.LogError(ex, "Error in GetContractFullAsync: " + ex.Message);
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

    public override async Task<ListContractsResponse> GetContractHistory(GetContractRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetContractIerarch called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            var contractsHistory = await _repo.GetContractHistoryAsync(request.ContractId);
            ListContractsResponse response = new ListContractsResponse();
            if (contractsHistory == null || contractsHistory.Count == 0)
            {
                response.Result = new Result { Status = Status.NotFound };
                return response;
            }
            response.Contracts.AddRange(contractsHistory);
            response.Result = new Result { Status = Status.Ok };
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetContractHistory: " + ex.Message);
            throw;
        }
    }

    public override async Task<ContractResponse> UpdateContract(ContractRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetListContractLines called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            Contract _contract = await _repo.UpdateContractAsync(request.Contract);
            return new ContractResponse() { Contract = _contract, Result = new Result { Status = Status.Ok } };

        } catch (Exception ex)
        {
            _logger.LogError(ex, "Error in UpdateContract: " + ex.Message);
            throw;
        }
    }

    public override async Task<ContractResponse> CreateContract(ContractRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetListContractLines called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            Contract _contract = await _repo.CreateContractAsync(request.Contract);
            return new ContractResponse() { Contract = _contract, Result = new Result { Status = Status.Ok } };

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in CreateContract: " + ex.Message);
            throw;
        }

    }

    public override async Task<ContractLineResponse> UpdateContractLine(UpdateContractLineRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetListContractLines called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            Line _line = await _repo.UpdateLineAsync(request.Line);
            if ( _line == null ) return new ContractLineResponse() { Result = new Result { Status = Status.BadRequest } };
            
            return new ContractLineResponse() { Line = _line, Result = new Result { Status = Status.Ok } };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in UpdateContractLine: " + ex.Message);
            throw;
        }

    }

    public override async Task<TreeNodeResponse> GetTreeContracts(ListContractsRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetTreeContracts called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            var nodes = await _repo.GetTreeNodesAsync(request);
            TreeNodeResponse response = new TreeNodeResponse();
            if (nodes == null || nodes.Count == 0)
            {
                response.Result = new Result { Status = Status.NotFound };
                return response;
            }
            response.NodeContracts.AddRange(nodes);
            response.Result = new Result { Status = Status.Ok };
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetTreeContracts: " + ex.Message);
            throw;
        }
    }

    public override  async Task<ContractLineResponse> CreateContractLine(CreateContractLineRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetListContractLines called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            Line line = await _repo.CreateContractLineAsync(request);
            return new ContractLineResponse() { Line = line, Result = new Result { Status = Status.Ok } };

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in CreateContractLine: " + ex.Message);
            throw;
        }
    }




    #endregion
}

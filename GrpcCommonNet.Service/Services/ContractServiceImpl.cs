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
        _logger.LogDebug($"GetContract called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

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
            _logger.LogError(ex, "Error in GetContract: " + ex.Message);
            throw;
        }
    }

    public override async Task<ContractResponse> GetContractFull(GetContractRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetContractFull called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

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
            _logger.LogError(ex, "Error in GetContractFull: " + ex.Message);
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

    public override async Task<ListContractsResponse> GetContractHistory(GetContractRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetContractHistory called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
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
        _logger.LogDebug($"UpdateContract called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

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
        _logger.LogDebug($"CreateContract called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

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

    public override async Task<UndeletedIdsContractResponse> DeleteIdsContract(DeleteIdsContractRequest request,  ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"DeleteIdsContract called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            UndeletedIdsContractResponse response = new UndeletedIdsContractResponse();
            
            List<int> undeletedList = await _repo.DeleteIdsContractAsync(request);
            //if (undeletedList.Count ==  0) response.Result = new Result { Status = Status.NotFound};
            response.UndeletedIds.AddRange(undeletedList);
            response.Result = new Result { Status = Status.Ok };

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in DeleteIdsContract: " + ex.Message);
            throw;
        }

    }

    #endregion

    #region работа со строками контракта

    public override async Task<ContractLineResponse> CreateContractLine(CreateContractLineRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"CreateContractLine called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            Line line = await _repo.CreateContractLineAsync(request, userData);
            return new ContractLineResponse() { Line = line, Result = new Result { Status = Status.Ok } };

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in CreateContractLine: " + ex.Message);
            throw;
        }
    }

    public override async Task<ContractLineResponse> UpdateContractLine(UpdateContractLineRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"UpdateContractLine called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            Line _line = await _repo.UpdateLineAsync(request,userData);
            if (_line == null) return new ContractLineResponse() { Result = new Result { Status = Status.BadRequest } };

            return new ContractLineResponse() { Line = _line, Result = new Result { Status = Status.Ok } };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in UpdateContractLine: " + ex.Message);
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

    public override async Task<UndeletedIdsContractLineResponse> DeleteIdsContractLine(DeleteIdsContractLineRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"DeleteIdsContractLine called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            UndeletedIdsContractLineResponse response = new UndeletedIdsContractLineResponse();

            List<int> undeletedList = await _repo.DeleteIdsContractLineAsync(request);
            
            response.UndeletedIds.AddRange(undeletedList);
            response.Result = new Result { Status = Status.Ok };

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in DeleteIdsContractLine: " + ex.Message);
            throw;
        }

    }

    #endregion
}

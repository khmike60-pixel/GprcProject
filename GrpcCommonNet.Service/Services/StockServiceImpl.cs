using Grpc.Core;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Currency;
using GrpcCommonNet.Library.Stock;
using GrpcCommonNet.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Status = GrpcCommonNet.Library.Common.Status;

[Authorize] // либо [Authorize(Roles = "admin")] при роли
public class StockServiceImpl: StockServices.StockServicesBase
{
    private readonly StockRepository _repo;
    private readonly ILogger<StockServiceImpl> _logger;

    public StockServiceImpl(StockRepository repo, ILogger<StockServiceImpl> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public override async Task<ListStockResponse> GetListStock(ListStockRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"GetListCurrency called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            var resp = new ListStockResponse();

            var list = await _repo.GetListStocksAsync(request);

            foreach (Stock c in list)
            {
                Stock maskedStock = new();
                if (request.FieldMask == null) maskedStock = c;
                else request.FieldMask.Merge(c, maskedStock);
                resp.Stocks.Add(maskedStock);
            }
            resp.Result = new Result { Status = Status.Ok };
            return resp;
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ListStockResponse { Result = new Result { Status = Status.BadRequest } };
        }
    }
}

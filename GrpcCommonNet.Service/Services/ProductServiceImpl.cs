using Grpc.Core;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Product;
using GrpcCommonNet.Service.Models;
using GrpcCommonNet.Service.Repository;
using Microsoft.AspNetCore.Authorization;
using Status = GrpcCommonNet.Library.Common.Status;

[Authorize]
public class ProductServiceImpl : ProductServices.ProductServicesBase
{
    private readonly ProductRepository _repo;
    private readonly ILogger<ProductServiceImpl> _logger;

    public ProductServiceImpl(ProductRepository repo, ILogger<ProductServiceImpl> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    #region Методы для иерархии
    public override  async Task<TreeCatalogResponse>  TreeCatalog(CatalogFilterRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"ListContragents called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            TreeCatalogResponse response =  new TreeCatalogResponse();
            List<CatalogLine>  catalogLines = await _repo.TreeAsync(request, userData);

            foreach (var catalogLine in catalogLines)
            {
                CatalogLine maskcatalogLine = new CatalogLine();
                if (request.FieldMask == null || request.FieldMask.Paths.Count == 0)
                    maskcatalogLine = catalogLine;
                else
                    request.FieldMask.Merge(catalogLine, maskcatalogLine);
                response.Catalog.Add(maskcatalogLine);
                response.Result = new Result { Status = Status.Ok };
            }
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new TreeCatalogResponse { Result = new Result { Status = Status.BadRequest } };
        }

    }

    #endregion

    #region  Методы  для "товаров"

    public override async Task<ListProductsResponse> ListProducts(ProductFilterRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"ListContragents called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            ListProductsResponse response = new ListProductsResponse();
            List<Product> productLines = await _repo.ListAsync(request, userData);
            foreach (var productLine in productLines)
            {
                Product maskProductLine = new Product();
                if (request.FieldMask == null || request.FieldMask.Paths.Count == 0)
                    maskProductLine = productLine;
                else
                    request.FieldMask.Merge(productLine, maskProductLine);
                response.Products.Add(maskProductLine);
            }
            response.Result = new Result { Status = Status.Ok };
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ListProductsResponse { Result = new Result { Status = Status.BadRequest } };
        }
    }

    #endregion
}

using Grpc.Core;
using GrpcCommonNet.Library.Application;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.DocumentType;
using GrpcCommonNet.Service.Models;
using GrpcCommonNet.Service.Repository;
using Microsoft.AspNetCore.Authorization;
using Status = GrpcCommonNet.Library.Common.Status;

[Authorize]
public class DocumentTypeServiceImpl : DocumentTypeServices.DocumentTypeServicesBase
{
    private readonly DocumentTypeRepository _repo;
    private readonly ILogger<UserServiceImpl> _logger;

    public override async Task<DocumentTypeResponse> GetDocumentType(DocumentTypeRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"ListApplication called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            DocumentType docType = await _repo.GetByIdAsync(request.Id);
            if (docType != null)
            {
                DocumentTypeResponse response = new DocumentTypeResponse();
                DocumentType maskedDocumentType = new DocumentType();
                request.FieldMask.Merge(docType, maskedDocumentType);
                response.DocumentType = maskedDocumentType;
                response.Result = new Result { Status = Status.Ok };
                return response;
            }
            else return new DocumentTypeResponse { Result = new Result { Status = Status.NotFound } };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new DocumentTypeResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }


}

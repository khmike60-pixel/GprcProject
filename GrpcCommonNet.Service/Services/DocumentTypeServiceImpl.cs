using Grpc.Core;
using GrpcCommonNet.Library.Application;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Currency;
using GrpcCommonNet.Library.Department;
using GrpcCommonNet.Library.DocumentType;
using GrpcCommonNet.Service.Models;
using GrpcCommonNet.Service.Repository;
using Microsoft.AspNetCore.Authorization;
using Status = GrpcCommonNet.Library.Common.Status;

[Authorize]
public class DocumentTypeServiceImpl : DocumentTypeServices.DocumentTypeServicesBase
{
    private readonly DocumentTypeRepository _repo;
    private readonly ILogger<DocumentTypeServiceImpl> _logger;

    public DocumentTypeServiceImpl(DocumentTypeRepository repo, ILogger<DocumentTypeServiceImpl> logger)
    {
        _repo = repo;
        _logger = logger;
    }


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
                if (request.FieldMask != null)
                {
                    request.FieldMask.Merge(docType, maskedDocumentType);
                    response.DocumentType = maskedDocumentType;
                }
                else response.DocumentType = docType;
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

    public override async Task<ListDocumentTypeResponse> GetBranchDocumentTypes(DocumentTypeFilterRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"ListApplication called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            ListDocumentTypeResponse response = new ListDocumentTypeResponse();
            List<DocumentType> documentTypes = await _repo.GetBranchAsync(request.Head);
            if (documentTypes == null) 
                return new ListDocumentTypeResponse { Result = new Result { Status = Status.NotFound } };
            response.DocumentTypes.AddRange(documentTypes);
            response.Result = new Result { Status = Status.Ok };
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new ListDocumentTypeResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };

        }
    }

    public override async Task<DocumentTypeResponse> CreateDocumentType(CreateDocumentTypeRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"ListApplication called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        
        try
        {
            DocumentType docType = await _repo.CreateDocumentTypeAsync(request.DocumentType);
            if (docType != null)
            {
                DocumentTypeResponse response = new DocumentTypeResponse();
                DocumentType maskedDocumentType = new DocumentType();
                response.DocumentType = docType;
                response.Result = new Result { Status = Status.Ok };
                return response;
            }
            else return new DocumentTypeResponse { Result = new Result { Status = Status.NotFound } };


            return new DocumentTypeResponse { Result = new Result { Status = Status.Ok } };

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new DocumentTypeResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    public override async Task<DocumentTypeResponse> UpdateDocumentType(UpdateDocumentTypeRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"ListApplication called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            DocumentType docType = await _repo.UpdateDocumentTypeAsync(request.DocumentType);
            if (docType != null)
            {
                DocumentTypeResponse response = new DocumentTypeResponse();
                response.DocumentType = docType;
                response.Result = new Result { Status = Status.Ok };
                return response;
            }
            else 
                return new DocumentTypeResponse { Result = new Result { Status = Status.NotFound } };

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new DocumentTypeResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    public override async Task<DocumentTypeResponse> MoveDocumentType(MoveDocumentTypeRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"ListApplication called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            DocumentType documentType = await _repo.MoveDocumentTypeAsync(request.Id, request.NewParentId);
            if (documentType != null)
            {
                DocumentTypeResponse response = new DocumentTypeResponse();
                response.DocumentType = documentType;
                response.Result = new Result { Status = Status.Ok };
                return response;
            }
            else
            {
                return new DocumentTypeResponse { Result = new Result { Status = Status.NotFound } };
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new DocumentTypeResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };
        }
    }

    public override async Task<DeleteDocumentTypeResponse> DeleteDocumentType(DeleteDocumentTypeRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"DeleteCurrency called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");

        try
        {
            DeleteDocumentTypeResponse resp = new DeleteDocumentTypeResponse();

            var ok = await _repo.DeleteByIdAsync(request.Id);
            resp = new DeleteDocumentTypeResponse
            {
                Result = ok ? new Result { Status = Status.Ok } : new Result { Status = Status.NotFound }
            };
            return resp;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new DeleteDocumentTypeResponse { Result = new Result { Status = Status.BadRequest } };
        }
    }

    public override async Task<UndeletedIdsDocumentTypeResponse> DeleteIdsDocumentType(DeleteIdsDocumentTypeRequest request, ServerCallContext context)
    {
        UserData userData = new UserData().GetUserData(context);
        _logger.LogDebug($"UndeletedIdsDocumentType called: {request} UserData : " + "{" + $"User = {userData.User}, Application = {userData.Application}" + "}");
        try
        {
            UndeletedIdsDocumentTypeResponse resp = new UndeletedIdsDocumentTypeResponse();
            var ids = await _repo.DeleteIdsAsync(request.Ids);
            resp.UndeletedIds.AddRange(ids);
            resp.Result = new Result { Status = Status.Ok };
            return resp;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new UndeletedIdsDocumentTypeResponse { Result = new Result { Status = Status.BadRequest } };
        }
    }
}

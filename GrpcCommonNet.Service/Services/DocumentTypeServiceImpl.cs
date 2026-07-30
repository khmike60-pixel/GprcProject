using Grpc.Core;
using GrpcCommonNet.Service.Repository;
using Microsoft.AspNetCore.Authorization;

[Authorize]
public class DocumentTypeServiceImpl : DocumentTypeServices.DocumentTypeSericesBase
{
    private readonly DocumentTypeRepository _repo;
    private readonly ILogger<UserServiceImpl> _logger;

    public override async Task<DocumentTypeResponse> GetDocumentTypeAsync(DocumentTypeRequest request, ServerCallContext context)
    {
        return new DocumentTypeResponse();
    }
}

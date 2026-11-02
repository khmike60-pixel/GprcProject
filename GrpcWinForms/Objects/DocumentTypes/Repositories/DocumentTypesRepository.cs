using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.DocumentType;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Objects.DocumentTypes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.DocumentTypes.Repositories
{
    public class DocumentTypesRepository
    {
        public static async Task<List<TreeDocumentType>> GetDocumentTypes(DocumentType type)
        {
            try
            {
                var request = new DocumentTypeFilterRequest() 
                { 
                    Head = string.IsNullOrEmpty(type?.Code) ? string.Empty : type.Code, 
                    FieldMask = new FieldMask() 
                };
                request.FieldMask.Paths.AddRange(new[] { "id", "parent", "name", "code" });

                ListDocumentTypeResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.DocumentType.GetBranchDocumentTypesAsync(request).ResponseAsync);

                var treeItems = new List<TreeDocumentType>();
                foreach (var item in response.DocumentTypes)
                {
                    var tree = new TreeDocumentType()
                    {
                        Id = Convert.ToInt32(item.Id),
                        Name = item.Name,
                        ParentId = item.Parent.Id,
                        Code = item.Code
                    };
                    treeItems.Add(tree);
                }

                return treeItems;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetDocumentTypes: {ex.Message}", ex);
            }
        }
    }
}

using GrpcCommonNet.Library.Common;
using GrpcWinForms.Controls.TreeBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.StockDocuments.Models
{
    public class TreeDocumentType : ITreeData
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ParentId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DocumentType DocumentType { get; set; }
    }
}

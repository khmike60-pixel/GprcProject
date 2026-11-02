using GrpcCommonNet.Library.Common;
using GrpcWinForms.Controls.TreeBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.StockDocuments.Models
{
    public class TreeStockDocType : ITreeData
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public DocumentType DocumentType { get; set; }
    }
}

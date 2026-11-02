using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Proto.Utils;
using SmartLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.StockDocuments.Repositories
{
    public static class StockDocumentsRepository
    {

        public static async Task<List<StockOperation>> GetStockDocuments(
                Period period,
                Contragent contragentTo,
                Contragent contragentFrom,
                Stock stockTo,
                Stock stockFrom,
                DocumentType type,
                string number)
        {
            List<StockOperation> operations = new List<StockOperation>();
            
            return operations;
        }

        public static async Task<List<StockLocal>> GetStockLocalsAsync(Stock stock)
        {
            List<StockLocal> locals = new List<StockLocal>();
            return locals;
        }
    };
        

    public class StockLocal
    {
        int Id { get; set; }
        string Name { get; set; }
        int ParentId { get; set; }
    }
}

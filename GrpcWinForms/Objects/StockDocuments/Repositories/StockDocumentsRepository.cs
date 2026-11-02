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
            /*
            operations.Add(new StockOperation
            {
                Id = 1,
                DocumentType = type,
                Number = number,
                Date = Timestamp.FromDateTime(DateTime.UtcNow),
                Status = StatusOperation.New,
                ContragentTo = contragentTo,
                ContragentFrom = contragentFrom,
                StockTo = stockTo,
                StockFrom = stockFrom,
                SumOut = MyConvert.ToDecimalValue(1000),
                SumInp = MyConvert.ToDecimalValue(1000)
            });
            operations.Add(new StockOperation
            {
                Id = 1,
                DocumentType = type,
                Number = number,
                Date = Timestamp.FromDateTime(DateTime.UtcNow),
                Status = StatusOperation.New,
                ContragentTo = contragentTo,
                ContragentFrom = contragentFrom,
                StockTo = stockTo,
                StockFrom = stockFrom,
                SumOut = MyConvert.ToDecimalValue(1000),
                SumInp = MyConvert.ToDecimalValue(1000)
            });
            */
            return operations;
        }
    };
        

    public class StockLocal
    {
        int Id { get; set; }
        string Name { get; set; }
        int ParentId { get; set; }
    }
}

using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Geolocation;
using GrpcCommonNet.Library.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Stocks.Repositories
{
    public class StocksReposirory
    {
        public async Task<List<Stock>> GetStocksAsync(string name)
        {
            try
            {
                List<Stock> stocks = new();
                ListStockRequest request = new ListStockRequest()
                {

                };
                
                return stocks;
            }
            catch (Exception ex) 
            {
                throw new Exception($"Ошибка при получении списка складов: {ex.Message}", ex);
            }
        }
    }
}

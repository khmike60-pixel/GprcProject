using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Geolocation;
using GrpcCommonNet.Library.Stock;
using GrpcWinForms.GrpcUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GrpcWinForms.Objects.Stocks.Repositories
{
    public class StocksReposirory
    {
        public static async Task<List<Stock>> GetStocksAsync(string name)
        {
            try
            {
                ListStockRequest request = new ListStockRequest() {Name = name};
                ListStockResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Stock.GetListStockAsync(request).ResponseAsync); 
                if (response.Result.Status == Status.Ok) return new List<Stock>(response.Stocks);
                else return new List<Stock>();
            }
            catch (Exception ex) 
            {
                throw new Exception($"Ошибка при получении списка складов: {ex.Message}", ex);
            }
        }

        public static async Task<List<GeoPlace>> GetGeoPlacesAsync(Stock stock)
        {
            try
            {
                TreePlaceRequest request = new TreePlaceRequest() { Id = stock.Place.Id};
                TreePlaceResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Geolocation.GetTreePlaceAsync(request).ResponseAsync);
                if (response.Result.Status == Status.Ok) return new List<GeoPlace>(response.TreePlaces);
                else return new List<GeoPlace>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении списка мест хранения: {ex.Message}", ex);
            }

        }
    }
}

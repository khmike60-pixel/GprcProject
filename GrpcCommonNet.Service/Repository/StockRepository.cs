using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Stock;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System.Data.Common;

public class StockRepository
{
    private readonly string _connectionString = "";
    private readonly ILogger<StockRepository> _logger;

    public StockRepository(ILogger<StockRepository> logger, IConfiguration configuration)
    {
        _logger = logger;
        _connectionString = configuration.GetConnectionString("MySql");
    }

    public async Task<List<Stock>> GetListStocksAsync(ListStockRequest request)
    {
        try
        {
            List<Stock> stocks = new();
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = $@"
            select 
                s.*,
                p.place_name
            from cwatis.stocks s
                left join global_db.places p on p.place_id = s.place_id
            where 1 = 1
            ";

            using var rdr = await cmd.ExecuteReaderAsync();
            while (await rdr.ReadAsync())
                stocks.Add(FillStock(rdr));

            List<Stock> resultStocks = new();
            if (request.FieldMask != null && request.FieldMask.Paths.Count != 0)
            {
                foreach(Stock stock  in stocks)
                {
                    Stock item = new Stock();
                    request.FieldMask.Merge(stock, item);
                    resultStocks.Add(item);
                }
            }
            else {  resultStocks = stocks; }

            return resultStocks;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в GetListStocksAsync: " + ex.Message);
        }
    }

    

    private Stock FillStock(DbDataReader rdr)
    {
        Stock stock = new();
        stock.Id = rdr["stock_Id"] == DBNull.Value? 0: Convert.ToInt32(rdr["stock_Id"]);
        stock.Place = new Place()
        {
            Id = rdr["place_Id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["stock_Id"]),
            Name = rdr["place_name"].ToString()
        };
        stock.Name = rdr["stock_name"].ToString();

        return stock;
    }
}

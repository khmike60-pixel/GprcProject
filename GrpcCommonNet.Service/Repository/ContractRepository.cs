using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contract;
using GrpcCommonNet.Proto.Utils;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System.Data.Common;
using System.Reflection.Metadata;

public class ContractRepository
{
    private readonly string _connectionString = "";
    private readonly ILogger<ContractRepository> _logger;

    public ContractRepository(ILogger<ContractRepository> logger, IConfiguration configuration)
    {
        _logger = logger;
        _connectionString = configuration.GetConnectionString("MySql");
    }

    #region Методы работы с контрактами

    public async Task<Contract> GetByIdAsync(int id)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = $@"
                        SELECT 
                            c.* , l.*, 
                            u.Short,
                            cu.Abbrev
                        FROM cwatis.contracts c 
                            LEFT JOIN global_db.rfr_currency cu ON cu.currencyId = c.currencyId
                            LEFT JOIN cwatis.contractlines l ON c.contract_id = l.contract_Id
                            LEFT JOIN global_db.rfr_units u ON l.UnitId = u.UnitId
                        WHERE 1=1
                            and c.contract_id = {id}";
            using var rdr = await cmd.ExecuteReaderAsync();
            Contract contract = new Contract();

            if (await rdr.ReadAsync())
            {
                contract = FillContract(rdr);
            }
            return contract;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetByIdAsync: " + ex.Message);
            throw;
        }

    }

    public async Task<List<Contract>> GetListAsync(ListContractsRequest request)
    {
        try
        {
            DateTime dateStart = request.StartDate == null ? DateTime.MinValue: request.StartDate.ToDateTime().Date;
            DateTime dateEnd   = request.EndDate == null ? DateTime.MaxValue: request.EndDate.ToDateTime().Date;
            Contragent buyer   = request.Buyer;
            Contragent seller  = request.Seller;
            int stateFrom      = request.StateFrom;
            int stateTo        = request.StateTo;


            List<Contract> contracts = new List<Contract>();
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = $@"
                with cnt as (
                    SELECT c.*
                    FROM cwatis.contracts c
                    where c.contract_PreviousId is null
                )
                SELECT * 
                from cnt
                    left join cwatis.documenttypes c on c.DocumentType_Id = cnt.DocumentType_Id
                    LEFT JOIN global_db.rfr_currency cu ON cu.currencyId = cnt.currencyId
                where 
                    1 = 1
                order by cnt.contract_date desc;
            ";
            using var rdr = await cmd.ExecuteReaderAsync();

            while (await rdr.ReadAsync())
                contracts.Add(FillContract(rdr));
            
            return contracts;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetListAsync: " + ex.Message);
            throw;
        }
    }

    public async Task<List<Line>> GetListLinesAsync(ContractLineRequest request)
    {
        try
        {
            //var dict = new Dictionary<int, Contract>();
            List<Line> lines = new List<Line>();
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = $@"
                        SELECT 
                            l.contractline_id line_id, l.contractline_order line_order, 
                            l.contractline_Name line_Name, l.rfr_MGoodGroupId line_product_id, l.UnitId line_Unit_Id, u.Short line_Unit_Name, 
                            l.contractline_qty line_qty, l.contractline_price line_price, l.contractline_amount line_amount, 
                            l.contractline_vat_prc line_vat_per, l.contractline_sumvat line_sum_vat, l.contractline_sum line_sum,
                            1
                        FROM cwatis.contractlines l 
                            LEFT JOIN global_db.rfr_units u ON u.UnitId = l.UnitId
                            LEFT JOIN global_db.rfr_goods_tree g ON g.MGoodGroupId = l.rfr_MGoodGroupId
                        WHERE 1=1
                            and l.contract_id = {request.Id} 
                        ORDER BY contractline_order";
            using var rdr = await cmd.ExecuteReaderAsync();

            while(await rdr.ReadAsync())
                lines.Add(FillLine(rdr));

            return lines;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetListLinesAsync: " + ex.Message);
            throw;
        }
    }

    public async Task<List<Contract>> GetContractIerarchAsync(int root_id)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = $@"
                SELECT 
                    c.* ,
                    cu.Abbrev, t.DocumentType_Name,
                    1
                FROM cwatis.contracts c 
                    LEFT JOIN global_db.rfr_currency cu ON cu.currencyId = c.currencyId
                    LEFT JOIN cwatis.documenttypes t ON c.DocumentType_Id = t.DocumentType_Id
                WHERE 1=1
                and (c.contract_RootId = {root_id} Or c.contract_id = {root_id})
                ORDER BY c.contract_date ASC
            ";
            using var rdr = await cmd.ExecuteReaderAsync();
            
            List<Contract> contracts = new List<Contract>();
            while (await rdr.ReadAsync())
            {
                contracts.Add(FillContract(rdr));
            }

            return contracts;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetContractIerarchAsync: " + ex.Message);
            throw;
        }
    }


    #endregion

    #region внутренние методы   
    private Contract FillContract(DbDataReader rdr)
    {
        Contract contract = new Contract();
        contract.Id = rdr["contract_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["contract_id"]);
        contract.RootId = rdr["contract_rootid"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["contract_rootid"]);
        //contract.ParentId = rdr["contract_ParentId"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["contract_ParentId"]);
        contract.Seller = new Contragent()
        {
            Id = rdr["contract_sellerId"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["contract_sellerId"]),
            Name = rdr["contract_sellername"] == DBNull.Value ? "" : rdr["contract_sellername"].ToString() ?? ""
        };
        contract.Buyer = new Contragent()
        {
            Id = rdr["contract_buyerId"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["contract_buyerId"]),
            Name = rdr["contract_buyername"] == DBNull.Value ? "" : rdr["contract_buyername"].ToString() ?? ""
        };
        contract.Consignee = new Contragent()
        {
            Id = rdr["contract_consigneeId"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["contract_consigneeId"]),
            Name = rdr["contract_consigneename"] == DBNull.Value ? "" : rdr["contract_consigneename"].ToString() ?? ""
        };
        contract.Shipper = new Contragent()
        {
            Id = rdr["contract_shipperId"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["contract_shipperId"]),
            Name = rdr["contract_shippername"] == DBNull.Value ? "" : rdr["contract_shippername"].ToString() ?? ""
        };

        contract.Date = rdr["contract_date"] == DBNull.Value ? DateTime.MinValue.ToUniversalTime().ToTimestamp() : Convert.ToDateTime(rdr["contract_date"]).ToLocalTime().ToUniversalTime().ToTimestamp();
        contract.Number = rdr["contract_number"] == DBNull.Value ? "" : rdr["contract_number"].ToString() ?? "";

        contract.Currency = new Currency()
        {
            Id = rdr["currencyId"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["currencyId"]),
            Abbrev = rdr["Abbrev"] == DBNull.Value ? "" : rdr["Abbrev"].ToString() ?? ""
        };
        contract.Sum = rdr["Sum"] == DBNull.Value ? MyConvert.ToDecimalValue(0,2) : MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["Sum"]),2);
        contract.Amount = rdr["Amount"] == DBNull.Value ? MyConvert.ToDecimalValue(0, 2) : MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["Amount"]), 2);
        contract.SumVat = rdr["SumVat"] == DBNull.Value ? MyConvert.ToDecimalValue(0, 2) : MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["SumVat"]), 2);
        contract.TypeContract = new TypeContract()
        {
            TypeContractId = rdr["DocumentType_Id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["DocumentType_Id"]),
            //TypeContractName = rdr["ContractType_Name"] == DBNull.Value ? "" : rdr["ContractType_Name"].ToString() ?? ""
        };
        // Исправление: преобразование строки JSON в Struct
        if (rdr["contract_data"] == DBNull.Value || string.IsNullOrWhiteSpace(rdr["contract_data"].ToString()))
        {
            contract.Data = new Google.Protobuf.WellKnownTypes.Struct();
        }
        else
        {
            contract.Data = Google.Protobuf.WellKnownTypes.Struct.Parser.ParseJson(rdr["contract_data"].ToString() ?? "");
        }

        return contract;
    }

    private Line FillLine(DbDataReader rdr)
    {
        Line line = new Line();

        line.Id = rdr["line_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["line_id"]);
        line.Order = rdr["line_order"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["line_order"]);
        line.Product = new Product()
        {
            Id = rdr["line_product_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["line_product_id"])
        };
        line.Name = rdr["line_name"] == DBNull.Value ? "" : Convert.ToString(rdr["line_name"]);
        line.Unit = new Unit()
        {
            Id = rdr["line_unit_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["line_unit_id"]),
            Short = rdr["line_Unit_Name"] == DBNull.Value ? "" : Convert.ToString(rdr["line_Unit_Name"])
        };
        line.Qty = rdr["line_qty"] == DBNull.Value ? MyConvert.ToDecimalValue(0, 2) : MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["line_qty"]), 2);
        line.Price = rdr["line_price"] == DBNull.Value ? MyConvert.ToDecimalValue(0, 2) : MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["line_price"]), 2);
        line.Amount = rdr["line_amount"] == DBNull.Value ? MyConvert.ToDecimalValue(0, 2) : MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["line_amount"]), 2);
        line.VatPrc = rdr["line_vat_per"] == DBNull.Value ? MyConvert.ToDecimalValue(0, 2) : MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["line_vat_per"]), 2);
        line.SumVat = rdr["line_sum_vat"] == DBNull.Value ? MyConvert.ToDecimalValue(0, 2) : MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["line_sum_vat"]), 2);
        line.Sum = rdr["line_sum"] == DBNull.Value ? MyConvert.ToDecimalValue(0, 2) : MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["line_sum"]), 2);


        return line;
    }

    private async Task<List<Contract>> Fill(DbDataReader rd, Dictionary<int, Contract> dict)
    {
        List<Contract> result = new List<Contract>();
        while (await rd.ReadAsync())
        {
            int docId = rd["contract_id"] == DBNull.Value ? 0 : Convert.ToInt32(rd["contract_id"]);
            Contract contract;


            if (!dict.TryGetValue(docId, out contract))
            {
                contract = FillContract(rd);
                dict.Add(docId, contract);
                //result.Add(contract);
            }

            // если строка существует (LEFT JOIN может дать NULL)
            if (rd["contractline_id"] != DBNull.Value)
            {
                var line = new Line();

                line.Id = Convert.ToInt32(rd["contractline_id"]);
                line.Order = Convert.ToInt32(rd["contractline_order"]);
                line.Name = rd["contractline_name"] == DBNull.Value ? "" : Convert.ToString(rd["contractline_name"]);
                line.Unit = new Unit()
                {
                    Id = rd["UnitId"] == DBNull.Value ? 0 : Convert.ToInt32(rd["UnitId"]),
                    Short = rd["Short"] == DBNull.Value ? "" : Convert.ToString(rd["Short"])
                };
                line.Qty = rd["contractline_qty"] == DBNull.Value ? MyConvert.ToDecimalValue(0, 2) : MyConvert.ToDecimalValue(Convert.ToDecimal(rd["contractline_qty"]), 2);
                line.Price = rd["contractline_price"] == DBNull.Value ? MyConvert.ToDecimalValue(0, 2) : MyConvert.ToDecimalValue(Convert.ToDecimal(rd["contractline_price"]), 2);
                line.Sum = rd["contractline_amount"] == DBNull.Value ? MyConvert.ToDecimalValue(0, 2) : MyConvert.ToDecimalValue(Convert.ToDecimal(rd["contractline_amount"]), 2);
                line.VatPrc = rd["contractline_vat_prc"] == DBNull.Value ? MyConvert.ToDecimalValue(0, 2) : MyConvert.ToDecimalValue(Convert.ToDecimal(rd["contractline_vat_prc"]), 2);
                line.SumVat = rd["contractline_sumvat"] == DBNull.Value ? MyConvert.ToDecimalValue(0, 2) : MyConvert.ToDecimalValue(Convert.ToDecimal(rd["contractline_sumvat"]), 2);
                line.Sum = rd["contractline_sum"] == DBNull.Value ? MyConvert.ToDecimalValue(0, 2) : MyConvert.ToDecimalValue(Convert.ToDecimal(rd["contractline_sum"]), 2);


                contract.Lines.Add(line);
                result.Add(contract);
            }
        }
        return result;
    }

    #endregion

}

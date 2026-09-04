using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contract;
using GrpcCommonNet.Proto.Utils;
using GrpcCommonNet.Service.Models;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using System.Text;
using System.Xml.Linq;
using Contract = GrpcCommonNet.Library.Contract.Contract;
using Metadata = GrpcCommonNet.Library.Contract.Metadata;

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
                            c.* , 
                            -- l.*, 
                            -- u.Short,
                            cu.Abbrev, t.DocumentType_Name, t.DocumentType_Code as DocumentType_Code,
                            t.DocumentType_Form as DocumentType_Form
                        FROM cwatis.contracts c 
                            LEFT JOIN global_db.rfr_currency cu ON cu.currencyId = c.currencyId
                            left join cwatis.documenttypes t ON c.DocumentType_Id = t.DocumentType_Id
                            -- LEFT JOIN cwatis.contractlines l ON c.contract_id = l.contract_Id
                            -- LEFT JOIN global_db.rfr_units u ON l.UnitId = u.UnitId
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

    public async Task<Contract> GetContractFullAsync(GetContractRequest request)
    {
        try
        {
            bool noDeletedLines = request.NoDeletedLines;
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = $@"
                SELECT 
                    c.* ,
                    if(cd.ContractDoc_Id is not null, true, false) as haveDoc,
                    cu.Abbrev, 
                    t.DocumentType_Name as DocumentType_Name, 
                    t.DocumentType_Code as DocumentType_Code,
                    t.DocumentType_Form as DocumentType_Form
                FROM cwatis.contracts c 
                    LEFT JOIN global_db.rfr_currency cu ON cu.currencyId = c.currencyId
                    left join cwatis.documenttypes t ON c.DocumentType_Id = t.DocumentType_Id
                    left join cwatis.contractdocs cd on cd.contract_id = c.contract_id  
                WHERE 1=1
                    and c.contract_id = {request.ContractId};
                SELECT
                    l.contractline_id line_id, l.contractline_order line_order, l.operation, l.contract_id,
                    l.contractline_Name line_Name, l.rfr_MGoodGroupId line_product_id, l.UnitId line_Unit_Id, u.Short line_Unit_Name, 
                    l.contractline_qty line_qty, l.contractline_price line_price, 
                    l.contractline_vat_prc line_vat_per, 
                    if(l.Operation = 'удалена', 0, l.contractline_amount) line_amount, 
                    if(l.Operation = 'удалена', 0, l.contractline_sumvat) line_sum_vat, 
                    if(l.Operation = 'удалена', 0, l.contractline_sum) line_sum,
                    u.Short
                FROM cwatis.contractlines l
                    left join global_db.rfr_units u on l.UnitId = u.UnitId
                where 1 = 1
                    and l.contract_id = {request.ContractId}
                    and (!{noDeletedLines} or l.Operation != 'удалена');
                ";
            using var rdr = await cmd.ExecuteReaderAsync();
            Contract contract = new Contract();

            if (await rdr.ReadAsync())
            {
                contract = FillContract(rdr);
            }
            if (await rdr.NextResultAsync())
            {
                while (await rdr.ReadAsync())
                {
                    contract.Lines.Add(FillLine(rdr));
                }

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
            DateTime dateStart = request.StartDate == null ? DateTime.MinValue : request.StartDate.ToDateTime().ToLocalTime();
            DateTime dateEnd = request.EndDate == null ? DateTime.MaxValue : request.EndDate.ToDateTime().ToLocalTime();
            Contragent buyer = request.Buyer;
            Contragent seller = request.Seller;
            int stateFrom = request.StateFrom;
            int stateTo = request.StateTo;
            bool withAdd = request.WithAdd;


            List<Contract> contracts = new List<Contract>();
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = $@"
            WITH curr_contracts AS (
                SELECT 
                    c.contract_id,
                    c.contract_rootid,
                    c.contract_date,
                    c.contract_number,
                    c.DocumentType_Id,
                    c.CurrencyId,
                    c.sum,
                    ROW_NUMBER() OVER (
                        PARTITION BY COALESCE(c.contract_rootid, c.contract_id) 
                        ORDER BY c.contract_date DESC, c.contract_id
                    ) AS rn
                FROM cwatis.contracts c
            )
            select 
                c.contract_id,
                t.DocumentType_Name as DocumentType_Name,
                t.DocumentType_Code as DocumentType_Code,
                t.DocumentType_Form as DocumentType_Form,
                c.contract_Date as Date,
                curr.sum,
                c.contract_RootId as RootId,
                cu.Abbrev as Abbrev,
                c.*	
            from cwatis.contracts c  
                right join curr_contracts curr on COALESCE(curr.contract_rootid, curr.contract_id) = c.contract_id
                left join cwatis.documenttypes t on t.DocumentType_Id = c.DocumentType_Id
                left join global_db.rfr_currency cu ON cu.currencyId = c.currencyId
            where 1 = 1 
                and c.contract_Date >= @startdate and c.contract_Date <= @enddate
                and curr.rn = 1

            union

            select 
                c.contract_id,
                t.DocumentType_Name as DocumentType_Name,
                t.DocumentType_Code as DocumentType_Code,
                t.DocumentType_Form as DocumentType_Form,
                c.contract_Date as Date,
                c.Sum,
                c.contract_RootId as RootId,
                cu.Abbrev as Abbrev,
                c.*
            from cwatis.contracts c
                left join cwatis.documenttypes t on t.DocumentType_Id = c.DocumentType_Id
                left join global_db.rfr_currency cu ON cu.currencyId = c.currencyId
            where 
                1 = 1
                and ifnull(@withAdd,false)
                and c.contract_Date >= @startdate and c.contract_Date <= @enddate
                and c.contract_RootId is not null

            order by RootId, Date desc;
                        ";

            cmd.Parameters.AddWithValue("@startdate", dateStart);
            cmd.Parameters.AddWithValue("@enddate", dateEnd);
            cmd.Parameters.AddWithValue("@withAdd", withAdd);

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

    public async Task<List<Contract>> GetContractHistoryAsync(int id)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = $@"
                with root_contract as (
	                select 
		                COALESCE(c.contract_rootid, c.contract_id) root
	                from cwatis.contracts c
	                where 1= 1 
		                and c.contract_id = {id}
                    )
                select
	                cu.Abbrev, 
	                t.DocumentType_Name, t.DocumentType_Code as DocumentType_Code, t.DocumentType_Form as DocumentType_Form,
	                c.*
                from cwatis.contracts c 
	                left join root_contract r on COALESCE(c.contract_rootid, c.contract_id) = r.root
                    LEFT JOIN global_db.rfr_currency cu ON cu.currencyId = c.currencyId
	                LEFT JOIN cwatis.documenttypes t ON c.DocumentType_Id = t.DocumentType_Id
                where COALESCE(c.contract_rootid, c.contract_id) = r.root
                order by c.contract_Date desc;
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

    public async Task<Contract> UpdateContractAsync(Contract _contract)
    {
        Contract contract = new Contract();
        contract = _contract;
        try
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                                    UPDATE cwatis.contracts set 
                                        contract_RootId = @RootId, 
                                        contract_PreviousId = @PrevId, 
                                        contract_SellerId = @SellerId, contract_SellerName = @SellerName, contract_SellerSignId = @SellerSignId, contract_SellerBAccountId = @SellerBAcctId, 
                                        contract_BuyerId = @BuyerId, contract_BuyerName = @BuyerName, contract_BuyerSignId = @BuyerSignId, contract_BuyerBAccountId = @BuyerBAcctId, 
                                        contract_ShipperId = @ShipperId, contract_ShipperName = @ShipperName, 
                                        contract_ConsigneeId = @ConsigneeId, contract_ConsigneeName = @ConsigneeName,
                                        Initiator_Id = @InitId, Initiator_Name = @InitName, Executor_Id = @ExecId, Executor_Name = @ExecName, 
                                        contract_Date = @CDate, contract_ExpirationDate = @ExpDate,
                                        contract_Number = @CNumber, contract_Name = @CName, contract_DocName = @DocName, 
                                        CurrencyId = @CurrId, CurrencyPaymentId = @CurrPayId, 
                                        Sum = @Sum, Amount = @Amount, SumVat = @SumVat, IsVat = @IsVat, VatPrc = @VatPrc, 
                                        contract_State = @CState, contract_data = @CData, IsContract = @IsCont, IsOrder = @IsOrd, DocumentType_Id = @DocTypeId, 
                                        SDid = @SDid,
                                        ProjectTypes = @ProjTypes, TemplDoc_Id = @TemplDocId, Comment = @Comment, 
                                        create_at = @CreateAt, create_by = @CreateBy, create_userid = @CreateUid, 
                                        Contract_SignPlaceId = @SignPlaceId
                                    where contract_id = @Id;

                                    SELECT 
                                        c.* ,
                                        if(cd.ContractDoc_Id is not null, true, false) as haveDoc,
                                        cu.Abbrev, 
                                        t.DocumentType_Name as DocumentType_Name, 
                                        t.DocumentType_Code as DocumentType_Code,
                                        t.DocumentType_Form as DocumentType_Form
                                    FROM cwatis.contracts c 
                                        LEFT JOIN global_db.rfr_currency cu ON cu.currencyId = c.currencyId
                                        left join cwatis.documenttypes t ON c.DocumentType_Id = t.DocumentType_Id
                                        left join cwatis.contractdocs cd on cd.contract_id = c.contract_id  
                                    WHERE 1=1
                                        and c.contract_id = @Id;
                                    ";

                MySqlParameterCollection p = cmd.Parameters;
                p.AddWithValue("@Id", contract.Id);
                p.AddWithValue("@RootId", contract.RootId == 0 ? null : contract.RootId);
                p.AddWithValue("@PrevId", contract.PreviousId == 0 ? null : contract.PreviousId);
                p.AddWithValue("@SellerId", contract.Seller.Id == 0 ? null : contract.Seller.Id);
                p.AddWithValue("@SellerName", contract.Seller.Name);
                p.AddWithValue("@SellerSignId", contract.Seller.Entity?.Signatory.Id == 0 ? null : contract.Seller.Entity?.Signatory.Id);
                p.AddWithValue("@SellerBAcctId", null);                         // _contract.SellerBAccountId 
                p.AddWithValue("@BuyerId", contract.Buyer.Id == 0 ? null : contract.Buyer.Id);
                p.AddWithValue("@BuyerName", contract.Buyer.Name);
                p.AddWithValue("@BuyerSignId", contract.Buyer.Entity?.Signatory.Id);
                p.AddWithValue("@BuyerBAcctId", null);            // _contract.BuyerBAccountId
                p.AddWithValue("@ShipperId", contract.Shipper.Id == 0 ? null : contract.Shipper.Id);
                p.AddWithValue("@ShipperName", contract.Shipper.Name);
                p.AddWithValue("@ConsigneeId", contract.Consignee.Id == 0 ? null : contract.Consignee.Id);
                p.AddWithValue("@ConsigneeName", contract.Consignee?.Name);
                p.AddWithValue("@InitId", contract.Initiator.Id == 0 ? null : contract.Initiator.Id);
                p.AddWithValue("@InitName", contract.Initiator?.Name);
                p.AddWithValue("@ExecId", contract.Executor.Id == 0 ? null : contract.Executor.Id);
                p.AddWithValue("@ExecName", contract.Executor?.Name);
                p.AddWithValue("@CDate", contract.Date ==  null ? null : contract.Date.ToDateTime().ToLocalTime());
                p.AddWithValue("@ExpDate", contract.ExpirationDate == null ? null: contract.ExpirationDate.ToDateTime().ToLocalTime()) ;
                p.AddWithValue("@CNumber", contract.Number);
                p.AddWithValue("@CName", contract.Name);
                p.AddWithValue("@DocName", contract.DocName);
                p.AddWithValue("@CurrId", contract.Currency.Id ==  0 ? null : contract.Currency.Id);
                p.AddWithValue("@CurrPayId", contract.CurrencyPayment?.Id);
                p.AddWithValue("@Sum", MyConvert.ToDecimal(contract.Sum));
                p.AddWithValue("@Amount", MyConvert.ToDecimal(contract.Amount));
                p.AddWithValue("@SumVat", MyConvert.ToDecimal(contract.SumVat));
                p.AddWithValue("@IsVat", contract.IsVat);
                p.AddWithValue("@VatPrc", MyConvert.ToDecimal(contract.VatPrc));
                p.AddWithValue("@CState", contract.State);
                p.AddWithValue("@CData", contract.Data?.ToString()); // JSON как строка
                p.AddWithValue("@IsCont", null);                    // _contract.IsContract
                p.AddWithValue("@IsOrd", null);        // _contract.IsOrder
                p.AddWithValue("@DocTypeId", contract.TypeContract.Id);
                p.AddWithValue("@SDid", contract.Department?.Id);
                p.AddWithValue("@ProjTypes", contract.ManagerType.ToString()); // Enum в строку
                p.AddWithValue("@TemplDocId", null);               // _contract.TemplDocId
                p.AddWithValue("@Comment", contract.Comment);
                p.AddWithValue("@CreateAt", contract.Metadata?.CreateAt);
                p.AddWithValue("@CreateBy", contract.Metadata?.CreateBy);
                p.AddWithValue("@CreateUid", contract.Metadata?.CreateUserid == 0 ? null : contract.Metadata?.CreateUserid);
                p.AddWithValue("@SignPlaceId", contract.PlaceSigned?.Id);

                using var rdr = await cmd.ExecuteReaderAsync();
                contract = new Contract();

                if (await rdr.ReadAsync())
                    contract = FillContract(rdr);
                else contract = _contract;
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при обновлении контракта.", ex);
        }
        return contract;
    }

    public async Task<Contract> CreateContractAsync(Contract _contract)
    {
        Contract contract = new Contract();
        contract = _contract;
        try
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                                    INSERT INTO cwatis.contracts (
                                        contract_RootId, 
                                        contract_PreviousId , 
                                        contract_SellerId , contract_SellerName , contract_SellerSignId , contract_SellerBAccountId , 
                                        contract_BuyerId , contract_BuyerName , contract_BuyerSignId , contract_BuyerBAccountId , 
                                        contract_ShipperId , contract_ShipperName , 
                                        contract_ConsigneeId , contract_ConsigneeName ,
                                        Initiator_Id , Initiator_Name , Executor_Id , Executor_Name , 
                                        contract_Date , contract_ExpirationDate ,
                                        contract_Number , contract_Name , contract_DocName , 
                                        CurrencyId , CurrencyPaymentId , 
                                        Sum , Amount , SumVat , IsVat , VatPrc , 
                                        contract_State , contract_data , IsContract , IsOrder , DocumentType_Id , 
                                        SDid ,
                                        ProjectTypes , TemplDoc_Id , Comment , 
                                        create_at , create_by , create_userid , 
                                        Contract_SignPlaceId 
                                    )
                                    VALUES (
                                        @RootId, 
                                        @PrevId, 
                                        @SellerId, @SellerName, @SellerSignId, @SellerBAcctId, 
                                        @BuyerId, @BuyerName, @BuyerSignId, @BuyerBAcctId, 
                                        @ShipperId, @ShipperName, 
                                        @ConsigneeId, @ConsigneeName,
                                        @InitId, @InitName, @ExecId, @ExecName, 
                                        @CDate, @ExpDate,
                                        @CNumber, @CName, @DocName, 
                                        @CurrId, @CurrPayId, 
                                        @Sum, @Amount, @SumVat, @IsVat, @VatPrc, 
                                        @CState, @CData, @IsCont, @IsOrd, @DocTypeId, 
                                        @SDid,
                                        @ProjTypes, @TemplDocId, @Comment, 
                                        @CreateAt, @CreateBy, @CreateUid, 
                                        @SignPlaceId
                                    );
                                    SELECT 
                                        c.* ,
                                        if(cd.ContractDoc_Id is not null, true, false) as haveDoc,
                                        cu.Abbrev, 
                                        t.DocumentType_Name as DocumentType_Name, 
                                        t.DocumentType_Code as DocumentType_Code,
                                        t.DocumentType_Form as DocumentType_Form
                                    FROM cwatis.contracts c 
                                        LEFT JOIN global_db.rfr_currency cu ON cu.currencyId = c.currencyId
                                        left join cwatis.documenttypes t ON c.DocumentType_Id = t.DocumentType_Id
                                        left join cwatis.contractdocs cd on cd.contract_id = c.contract_id  
                                    WHERE 1=1
                                        and c.contract_id = LAST_INSERT_ID();
                                    ";

                MySqlParameterCollection p = cmd.Parameters;

                p.AddWithValue("@RootId", contract.RootId == 0 ? null : contract.RootId);
                p.AddWithValue("@PrevId", contract.PreviousId == 0 ? null : contract.PreviousId);
                p.AddWithValue("@SellerId", contract.Seller?.Id);
                p.AddWithValue("@SellerName", contract.Seller?.Name);
                p.AddWithValue("@SellerSignId", contract.Seller?.Entity?.Signatory.Id);
                p.AddWithValue("@SellerBAcctId", null);                         // _contract.SellerBAccountId 
                p.AddWithValue("@BuyerId", contract.Buyer?.Id);
                p.AddWithValue("@BuyerName", contract.Buyer?.Name);
                p.AddWithValue("@BuyerSignId", contract.Buyer?.Entity?.Signatory.Id);
                p.AddWithValue("@BuyerBAcctId", null);            // _contract.BuyerBAccountId
                p.AddWithValue("@ShipperId", contract.Shipper?.Id);
                p.AddWithValue("@ShipperName", contract.Shipper?.Name);
                p.AddWithValue("@ConsigneeId", contract.Consignee?.Id);
                p.AddWithValue("@ConsigneeName", contract.Consignee?.Name);
                p.AddWithValue("@InitId", contract.Initiator?.Id == 0 ? null : contract.Initiator?.Id);
                p.AddWithValue("@InitName", contract.Initiator?.Name);
                p.AddWithValue("@ExecId", contract.Executor?.Id == 0 ? null : contract.Executor?.Id);
                p.AddWithValue("@ExecName", contract.Executor?.Name);
                p.AddWithValue("@CDate", contract.Date.ToDateTime() == DateTime.MinValue ? null : contract.Date.ToDateTime());
                p.AddWithValue("@ExpDate", contract.ExpirationDate.ToDateTime() == DateTime.MinValue ? null : contract.ExpirationDate.ToDateTime());
                p.AddWithValue("@CNumber", contract.Number);
                p.AddWithValue("@CName", contract.Name);
                p.AddWithValue("@DocName", contract.DocName);
                p.AddWithValue("@CurrId", contract.Currency?.Id == 0 ? null : contract.Currency?.Id);
                p.AddWithValue("@CurrPayId", contract.CurrencyPayment?.Id);
                p.AddWithValue("@Sum", MyConvert.ToDecimal(contract.Sum));
                p.AddWithValue("@Amount", MyConvert.ToDecimal(contract.Amount));
                p.AddWithValue("@SumVat", MyConvert.ToDecimal(contract.SumVat));
                p.AddWithValue("@IsVat", contract.IsVat);
                p.AddWithValue("@VatPrc", MyConvert.ToDecimal(contract.VatPrc));
                p.AddWithValue("@CState", contract.State);
                p.AddWithValue("@CData", contract.Data?.ToString()); // JSON как строка
                p.AddWithValue("@IsCont", null);                    // _contract.IsContract
                p.AddWithValue("@IsOrd", null);        // _contract.IsOrder
                p.AddWithValue("@DocTypeId", contract.TypeContract.Id);
                p.AddWithValue("@SDid", contract.Department?.Id);
                p.AddWithValue("@ProjTypes", contract.ManagerType.ToString()); // Enum в строку
                p.AddWithValue("@TemplDocId", null);               // _contract.TemplDocId
                p.AddWithValue("@Comment", contract.Comment);
                p.AddWithValue("@CreateAt", contract.Metadata?.CreateAt);
                p.AddWithValue("@CreateBy", contract.Metadata?.CreateBy);
                p.AddWithValue("@CreateUid", contract.Metadata?.CreateUserid == 0 ? null : contract.Metadata?.CreateUserid);
                p.AddWithValue("@SignPlaceId", contract.PlaceSigned?.Id);

                using var rdr = await cmd.ExecuteReaderAsync();
                contract = new Contract();

                if (await rdr.ReadAsync())
                    contract = FillContract(rdr);
                else contract = _contract;
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при создании нового контракта.", ex);
        }
        return contract;
    }

    public async Task<List<NodeContract>> GetTreeNodesAsync(ListContractsRequest request)
    {
        try
        {
            DateTime dateStart = request.StartDate == null ? DateTime.MinValue : request.StartDate.ToDateTime().ToLocalTime();
            DateTime dateEnd = request.EndDate == null ? DateTime.MaxValue : request.EndDate.ToDateTime().ToLocalTime();
            Contragent buyer = request.Buyer;
            Contragent seller = request.Seller;
            int stateFrom = request.StateFrom;
            int stateTo = request.StateTo;
            bool withAdd = request.WithAdd;


            List<NodeContract> nodes = new List<NodeContract>();
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using (MySqlCommand cmd = new MySqlCommand("cwatis.Contract_Tree_Get", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("_Start", dateStart);
                cmd.Parameters.AddWithValue("_End", dateEnd);
                cmd.Parameters.AddWithValue("_WithAgreement", withAdd);

                using var rdr = await cmd.ExecuteReaderAsync();

                while (await rdr.ReadAsync())
                    nodes.Add(FillNodeContract(rdr));
            }

            return nodes;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetTreeNodesAsync: " + ex.Message);
            throw;
        }
    }


    #endregion

    #region Методы  работы  со  строками 
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
                                        l.contractline_id line_id, l.contractline_order line_order, l.operation,l.contract_id,
                                        l.contractline_Name line_Name, l.rfr_MGoodGroupId line_product_id, l.UnitId line_Unit_Id, u.Short line_Unit_Name, 
                                        l.contractline_qty line_qty, l.contractline_price line_price, l.contractline_amount line_amount, 
                                        l.contractline_vat_prc line_vat_per, l.contractline_sumvat line_sum_vat, l.contractline_sum line_sum,
                                        1
                                    FROM cwatis.contractlines l 
                                        LEFT JOIN global_db.rfr_units u ON u.UnitId = l.UnitId
                                        LEFT JOIN global_db.rfr_goods_tree g ON g.MGoodGroupId = l.rfr_MGoodGroupId
                                    WHERE 1=1
                                        and l.contract_id = {request.Id} 
                                        and (ifnull(@All,false) = true or l.operation != 'удалена')
                                    ORDER BY contractline_order";
            cmd.Parameters.AddWithValue("@All", request.All);

            using var rdr = await cmd.ExecuteReaderAsync();

            while (await rdr.ReadAsync())
                lines.Add(FillLine(rdr));

            return lines;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetListLinesAsync: " + ex.Message);
            throw;
        }
    }

    public async Task<Line> CreateContractLineAsync(CreateContractLineRequest request, UserData userData)
    {
        try
        {
            Line line = new Line();

            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = $@"
                                    INSERT INTO cwatis.contractlines (
                                        contractline_order, operation, contract_id,
                                        contractline_Name, rfr_MGoodGroupId, UnitId, 
                                        contractline_qty, contractline_price, contractline_amount, 
                                        contractline_vat_prc, contractline_sumvat, contractline_sum,
                                        comment, RoundForLine, Specification, Added_From, 
                                        SupplierId, contractline_baseDiscount, DiscountAdditional, 
                                        contractline_baseprice

                                    )
                                    VALUES  (
                                        @line_order, @operation, @contract_id,
                                        @line_Name, @line_product_id, @line_Unit_Id, 
                                        @line_qty, @line_price, @line_amount, 
                                        @line_vat_per, @line_sum_vat, @line_sum,
                                        @comment, @RoundForLine, @Specification, @Added_From, 
                                        @SupplierId,  @line_baseDiscount, @line_DiscountAdditional, 
                                        @line_baseprice
                                    );

                                    SELECT
                                        l.contractline_id line_id, l.contractline_order line_order, l.operation,l.contract_id,
                                        l.contractline_Name line_Name, l.rfr_MGoodGroupId line_product_id, l.UnitId line_Unit_Id, u.Short line_Unit_Name, 
                                        l.contractline_qty line_qty, l.contractline_price line_price, l.contractline_amount line_amount, 
                                        l.contractline_vat_prc line_vat_per, l.contractline_sumvat line_sum_vat, l.contractline_sum line_sum,
                                        l.comment, l.RoundForLine, l.Specification, l.Added_From, 
                                        l.SupplierId, l.contractline_baseDiscount, l.DiscountAdditional, 
                                        l.contractline_baseprice,
                                        1
                                    FROM cwatis.contractlines l 
                                        LEFT JOIN global_db.rfr_units u ON u.UnitId = l.UnitId
                                        LEFT JOIN global_db.rfr_goods_tree g ON g.MGoodGroupId = l.rfr_MGoodGroupId
                                    WHERE 1=1
                                        and l.contractline_id = LAST_INSERT_ID() 
                                    ORDER BY contractline_order";

            cmd.Parameters.AddWithValue("line_order", request.Line.Id);
            cmd.Parameters.AddWithValue("operation", request.Line.Operation);
            cmd.Parameters.AddWithValue("contract_id", request.Line.ContractId);
            cmd.Parameters.AddWithValue("line_Name", request.Line.Name);
            cmd.Parameters.AddWithValue("line_product_id", request.Line.Product?.Id);
            cmd.Parameters.AddWithValue("line_Unit_Id", request.Line.Unit?.Id);
            cmd.Parameters.AddWithValue("line_qty", request.Line.Qty);
            cmd.Parameters.AddWithValue("line_price", request.Line.Price);
            cmd.Parameters.AddWithValue("line_amount", request.Line.Amount);
            cmd.Parameters.AddWithValue("line_vat_per", request.Line.VatPrc);
            cmd.Parameters.AddWithValue("line_sum_vat", request.Line.SumVat);
            cmd.Parameters.AddWithValue("line_sum", request.Line.Sum);
            cmd.Parameters.AddWithValue("comment", request.Line.Comment);
            cmd.Parameters.AddWithValue("RoundForLine", request.Line.RoundForLine);
            cmd.Parameters.AddWithValue("Specification", request.Line.Specification);
            cmd.Parameters.AddWithValue("Added_From", request.Line.AddedFrom);
            cmd.Parameters.AddWithValue("SupplierId", request.Line.Supplier?.Id);
            cmd.Parameters.AddWithValue("line_baseDiscount", request.Line.BaseDiscount);
            cmd.Parameters.AddWithValue("line_DiscountAdditional", request.Line.DiscountAdditional);
            cmd.Parameters.AddWithValue("line_baseprice", request.Line.BasePrice);
            using var rdr = await cmd.ExecuteReaderAsync();

            if (await rdr.ReadAsync())
                line = FillLine(rdr);

            return line;
        } catch (Exception  ex)
        {
            _logger.LogError(ex, "Error in CreateContractLineAsync: " + ex.Message);
            throw;
        }
    }

    public async Task<Line> UpdateLineAsync(UpdateContractLineRequest request,  UserData userData)
    {
        try
        {
            List<string> updateFields = new List<string>();
            var parameters = new List<MySqlParameter> { new MySqlParameter("@id", request.Line.Id) };
            if (request.FieldMask == null || request.FieldMask.Paths.Count == 0)
                updateFields = AllFieldsLine(request.Line, parameters);
            else
                updateFields = MappingLine(request.Line, parameters, request.FieldMask.Paths.ToList());

            // Защита от ситуации, когда маска передана, но в ней нет валидных полей
            if (updateFields.Count == 0)
                throw new Exception(string.Join(Environment.NewLine, "UpdateMask пуста."));

            string sql = 
                $@"UPDATE cwatis.contractlines SET {string.Join(", ", updateFields)} WHERE contractline_id = {request.Line.Id}; "+ 
                $@"SELECT
                    l.contractline_id line_id, l.contractline_order line_order, l.operation,l.contract_id, l.contractline_PreviousId line_previousid,
                    l.contractline_Name line_Name, l.rfr_MGoodGroupId line_product_id, l.UnitId line_Unit_Id, u.Short line_Unit_Name,
                    l.contractline_qty line_qty, l.contractline_price line_price, l.contractline_amount line_amount, l.IsVat IsVat,
                    l.contractline_vat_prc line_vat_per, l.contractline_sumvat line_sum_vat, l.contractline_sum line_sum,
                    l.comment, l.RoundForLine, l.Specification, l.Added_From, 
                    l.SupplierId, l.contractline_baseDiscount, l.DiscountAdditional, 
                    l.contractline_baseprice,
--                  u.Abbrev as Unit_Abbrev, g.MGoodGroupName as Product_Name, g.MGoodGroupCode as Product_Code,
                    1
                FROM cwatis.contractlines l
                    LEFT JOIN global_db.rfr_units u ON u.UnitId = l.UnitId
                    LEFT JOIN global_db.rfr_goods_tree g ON g.MGoodGroupId = l.rfr_MGoodGroupId
                WHERE 1 = 1
                    and l.contractline_id = {request.Line.Id}
                ORDER BY contractline_order;
                select 
                    c.sum, c.sumvat, c.amount
                from cwatis.contracts c
                where c.contract_id = {request.Line.ContractId}
                ";

            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = sql;
            cmd.Parameters.AddRange(parameters.ToArray());

            using var rdr = await cmd.ExecuteReaderAsync();

            Line line = new Line(); 
            if (await rdr.ReadAsync())
                line = FillLine(rdr);
            else line = request.Line;

            return line;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка при обновлении строки контракта.", ex);
        }
    }

    #endregion

    public List<string> MappingLine(Line line, List<MySqlParameter> parameters, List<string> Paths)
    {
        List<string> updateFields = new List<string>();
        foreach (string path in Paths)
        {
            switch (path.ToLowerInvariant())
            {
                case "previous_id":
                    updateFields.Add("contractline_id = @previous_id");
                    parameters.Add(new MySqlParameter("@previous_id", line.Id));
                    break;
                case "operation":
                    updateFields.Add("operation = @operation");
                    parameters.Add(new MySqlParameter("@operation", line.Operation));
                    break;
                case "product.id":
                    updateFields.Add("rfr_MGoodGroupId = @product_id");
                    parameters.Add(new MySqlParameter("@product_id", line.Product.Id));
                    break;
                case "unit.id":
                    updateFields.Add("UnitId = @unit_id");
                    parameters.Add(new MySqlParameter("@unit_id", line.Unit.Id));
                    break;
                case "supplier.id":
                    updateFields.Add("supplier_id = @supplier_id");
                    parameters.Add(new MySqlParameter("@supplier_id", line.Supplier.Id));
                    break;
                case "name":
                    updateFields.Add("contractline_Name = @name");
                    parameters.Add(new MySqlParameter("@name", line.Name));
                    break;
                case "added_from":
                    updateFields.Add("Added_From = @Added_From");
                    parameters.Add(new MySqlParameter("@Added_From", line.AddedFrom));
                    break;
                case "order":
                    updateFields.Add("contractline_order = @order");
                    parameters.Add(new MySqlParameter("@order", line.Order));
                    break;
                case "specification":
                    updateFields.Add("specification = @specification");
                    parameters.Add(new MySqlParameter("@specification", line.Specification));
                    break;
                case "round_for_Line":
                    updateFields.Add("RoundForLine = @RoundForLine");
                    parameters.Add(new MySqlParameter("@RoundForLine", line.RoundForLine));
                    break;
                case "qty":
                    updateFields.Add("contractline_qty = @qty");
                    parameters.Add(new MySqlParameter("@qty", MyConvert.ToDecimal(line.Qty)));
                    break;
                case "base_discount":
                    updateFields.Add("contractline_baseDiscount = @baseDiscount");
                    parameters.Add(new MySqlParameter("@baseDiscount", MyConvert.ToDecimal(line.BaseDiscount)));
                    break;
                case "discount_additional":
                    updateFields.Add("DiscountAdditional = @DiscountAdditional");
                    parameters.Add(new MySqlParameter("@DiscountAdditional", MyConvert.ToDecimal(line.DiscountAdditional)));
                    break;
                case "base_price":
                    updateFields.Add("contractline_baseprice = @BasePrice");
                    parameters.Add(new MySqlParameter("@BasePrice", MyConvert.ToDecimal(line.BasePrice)));
                    break;
                case "price":
                    updateFields.Add("contractline_price = @Price");
                    parameters.Add(new MySqlParameter("@Price", MyConvert.ToDecimal(line.Price)));
                    break;
                case "amount":
                    updateFields.Add("contractline_amount = @amount");
                    parameters.Add(new MySqlParameter("@amount", MyConvert.ToDecimal(line.Amount)));
                    break;
                case "is_vat":
                    updateFields.Add("IsVat = @IsVat");
                    parameters.Add(new MySqlParameter("@IsVat", line.IsVat));
                    break;
                case "vat_prc":
                    updateFields.Add("contractline_vat_prc = @IsVat");
                    parameters.Add(new MySqlParameter("@IsVat", MyConvert.ToDecimal(line.VatPrc)));
                    break;
                case "sum_vat":
                    updateFields.Add("contractline_sumvat = @SumVat");
                    parameters.Add(new MySqlParameter("@SumVat", MyConvert.ToDecimal(line.SumVat)));
                    break;
                case "sum":
                    updateFields.Add("contractline_sum = @Sum");
                    parameters.Add(new MySqlParameter("@Sum", MyConvert.ToDecimal(line.Sum)));
                    break;
                case "comment":
                    updateFields.Add("Comment = @comment");
                    parameters.Add(new MySqlParameter("@comment", line.Comment));
                    break;
                default:
                    // Игнорируем неизвестные или защищенные от изменения поля (например, id, contractline_id)
                    break;
            }
        }

        return updateFields;
    }

    public List<string> AllFieldsLine(Line line, List<MySqlParameter> parameters)
    {
        List<string> updateFields = new List<string>();
        updateFields.Add("contractline_previousid = @previous_id");
        parameters.Add(new MySqlParameter("@previous_id", line.PreviousId));
        updateFields.Add("operation = @operation");
        parameters.Add(new MySqlParameter("@operation", line.Operation));
        updateFields.Add("rfr_MGoodGroupId = @product_id");
        parameters.Add(new MySqlParameter("@product_id", line.Product.Id));
        updateFields.Add("UnitId = @unit_id");
        parameters.Add(new MySqlParameter("@unit_id", line.Unit.Id));
        updateFields.Add("supplier_id = @supplier_id");
        parameters.Add(new MySqlParameter("@supplier_id", line.Supplier?.Id));
        updateFields.Add("contractline_Name = @name");
        parameters.Add(new MySqlParameter("@name", line.Name));
        updateFields.Add("Added_From = @Added_From");
        parameters.Add(new MySqlParameter("@Added_From", line.AddedFrom));
        updateFields.Add("contractline_order = @order");
        parameters.Add(new MySqlParameter("@order", line.Order));
        updateFields.Add("specification = @specification");
        parameters.Add(new MySqlParameter("@specification", line.Specification));
        updateFields.Add("RoundForLine = @RoundForLine");
        parameters.Add(new MySqlParameter("@RoundForLine", line.RoundForLine));
        updateFields.Add("contractline_qty = @qty");
        parameters.Add(new MySqlParameter("@qty", MyConvert.ToDecimal(line.Qty)));
        updateFields.Add("contractline_baseDiscount = @baseDiscount");
        parameters.Add(new MySqlParameter("@baseDiscount", MyConvert.ToDecimal(line.BaseDiscount)));
        updateFields.Add("DiscountAdditional = @DiscountAdditional");
        parameters.Add(new MySqlParameter("@DiscountAdditional", MyConvert.ToDecimal(line.DiscountAdditional)));
        updateFields.Add("contractline_baseprice = @BasePrice");
        parameters.Add(new MySqlParameter("@BasePrice", MyConvert.ToDecimal(line.BasePrice)));
        updateFields.Add("contractline_price = @Price");
        parameters.Add(new MySqlParameter("@Price", MyConvert.ToDecimal(line.Price)));
        updateFields.Add("contractline_amount = @amount");
        parameters.Add(new MySqlParameter("@amount", MyConvert.ToDecimal(line.Amount)));
        updateFields.Add("IsVat = @IsVat");
        parameters.Add(new MySqlParameter("@IsVat", line.IsVat));
        updateFields.Add("contractline_vat_prc = @VatPrc");
        parameters.Add(new MySqlParameter("@VatPrc", line.VatPrc));
        updateFields.Add("contractline_sumvat = @SumVat");
        parameters.Add(new MySqlParameter("@SumVat", MyConvert.ToDecimal(line.SumVat)));
        updateFields.Add("contractline_sum = @Sum");
        parameters.Add(new MySqlParameter("@Sum", MyConvert.ToDecimal(line.Sum)));
        updateFields.Add("Comment = @comment");
        parameters.Add(new MySqlParameter("@comment", line.Comment));

        return updateFields;
    }


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

        contract.Date = rdr["contract_date"] == DBNull.Value ? null : Convert.ToDateTime(rdr["contract_date"]).ToLocalTime().ToUniversalTime().ToTimestamp();
        contract.ExpirationDate = rdr["contract_ExpirationDate"] == DBNull.Value ? null : Convert.ToDateTime(rdr["contract_ExpirationDate"]).ToLocalTime().ToUniversalTime().ToTimestamp();
        contract.Number = rdr["contract_number"] == DBNull.Value ? "" : rdr["contract_number"].ToString() ?? "";

        contract.Currency = new Currency()
        {
            Id = rdr["currencyId"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["currencyId"]),
            Abbrev = rdr["Abbrev"] == DBNull.Value ? "" : rdr["Abbrev"].ToString() ?? ""
        };
        contract.Sum = rdr["Sum"] == DBNull.Value ? MyConvert.ToDecimalValue(0, 2) : MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["Sum"]), 2);
        contract.Amount = rdr["Amount"] == DBNull.Value ? MyConvert.ToDecimalValue(0, 2) : MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["Amount"]), 2);
        contract.SumVat = rdr["SumVat"] == DBNull.Value ? MyConvert.ToDecimalValue(0, 2) : MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["SumVat"]), 2);
        contract.TypeContract = new DocumentType()
        {
            Id = rdr["DocumentType_Id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["DocumentType_Id"]),
            Name = rdr["DocumentType_Name"] == DBNull.Value ? "" : rdr["DocumentType_Name"].ToString() ?? "",
            Code = rdr["DocumentType_Code"] == DBNull.Value ? "" : rdr["DocumentType_Code"].ToString() ?? "",
            Form = rdr["DocumentType_Form"] == DBNull.Value ? "" : rdr["DocumentType_Form"].ToString() ?? ""
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

        contract.Initiator = new Manager() 
        { 
            Id = rdr["Initiator_Id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["Initiator_Id"]),
            Name = rdr["Initiator_Name"] == DBNull.Value ? "" : rdr["Initiator_Name"].ToString()
        };
        contract.Executor = new Manager()
        {
            Id = rdr["Executor_Id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["Executor_Id"]),
            Name = rdr["Executor_Name"] == DBNull.Value ? "" : rdr["Executor_Name"].ToString()
        };

        contract.ManagerType = rdr["ProjectTypes"] == DBNull.Value ? "" : rdr["ProjectTypes"].ToString();
        contract.State = Convert.ToInt16(rdr["contract_State"]) == 0 ? ContractState.Draft :
                              Convert.ToInt16(rdr["contract_State"]) == 1 ? ContractState.SentToClient :
                              Convert.ToInt16(rdr["contract_State"]) == 2 ? ContractState.Signed :
                              Convert.ToInt16(rdr["contract_State"]) == 3 ? ContractState.Active :
                              Convert.ToInt16(rdr["contract_State"]) == 4 ? ContractState.Complited :
                              ContractState.Draft;

        contract.DocName = rdr["contract_DocName"] == DBNull.Value ? "" : rdr["contract_DocName"].ToString();

        return contract;
    }

    private Line FillLine(DbDataReader rdr)
    {
        bool t = HasColumn(rdr, "comment");

        Line line = new Line();

        line.Id = rdr["line_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["line_id"]);
        line.Order = rdr["line_order"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["line_order"]);
        line.ContractId = rdr["contract_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["contract_id"]);
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
        if (HasColumn(rdr, "operation"))
            line.Operation = rdr["operation"] == DBNull.Value ? "" : rdr["operation"].ToString();
        if (HasColumn(rdr, "Comment"))
            line.Comment = rdr["comment"] == DBNull.Value ? "" : rdr["comment"].ToString();
        if (HasColumn(rdr, "line_previousid"))
            line.PreviousId = rdr["line_previousid"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["line_previousid"]);
        if (HasColumn(rdr, "create_at") && HasColumn(rdr, "create_by") && HasColumn(rdr, "create_userid"))
            line.Metadata = new Metadata()
            {
                CreateAt = rdr["create_at"] == DBNull.Value ? DateTime.MinValue.ToUniversalTime().ToTimestamp() : Convert.ToDateTime(rdr["create_at"]).ToLocalTime().ToUniversalTime().ToTimestamp(),
                CreateBy = rdr["create_by"] == DBNull.Value ? "" : rdr["create_by"].ToString(),
                CreateUserid = rdr["create_userid"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["create_userid"])
            };
        if (HasColumn(rdr, "line_baseDiscount"))
            line.BaseDiscount = rdr["line_baseDiscount"] == DBNull.Value ? MyConvert.ToDecimalValue(0, 2) : MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["line_baseDiscount"]), 2);
        if (HasColumn(rdr, "DiscountAdditional"))
            line.DiscountAdditional = rdr["DiscountAdditional"] == DBNull.Value ? MyConvert.ToDecimalValue(0, 2) : MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["DiscountAdditional"]), 2);
        if (HasColumn(rdr, "line_baseprice"))
            line.BasePrice = rdr["line_baseprice"] == DBNull.Value ? MyConvert.ToDecimalValue(0, 2) : MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["line_baseprice"]), 2);
        if (HasColumn(rdr, "IsVat"))
            line.IsVat = rdr["IsVat"] == DBNull.Value ? false : Convert.ToBoolean(rdr["IsVat"]);
        if (HasColumn(rdr, "line_Unit_Name"))
            line.Unit.Short = rdr["line_Unit_Name"] == DBNull.Value ? "" : Convert.ToString(rdr["line_Unit_Name"]);
        if (HasColumn(rdr, "line_Unit_Code"))
            line.Unit.Code = rdr["line_Unit_Code"] == DBNull.Value ? "" : Convert.ToString(rdr["line_Unit_Code"]); // ??????
        if  (HasColumn(rdr, "RoundForLine"))
            line.RoundForLine = rdr["RoundForLine"] == DBNull.Value ? MyConvert.ToDecimalValue(0) : MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["RoundForLine"]));
        if (HasColumn(rdr, "Specification"))
            line.Specification = rdr["Specification"] == DBNull.Value ? 1 : Convert.ToInt32(rdr["Specification"]);
        if (HasColumn(rdr, "Added_From"))
            line.AddedFrom = rdr["Added_From"] == DBNull.Value ? "" : rdr["Added_From"].ToString();
        if (HasColumn(rdr, "SupplierId"))
            line.Supplier = new Contragent() { Id = rdr["SupplierId"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["SupplierId"]) };

        return line;
    }

    private NodeContract FillNodeContract(DbDataReader rdr)
    {
        NodeContract nodeContract = new NodeContract();

        nodeContract.NodeId = rdr["node_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["node_id"]);
        nodeContract.ParentNodeId = rdr["parent_node_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["parent_node_id"]);
        nodeContract.TreeLevel = rdr["Tree_Level"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["Tree_Level"]);
        nodeContract.NodeType = rdr["node_type"] == DBNull.Value ? "" : rdr["node_type"].ToString();
        nodeContract.Contract = new Contract();
        nodeContract.Contract.Id = rdr["contract_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["contract_id"]);
        nodeContract.Contract.RootId = rdr["contract_rootid"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["contract_rootid"]);
        nodeContract.Contract.Date = rdr["contract_date"] == DBNull.Value ? DateTime.MinValue.ToUniversalTime().ToTimestamp() : Convert.ToDateTime(rdr["contract_date"]).ToLocalTime().ToUniversalTime().ToTimestamp();
        nodeContract.Contract.Number = rdr["contract_number"] == DBNull.Value ? "" : rdr["contract_number"].ToString();
        nodeContract.Contract.DocName = rdr["contract_DocName"] == DBNull.Value ? "" : rdr["contract_DocName"].ToString();
        nodeContract.Contract.Seller = new Contragent()
        {
            Id = rdr["contract_sellerId"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["contract_sellerId"]),
            Name = rdr["contract_sellername"] == DBNull.Value ? "" : rdr["contract_sellername"].ToString() ?? ""
        };
        nodeContract.Contract.Buyer = new Contragent()
        {
            Id = rdr["contract_buyerId"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["contract_buyerId"]),
            Name = rdr["contract_buyername"] == DBNull.Value ? "" : rdr["contract_buyername"].ToString() ?? ""
        };
        nodeContract.Contract.TypeContract = new DocumentType()
        {
            Id = rdr["DocumentType_Id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["DocumentType_Id"]),
            Name = rdr["DocumentType_Name"] == DBNull.Value ? "" : rdr["DocumentType_Name"].ToString() ?? "",
            Code = rdr["DocumentType_Code"] == DBNull.Value ? "" : rdr["DocumentType_Code"].ToString() ?? "",
            Form = rdr["DocumentType_Form"] == DBNull.Value ? "" : rdr["DocumentType_Form"].ToString() ?? ""
        };
        nodeContract.Contract.Currency = new Currency()
        {
            Id = rdr["currencyId"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["currencyId"]),
            Abbrev = rdr["Abbrev"] == DBNull.Value ? "" : rdr["Abbrev"].ToString() ?? ""
        };
        nodeContract.Contract.Sum = rdr["Sum"] == DBNull.Value ? MyConvert.ToDecimalValue(0, 2) : MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["Sum"]), 2);
        nodeContract.Contract.Amount = rdr["Amount"] == DBNull.Value ? MyConvert.ToDecimalValue(0, 2) : MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["Amount"]), 2);
        nodeContract.Contract.SumVat = rdr["SumVat"] == DBNull.Value ? MyConvert.ToDecimalValue(0, 2) : MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["SumVat"]), 2);
        nodeContract.Contract.ManagerType = rdr["ProjectTypes"] == DBNull.Value ? "" : rdr["ProjectTypes"].ToString();
        nodeContract.Contract.State = Convert.ToInt16(rdr["contract_State"]) == 0 ? ContractState.Draft :
                                      Convert.ToInt16(rdr["contract_State"]) == 1 ? ContractState.SentToClient :
                                      Convert.ToInt16(rdr["contract_State"]) == 2 ? ContractState.Signed :
                                      Convert.ToInt16(rdr["contract_State"]) == 3 ? ContractState.Active :
                                      Convert.ToInt16(rdr["contract_State"]) == 4 ? ContractState.Complited :
                                      ContractState.Draft;

        /*
		root_date,
		sort_id,
		sort_date,
		path,
		original_level,
        */
        /*
		IsContract,
		contract_consigneeId, 
		contract_consigneeName,
		contract_shipperId, 
		contract_shipperName,
		contract_data, 
		ProjectTypes,
		Contract_State
        */
        return nodeContract;
    }

    private bool HasColumn(DbDataReader reader, string columnName)
    {
        bool result = true;
        try
        {
            int i = reader.GetOrdinal(columnName);
            result = true;
        } catch
        {
            result = false;
        }

        return result;
    }

    #endregion

}

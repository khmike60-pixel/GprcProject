using Google.Protobuf.Collections;
using GrpcCommonNet.Library.Bank;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Service.Models;
using MySql.Data.MySqlClient;
using System.Data.Common;

public class BankRepository
{
    private readonly string _connectionString = "";
    private readonly ILogger<BankRepository> _logger;

    public BankRepository(IConfiguration configuration, ILogger<BankRepository> logger)
    {
        _connectionString = configuration.GetConnectionString("MySql");
        _logger = logger;
    }

    public async Task<Bank> GetByIdAsync(int id)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = $@"
                SELECT b.*, g.GeoLocation_Code2, g.GeoLocation_Name
                    FROM global_db.m_bank b 
                    LEFT JOIN global_db.geolocations g ON b.ID_M_GEOCOUNTRY_REG = g.GEOLOCATION_Id
                    where b.ID_M_BANK = {id}";
            using var rdr = await cmd.ExecuteReaderAsync();
            Bank bank = new Bank();
            if (await rdr.ReadAsync()) 
                return bank = FillBank(rdr);
            else
                return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw new Exception("Ошибка в GetByIdAsync: " + ex.Message);
        }
    }

    public async Task<List<Bank>> GetListAsync(BankFilterRequest request)
    {
        List<Bank> banks = new List<Bank>();
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = $@"
                SELECT b.*, g.GeoLocation_Code2, g.GeoLocation_Name
                    FROM global_db.m_bank b 
                    LEFT JOIN global_db.geolocations g ON b.ID_M_GEOCOUNTRY_REG = g.GEOLOCATION_Id
                WHERE (@Name IS NULL OR b.NameBank LIKE CONCAT('%', @Name, '%'))
                  AND (@Mfo IS NULL OR b.MFO = @Mfo);
                ORDER BY b.NameBank;
                ";
            cmd.Parameters.AddWithValue("@Name", request.Name);
            cmd.Parameters.AddWithValue("@Mfo", request.Mfo);

            using var rdr = await cmd.ExecuteReaderAsync();
            while (await rdr.ReadAsync())
            {
                Bank bank = FillBank(rdr);
                banks.Add(bank);
            }
            return banks;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw new Exception("Ошибка в ListAllAsync: " + ex.Message);
        }
    }

    public async Task<PagedResult<Bank>> GetPagedListAsync(BankFilterRequest request)
    {
        PagedResult<Bank> pagedResult = new PagedResult<Bank>();
        List<Bank> banks = new List<Bank>();
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = $@"
                SELECT b.*, g.GeoLocation_Code2, g.GeoLocation_Name
                    FROM global_db.m_bank b 
                        LEFT JOIN global_db.geolocations g ON b.ID_M_GEOCOUNTRY_REG = g.GEOLOCATION_Id
                    WHERE 1 = 1
                        AND (IFNULL(@name,'') = '' OR b.NameBank LIKE CONCAT('%', @name, '%'))
                        AND (IFNULL(@mfo,'') = '' OR b.MFO = @mfo)
                    ORDER BY b.NameBank
                    LIMIT {request.Paging.PageSize * (request.Paging.PageNumber - 1)}, {request.Paging.PageSize};
                ";
                cmd.Parameters.AddWithValue("@name", request.Name);
                cmd.Parameters.AddWithValue("@mfo", request.Mfo);
                using var rdr = await cmd.ExecuteReaderAsync();
                while (await rdr.ReadAsync())
                {
                    Bank bank = FillBank(rdr);
                    banks.Add(bank);
                }
                pagedResult.Items = banks;
            }
            // Get total count
            /**/
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                SELECT COUNT(*) FROM global_db.m_bank b 
                    WHERE 1 = 1 
                        AND (IFNULL(@name,'') = '' OR b.NameBank LIKE CONCAT('%', @name, '%'))
                        AND (IFNULL(@mfo,'') = '' OR b.MFO = @mfo)
            ";
                cmd.Parameters.AddWithValue("@name", request.Name);
                cmd.Parameters.AddWithValue("@mfo", request.Mfo);

                pagedResult.TotalCount = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                pagedResult.PageNumber = request.Paging.PageNumber;
                pagedResult.PageSize = request.Paging.PageSize;
            }
            return pagedResult;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw new Exception("Ошибка в GetPagedListAsync: " + ex.Message);
        }
    }

    public async Task<Bank> CreateAsync(CreateBankRequest request)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = $@"
                INSERT INTO global_db.m_bank (
	                NameBank,
	                MCode,
	                MFO,
	                SWIFT,
	                SuperShort,
	                MicrosCode,
	                MicrosCodeConfirm,
	                ID_M_GEOCOUNTRY_REG,
	                Comment
                    )
                VALUE (
                    @name,
	                @short,
	                @mfo,
	                @swift,
	                @super_short,
	                @micros_code,
	                @micros_code_confirm,
	                @geolocation_id,
	                @comment
                    );
                SELECT b.*, g.GeoLocation_Code2, g.GeoLocation_Name
                    FROM global_db.m_bank b 
                    LEFT JOIN global_db.geolocations g ON b.ID_M_GEOCOUNTRY_REG = g.GEOLOCATION_Id
                    where b.ID_M_BANK = LAST_INSERT_ID()";

            cmd.Parameters.AddWithValue("@name", request.Bank.Name ?? String.Empty);
            cmd.Parameters.AddWithValue("@short", request.Bank.Short ?? String.Empty);
            cmd.Parameters.AddWithValue("@mfo", request.Bank.Mfo ?? String.Empty);
            cmd.Parameters.AddWithValue("@swift", request.Bank.Swift ?? String.Empty);
            cmd.Parameters.AddWithValue("@super_short", request.Bank.SuperShort ?? String.Empty);
            cmd.Parameters.AddWithValue("@micros_code", request.Bank.MicrosCode ?? String.Empty);
            cmd.Parameters.AddWithValue("@micros_code_confirm", request.Bank.MicrosCodeConfirm);

            cmd.Parameters.AddWithValue("@geolocation_id", request.Bank.Geolocation == null ? null : request.Bank.Geolocation.Id);
            cmd.Parameters.AddWithValue("@comment", request.Bank.Comment ?? String.Empty);


            using var rdr = await cmd.ExecuteReaderAsync();
            Bank bank = new Bank();
            if (await rdr.ReadAsync())
                return bank = FillBank(rdr);
            else
                return bank;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw new Exception("Ошибка в CreateAsync: " + ex.Message);
        }
    }

    public async Task<Bank> UpdateAsync(UpdateBankRequest request)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = $@"
                UPDATE global_db.m_bank b SET 
	                b.NameBank = IFNULL(@name,b.NameBank),
	                b.MCode = IFNULL(@short,b.MCode),
	                b.MFO = IFNULL(@mfo,b.MFO),
	                b.SWIFT = IFNULL(@swift,b.SWIFT),
	                b.SuperShort = IFNULL(@super_short,b.SuperShort),
	                b.MicrosCode = IFNULL(@micros_code,b.MicrosCode),
	                b.MicrosCodeConfirm = IFNULL(@micros_code_confirm,b.MicrosCodeConfirm),
	                b.ID_M_GEOCOUNTRY_REG = IFNULL(@geolocation_id,b.ID_M_GEOCOUNTRY_REG),
	                b.Comment = IFNULL(@comment,b.Comment)
                WHERE b.ID_M_BANK  = @id;
                SELECT b.*, g.GeoLocation_Code2, g.GeoLocation_Name
                    FROM global_db.m_bank b 
                    LEFT JOIN global_db.geolocations g ON b.ID_M_GEOCOUNTRY_REG = g.GEOLOCATION_Id
                    where b.ID_M_BANK = @id";

            cmd.Parameters.AddWithValue("@id",  request.Bank.Id);
            cmd.Parameters.AddWithValue("@name", !request.Bank.HasName ? null : request.Bank.Name);
            cmd.Parameters.AddWithValue("@short", request.Bank.Short);
            cmd.Parameters.AddWithValue("@mfo", request.Bank.Mfo);
            cmd.Parameters.AddWithValue("@swift", !request.Bank.HasSwift ? null : request.Bank.Swift);
            cmd.Parameters.AddWithValue("@super_short", !request.Bank.HasSuperShort ? null : request.Bank.SuperShort);
            cmd.Parameters.AddWithValue("@micros_code", !request.Bank.HasMicrosCode ? null : request.Bank.MicrosCode);
            cmd.Parameters.AddWithValue("@micros_code_confirm", !request.Bank.HasMicrosCodeConfirm ? null : request.Bank.MicrosCodeConfirm);

            cmd.Parameters.AddWithValue("@geolocation_id", request.Bank.Geolocation == null ? null : request.Bank.Geolocation.Id);
            cmd.Parameters.AddWithValue("@comment", !request.Bank.HasComment ? null : request.Bank.Comment);


            using var rdr = await cmd.ExecuteReaderAsync();
            Bank bank = new Bank();
            if (await rdr.ReadAsync())
                return bank = FillBank(rdr);
            else
                return bank;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw new Exception("Ошибка в UpdateAsync: " + ex.Message);
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = $@"
                DELETE FROM global_db.m_bank 
                WHERE ID_M_BANK = @id;
                ";
            cmd.Parameters.AddWithValue("@id", id);
            int affectedRows = await cmd.ExecuteNonQueryAsync();
            return affectedRows > 0;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw new Exception("Ошибка в DeleteAsync: " + ex.Message);
        }
    }

    public async Task<List<int>> DeleteByIdsAsync(RepeatedField<int> ids)
    {
        try
        {
            var deleted = new List<int>();
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            // Build parameters
            var idx = 0;
            var parts = new List<string>();
            foreach (var id in ids)
            {
                var pname = "@id" + idx++;
                parts.Add(pname);
                cmd.Parameters.AddWithValue(pname, id);
            }
            if (parts.Count == 0) return deleted;
            cmd.CommandText =
               $"DELETE IGNORE FROM global_db.m_bank WHERE ID_M_BANK IN ({string.Join(',', parts)}); " +
               $"SELECT GROUP_CONCAT(b.ID_M_BANK) FROM global_db.m_bank b WHERE b.ID_M_BANK IN ({string.Join(',', parts)}); ";

            var rdr = await cmd.ExecuteReaderAsync();

            var listAffected = rdr.Read() ? rdr.GetValue(0) : String.Empty;

            string[] numberStrings = { };
            List<int> Affected = new List<int>();

            if (listAffected != null && !listAffected.ToString().Equals(String.Empty))
            {
                numberStrings = ((string)listAffected).Split(',');
                Affected = numberStrings.Select(s => int.Parse(s.Trim())).ToList();
            }

            return Affected;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в DeleteByIdsAsync: " + ex.Message);
        }
    }



    private Bank FillBank(DbDataReader rdr)
    {
        Bank bank = new Bank();
        bank.Id = rdr["ID_M_BANK"] ==  DBNull.Value ? 0 : Convert.ToInt32(rdr["ID_M_BANK"]);
        bank.Name = rdr["NameBank"] == DBNull.Value ? String.Empty : Convert.ToString(rdr["NameBank"]);
        bank.Short = rdr["MCode"] == DBNull.Value ? String.Empty : Convert.ToString(rdr["MCode"]);
        bank.Mfo = rdr["MFO"] == DBNull.Value ? String.Empty : Convert.ToString(rdr["MFO"]);
        bank.Swift = rdr["SWIFT"] == DBNull.Value ? String.Empty : Convert.ToString(rdr["SWIFT"]);
        bank.SuperShort = rdr["SuperShort"] == DBNull.Value ? String.Empty : Convert.ToString(rdr["SuperShort"]);
        bank.MicrosCode = rdr["MicrosCode"] == DBNull.Value ? String.Empty : Convert.ToString(rdr["MicrosCode"]);
        bank.MicrosCodeConfirm = rdr["MicrosCodeConfirm"] == DBNull.Value ? false : Convert.ToBoolean(rdr["MicrosCodeConfirm"]);
        bank.Comment = rdr["Comment"] == DBNull.Value ? String.Empty : Convert.ToString(rdr["Comment"]);
        bank.Geolocation = new Geolocation
        {
            Id = rdr["ID_M_GEOCOUNTRY_REG"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["ID_M_GEOCOUNTRY_REG"]),
            Code2 = rdr["GeoLocation_Code2"] == DBNull.Value ? String.Empty : Convert.ToString(rdr["GeoLocation_Code2"]),
            Name = rdr["GeoLocation_Name"] == DBNull.Value ? String.Empty : Convert.ToString(rdr["GeoLocation_Name"])
        };
        return bank;
    }
}

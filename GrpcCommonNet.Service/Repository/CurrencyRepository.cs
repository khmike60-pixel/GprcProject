using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library;
using GrpcCommonNet.Library.Currency;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Proto.Utils;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Threading.Tasks;

public class CurrencyRepository
{
    private readonly string _connectionString = "";
    private readonly ILogger<CurrencyRepository> _logger;

    public CurrencyRepository(ILogger<CurrencyRepository> logger, IConfiguration configuration)
    {
        _logger = logger;
        _connectionString = configuration.GetConnectionString("MySql");
    }

    #region Методы получения данных валют
    public async Task<Currency?> GetByIdAsync(int id)
    {

        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = $@"SELECT c.CurrencyId id, c.Code code, c.Abbrev abbrev, c.Name name, c.Scale scale, c.Dec `dec`, c.OrdNumber order_number, c.IsVisible is_visible 
                            FROM global_db.rfr_currency c WHERE CurrencyId = {id} LIMIT 1";
            //cmd.Parameters.AddWithValue("@id", id);
            using var rdr = await cmd.ExecuteReaderAsync();
            if (await rdr.ReadAsync())
            {
                return new Currency
                {
                    Id = rdr.IsDBNull(0) ? 0 : rdr.GetInt32(0),
                    Code = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1),
                    Abbrev = rdr.IsDBNull(2) ? string.Empty : rdr.GetString(2),
                    Name = rdr.IsDBNull(3) ? string.Empty : rdr.GetString(3),
                    Scale = rdr.IsDBNull(4) ? 0 : rdr.GetInt32(4),
                    Dec = rdr.IsDBNull(5) ? 0 : rdr.GetInt32(5),
                    OrderNumber = rdr.IsDBNull(6) ? 0 : rdr.GetInt32(6),
                    IsVisible = !rdr.IsDBNull(7) && rdr.GetBoolean(7)
                };
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в GetByCodeAsync: " + ex.Message);
        }

        return null;
    }

    public async Task<List<Currency>> GetListAsync(bool includeInvisible, string? orderBy, string? codeFilter, string? abbrevFilter)
    {
        var result = new List<Currency>();
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            var whereParts = new List<string>();
            if (!string.IsNullOrEmpty(codeFilter))
            {
                whereParts.Add("c.Code LIKE @codeFilter");
                cmd.Parameters.AddWithValue("@codeFilter", "%" + codeFilter + "%");
            }
            if (!string.IsNullOrEmpty(abbrevFilter))
            {
                whereParts.Add("c.Abbrev LIKE @abbrevFilter");
                cmd.Parameters.AddWithValue("@abbrevFilter", "%" + abbrevFilter + "%");
            }
            if (!includeInvisible)
            {
                whereParts.Add("c.IsVisible = 1");
            }

            var where = whereParts.Count > 0 ? "WHERE " + string.Join(" AND ", whereParts) : string.Empty;
            var order = string.IsNullOrEmpty(orderBy) ? "ORDER BY order_number ASC" : "ORDER BY " + orderBy;

            cmd.CommandText = $@"SELECT c.CurrencyId id, c.Code code, c.Abbrev abbrev, c.Name name, c.Scale scale, c.Dec as `dec`, c.OrdNumber order_number, c.IsVisible is_visible
                              FROM global_db.rfr_currency c {where} {order} LIMIT 1000";

            using var rdr = await cmd.ExecuteReaderAsync();
            while (await rdr.ReadAsync())
            {
                result.Add(new Currency
                {
                    Id = rdr.IsDBNull(0) ? 0 : rdr.GetInt32(0),
                    Code = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1),
                    Abbrev = rdr.IsDBNull(2) ? string.Empty : rdr.GetString(2),
                    Name = rdr.IsDBNull(3) ? string.Empty : rdr.GetString(3),
                    Scale = rdr.IsDBNull(4) ? 0 : rdr.GetInt32(4),
                    Dec = rdr.IsDBNull(5) ? 0 : rdr.GetInt32(5),
                    OrderNumber = rdr.IsDBNull(6) ? 0 : rdr.GetInt32(6),
                    IsVisible = !rdr.IsDBNull(7) && rdr.GetBoolean(7)
                });
            }
        }
        catch (Exception ex)
        {
            throw new Exception ("Ошибка в GetListAsync: " + ex.Message);
        }
        return result;
    }

    public async Task<Currency> CreateAsync(Currency c)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO global_db.rfr_currency (Code, Abbrev, Name, Scale, `Dec`, OrdNumber, IsVisible)
                            VALUES (@code, @abbrev, @name, @scale, @dec, @order, @visible);
                            SELECT CurrencyId, Code, Abbrev, Name, Scale, `Dec`, OrdNumber, IsVisible 
                            FROM global_db.rfr_currency WHERE CurrencyId = LAST_INSERT_ID();";
            cmd.Parameters.AddWithValue("@code", c.Code ?? string.Empty);
            cmd.Parameters.AddWithValue("@abbrev", c.Abbrev ?? string.Empty);
            cmd.Parameters.AddWithValue("@name", c.Name ?? string.Empty);
            cmd.Parameters.AddWithValue("@scale", c.Scale);
            cmd.Parameters.AddWithValue("@dec", c.Dec);
            cmd.Parameters.AddWithValue("@order", c.OrderNumber);
            cmd.Parameters.AddWithValue("@visible", c.IsVisible ? 1 : 0);

            var rdr = await cmd.ExecuteReaderAsync();

            if (await rdr.ReadAsync())
            {
                return new Currency
                {
                    Id = rdr.IsDBNull(0) ? 0 : rdr.GetInt32(0),
                    Code = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1),
                    Abbrev = rdr.IsDBNull(2) ? string.Empty : rdr.GetString(2),
                    Name = rdr.IsDBNull(3) ? string.Empty : rdr.GetString(3),
                    Scale = rdr.IsDBNull(4) ? 0 : rdr.GetInt32(4),
                    Dec = rdr.IsDBNull(5) ? 0 : rdr.GetInt32(5),
                    OrderNumber = rdr.IsDBNull(6) ? 0 : rdr.GetInt32(6),
                    IsVisible = !rdr.IsDBNull(7) && rdr.GetBoolean(7)
                };
            } 
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в CreateAsync: " + ex.Message);
        }
        return null!;
    }

    public async Task<Currency> UpdateAsync(Currency c, List<string> fields)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"UPDATE global_db.rfr_currency SET ";
            if (fields.Count == 0)
            {
                cmd.CommandText += @" Code = @code, 
                                Abbrev = @abbrev, 
                                Name  = @name, 
                                Scale = @scale, 
                                `Dec` = @dec, 
                                OrdNumber = @order, 
                                IsVisible = @visible,";
                cmd.Parameters.AddWithValue("@code", c.Code ?? string.Empty);
                cmd.Parameters.AddWithValue("@abbrev", c.Abbrev ?? string.Empty);
                cmd.Parameters.AddWithValue("@name", c.Name ?? string.Empty);
                cmd.Parameters.AddWithValue("@scale", c.Scale);
                cmd.Parameters.AddWithValue("@dec", c.Dec);
                cmd.Parameters.AddWithValue("@order", c.OrderNumber);
                cmd.Parameters.AddWithValue("@visible", c.IsVisible ? 1 : 0);
            }

            foreach (var field in fields)
            {
                switch (field)
                {
                    case "code":
                        cmd.CommandText += "Code = @code,";
                        cmd.Parameters.AddWithValue("@code", c.Code ?? string.Empty);
                        break;
                    case "abbrev":
                        cmd.CommandText += "Abbrev = @abbrev,";
                        cmd.Parameters.AddWithValue("@abbrev", c.Abbrev ?? string.Empty);
                        break;
                    case "name":
                        cmd.CommandText += "Name = @name,";
                        cmd.Parameters.AddWithValue("@name", c.Name ?? string.Empty);
                        break;
                    case "scale":
                        cmd.CommandText += "Scale = @scale,";
                        cmd.Parameters.AddWithValue("@scale", c.Scale);
                        break;
                    case "dec":
                        cmd.CommandText += "`Dec` = @dec,";
                        cmd.Parameters.AddWithValue("@dec", c.Dec);
                        break;
                    case "order_number":
                        cmd.CommandText += "OrdNumber = @order,";
                        cmd.Parameters.AddWithValue("@order", c.OrderNumber);
                        break;
                    case "is_visible":
                        cmd.CommandText += "IsVisible = @visible,";
                        cmd.Parameters.AddWithValue("@visible", c.IsVisible ? 1 : 0);
                        break;
                }
            }
            cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1);  // Убираем последнюю запятую

            cmd.CommandText += @" WHERE CurrencyId = @id;
                                SELECT c.CurrencyId, c.Code, c.Abbrev, c.Name, c.Scale, c.`Dec`, c.OrdNumber, c.IsVisible 
                                FROM global_db.rfr_currency c WHERE c.CurrencyId = @id;";
            cmd.Parameters.AddWithValue("@id", c.Id);

            var rdr = await cmd.ExecuteReaderAsync();

            if (await rdr.ReadAsync())
            {
                return new Currency
                {
                    Id = rdr.IsDBNull(0) ? 0 : rdr.GetInt32(0),
                    Code = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1),
                    Abbrev = rdr.IsDBNull(2) ? string.Empty : rdr.GetString(2),
                    Name = rdr.IsDBNull(3) ? string.Empty : rdr.GetString(3),
                    Scale = rdr.IsDBNull(4) ? 0 : rdr.GetInt32(4),
                    Dec = rdr.IsDBNull(5) ? 0 : rdr.GetInt32(5),
                    OrderNumber = rdr.IsDBNull(6) ? 0 : rdr.GetInt32(6),
                    IsVisible = !rdr.IsDBNull(7) && rdr.GetBoolean(7)
                };
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в UpdateAsync:" + ex.Message    );
        }
        return null!;
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                                DELETE FROM global_db.rfr_currency c WHERE c.CurrencyId = @id;
                                SELECT c.CurrencyId FROM global_db.rfr_currency c WHERE c.CurrencyId = @id;";
            cmd.Parameters.AddWithValue("@id", id);

            var rdr = await cmd.ExecuteReaderAsync();
            if (await rdr.ReadAsync()) return false;
            else return true;
        } catch (Exception ex)
        {
            throw new Exception("Ошибка в DeleteByIdAsync:" + ex.Message);
        }
    }

    public async Task<List<int>> DeleteByIdsAsync(IEnumerable<int> ids)
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
               $"DELETE IGNORE FROM global_db.rfr_currency WHERE CurrencyId IN ({string.Join(',', parts)}); " +
               $"SELECT GROUP_CONCAT(c.CurrencyId) FROM global_db.rfr_currency c WHERE c.CurrencyId IN ({string.Join(',', parts)}); ";
            
            var rdr = await cmd.ExecuteReaderAsync();

            var listAffected  = rdr.Read() ? rdr.GetValue(0) : String.Empty;

            string[] numberStrings = { };
            List<int> Affected = new List<int>();

            if (listAffected != null && !listAffected.ToString().Equals(String.Empty))
            {
                numberStrings = ((string)listAffected).Split(',');
                Affected = numberStrings.Select(s => int.Parse(s.Trim())).ToList();
            }

            return Affected;
        } catch (Exception ex)
        {
            throw new Exception("Ошибка в DeleteByIdsAsync: " + ex.Message);
        }
    }

    #endregion

    #region Методы получение данных по курсам валют
    public async Task<List<CurrencyRate>> GetListRatesDateAsync(string abbrev, bool includeInvisible, string name, DateTime  date)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                WITH RankedRates AS (
                    SELECT
                        CurrencyId,
                        Date,
                        Rate,
                        ROW_NUMBER() OVER (
                            PARTITION BY CurrencyId
                            ORDER BY Date DESC
                        ) as rn
                    FROM
                        global_db.cbrates
                    WHERE
                        Date <= @date
                )
                select
                    c.CurrencyId,
                    c.Abbrev, 
                    c.Name,
	                c.OrdNumber,
                    rr.Rate,
                    rr.Date,
                    c.IsVisible,
	                ifnull(c.OrdNumber, 500) as number
                FROM
                    global_db.rfr_Currency c
                    LEFT JOIN
                        RankedRates rr ON C.CurrencyId = rr.CurrencyId AND rr.rn = 1
                where 1 = 1
	                and c.Name like CONCAT('%',IFNULL(@name,""),'%') 
	                and c.Abbrev like CONCAT('%',IFNULL(@code,""),'%') 
	                and IFNULL(@includeInvisible,true) or c.IsVisible = 1
	                and c.IsMain != 1
                order by `number`;";
            cmd.Parameters.AddWithValue("@code", abbrev);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@includeInvisible", includeInvisible);
            cmd.Parameters.AddWithValue("@date", date);
            using var rdr = await cmd.ExecuteReaderAsync();
            List<CurrencyRate> currencyrates = new List<CurrencyRate>();
            while (rdr.Read())
                currencyrates.Add(FillCurrencyRate(rdr));        

            return currencyrates;
        }
        catch (Exception ex) {
            throw new Exception("Ошибка в GetListRatesDateAsync:" + ex.Message);
        }

    }

    public async Task<Rate?> GetRateAsync(string codeOrAbbrev, string date)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT r.RateId, r.CurrencyId, r.Date, r.Rate
                            FROM global_db.cbrates r
                            JOIN global_db.rfr_currency c ON c.CurrencyId = r.CurrencyId
                            WHERE (c.Code = @code OR c.Abbrev = @code or c.CurrencyId = @code) AND (r.Date <= @date) order by r.Date desc LIMIT 1";
            cmd.Parameters.AddWithValue("@code", codeOrAbbrev);
            cmd.Parameters.AddWithValue("@date", date);
            using var rdr = await cmd.ExecuteReaderAsync();
            if (await rdr.ReadAsync())
            {
                Rate rate = new Rate();
                rate = FillRate(rdr);
                //return new Rate
                //{
                //    RateId = rdr.IsDBNull(0) ? 0 : rdr.GetInt64(0),
                //    CurrencyId = rdr.IsDBNull(1) ? 0 : rdr.GetInt64(1),
                //    Date = rdr.IsDBNull(2) ? null : rdr.GetDateTime(2).ToLocalTime().ToUniversalTime().ToTimestamp(),
                //    Rate_ = rdr.IsDBNull(3) ? new DecimalValue { Units = 0, Scale = 0 } : MyMath.ToDecimalValue((decimal)rdr.GetDouble(3), 2)
                //};
                return rate;
            }
            return null;
        }  catch (Exception ex)
        {
            throw new Exception("Ошибка в GetRateAsync:" + ex.Message);
        }
    }

    public async Task<List<Rate>> GetRatesAsync(string? filter, string? startDate, string? endDate)
    {
        var result = new List<Rate>();
        using var conn = new MySqlConnection(_connectionString);
        await conn.OpenAsync();
        using var cmd = conn.CreateCommand();
        var where = "WHERE 1=1";
        if (!string.IsNullOrEmpty(filter))
        {
            where += " AND (c.Code = @code OR c.Abbrev = @code OR c.CurrencyId = @code)";
            cmd.Parameters.AddWithValue("@code", filter);
        }
        if (!string.IsNullOrEmpty(startDate))
        {
            where += " AND r.date >= @start";
            cmd.Parameters.AddWithValue("@start", DateTime.Parse(startDate));
        }
        if (!string.IsNullOrEmpty(endDate))
        {
            where += " AND r.date <= @end";
            cmd.Parameters.AddWithValue("@end", DateTime.Parse(endDate));
        }
        cmd.CommandText = $@"SELECT r.RateId, r.CurrencyId, r.Date, r.Rate
                              FROM global_db.cbrates r
                              JOIN global_db.rfr_currency c ON c.CurrencyId = r.CurrencyId
                              {where} ORDER BY r.date DESC";
        using var rdr = await cmd.ExecuteReaderAsync();
        while (await rdr.ReadAsync())
        {
            Rate rate = new Rate();
            result.Add(FillRate(rdr));
            //result.Add(new Rate
            //{
            //    RateId = rdr.IsDBNull(0) ? 0 : rdr.GetInt64(0),
            //    CurrencyId = rdr.IsDBNull(1) ? 0 : rdr.GetInt64(1),
            //    Date = rdr.IsDBNull(2) ? null : rdr.GetDateTime(2).ToLocalTime().ToUniversalTime().ToTimestamp(),
            //    Rate_ = rdr.IsDBNull(3) ? new DecimalValue { Units = 0, Scale = 0 } : MyMath.ToDecimalValue((decimal)rdr.GetDouble(3), 2)
            //});
        }
        return result;
    }

    public async Task<Rate> CreateRateAsync(Rate rate)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO global_db.cbrates (CurrencyId, Date, Rate)
                            VALUES (@currencyId, @date, @rate);
                            SELECT r.RateId, r.CurrencyId, r.Date, r.Rate 
                            FROM global_db.cbrates r WHERE r.RateId = LAST_INSERT_ID();";
            cmd.Parameters.AddWithValue("@currencyId", rate.CurrencyId);
            cmd.Parameters.AddWithValue("@date", rate.Date.ToDateTime().ToLocalTime());
            cmd.Parameters.AddWithValue("@rate", MyConvert.ToDecimal(rate.Rate_));
            var rdr = await cmd.ExecuteReaderAsync();
            if (await rdr.ReadAsync())
            {
                Rate createdRate = new Rate();
                return createdRate = FillRate(rdr);
                //return new Rate
                //{
                //    RateId = rdr.IsDBNull(0) ? 0 : rdr.GetInt64(0),
                //    CurrencyId = rdr.IsDBNull(1) ? 0 : rdr.GetInt64(1),
                //    Date = rdr.IsDBNull(2) ? null : rdr.GetDateTime(2).ToLocalTime().ToUniversalTime().ToTimestamp(),
                //    Rate_ = rdr.IsDBNull(3) ? new DecimalValue { Units = 0, Scale = 0 } : MyMath.ToDecimalValue((decimal)rdr.GetDouble(3), 2)
                //};
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в CreateRateAsync: " + ex.Message);
        }
        return null!;
    }

    public async Task<Rate> UpdateRateAsync(long id, Timestamp date, DecimalValue rate)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"UPDATE global_db.cbrates SET ";
                cmd.CommandText += @"Date = @date, Rate  = @rate ";
            cmd.CommandText +=  @" WHERE RateId = @id;
                                SELECT r.RateId, r.CurrencyId, r.Date, r.Rate 
                                FROM global_db.cbrates r WHERE r.RateId = @id;";
            cmd.Parameters.AddWithValue("@id", id); 
            cmd.Parameters.AddWithValue("@date", date.ToDateTime().ToLocalTime());
            cmd.Parameters.AddWithValue("@rate", MyConvert.ToDecimal(rate));
            var rdr = await cmd.ExecuteReaderAsync();   
            if(await rdr.ReadAsync())
            {
                Rate updateRate = new Rate();
                return updateRate = FillRate(rdr);
                //return new Rate
                //{
                //    RateId = rdr.IsDBNull(0) ? 0 : rdr.GetInt64(0),
                //    CurrencyId = rdr.IsDBNull(1) ? 0 : rdr.GetInt64(1),
                //    Date = rdr.IsDBNull(2) ? null : rdr.GetDateTime(2).ToLocalTime().ToUniversalTime().ToTimestamp(),
                //    Rate_ = rdr.IsDBNull(3) ? new DecimalValue { Units = 0, Scale = 0 } : MyMath.ToDecimalValue((decimal)rdr.GetDouble(3), 2)
                //};
            } else return new Rate {}; 
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в UpdateRateAsync: " + ex.Message);
        }
    }

    public async Task<bool> DeleteRateAsync(long id)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM global_db.cbrates r WHERE r.RateId = @id";
            cmd.Parameters.AddWithValue("@id", id);
            var affected = await cmd.ExecuteNonQueryAsync();
            return affected > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в DeleteRateByIdAsync: " + ex.Message);
        }
    }

    public async Task<List<int>> DeleteIdsRatesAsync(IEnumerable<int> ids)
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
               $"DELETE IGNORE FROM global_db.cbrates WHERE RateId IN ({string.Join(',', parts)}); " +
               $"SELECT GROUP_CONCAT(r.RateId) FROM global_db.cbrates r WHERE r.RateId IN ({string.Join(',', parts)}); ";
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
            throw new Exception("Ошибка в DeleteRatesByIdsAsync: " + ex.Message);
        }
    }

    #endregion

    private CurrencyRate FillCurrencyRate(DbDataReader rdr)
    {
        var currencyRate = new CurrencyRate();
        currencyRate.Id = Convert.ToInt32(rdr["CurrencyId"]);
        currencyRate.Name  = rdr["Name"]  ==  DBNull.Value  ? string.Empty : rdr["Name"].ToString();
        currencyRate.Abbrev = rdr["Abbrev"] == DBNull.Value ? string.Empty : rdr["Abbrev"].ToString();

        if (rdr["Date"] == DBNull.Value) currencyRate.Date = null;
        else
        {
            DateTime date = Convert.ToDateTime(rdr["Date"]);
            currencyRate.Date = Timestamp.FromDateTime(date.ToLocalTime().ToUniversalTime());
            
            decimal rate =  rdr["Rate"] == DBNull.Value ? 0 : Convert.ToDecimal(rdr["Rate"]);
            DecimalValue rateDecimal = new DecimalValue { Units = (int)(rate * 100), Scale = 2 };
            currencyRate.Rate = rateDecimal;

        }

        return currencyRate;
    }

    private Rate FillRate(DbDataReader rdr)
    {
        int scale = 2; // Кол-во знаков в Rate в таблице cbrates

        var rate = new Rate();
        rate.RateId = Convert.ToInt32(rdr["RateId"]);
        rate.CurrencyId = Convert.ToInt32(rdr["CurrencyId"]);
        DateTime date = Convert.ToDateTime(rdr["Date"]);
        rate.Date = Timestamp.FromDateTime(date.ToLocalTime().ToUniversalTime());
        decimal rateValue = Convert.ToDecimal(rdr["Rate"]);
        rate.Rate_ = new DecimalValue { Units = (int)((double)rateValue * Math.Pow(10, scale)), Scale = scale };


        return rate;
    }

}

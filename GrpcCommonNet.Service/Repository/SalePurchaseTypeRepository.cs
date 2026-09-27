using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.SalePurchaseType;
using GrpcCommonNet.Proto.Utils;
using GrpcCommonNet.Service.Models;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Data;
using System.Data.Common;
using System.Net.NetworkInformation;
using System.Text.Json;
using ZstdSharp.Unsafe;

public class SalePurchaseTypeRepository
{
    private readonly string _connectionString = "";
    private readonly ILogger<SalePurchaseTypeRepository> _logger;

    #region  Таблица типов продаж/покупок
    public SalePurchaseTypeRepository(ILogger<SalePurchaseTypeRepository> logger, IConfiguration configuration)
    {
        _logger = logger;
        _connectionString = configuration.GetConnectionString("MySql");
    }

    public async Task<SalePurchaseType> GetSalePurchaseTypeAsync(SalePurchaseTypeRequest request, UserData userData)
    {
        SalePurchaseType salePurchaseType = new SalePurchaseType();
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @$"
select 
    spc.*,
    cu.Abbrev  CurrencyCode,  -- валюта страны
    mcu.Abbrev CurrencyMainCode, -- основная валюта
    scu.Abbrev CurrencySalaryCode, -- валюта выдачи з/п
    ccu.Abbrev CurrencyCrossCode, -- кросс-валюта
    g.GeoLocation_MCode, g.GeoLocation_Code2
FROM global_db.rfr_country_currency spc 
    left join global_db.rfr_currency cu on cu.currencyId = spc.currencyId
    left join global_db.rfr_currency mcu on spc.main_currency_Id = mcu.currencyId
    left join global_db.rfr_currency scu on spc.salary_currency_Id = scu.currencyId
    left join global_db.rfr_currency ccu on spc.cross_rate_currency_id = ccu.currencyId
    left join global_db.geolocations g on g.geolocation_id = spc.ID_M_COUNTRY
WHERE 1 = 1
    and spc.id = {request.Id};"
            ;

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
                salePurchaseType = FillSalePurchaseType(reader);
            else return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetSalePurchaseType: " + ex.Message);
            throw;
        }

        return salePurchaseType;
    }

    public async Task<List<SalePurchaseType>> ListSalePurchaseTypeAsync(ListSalePurchaseTypeRequest request, UserData userData)
    {
        List<SalePurchaseType> listSalePurchaseType = new List<SalePurchaseType>();
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @$"
select 
    spc.*,
    cu.Abbrev  CurrencyCode,  -- валюта страны
    mcu.Abbrev CurrencyMainCode, -- основная валюта
    scu.Abbrev CurrencySalaryCode, -- валюта выдачи з/п
    ccu.Abbrev CurrencyCrossCode, -- кросс-валюта
    g.GeoLocation_MCode, g.GeoLocation_Code2
FROM global_db.rfr_country_currency spc 
    left join global_db.rfr_currency cu on cu.currencyId = spc.currencyId
    left join global_db.rfr_currency mcu on spc.main_currency_Id = mcu.currencyId
    left join global_db.rfr_currency scu on spc.salary_currency_Id = scu.currencyId
    left join global_db.rfr_currency ccu on spc.cross_rate_currency_id = ccu.currencyId
    left join global_db.geolocations g on g.geolocation_id = spc.ID_M_GEOCOUNTRY
WHERE 1 = 1
    and (ifnull(@name,'') = '' or spc.comment like CONCAT('%',@name,'%'))
";
            cmd.Parameters.AddWithValue("@name", request.Name);
            using var reader = await cmd.ExecuteReaderAsync();
            while (reader.Read())
            {
                SalePurchaseType salePurchaseType = new SalePurchaseType();
                salePurchaseType = FillSalePurchaseType(reader);
                listSalePurchaseType.Add(salePurchaseType);
            }
            return listSalePurchaseType;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в ListSalePurchaseTypeAsync: " + ex.Message);
        }
    }

    public async Task<SalePurchaseType> CreateSalePurchaseTypeAsync(CreateSalePurchaseTypeRequest request, UserData userData)
    {
        SalePurchaseType salePurchaseType = new SalePurchaseType();
        try
        {

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in CreateSalePurchaseType: " + ex.Message);
            throw;
        }
        return salePurchaseType;
    }

    public async Task<SalePurchaseType> UpdateSalePurchaseTypeAsync(UpdateSalePurchaseTypeRequest request, UserData userData)
    {
        SalePurchaseType salePurchaseType = new SalePurchaseType();
        try
        {

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in UpdateSalePurchaseType: " + ex.Message);
            throw;
        }
        return salePurchaseType;
    }

    public async Task<List<int>> DeleteSalePurchaseTypeAsync(DeleteSalePurchaseTypeRequest request, UserData userData)
    {
        DeleteSalePurchaseTypeResponse deletePurchaseType = new DeleteSalePurchaseTypeResponse();
        try
        {

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in DeleteSalePurchaseType: " + ex.Message);
            throw;
        }
        return new List<int>();
    }

    #endregion


    #region Таблица валют курсов в типах продаж/покупок

    public async Task<SalePurchaseRate> GetSalePurchaseRateAsync(SalePurchaseRateRequest request, UserData userData)
    {
        return new SalePurchaseRate();
    }

    public async Task<List<SalePurchaseRate>> ListSalePurchaseRateAsync(ListSalePurchaseRateRequest request, UserData userData)
    {
        DateTime dateStart = request.DateStart.ToDateTime();
        DateTime dateEnd = request.DateEnd.ToDateTime();
        int id = Convert.ToInt32(request.SalePurchaseType.Id);
        int main_id = 5;
        int cross_id = 31;

        List<SalePurchaseRate> list = new List<SalePurchaseRate>();
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using (MySqlCommand cmd = new MySqlCommand("global_db.refresh_priceparams", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("_CountryCurrId", id);
                cmd.Parameters.AddWithValue("_MainCurrId", main_id);
                cmd.Parameters.AddWithValue("_PerCrossRate", cross_id);
                cmd.Parameters.AddWithValue("_BeginDate", dateStart);
                cmd.Parameters.AddWithValue("_EndDate", dateEnd);

                using var rdr = await cmd.ExecuteReaderAsync();

                while (await rdr.ReadAsync())
                    list.Add(FillSalePurchaseRate(rdr));
            }
        } catch (Exception ex) {
            throw new Exception("Ошибка в ListSalePurchaseRateAsync: " + ex.Message);
        }

        return list;
    }

    public async Task<SalePurchaseRate> CreateSalePurchaseRateAsync(CreateSalePurchaseRateRequest request, UserData userData)
    {
        return new SalePurchaseRate();
    }

    public async Task<SalePurchaseRate> UpdateSalePurchaseRateAsync(UpdateSalePurchaseRateRequest request, UserData userData)
    {
        return new SalePurchaseRate();
    }

    public async Task<List<int>> DeleteSalePurchaseRateAsync(DeleteSalePurchaseRateRequest request, UserData userData)
    {
        List<int> undeleted_ids = new List<int>();

        return undeleted_ids;
    }


    #endregion


    #region Внутренние технические методы

    public SalePurchaseType FillSalePurchaseType(DbDataReader rdr)
    {
        SalePurchaseType salePurchaseType = new SalePurchaseType();
        salePurchaseType.Country = new Geolocation();
        salePurchaseType.Currency = new Currency();

        if (HasColumn(rdr, "id")) { salePurchaseType.Id = rdr["id"] == DBNull.Value ? null : Convert.ToInt32(rdr["id"]); }
        if (HasColumn(rdr, "comment")) { salePurchaseType.Name = rdr["comment"].ToString(); }
        if (HasColumn(rdr, "ID_M_COUNTRY")) { salePurchaseType.Country.Id = rdr["ID_M_COUNTRY"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["ID_M_COUNTRY"]); }
        if (HasColumn(rdr, "GeoLocation_MCode")) { salePurchaseType.Country.Name = rdr["GeoLocation_MCode"].ToString(); }
        if (HasColumn(rdr, "GeoLocation_Code2")) { salePurchaseType.Country.Code2 = rdr["GeoLocation_Code2"].ToString(); }
        if (HasColumn(rdr, "currencyId")) { salePurchaseType.Currency.Id = rdr["currencyId"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["currencyId"]); }
        if (HasColumn(rdr, "CurrencyCode")) { salePurchaseType.Currency.Abbrev = rdr["CurrencyCode"].ToString(); }

        if (HasColumn(rdr, "main_currency_id")) 
        {
            if (salePurchaseType.CurrencyMain == null) salePurchaseType.CurrencyMain = new Currency();
            salePurchaseType.CurrencyMain.Id = rdr["main_currency_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["main_currency_id"]);
        }
        if (HasColumn(rdr, "CurrencyMainCode"))
        {
            if (salePurchaseType.CurrencyMain == null) salePurchaseType.CurrencyMain = new Currency();
            salePurchaseType.CurrencyMain.Abbrev = rdr["CurrencyMainCode"].ToString();
        }

        if (HasColumn(rdr, "salary_currency_id")) 
        {
            if (salePurchaseType.CurrencySalary == null) salePurchaseType.CurrencySalary = new Currency();
            salePurchaseType.CurrencySalary.Id = rdr["salary_currency_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["salary_currency_id"]);
        }
        if (HasColumn(rdr, "CurrencySalaryCode"))
        {
            if (salePurchaseType.CurrencySalary == null) salePurchaseType.CurrencySalary = new Currency();
            salePurchaseType.CurrencySalary.Abbrev = rdr["CurrencySalaryCode"].ToString();
        }

        if (HasColumn(rdr, "cross_rate_currency_id"))
        {
            if (salePurchaseType.CurrencyCross== null) salePurchaseType.CurrencyCross = new Currency();
            salePurchaseType.CurrencyCross.Id = rdr["cross_rate_currency_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["cross_rate_currency_id"]);
        }
        if (HasColumn(rdr, "CurrencyCrossCode"))
        {
            if (salePurchaseType.CurrencyCross == null) salePurchaseType.CurrencyCross = new Currency();
            salePurchaseType.CurrencyCross.Abbrev = rdr["CurrencyCrossCode"].ToString();
        }
        // Неправильный вариант - к удалению
        if (HasColumn(rdr, "currency_in_use")) 
        {
            string json = rdr["currency_in_use"].ToString() ?? "";
            if (!string.IsNullOrWhiteSpace(json))
            {
                var value = Google.Protobuf.WellKnownTypes.Value.Parser.ParseJson(json);
                var st = new Google.Protobuf.WellKnownTypes.Struct();
                st.Fields["currency_in_use"] = value;
                salePurchaseType.Data = st;
            }
        }

        if (HasColumn(rdr, "currency_in_use"))
        {
            if (!rdr.IsDBNull("currency_in_use"))
            {
                //string jsonString = rdr["currency_in_use"].ToString();
                List<CurrencyUsing> list = JsonSerializer.Deserialize<List<CurrencyUsing>>(rdr["currency_in_use"].ToString(), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Чтобы id смапился на Id, а code на Code
                });

                salePurchaseType.CurrenciesUsing.AddRange(list);
            }
        }

        if (HasColumn(rdr, "confirmed")) 
            salePurchaseType.Confirmed = rdr["confirmed"] == DBNull.Value ? false : Convert.ToBoolean(rdr["confirmed"]);
        if (HasColumn(rdr, "by_default"))
            salePurchaseType.Default = rdr["by_default"] == DBNull.Value ? false : Convert.ToBoolean(rdr["by_default"]);
        if (HasColumn(rdr, "conf_id")) 
        { 
            if (salePurchaseType.MetaData == null) salePurchaseType.MetaData = new MetaData();
            salePurchaseType.MetaData.ConfirmedUserid = rdr["conf_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["conf_id"]);
        }
        if (HasColumn(rdr, "ID_M_GEOCOUNTRY")) 
        {
            if (salePurchaseType.Country == null) salePurchaseType.Country = new Geolocation();
            salePurchaseType.Country.Id = rdr["ID_M_GEOCOUNTRY"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["ID_M_GEOCOUNTRY"]);
        }
        if (HasColumn(rdr, "GeoLocation_MCode"))
        {
            if (salePurchaseType.Country == null) salePurchaseType.Country= new Geolocation();
            salePurchaseType.Country.Name = rdr["GeoLocation_MCode"].ToString();
        }


        return salePurchaseType;
    }

    public SalePurchaseRate FillSalePurchaseRate(DbDataReader rdr)
    {
        SalePurchaseRate s = new SalePurchaseRate();
        s.SalePurchaseType = new SalePurchaseType();
        s.MetaData = new MetaData();

        if (HasColumn(rdr, "id")) { s.Id = Convert.ToInt32(rdr["id"]); }
        if (HasColumn(rdr, "CountryCurrId")) { s.SalePurchaseType.Id = Convert.ToInt32(rdr["CountryCurrId"]); }
        if (HasColumn(rdr, "date")) { s.Date = Convert.ToDateTime(rdr["date"]).ToUniversalTime().ToTimestamp(); }
        if (HasColumn(rdr, "CBRate")) { s.RateCb = rdr.IsDBNull("CBRate") ? MyConvert.ToDecimalValue(0) : MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["CBRate"])); }

        if (HasColumn(rdr, "Rates")) { 
            var jsonRates = rdr["Rates"]; 
        }

        if (HasColumn(rdr, "SalaryRate")) { s.SalaryRate = rdr.IsDBNull("SalaryRate") ? MyConvert.ToDecimalValue(0): MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["SalaryRate"])); }
        if (HasColumn(rdr, "BankToCashRes")) { s.BankToCashRes = rdr.IsDBNull("BankToCashRes") ? MyConvert.ToDecimalValue(0): MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["BankToCashRes"])); }
        if (HasColumn(rdr, "BankToCashNonres")) { s.BankToCashNonres = s.BankToCashRes = rdr.IsDBNull("BankToCashNonres") ? MyConvert.ToDecimalValue(0) : MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["BankToCashNonres"])); }
        if (HasColumn(rdr, "CashToBank")) { s.CashToBank = rdr.IsDBNull("CashToBank") ? MyConvert.ToDecimalValue(0) : MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["CashToBank"])); }
        if (HasColumn(rdr, "Vat")) { s.Vat = rdr.IsDBNull("Vat") ? MyConvert.ToDecimalValue(0) : MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["Vat"])); }
        if (HasColumn(rdr, "Oncost")) { s.OnCost = rdr.IsDBNull("Oncost") ? MyConvert.ToDecimalValue(0) : MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["Oncost"])); }
        if (HasColumn(rdr, "MaxProfit")) { s.MaxProfit = rdr.IsDBNull("MaxProfit") ? MyConvert.ToDecimalValue(0) : MyConvert.ToDecimalValue(Convert.ToDecimal(rdr["MaxProfit"])); }

        if (HasColumn(rdr, "Checked")) { s.Checked = rdr.IsDBNull("Checked") ? false: Convert.ToBoolean(rdr["Checked"]); }
        if (HasColumn(rdr, "Confirmed")) { s.Confirmed = rdr.IsDBNull("Confirmed") ? false : Convert.ToBoolean(rdr["Confirmed"]); }

        if (HasColumn(rdr, "CheckDate")) { s.MetaData.CheckedAt = rdr.IsDBNull("CheckDate")? null: Convert.ToDateTime(rdr["CheckDate"]).ToUniversalTime().ToTimestamp(); }
        if (HasColumn(rdr, "CheckerId")) { s.MetaData.CheckedUserid = rdr.IsDBNull("CheckerId")? null: Convert.ToInt32(rdr["CheckerId"]); }
        if (HasColumn(rdr, "CheckName")) { s.MetaData.CheckedBy = Convert.ToString(rdr["CheckName"]); }
        if (HasColumn(rdr, "CheckUserName")) { s.MetaData.CheckedName = Convert.ToString(rdr["CheckUserName"]); }

        if (HasColumn(rdr, "ConfDate")) { s.MetaData.ConfirmedAt = rdr.IsDBNull("ConfDate") ? null : Convert.ToDateTime(rdr["ConfDate"]).ToUniversalTime().ToTimestamp(); }
        if (HasColumn(rdr, "ConfirmerId")) { s.MetaData.ConfirmedUserid = rdr.IsDBNull("ConfirmerId") ? null: Convert.ToInt32(rdr["ConfirmerId"]); }
        if (HasColumn(rdr, "ConfName")) { s.MetaData.ConfirmedBy = Convert.ToString(rdr["ConfName"]); }
        if (HasColumn(rdr, "ConfUserName")) { s.MetaData.ConfirmedName = Convert.ToString(rdr["ConfUserName"]); }

        return s;
    }

    private bool HasColumn(DbDataReader reader, string columnName)
    {
        bool result = true;
        try
        {
            int i = reader.GetOrdinal(columnName);
            result = true;
        }
        catch
        {
            result = false;
        }

        return result;
    }

    #endregion
   
}
using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Unit;
using GrpcCommonNet.Proto.Utils;
using GrpcCommonNet.Service.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;

namespace GrpcCommonNet.Service.Repository
{
    public class UnitRepository
    {
        private readonly string _connectionString = "";
        private readonly ILogger<UnitRepository> _logger;

        public UnitRepository(ILogger<UnitRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("MySql");
        }

        #region Методы получение данных Ед. измерения
        public async Task<Unit> GetUnitByIdAsync(long unitId, UserData userData)
        {
            try
            {
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = $@"
                    SELECT * FROM global_db.rfr_units u
                    WHERE u.UnitId = {unitId}
                    ";
                using DbDataReader rdr = await cmd.ExecuteReaderAsync();
                DataTable schemaTable = rdr.GetSchemaTable();
                Unit unit = new Unit();
                if (rdr.Read())
                    unit = UnitFill(rdr, schemaTable);
                return unit;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в GetUnitById: " + ex.Message);
            }
        }

        public async Task<List<Unit>> GetListAsync(long unitId, string unitShort, bool unitIsArchive)
        {
            string text =
                @"select *
                from global_db.rfr_units u
                where 1 = 1 ";
            List<Unit> list = new List<Unit>();
            try
            {
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = text;

                if (unitId != null && unitId != 0)
                {
                    cmd.CommandText += @"and UnitId = @unitId ";
                    cmd.Parameters.AddWithValue("@unitid", unitId);
                }
                if (!unitShort.Equals(String.IsNullOrEmpty))
                {
                    cmd.CommandText += @"and u.Short Like @unitShort ";
                    cmd.Parameters.AddWithValue("@unitShort", "%" + unitShort + "%");
                }
                if (unitIsArchive != null && unitIsArchive == false)
                {
                    cmd.CommandText += @"and u.IsArchive = @unitIsArchive ";
                    cmd.Parameters.AddWithValue("@unitIsArchive", unitIsArchive);
                }
                cmd.CommandText += @"order by u.Short;";
                using var rdr = await cmd.ExecuteReaderAsync();
                DataTable schemaTable = rdr.GetSchemaTable();
                while (await rdr.ReadAsync())
                {
                    Unit unit = UnitFill(rdr,schemaTable);
                    list.Add(unit);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в GetListAsync: " + ex.Message);
            }
            return list;
        }

        public async Task<Unit> CreateAsync(Unit unit, UserData userData)
        {
            try
            {
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = $@"INSERT INTO global_db.rfr_units (
                                        Code, Short, Rem, IsMain, Rate, FacturaCode, RWSCode, RWSMCode,
                                        EFacturaMCode, International, IsChecked, CheckerID, CheckDate,
                                        IsArchive, ReplId, Comment)
                                    VALUE (
                                        @Code, @Short, @Rem, @IsMain, @Rate, @FacturaCode, @RWSCode, @RWSMCode,
                                        @EFacturaMCode, @International, @IsChecked, @CheckerID, @CheckDate,
                                        @IsArchive, @ReplId, @Comment);
                                    SELECT * FROM global_db.rfr_units u
                                    WHERE u.UnitId = LAST_INSERT_ID();";

                cmd.Parameters.AddWithValue("@Code", unit.Code ?? string.Empty);
                cmd.Parameters.AddWithValue("@Short", unit.Short ?? string.Empty);
                cmd.Parameters.AddWithValue("@Rem", unit.Rem ?? string.Empty);
                cmd.Parameters.AddWithValue("@IsMain", unit.IsMain);
                cmd.Parameters.AddWithValue("@Rate", MyConvert.ToDecimal(unit.Rate));
                cmd.Parameters.AddWithValue("@FacturaCode", unit.FactureCode);
                cmd.Parameters.AddWithValue("@RWSCode", unit.RwsCode ?? string.Empty);
                cmd.Parameters.AddWithValue("@RWSMCode", unit.RwsMcode ?? string.Empty);
                cmd.Parameters.AddWithValue("@EFacturaMCode", unit.EfactureMcode ?? string.Empty);
                cmd.Parameters.AddWithValue("@International", unit.International ?? string.Empty);
                cmd.Parameters.AddWithValue("@IsChecked", unit.IsChecked);
                cmd.Parameters.AddWithValue("@CheckerID", unit.CheckerId);
                cmd.Parameters.AddWithValue("@CheckDate", unit.CheckDate == null ? null : unit.CheckDate.ToDateTime().ToLocalTime());
                cmd.Parameters.AddWithValue("@IsArchive", unit.IsArchive);
                cmd.Parameters.AddWithValue("@ReplId", unit.ReplId ?? string.Empty);
                cmd.Parameters.AddWithValue("@Comment", unit.Comment ?? string.Empty);

                using var rdr = await cmd.ExecuteReaderAsync();
                DataTable schema = rdr.GetSchemaTable();

                Unit newUnit = new Unit();
                if(await rdr.ReadAsync())
                {
                    newUnit = UnitFill(rdr, schema);
                }
                return newUnit;
            }
            catch (Exception ex)
            { 
                throw new Exception("Ошибка в CreateAsync: " + ex.Message);
            }
        }

        public async Task<Unit> UpdateAsync(Unit unit, UserData  userData)
        {
            try
            {
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = $@"UPDATE global_db.rfr_units
                                     SET
                                        Code  =  @Code,
                                        Short = @Short,
                                        Rem =  @Rem,
                                        IsMain = @IsMain,
                                        Rate = @Rate,
                                        FacturaCode = @FacturaCode, 
                                        RWSCode = @RWSCode, 
                                        RWSMCode = @RWSMCode,
                                        EFacturaMCode = @EFacturaMCode, 
                                        International = @International, 
                                        IsChecked = @IsChecked, 
                                        CheckerID = @CheckerID, 
                                        CheckDate = @CheckDate,
                                        IsArchive = @IsArchive, 
                                        ReplId = @ReplId, 
                                        Comment = @Comment
                                    WHERE UnitId = @id;
                                    SELECT * FROM global_db.rfr_units u
                                    WHERE u.UnitId = @id;";

                cmd.Parameters.AddWithValue("@id", unit.Id);
                cmd.Parameters.AddWithValue("@Code", unit.Code ?? string.Empty);
                cmd.Parameters.AddWithValue("@Short", unit.Short ?? string.Empty);
                cmd.Parameters.AddWithValue("@Rem", unit.Rem ?? string.Empty);
                cmd.Parameters.AddWithValue("@IsMain", unit.IsMain);
                cmd.Parameters.AddWithValue("@Rate", MyConvert.ToDecimal(unit.Rate));
                cmd.Parameters.AddWithValue("@FacturaCode", unit.FactureCode);
                cmd.Parameters.AddWithValue("@RWSCode", unit.RwsCode ?? string.Empty);
                cmd.Parameters.AddWithValue("@RWSMCode", unit.RwsMcode ?? string.Empty);
                cmd.Parameters.AddWithValue("@EFacturaMCode", unit.EfactureMcode ?? string.Empty);
                cmd.Parameters.AddWithValue("@International", unit.International ?? string.Empty);
                cmd.Parameters.AddWithValue("@IsChecked", unit.IsChecked);
                cmd.Parameters.AddWithValue("@CheckerID", unit.CheckerId);
                cmd.Parameters.AddWithValue("@CheckDate", unit.CheckDate == null ? null : unit.CheckDate.ToDateTime().ToLocalTime());
                cmd.Parameters.AddWithValue("@IsArchive", unit.IsArchive);
                cmd.Parameters.AddWithValue("@ReplId", unit.ReplId ?? string.Empty);
                cmd.Parameters.AddWithValue("@Comment", unit.Comment ?? string.Empty);

                using var rdr = await cmd.ExecuteReaderAsync();
                DataTable schema = rdr.GetSchemaTable();

                Unit newUnit = new Unit();
                if (await rdr.ReadAsync())
                {
                    newUnit = UnitFill(rdr, schema);
                }
                return newUnit;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в UpdateAsync: " + ex.Message);
            }
        }

        public async Task<bool> DeleteByIdAsync(long id, UserData userData)
        {

            try
            {
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = $@"DELETE FROM global_db.rfr_units
                                    WHERE UnitId = {id};";

                int retval = await cmd.ExecuteNonQueryAsync();

                if (retval > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в DeleteByIdAsync: " + ex.Message);
            }
        }

        public async Task<List<int>> DeleteIdsAsync(List<int> ids, UserData userData)
        {
            List<int> undeleted_list = new List<int>();
            try
            {
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = $@"DELETE IGNORE FROM global_db.rfr_units
                                    WHERE UnitId in ({string.Join(',', ids)});
                                    SELECT u.UnitId FROM global_db.rfr_units u WHERE u.UnitId IN ({string.Join(',', ids)});";

                using var rdr = await cmd.ExecuteReaderAsync();

                while(await rdr.ReadAsync())
                {
                    undeleted_list.Add(Convert.ToInt32(rdr["UserId"]));
                }
                
                return undeleted_list;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в DeleteByIdsAsync:", ex);
            }
        }

        #endregion

        #region Внутренние методы

        private Unit UnitFill(DbDataReader rdr, DataTable schemaTable)
        {
            Unit unit = new Unit();
            unit.Id = rdr["UnitId"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["UnitId"]);
            unit.Code = rdr["Code"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["Code"]);
            unit.Short = rdr["Short"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["Short"]);
            unit.Rem  = rdr["Rem"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["Rem"]);
            unit.IsMain = rdr["IsMain"] == DBNull.Value ? false : Convert.ToBoolean(rdr["IsMain"]);

            unit.Rate = MyConvert.ToDecimalValueField(rdr, "Rate");

            unit.FactureCode = rdr["FacturaCode"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["FacturaCode"]);
            unit.RwsCode  = rdr["RWSCode"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["RWSCode"]);
            unit.RwsMcode = rdr["RWSMCode"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["RWSMCode"]);
            unit.EfactureMcode = rdr["EFacturaMCode"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["EFacturaMCode"]);
            unit.International = rdr["International"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["International"]);
            unit.IsChecked = rdr["IsChecked"] == DBNull.Value ? false : Convert.ToBoolean(rdr["IsChecked"]);
            unit.CheckerId  = rdr["CheckerID"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["CheckerID"]);
            unit.CheckDate  = rdr["CheckDate"] == DBNull.Value ? null : Timestamp.FromDateTime(Convert.ToDateTime(rdr["CheckDate"]).ToLocalTime().ToUniversalTime());
            unit.IsArchive = rdr["IsArchive"] == DBNull.Value ? false : Convert.ToBoolean(rdr["IsArchive"]);
            unit.ReplId  = rdr["ReplId"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["ReplId"]);
            unit.Comment = rdr["Comment"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["Comment"]);

            return unit;    
        }

        #endregion

    }
}

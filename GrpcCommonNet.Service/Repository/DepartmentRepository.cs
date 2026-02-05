using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Department;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;

namespace GrpcCommonNet.Service.Repository
{
    public class DepartmentRepository
    {
        private readonly string _connectionString = "";
        private readonly ILogger<DepartmentRepository> _logger;

        public DepartmentRepository(IConfiguration configuration, ILogger<DepartmentRepository> logger)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("MySql");
        }

        #region Методы  получения данных Подразделений

        public async Task<Department?> GetByIdAsync(int id)
        {
            try
            {
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = conn.CreateCommand();

                cmd.CommandText = @"select SDId, Name, MCode, Code FROM global_db.rfr_subdivisions WHERE SDId = @Id";
                cmd.Parameters.AddWithValue("@Id", id);

                using var reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                    return new Department
                    {
                        Id = reader.GetInt32("SDId"),
                        Name = reader.GetString("Name"),
                        Short = reader.GetString("MCode"),
                        Symbol = reader.GetString("Code")   
                    };
                else  return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в GetByIdAsync: " + ex.Message);
            }
        }

        public async Task<List<Department>> GetListAsync(string? name)
        {
            var departments = new List<Department>();
            try
            {
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"select d.SDId, d.Name, d.MCode, d.Code FROM global_db.rfr_subdivisions d
                                    where 1 = 1
                                        and (@name is null 
                                            or @name = '' 
                                            or d.Name like CONCAT('%',@name,'%')
                                            or d.MCode like CONCAT('%',@name,'%'))
                                    order by d.Name";
                cmd.Parameters.AddWithValue("@name", name);

                using var rdr = await cmd.ExecuteReaderAsync();
                while (await rdr.ReadAsync())
                {
                    departments.Add(new Department
                    {
                        Id = Convert.ToInt32(rdr["SDId"]),
                        Name = Convert.ToString(rdr["Name"]),
                        Short = Convert.ToString(rdr["MCode"]),
                        Symbol = Convert.ToString(rdr["Code"])
                    });
                }
                return departments;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в GetListAsync: " + ex.Message);
            }
        }

        public async Task<Department> CreatetAsync(Department department)
        {
            try
            {
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = $@"
                        INSERT INTO global_db.rfr_subdivisions (
                            Name, MCode, Code)
                        VALUES (@name, @mcCode, @code);
                        select * FROM global_db.rfr_subdivisions WHERE SDId = LAST_INSERT_ID();
                ";

                cmd.Parameters.AddWithValue("@name", department.Name);
                cmd.Parameters.AddWithValue("@mcCode", department.Short);
                cmd.Parameters.AddWithValue("@code", department.Symbol);

                var rdr = await cmd.ExecuteReaderAsync();
                Department returnDepartment = new Department();
                if (await rdr.ReadAsync()) return returnDepartment = Fill(rdr);
                else  return returnDepartment;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в CreatetAsync: " + ex.Message);
            }
        }   

        public async Task<Department> UpdateAsync(Department department)
        {
            try
            {
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = $@"
                        UPDATE global_db.rfr_subdivisions 
                        SET 
                            Name = @Name,
                            MCode = @MCode,
                            Code = @Code
                        WHERE SDId = @Id;
                        select * FROM global_db.rfr_subdivisions WHERE SDId = @Id;
                ";
                cmd.Parameters.AddWithValue("@Id", department.Id);
                cmd.Parameters.AddWithValue("@Name", department.Name);
                cmd.Parameters.AddWithValue("@MCode", department.Short);
                cmd.Parameters.AddWithValue("@Code", department.Symbol);
                var rdr = await cmd.ExecuteReaderAsync();
                Department returnDepartment = new Department();
                if (await rdr.ReadAsync()) return returnDepartment = Fill(rdr);
                else  return returnDepartment;
            }
            catch (Exception ex)
            {
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
                cmd.CommandText = @"DELETE FROM global_db.rfr_subdivisions WHERE SDId = @Id";
                cmd.Parameters.AddWithValue("@Id", id);
                var rowsAffected = await cmd.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в DeleteAsync: " + ex.Message);
            }
        }

        public async  Task<List<int>> DeleteIdsAsync(IEnumerable<int> ids)
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
                   $"DELETE IGNORE FROM global_db.rfr_subdivisions d WHERE d.SDId IN ({string.Join(',', parts)}); " +
                   $"SELECT GROUP_CONCAT(d.SDId) FROM global_db.rfr_subdivisions d WHERE d.SDId IN ({string.Join(',', parts)}); ";

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
                throw new Exception("Ошибка в DeleteIdsAsync: " + ex.Message);
            }
        }

        #endregion

        private Department Fill(DbDataReader reader)
        {
            return new Department
            {
                Id = reader["SDId"] == DBNull.Value ? 0: Convert.ToInt32(reader["SDId"]),
                Name = reader["Name"] == DBNull.Value ? String.Empty : Convert.ToString(reader["Name"]),
                Short = reader["MCode"] == DBNull.Value ? String.Empty : Convert.ToString(reader["MCode"]),
                Symbol = reader["Code"] == DBNull.Value ? String.Empty : Convert.ToString(reader["Code"])
            };
        }   
    }
}

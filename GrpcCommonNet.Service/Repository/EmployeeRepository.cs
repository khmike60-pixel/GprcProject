using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Employee;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace GrpcCommonNet.Service.Repository
{
    public class EmployeeRepository
    {
        private readonly string _connectionString = "";
        private readonly ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(ILogger<EmployeeRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("MySql");
        }

        #region Методы работы с Сотрудниками
        
        /// <summary>
        /// Получить сотрудника
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Employee> GetEmployeeAsync(EmployeeRequest request)
        {
            Employee employee = new Employee();
            try
            {
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = $@"
                    SELECT 
                        e.*,
                        s.MCODE_SUBJ,
	                    u.UserAbbrev 
                    FROM cwatis.employees e 
                        left join global_db.m_subject s on e.ID_M_SUBJ = s.ID_M_SUBJ
                        left join refers.m_user u on u.UserId = e.UserId
                    WHERE employee_id = {request.Id}
                ";
                
                //cmd.Parameters.AddWithValue("@id", id);
                using var rdr = await cmd.ExecuteReaderAsync();
                if (await rdr.ReadAsync())
                {
                    employee =  FillEmployee(rdr);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в GetEmployeeAsync: " + ex.Message);
            }
            return employee;
        }

        /// <summary>
        /// Получить список сотрудников
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Employee>> ListEmployeeAsync(ListEmployeeRequest request)
        {
            List<Employee> employees= new List<Employee>();
            try
            {
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = $@"
                    SELECT 
                        e.*,
                        s.MCODE_SUBJ,
	                    u.UserAbbrev 
                    FROM cwatis.employees e 
                        left join global_db.m_subject s on e.ID_M_SUBJ = s.ID_M_SUBJ
                        left join refers.m_user u on u.UserId = e.UserId
                    WHERE 1 = 1
                        and (ifnull(@mcode,'')  = '' or MCODE_SUBJ like concat('%', @mcode, '%'))
                        and (ifnull(@Abbrev,'') = '' or UserAbbrev like concat('%', @Abbrev, '%'))
                ";
                
                cmd.Parameters.AddWithValue("@mcode", request.EmployeeName);
                cmd.Parameters.AddWithValue("@Abbrev", request.EmployeeShort);

                using var rdr = await cmd.ExecuteReaderAsync();
                Employee employee = new Employee();
                while (await rdr.ReadAsync())
                {
                    employees.Add(FillEmployee(rdr));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в GetEmployeeAsync: " + ex.Message);
            }
            return employees;
        }

        /// <summary>
        /// Создать нового сотрудника в cwatis
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Employee> CreateEmployeeAsync(CreateEmployeeRequest request)
        {
            try
            {
                Employee employee = new Employee();

                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = $@"
                    INSERT INTO cwatis.employees
                    ( e.UserId, e.ID_M_SUBJ )
                    VALUES
                    ( @UserId, @SubjectId );
                    SELECT 
                        e.*,
                        s.MCODE_SUBJ,
	                    u.UserAbbrev 
                    FROM cwatis.employees e 
                        left join global_db.m_subject s on e.ID_M_SUBJ = s.ID_M_SUBJ
                        left join refers.m_user u on u.UserId = e.UserId
                    WHERE employee_id = LAST_INSERT_ID();
                ";

                cmd.Parameters.AddWithValue("@UserId", request.Employee.User.Id);
                cmd.Parameters.AddWithValue("@SubjectId", request.Employee.Contragent.Id);

                using var rdr = await cmd.ExecuteReaderAsync();
                if (await rdr.ReadAsync())
                {
                    employee = FillEmployee(rdr);
                }

                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в CreateEmployeeAsync: " + ex.Message);
            }

        }

        /// <summary>
        /// Обновить данные сотрудника
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Employee> UpdateEmployeeAsync(UpdateEmployeeRequest request)
        {
            try
            {
                Employee employee = new Employee();

                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = $@"
                    UPDATE cwatis.employees e
                    set
                        e.UserId = @UserId, e.ID_M_SUBJ = @SubjectId
                    where e.Employee_Id = @Id;
                    SELECT 
                        e.*,
                        s.MCODE_SUBJ,
	                    u.UserAbbrev 
                    FROM cwatis.employees e 
                        left join global_db.m_subject s on e.ID_M_SUBJ = s.ID_M_SUBJ
                        left join refers.m_user u on u.UserId = e.UserId
                    WHERE employee_id = @Id;
                ";

                cmd.Parameters.AddWithValue("@Id", request.Employee.Id);
                cmd.Parameters.AddWithValue("@UserId", request.Employee.User.Id);
                cmd.Parameters.AddWithValue("@SubjectId", request.Employee.Contragent.Id);
                using var rdr = await cmd.ExecuteReaderAsync();
                if (await rdr.ReadAsync())
                {
                    employee = FillEmployee(rdr);
                }

                return employee;

            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в UpdateEmployeeAsync: " + ex.Message);
            }
        }

        /// <summary>
        /// Удолить сотрудениа по Id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteEmployeeAsync(DeleteEmployeeRequest request)
        {
            try
            {
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = $@"
                    DELETE FROM cwatis.employees e
                    where 1 = 1
                        and e.Employee_Id = {request.Id};
                ";
                var rdr = await cmd.ExecuteReaderAsync();
                if (await rdr.ReadAsync()) return false;
                else return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в DeleteEmployeeAsync: " + ex.Message);
            }
        }

        /// <summary>
        /// Удалить сотрудников по указанному списку Id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<int>> DeleteIdsAsync(IEnumerable<int> ids)
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
                   $"DELETE IGNORE FROM cwatis.employees e WHERE e.Employee_Id IN ({string.Join(',', parts)}); " +
                   $"SELECT GROUP_CONCAT(e.Employee_Id) FROM cwatis.employees e WHERE e.Employee_Id IN ({string.Join(',', parts)}); ";

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

        #region Технические методы

        private Employee FillEmployee(DbDataReader rdr)
        {
            Employee employee = new Employee();
            try
            {
                employee.Id = rdr["employee_id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["employee_id"]);
                employee.User = new User()
                {
                    Id = rdr["UserId"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["UserId"]),
                    UserSymbol = rdr["UserAbbrev"] == DBNull.Value ? "" : rdr["UserAbbrev"].ToString()
                };
                employee.Contragent = new Contragent()
                {
                    Id = rdr["ID_M_SUBJ"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["ID_M_SUBJ"]),
                    Name = rdr["MCODE_SUBJ"] == DBNull.Value ? "" : rdr["MCODE_SUBJ"].ToString()
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в FillEmployee: " + ex.Message);
            }
            return employee;
        }

        #endregion
    }


    #region Технические методы


    #endregion
}

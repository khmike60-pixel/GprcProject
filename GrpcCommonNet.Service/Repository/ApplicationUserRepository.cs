using GrpcCommonNet.Library.ApplicationUser;
using GrpcCommonNet.Library.Common;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Result = GrpcCommonNet.Library.Common.Result;

namespace GrpcCommonNet.Service.Repository
{
    public class ApplicationUserRepository
    {
        private readonly string _connectionString = "";
        private readonly ILogger<ApplicationUserRepository> _logger;

        public ApplicationUserRepository(ILogger<ApplicationUserRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("MySql");
        }

        #region Методы получения данных о приложениях пользователя 
        public async Task<List<ApplicationUser>> GetListApplicationUserAsync(ApplicationUserFilterRequest request)
        {
            List<ApplicationUser> app_user = new List<ApplicationUser>();
            try
            {
                using var connection = new MySqlConnection(_connectionString);
                await connection.OpenAsync();
                var query = @$"
                    SELECT 
                        us.MUSysId, us.IsBlockUser,
                        u.UserId, 
                        s.MSysId, s.MSysName, s.BaseName, s.ProductName
                    FROM refers.m_user_system us 
                        left JOIN refers.m_user u ON us.UserId = u.UserId
                        left JOIN refers.m_system s ON us.MSysId = s.MSysId
                    WHERE 1 = 1
                    	and ( 
                        	ifnull(@Name,'') = '' 
                        	or s.MSysName like CONCAT('%',@Name,'%') 
                        	or s.BaseName like CONCAT('%',@Name,'%') 
                        	or s.ProductName like CONCAT('%',@Name,'%')
                        )
                        and us.UserId = @UserId;";   

                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", request.UserId);
                command.Parameters.AddWithValue("@Name", request.Name);

                using var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    Application app = new Application();
                    app.Id = Convert.ToInt32(reader["MSysId"]);
                    app.Name = Convert.ToString(reader["MSysName"]);
                    app.Db = Convert.ToString(reader["BaseName"]);
                    app.Product = Convert.ToString(reader["ProductName"]);

                    User user = new User();
                    user.UserId = Convert.ToInt32(reader["UserId"]);
                    ApplicationUser applicationUser = new ApplicationUser
                    {
                        Id = Convert.ToInt32(reader["MUSysId"]),
                        IsBlocked = Convert.ToBoolean(reader["IsBlockUser"]),
                        Application = app,
                        User = user
                    };
                    app_user.Add(applicationUser);
                }
                return app_user;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в GetListApplicationUserAsync: " + ex.Message);
            }
        }
        
        public async Task<ApplicationUser> AddApplicationUserAsync(AddApplicationUserRequest request)
        {
            ApplicationUser newApplicationUser = new ApplicationUser();
            try
            {
                using var connection = new MySqlConnection(_connectionString);
                await connection.OpenAsync();
                var query = @$"
                    INSERT INTO refers.m_user_system (UserId, MSysId, IsBlockUser)
                    VALUES (@UserId, @MSysId, @IsBlockUser);
                    SELECT 
                        us.MUSysId, us.IsBlockUser,
                        u.UserId, 
                        s.MSysId, s.MSysName, s.BaseName, s.ProductName
                    FROM refers.m_user_system us 
                        left JOIN refers.m_user u ON us.UserId = u.UserId
                        left JOIN refers.m_system s ON us.MSysId = s.MSysId
                    WHERE 1 = 1
                        and us.MUSysId = LAST_INSERT_ID();";                    

                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", request.UserId);
                command.Parameters.AddWithValue("@MSysId", request.ApplicationId);
                command.Parameters.AddWithValue("@IsBlockUser", false);
                var rdr = await command.ExecuteReaderAsync();
                if (await rdr.ReadAsync())
                {
                    Application app = new Application();
                    app.Id = Convert.ToInt32(rdr["MSysId"]);
                    app.Name = Convert.ToString(rdr["MSysName"]);
                    app.Db = Convert.ToString(rdr["BaseName"]);
                    app.Product = Convert.ToString(rdr["ProductName"]);
                    User user = new User();
                    user.UserId = Convert.ToInt32(rdr["UserId"]);

                    newApplicationUser.Application = app;
                    newApplicationUser.User = user;
                    newApplicationUser.IsBlocked = Convert.ToBoolean(rdr["IsBlockUser"]);
                    newApplicationUser.Id = Convert.ToInt32(rdr["MUSysId"]);
                }
                return newApplicationUser;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в AddApplicationUserAsync: " + ex.Message);
            }
        }

        public async Task<List<ApplicationUser>> AddIdsApplicationUserAsync(AddIdsApplicationUserRequest request)
        {
            List<ApplicationUser> addedApplicationUsers = new List<ApplicationUser>();
            try
            {
                using var connection = new MySqlConnection(_connectionString);
                await connection.OpenAsync();
                var query = @$"
                    INSERT INTO refers.m_user_system (UserId, MSysId, IsBlockUser)
                    VALUES (@UserId, @MSysId, @IsBlockUser);
                    SELECT 
                        us.MUSysId, us.IsBlockUser,
                        u.UserId, 
                        s.MSysId, s.MSysName, s.BaseName, s.ProductName
                    FROM refers.m_user_system us 
                        left JOIN refers.m_user u ON us.UserId = u.UserId
                        left JOIN refers.m_system s ON us.MSysId = s.MSysId
                    WHERE 1 = 1
                        and us.MUSysId = LAST_INSERT_ID();";                    
                
                foreach (var appId in request.ApplicationIds)
                {
                    using var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserId", request.UserId);
                    command.Parameters.AddWithValue("@MSysId", appId);
                    command.Parameters.AddWithValue("@IsBlockUser", false);
                    var rdr = await command.ExecuteReaderAsync();
                    if (await rdr.ReadAsync())
                    {
                        Application app = new Application();
                        app.Id = Convert.ToInt32(rdr["MSysId"]);
                        app.Name = Convert.ToString(rdr["MSysName"]);
                        app.Db = Convert.ToString(rdr["BaseName"]);
                        app.Product = Convert.ToString(rdr["ProductName"]);
                        User user = new User();
                        user.UserId = Convert.ToInt32(rdr["UserId"]);
                        ApplicationUser newApplicationUser = new ApplicationUser
                        {
                            Application = app,
                            User = user,
                            IsBlocked = Convert.ToBoolean(rdr["IsBlockUser"]),
                            Id = Convert.ToInt32(rdr["MUSysId"])
                        };
                        addedApplicationUsers.Add(newApplicationUser);
                    }
                    rdr.Close();
                }
                return addedApplicationUsers;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в AddIdsApplicationUserAsync: " + ex.Message);
            }
        }

        public async Task<bool> DeleteApplicationUserAsync(DeleteApplicationUserRequest request)
        {
            try
            {
                using var connection = new MySqlConnection(_connectionString);
                await connection.OpenAsync();
                var query = @$"
                    DELETE FROM refers.m_user_system 
                    WHERE MUSysId = @Id;";                    
                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", request.Id);
                int affectedRows = await command.ExecuteNonQueryAsync();
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в DeleteApplicationUserAsync: " + ex.Message);
            }
        }

        public async Task<List<int>> DeleteIdsApplicationUserAsync(DeleteIdsApplicationUserRequest request)
        {
            try
            {
                using var connection = new MySqlConnection(_connectionString);
                await connection.OpenAsync();
                var query = @$"
                    DELETE IGNORE FROM refers.m_user_system
                    WHERE MUSysId IN ({string.Join(",", request.Ids)});
                    SELECT MUSysId FROM refers.m_user_system
                    WHERE MUSysId IN ({string.Join(",", request.Ids)});";
                using var command = new MySqlCommand(query, connection);
                
                List<int> undeletedIds = new List<int>();
                var rdr = await command.ExecuteReaderAsync();
                while (await rdr.ReadAsync())
                {
                    undeletedIds.Add(Convert.ToInt32(rdr["MUSysId"]));
                }
                return undeletedIds;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в DeleteIdsApplicationUserAsync: " + ex.Message);
            }
        }

        #endregion
    }
}

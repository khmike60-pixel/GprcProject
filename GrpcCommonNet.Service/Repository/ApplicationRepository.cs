using GrpcCommonNet.Library.Application;
using GrpcCommonNet.Library.Common;
using MySql.Data.MySqlClient;
using System.Data.Common;

public class ApplicationRepository
{
    private readonly string _connectionString = "";
    private readonly ILogger<ApplicationRepository> _logger;

    #region Методы получения  данных  о приложениях
    public ApplicationRepository(ILogger<ApplicationRepository> logger, IConfiguration configuration)
    {
        _logger = logger;
        _connectionString = configuration.GetConnectionString("MySql");
    }

    public async Task<Application?> GetByIdAsync(int id)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = $@"SELECT s.MSysId application_id, s.MSysName application_name, s.BaseName application_db, s.ProductName application_product 
                              FROM refers.m_system s where s.MSysId = {id}";
            using var rdr = await cmd.ExecuteReaderAsync();
            Application app = new Application();
            if (await rdr.ReadAsync())
            {
                app.Id = rdr.IsDBNull(0) ? 0 : rdr.GetInt32(0);
                app.Name = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1);
                app.Db = rdr.IsDBNull(2) ? string.Empty : rdr.GetString(2);
                app.Product = rdr.IsDBNull(3) ? string.Empty : rdr.GetString(3);
            }
            return app;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в GetByIdAsync: " + ex.Message);
        }
    }

    public async Task<List<Application>> GetListAsync(string? name, string? db, string? product)
    {
        List<Application> list = new List<Application>();
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            var whereParts = new List<string>();
            if (!string.IsNullOrEmpty(name))
            {
                whereParts.Add("s.MSysName LIKE @name");
                cmd.Parameters.AddWithValue("@name", "%" + name + "%");
            }
            if (!string.IsNullOrEmpty(db))
            {
                whereParts.Add("s.BaseName LIKE @db");
                cmd.Parameters.AddWithValue("@db", "%" + db + "%");
            }
            if (!string.IsNullOrEmpty(product))
            {
                whereParts.Add("s.ProductName LIKE @product");
                cmd.Parameters.AddWithValue("@product", "%" + product + "%");
            }

            var where = whereParts.Count > 0 ? "WHERE " + string.Join(" OR ", whereParts) : string.Empty;

            cmd.CommandText = $@"SELECT s.MSysId, s.MSysName, s.BaseName, s.ProductName
                              FROM refers.m_system s {where} LIMIT 1000";

            using var rdr = await cmd.ExecuteReaderAsync();
            while (await rdr.ReadAsync())
            {
                Application app = await FillApplication(rdr);
                list.Add(app);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в GetListAsync: " + ex.Message);
        }
        return list;
    }

    public async Task<List<Application>> GetListByUserAsync(ApplicationFilterRequest request)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @$"
                SELECT s.* 
	                FROM refers.m_user_system ms
	                    JOIN refers.m_system s ON ms.MSysId = s.MSysId
	                    JOIN refers.m_user u ON ms.UserId = u.UserId
                    WHERE u.UserId = {request.UserId}
            ";
            var rdr = await cmd.ExecuteReaderAsync();
            List<Application> list = new List<Application>();
            while (await rdr.ReadAsync())
            {
                Application app = await FillApplication(rdr);
                list.Add(app);
            }

            return list;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в GetListByUserAsync: " + ex.Message);
        }
    }

    public async Task<Application> CreateAsync(string product, string database, string name)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO refers.m_system 
                                (ProductName, BaseName, MSysName)
                                VALUES (@product, @database, @name);
                                select s.MSysId,s.ProductName, s.BaseName, s.MSysName from refers.m_system s where s.MSysId = LAST_INSERT_ID();";
            cmd.Parameters.AddWithValue("@product", product);
            cmd.Parameters.AddWithValue("@database", database);
            cmd.Parameters.AddWithValue("@name", name);

            var rdr = await cmd.ExecuteReaderAsync();

            Application app = new Application();
            if (rdr.Read())
                return new Application() {
                    Id       = rdr.IsDBNull(0) ? 0 : rdr.GetInt32(0),
                    Product  = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1),
                    Db       = rdr.IsDBNull(2) ? string.Empty : rdr.GetString(2),
                    Name     = rdr.IsDBNull(3) ? string.Empty : rdr.GetString(3)
                };
            else return null;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в CreateAsync: " + ex.Message);
        }
    }

    public async Task<Application> UpdateAsync(long id, string product, string database, string name)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"UPDATE refers.m_system 
                                SET ProductName = @product, BaseName = @database, MSysName = @name
                                where MSysId = @id;
                                select 
                                   s.MSysId,s.ProductName, s.BaseName, s.MSysName 
                                from refers.m_system s where s.MSysId = @id;";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@product", product);
            cmd.Parameters.AddWithValue("@database", database);
            cmd.Parameters.AddWithValue("@name", name);
            var rdr = await cmd.ExecuteReaderAsync();
            if (await rdr.ReadAsync()) 
                return new Application()
                {
                    Id       = rdr.IsDBNull(0) ? 0 : rdr.GetInt32(0),
                    Product = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1),
                    Db       = rdr.IsDBNull(2) ? string.Empty : rdr.GetString(2),
                    Name     = rdr.IsDBNull(3) ? string.Empty : rdr.GetString(3)
                };
            else
                return null;
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
            cmd.CommandText = @"
                                DELETE IGNORE FROM refers.m_system WHERE MSysId = @id;
                                SELECT s.MSysId FROM refers.m_system s WHERE MSysId = @id";
            cmd.Parameters.AddWithValue("@id", id);
            var rdr = await cmd.ExecuteReaderAsync();
            if (await rdr.ReadAsync()) return false;
            else return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в DeleteAsync: " + ex.Message);
        }
    }

    public  async Task<List<int>> DeleteIdsAsync(List<int> ids)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            string string_ids = string.Join(",", ids);
            cmd.CommandText = $@"DELETE IGNORE FROM refers.m_system WHERE MSysId IN ({string_ids});
                                 SELECT s.MSysId FROM refers.m_system s WHERE s.MSysId IN ({ string_ids});";
            //cmd.Parameters.AddWithValue("@string_ids", string_ids);

            using var rdr = await cmd.ExecuteReaderAsync();
            List<int> undeletedIds = new List<int>();
            while (await rdr.ReadAsync())
            {
                int id = rdr.IsDBNull(0) ? 0 : rdr.GetInt32(0);
                undeletedIds.Add(id);
            }
            return undeletedIds;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в DeleteIdsAsync: " + ex.Message);
        }
    }

    private async Task<Application> FillApplication(DbDataReader rdr)
    {
        return new Application
        {
            Id = rdr["MSysId"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["MSysId"]),
            Name = rdr["MSysName"] == DBNull.Value ? String.Empty : Convert.ToString(rdr["MSysName"]),
            Db = rdr["BaseName"] == DBNull.Value ? String.Empty : Convert.ToString(rdr["BaseName"]),
            Product = rdr["ProductName"] == DBNull.Value ? String.Empty : Convert.ToString(rdr["ProductName"])
        };
    }

    //public async Task<ApplicationOfUser> AddApplicationOfUserAsync(int userId, int appId)
    //{
    //    try
    //    {
    //        using var conn = new MySqlConnection(_connectionString);
    //        await conn.OpenAsync();
    //        using var cmd = conn.CreateCommand();
    //        cmd.CommandText = @"INSERT INTO refers.m_user_system 
    //                            (UserId, MSysId)
    //                           VALUES (@userId, @appId);
    //                            select 
    //                                us.MUSysId, 
    //                                s.MSysId,s.ProductName, s.BaseName, s.MSysName,
    //                                u.UserId, u.UserName        
    //                            from m_user_system us
    //                                left join refers.m_system s on s.MSysId = us.MSysId
    //                                left join refers.m_user u on u.UserId = us.UserId
    //                            where us.MUSysId = LAST_INSERT_ID();";
    //        cmd.Parameters.AddWithValue("@userId", userId);
    //        cmd.Parameters.AddWithValue("@appId", appId);
    //        var rdr = await cmd.ExecuteReaderAsync();
    //        ApplicationOfUser app_user = new ApplicationOfUser();
    //        Application app = new Application();
    //        User user = new User();
    //        int id = 0;
    //        if (rdr.Read())
    //        {
    //            id = rdr.IsDBNull(0) ? 0 : rdr.GetInt32(0);
    //            app = await FillApplication(rdr);
    //            user = new User()
    //            {
    //                UserId = rdr.IsDBNull(5) ? 0 : rdr.GetInt32(5),
    //                UserName = rdr.IsDBNull(6) ? string.Empty : rdr.GetString(6)
    //            };
    //        }
    //        else return null;

    //        return new ApplicationOfUser() { Id = id, Application = app, User = user };

    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception("Ошибка в AddApplicationOfUserAsync: " + ex.Message);
    //    }
    //}

    public async Task<bool> DeleteApplicationOfUserAsync(int id)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                                DELETE FROM refers.m_user_system WHERE MUSysId = @id;";
            cmd.Parameters.AddWithValue("@id", id);
            var rdr = await cmd.ExecuteReaderAsync();
            if (await rdr.ReadAsync()) return false;
            else return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в DeleteApplicationOfUserAsync: " + ex.Message);
        }
    }

    public async Task<List<int>> DeleteIdsApplicationOfUserAsync(List<int> ids)
    {
        try
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            string string_ids = string.Join(",", ids);
            cmd.CommandText = $@"DELETE IGNORE FROM refers.m_user_system WHERE MUSysId IN ({string_ids});
                                 SELECT us.MUSysId 
                                    FROM refers.m_user_system us
                                 WHERE us.MUSysId IN ({ string_ids});";
            //cmd.Parameters.AddWithValue("@string_ids", string_ids);
            using var rdr = await cmd.ExecuteReaderAsync();
            List<int> undeletedIds = new List<int>();
            while (await rdr.ReadAsync())
            {
                int id = rdr.IsDBNull(0) ? 0 : rdr.GetInt32(0);
                undeletedIds.Add(id);
            }
            return undeletedIds;
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка в DeleteIdsApplicationOfUserAsync: " + ex.Message);
        }
    }

    #endregion
}

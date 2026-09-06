using GrpcCommonNet.Library;
using GrpcCommonNet.Library.Common;
using MySql.Data.MySqlClient;

public class AuthRepository
{
    private readonly string _connectionString = "";
    private readonly ILogger<AuthRepository> _logger;

    public AuthRepository(ILogger<AuthRepository> logger, IConfiguration configuration)
    {
        _logger = logger;
        _connectionString = configuration.GetConnectionString("MySql");
    }

    public async Task<User> AuthToken(string login, string password, string app)
    {
        try
        {
            User user = new User ();

            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();
            using var cmd = conn.CreateCommand();
            cmd.CommandText =@"select
                                mu.UserId , 
	                            mu.UserName, 
	                            mu.PW, 
	                            ms.ProductName, 
	                            mus.IsBlockUser, 
	                            mu.UserAbbrev
                            from refers.m_user_system mus
                                left join refers.m_user mu on mus.UserId = mu.UserId
                                left join refers.m_system ms on mus.MSysId = ms.MSysId
                            where 1 = 1
                                and @login = UPPER(mu.UserName)
                                and @password = mu.PW
                                and @app = UPPER(ms.ProductName)
                                and mus.IsBlockUser = false;";

            cmd.Parameters.AddWithValue("@login", login.ToUpper());
            cmd.Parameters.AddWithValue("@app", app.ToUpper());
            cmd.Parameters.AddWithValue("@password", password);

            using var reader = await cmd.ExecuteReaderAsync();
            bool result =  false;
            if (await reader.ReadAsync())
            {
                user.Id = reader["UserId"] == null ? 0 : Convert.ToInt32(reader["UserId"]);
                user.UserSymbol = reader["UserAbbrev"] == null ? "" : reader["UserAbbrev"].ToString();
                result = true;
            }

            if (result == null || !result)
            {
                _logger.LogWarning("AuthToken: User not found or blocked. Login: {login}, App: {app}", login, app);
                return user;
            }
            return user;
        } catch (Exception ex)
        {
            throw new Exception("Ошибка в AuthToken: " + ex);
        }   

    }
}

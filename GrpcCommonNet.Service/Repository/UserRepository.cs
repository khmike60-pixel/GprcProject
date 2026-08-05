using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.User;
using GrpcCommonNet.Service.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data.Common;
using System.Drawing.Text;

namespace GrpcCommonNet.Service.Repository
{
    public class UserRepository
    {
        private readonly string _connectionString = "";
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(ILogger<UserRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("MySql");
        }

        #region Методы работы с пользователем
        public async Task<User> GetUserByIdAsync(int userId, UserData userData)
        {
            try
            {
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                string query = $@"SELECT u.UserId, u.UserAbbrev, u.ID_M_SUBJ, u.UserName, u.IsBlockUser, u.UserAccess,
                                      s.MCODE_SUBJ         
                                  FROM refers.m_user u 
                                    left JOIN global_db.m_subject s ON u.ID_M_SUBJ = s.ID_M_SUBJ
                                  WHERE UserId = @UserId";
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                using var rdr = await cmd.ExecuteReaderAsync();
                User user = UserFill(rdr);

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в GetUserByIdAsync:\n", ex);
            }
            ;
        }

        public async Task<List<User>> GetListAsync(UserFilterRequest request, UserData userData)
        {
            try
            {
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                string query = $@"
                    SELECT distinct  u.UserId UserId, u.UserAbbrev UserSymbol, u.UserName UserLogin, u.IsBlockUser UserIsBlocked,
                        ifnull(vc.type,2) type, vc.ContragentId, vc.Short, vc.Name
                    FROM refers.m_user u 
                        left JOIN global_db.v_contragents vc ON vc.ContragentId = u.ID_M_SUBJ 
                        left join refers.m_user_system us on us.UserId = u.UserId      
                        left join refers.m_system s on us.MSysId = s.MSysId      
                    WHERE 1 = 1
                        and (ifnull(@login,'') = '' or u.UserName Like CONCAT('%',@login,'%') or vc.Short Like CONCAT('%',@login,'%'))
                        and (ifnull(@ApplicationName,'') = '' or s.MSysName Like CONCAT('%',@ApplicationName,'%') or s.BaseName Like CONCAT('%',@ApplicationName,'%') or s.ProductName Like CONCAT('%',@ApplicationName,'%'))
                        and (ifnull(@isBlocked,'') = '' OR u.IsBlockUser = @isBlocked);
                    ";
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@login", request.UserLogin ?? string.Empty);
                cmd.Parameters.AddWithValue("@ApplicationName", request.ApplicationName ?? string.Empty);
                cmd.Parameters.AddWithValue("@isBlocked", request.HasUserIsBlocked ? request.UserIsBlocked : string.Empty);
                using var rdr = await cmd.ExecuteReaderAsync();
                List<User> users = new List<User>();
                while (await rdr.ReadAsync())
                {
                    User user = UserFill(rdr);
                    users.Add(user);
                }
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в GetListAsync: " + ex);
            }
            ;
        }

        public async Task<User> CreateUserAsync(User user, UserData userData)
        {
            try
            {
                if (user.UserId > 0) throw new Exception("Неправильные данные Пользователя:\n"); ;

                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                string query = $@"INSERT INTO refers.m_user 
                                (UserAbbrev, ";
                if (user.Contragent != null && user.Contragent.Id > 0) query += "ID_M_SUBJ, ";
                query += @$"
                                UserName, PW, IsBlockUser, UserAccess)
                                VALUE (@Symbol, ";
                if (user.Contragent != null && user.Contragent.Id > 0) query += "@ContragentId, ";
                query += @$"
                                @Login,  @Password, @IsBlocked, @Access);

                            SELECT u.UserId UserId, u.UserAbbrev UserSymbol, u.UserName UserLogin, u.IsBlockUser UserIsBlocked,
                                ifnull(vc.type,2) type, vc.ContragentId, vc.Short, vc.Name 
                            FROM refers.m_user u 
                                left JOIN global_db.v_contragents vc ON vc.ContragentId = u.ID_M_SUBJ 
                            WHERE u.UserId = LAST_INSERT_ID();";

                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Symbol", user.UserSymbol);

                if (user.Contragent != null && user.Contragent.Id > 0) cmd.Parameters.AddWithValue("@ContragentId", user.Contragent.Id);
                cmd.Parameters.AddWithValue("@Login", user.UserLogin);
                cmd.Parameters.AddWithValue("@Password", user.UserPassword);
                cmd.Parameters.AddWithValue("@IsBlocked", user.UserIsBlocked);
                cmd.Parameters.AddWithValue("@Access", user.UserAccess);
                using var rdr = await cmd.ExecuteReaderAsync();
                User newUser = new User();
                if (await rdr.ReadAsync()) 
                    user = UserFill(rdr);
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в CreateUserAsync: " + ex);
            }
        }

        public async Task<User> UpdateUserAsync(User user, UserData userData)
        {
            try
            {
                if (user.UserId == 0) throw new Exception("Неправильные данные Пользователя:\n");

                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                string query = $@"UPDATE refers.m_user 
                                SET 
                                    UserAbbrev = @Symbol, ";
                if (user.Contragent != null && user.Contragent.Id > 0) query += "ID_M_SUBJ = @ContragentId, ";
                query += $@"
                                    UserName = @Login, 
                                    PW  = @Password, 
                                    IsBlockUser  = @IsBlocked, 
                                    UserAccess  = @Access
                                WHERE UserId = @Id;
                           
                            SELECT u.UserId UserId, u.UserAbbrev UserSymbol, u.UserName UserLogin, u.IsBlockUser UserIsBlocked,
                                ifnull(vc.type,2) type, vc.ContragentId, vc.Short, vc.Name 
                            FROM refers.m_user u 
                                left JOIN global_db.v_contragents vc ON vc.ContragentId = u.ID_M_SUBJ 
                            WHERE u.UserId = @Id;";

                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", user.UserId);
                cmd.Parameters.AddWithValue("@Symbol", user.UserSymbol);
                if (user.Contragent != null && user.Contragent.Id > 0) cmd.Parameters.AddWithValue("@ContragentId", user.Contragent.Id);
                cmd.Parameters.AddWithValue("@Login", user.UserLogin);
                cmd.Parameters.AddWithValue("@Password", user.UserPassword);
                cmd.Parameters.AddWithValue("@IsBlocked", user.UserIsBlocked);
                cmd.Parameters.AddWithValue("@Access", user.UserAccess);
                using var rdr = await cmd.ExecuteReaderAsync();
                User newUser = new User();
                if (await rdr.ReadAsync())
                    newUser = UserFill(rdr);
                return newUser;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в UpdateUser: " + ex);
            }
        }

        public async Task<bool> DeleteUserAsync(long userId,UserData userData)
        {
            try
            {
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                string query = $@"DELETE FROM refers.m_user 
                                WHERE UserId = @Id;";

                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", userId);
                int qty = await cmd.ExecuteNonQueryAsync();
                if (qty == 0) return false;
                else return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в UpdateUser:\n", ex);
            }
        }

        public async Task<List<int>> DeleteIdsUserAsync(List<int> ids, UserData userData)
        {
            try {
                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();
                string string_ids = string.Join(",", ids);
                string query = $@"DELETE IGNORE FROM refers.m_user 
                              WHERE UserId in ({string_ids});
                              SELECT u.UserId FROM refers.m_user u
                              WHERE u.UserId IN ({string_ids});                   
                              ";

                using var cmd = new MySqlCommand(query, conn);
                using var rdr = await cmd.ExecuteReaderAsync();

                List<int> undeleted = new List<int>();

                while (rdr.Read()) 
                    undeleted.Add(rdr.GetInt32(0));
                return undeleted;
            }
            catch (Exception ex) {
                throw new Exception("Ошибка в DeleteIdsUserAsync:\n", ex);
            }

        }

        #endregion

        #region Внутренние  методы
        private User UserFill(DbDataReader rdr)
        {
            User user = new User();
            user.UserId = rdr["UserId"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["UserId"]);
            user.UserSymbol = rdr["UserSymbol"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["UserSymbol"]);
            user.UserLogin = rdr["UserLogin"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["UserLogin"]);
            user.UserIsBlocked = rdr["UserIsBlocked"] == DBNull.Value ? false : Convert.ToBoolean(rdr["UserIsBlocked"]);
            user.UserName = rdr["Short"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["Short"]);
            user.Contragent = new Contragent()
            {
                Id = rdr["ContragentId"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["ContragentId"]),
                Name = rdr["Name"] == DBNull.Value ? string.Empty : Convert.ToString(rdr["Name"])
            };
            return user;
        }

        #endregion
    }
}

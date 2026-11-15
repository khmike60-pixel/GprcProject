using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Permission;
using GrpcCommonNet.Service.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;
using System.Xml.Linq;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace GrpcCommonNet.Service.Repository
{
    public class PermissionRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<PermissionRepository> _logger;
        private readonly PermissionDbSources _dbSources;
        private readonly PermissionSubjects _subjects;

        public PermissionRepository(ILogger<PermissionRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("MySql");

        }

        public async Task<Permission> GetPermissionAsync(GetPermissionRequest request, UserData userData)
        {
            bool hasInLocalDb = false;
            try
            {
                string name = request.ObjectName;
                PermissionDbSources db = request.DbSources;
                string localDb = db.LocalDbName;
                string globalDb = db.GlobalDbName;

                if (string.IsNullOrEmpty(name)) return null;

                Permission permission = new();

                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();

                // Ищем в локальных  правах
                using (MySqlCommand command = new MySqlCommand($"{localDb}.GetRightValue", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@_SubjectId", request.Subjects.LocalSubjectId);
                    command.Parameters.AddWithValue("@_ObjectName", request.ObjectName);

                    using (var rdr = await command.ExecuteReaderAsync())
                    {
                        if (await rdr.ReadAsync())
                        {
                            permission = FillPermission(rdr);
                            hasInLocalDb = true;
                        }
                    }
                }

                if (hasInLocalDb) return permission;

                // Ищем в глобальнгых правах

                using (MySqlCommand command = new MySqlCommand($"{globalDb}.GetRightValue", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@_SubjectId", request.Subjects.GlobalSubjectId);
                    command.Parameters.AddWithValue("@_ObjectName", request.ObjectName);

                    using (var rdr = await command.ExecuteReaderAsync())
                    {
                        if (await rdr.ReadAsync())
                        {
                            permission = FillPermission(rdr);
                        }
                    }
                }

                return permission;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в GetPermissionAsync: " + ex.Message);
            }
        }


        private Permission FillPermission(DbDataReader rdr)
        {
            try
            {
                Permission permission = new();
                // Значение
                int intValue = rdr["value"] == DBNull.Value ? 0 : Convert.ToInt16(rdr["value"]);
                permission.Value =
                    intValue == 0 ? PermissionValue.None :
                    intValue == 10 ? PermissionValue.View :
                    intValue == 20 ? PermissionValue.Select :
                    intValue == 30 ? PermissionValue.Edit :
                    PermissionValue.None;

                // Признак проверки
                permission.CanCheck = rdr["CanCheck"] == DBNull.Value ? false : true;

                // Признак  утверждения
                permission.CanApprove = rdr["CanApprove"] == DBNull.Value ? false : true;

                // Признак суперпользователя
                permission.IsAdmin = rdr["IsAdmin"] == DBNull.Value ? false : true;

                return permission;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Permission;
using GrpcCommonNet.Service.Models;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
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

        public async Task<List<RightObject>> GetRightObjectsAsync(GetRightObjectsRequest request, UserData userData)
        {
            try
            {
                List<RightObject> rights = new();
                PermissionDbSources db = request.DbSources;

                using var conn = new MySqlConnection(_connectionString);
                await conn.OpenAsync();

                using (MySqlCommand command = new MySqlCommand($"{db}.GetRightObjects", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (var rdr = await command.ExecuteReaderAsync())
                    {
                        while(await rdr.ReadAsync())
                        {
                            if (request.FieldMask == null || request.FieldMask.Paths.Count == 0)
                                rights.Add(FillRightObject(rdr));
                            else
                            {
                                RightObject right = new RightObject();
                                request.FieldMask.Merge(FillRightObject(rdr), right);
                                rights.Add(right);
                            }
                        }
                    }
                }
                return rights;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка в GetRightObjects: " + ex.Message);
            }
        }

        public async Task<RightObject> AddRightObjectAsync(RightObjectRequest request, UserData userData)
        {
            return null;
        }

        public async Task<RightObject> EditRightObjectAsync(RightObjectRequest request, UserData userData)
        {
            return null;
        }

        public async Task<int> DeleteRightObjectAsync(DeleteRightObjectRequest request, UserData userData)
        {
            return 0;
        }

        public async Task<bool> MoveRightObjectAsync(MoveRightObjectRequest request, UserData userData)
        {
            return true;
        }

        public async Task<bool> IsRightObjectNameExistsAsync(IsRightObjectNameExistsRequest request, UserData userData)
        {
            return false;
        }

        public async Task<bool> IsRightObjectCodeExistsAsync(IsRightObjectCodeExistsRequest request, UserData userData)
        {
            return false;
        }

        public async Task<bool> IsRightObjectHasForeignKeyAsync(IsRightObjectHasForeignKeyRequest request, UserData userData)
        {
            return false;
        }

        public async Task<bool> IsRightObjectHasChildsAsync(IsRightObjectHasChildsRequest request, UserData userData)
        {
            return false;
        }



        #region ТТехнические меттоды (mapping)
        private RightObject FillRightObject(DbDataReader rdr)
        {
            RightObject right = new RightObject();
            try
            {
                right.Id = rdr["Right_Object_Id"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["Right_Object_Id"]);
                right.Name = rdr["Right_Object_Name"].ToString();
                right.Ids = rdr["Right_Object_ParentIds"].ToString();
                right.Names = rdr["Right_Object_PathCode"].ToString();
                right.Parent = new RightObject()
                {
                    Id = rdr["Right_Object_ParentId"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["Right_Object_ParentId"])
                };
                right.Code = rdr["Right_Object_Code"].ToString();
                right.IsGroup = Convert.ToBoolean(rdr["Right_Object_IsGroup"]);
                right.CheckAndApproveEnable = Convert.ToBoolean(rdr["Right_Object_CheckAndApproveEnable"]);
            }
            catch (DbException ex) {
                throw new Exception("Ошибка в FillRightObject: " + ex.Message);
            }
            return right;
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

        #endregion
    }
}

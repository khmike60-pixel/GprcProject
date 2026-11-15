using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Permission;
using GrpcWinForms.GrpcUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.PermissionManager.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly PermissionDbSources _dbSources;
        private readonly PermissionSubjects _subjects;

        public PermissionService(PermissionSubjects subjects)
        {
            _subjects = subjects;
            _dbSources = new PermissionDbSources()
            {
                GlobalDbName = GlobalConfig.GlobalDataBase,
                LocalDbName = GlobalConfig.LocalDataBase,
            };
        }

        /// <summary> Получение прав на указанный объект. </summary>
        /// <param name="name"> Имя объекта. </param>
        /// <exception cref="Exception"> В случае ошибка сервиса. </exception>
        public Permission GetPermission(string name)
        {
            try
            {
                GetPermissionRequest request = new GetPermissionRequest()
                { DbSources = _dbSources, Subjects = _subjects, ObjectName = name };

                GetPermissionResponse response = GrpcClients.GrpcClients.Permission.GetPermission(request);

                if (response.Result.Status == Status.Ok) return response.Permission;
                return response?.Permission;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении прав");
                return null;
            }
        }
    }
}

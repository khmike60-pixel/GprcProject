using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Permission;
using GrpcWinForms.Controls.UserPermissionsUI.Models;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.UserPermissionsUI.Services.Implementaions
{
    internal class RightObjectsService
    {
        //private IMapper<DataRow, RightObjectTreeModel> _rightObjectTreeMapper;
        private readonly PermissionDbSources _dbSources = new()
        {
            LocalDbName = "cwatis",
            GlobalDbName = "global_db"
        };
        private readonly string _sourceDbName;

        private readonly string _proc_GetRightObjects = "GetRightObjects";
        private readonly string _proc_AddRightObject = "AddRightObject";
        private readonly string _proc_EditRightObject = "EditRightObject";
        private readonly string _proc_DeleteRightObject = "DeleteRightObject";
        private readonly string _proc_MoveRightObject = "MoveRightObject";

        private readonly string _func_IsRightObjectNameExists = "IsRightObjectNameExists";
        private readonly string _func_IsRightObjectCodeExists = "IsRightObjectCodeExists";
        private readonly string _func_IsRightObjectHasForeignKey = "IsRightObjectHasForeignKey";
        private readonly string _func_IsRightObjectHasChilds = "IsRightObjectHasChilds";

        public RightObjectsService(string sourceDbName)
        {
            _sourceDbName = sourceDbName;
            //_rightObjectTreeMapper = new RightObjectTreeModelMapper();
        }

        /// <summary> Возвращает список объектов прав. </summary>
        public async Task<IEnumerable<RightObjectTreeModel>> Get()
        {
            try
            {
                IEnumerable<RightObjectTreeModel> rights = new List<RightObjectTreeModel>();
                GetRightObjectsRequest request = new GetRightObjectsRequest()
                {
                    DbSources = new GrpcCommonNet.Library.Common.PermissionDbSources()
                    {
                        LocalDbName = "cwatis",
                        GlobalDbName = "global_db"
                    }
                };

                GetRightObjectsResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Permission.GetRightObjectsAsync(request));
                if (response == null || response.RightObjects ==  null) return new List<RightObjectTreeModel>();
                return response.RightObjects.AsEnumerable().Select(r => ToRightObjectTreeModel(r));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return new List<RightObjectTreeModel>();
            }
        }

        /// <summary> Добавляет новый объект права. </summary>
        public async Task<RightObjectTreeModel> Add(int parentId)
        {
            try
            {
                RightObject newRightObject = new RightObject()
                {
                    Parent = new() { Id = parentId },
                    Name = GenerateUniqueName(),
                    Code = GenerateUniqueCode()
                };
                RightObjectRequest request = new RightObjectRequest()
                {
                    DbSources = _dbSources,
                    RightObject = newRightObject
                };

                RightObjectResponse response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Permission.AddRightObjectAsync(request));
                if (response == null || response.RightObject == null) return new RightObjectTreeModel();
                return ToRightObjectTreeModel(response.RightObject);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return new RightObjectTreeModel();
            }

        }

        /// <summary> Редактирование объекта права. </summary>
        public async void Edit(RightObjectTreeModel model)
        {
            try
            {
                RightObject newRightObject = new RightObject()
                {
                    Id = model.Id,
                    Parent = new() { Id = model.ParentId },
                    Name = model.Name,
                    Code = model.Code,
                    CheckAndApproveEnable = model.CheckAndApproveEnable
                };
                RightObjectRequest request = new RightObjectRequest()
                {
                    DbSources = _dbSources,
                    RightObject = newRightObject
                };

                RightObjectResponse response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Permission.EditRightObjectAsync(request));
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        /// <summary> Удаление объекта права. </summary>
        public async void Delete(RightObjectTreeModel model)
        {
            try
            {
                DeleteRightObjectRequest request = new DeleteRightObjectRequest()
                {
                    DbSources = new PermissionDbSources()
                    {
                        LocalDbName = "cwatis",
                        GlobalDbName = "global_db"
                    },
                    Id = model.Id,
                };
                DeleteRightObjectResponse response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Permission.DeleteRightObjectAsync(request));
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        /// <summary> Перемешение объекта по иерархии. </summary>
        /// <param name="model">Перемещаемый объект.</param>
        /// <param name="parentModel">Родительский объект. NULL если нужно переместить в корень.</param>
        public async void Move(RightObjectTreeModel model, RightObjectTreeModel parentModel)
        {
            try
            {
                MoveRightObjectRequest request = new MoveRightObjectRequest()
                {
                    DbSources = = _dbSources,
                    Id = model.Id,
                    ParentId = parentModel.Id
                };

                BoolResponse response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Permission.MoveRightObjectAsync(request));
                if (response == null || response.Response == true) throw new ApplicationException(_error);
                return;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        /// <summary>
        /// Возвразает true если имя уже существует.
        /// </summary>
        /// <param name="name">Имя для проверки.</param>
        /// <param name="excludeId">Необязательный параметр, указывающий идентификатор записи для исключения проверки.</param>
        public async Task<bool> IsNameExists(string name, int excludeId = -1)
        {
            try
            {
                IsRightObjectNameExistsRequest request = new IsRightObjectNameExistsRequest()
                {
                    DbSources = _dbSources,
                    Name = name,
                    ExcludeId = excludeId
                };
                BoolResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Permission.IsRightObjectNameExistsAsync(request));
                return response.Response;
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return true;
            }
        }

        /// <summary>
        /// Возвразает true если код уже существует.
        /// </summary>
        /// <param name="name">Имя для проверки.</param>
        /// <param name="excludeId">Необязательный параметр, указывающий идентификатор записи для исключения проверки.</param>
        public bool IsCodeExists(string code, int excludeId = -1) =>
            (bool)CallService.GetValueFromFunc(
                $"{_sourceDbName}.{_func_IsRightObjectCodeExists}",
                new Dictionary<string, object>()
                {
                    { "_Code", code },
                    { "_ExcludeId", excludeId }
                });

        /// <summary>
        /// Возвращает true если на объект права ссылаются внешние ключи.
        /// </summary>
        public bool HasForeignKey(int id) =>
            (bool)CallService.GetValueFromFunc(
                $"{_sourceDbName}.{_func_IsRightObjectHasForeignKey}",
                new Dictionary<string, object>()
                {
                    { "_Id", id },
                });

        /// <summary>
        /// Возвращает true если объект имеет детей.
        /// </summary>
        public bool HasChilds(int id) =>
            (bool)CallService.GetValueFromFunc(
                $"{_sourceDbName}.{_func_IsRightObjectHasChilds}",
                new Dictionary<string, object>()
                {
                    { "_Id", id },
                });

        private string GenerateUniqueName()
        {
            for (int cx = 1; cx < 2048; cx++)
            {
                string roleName = string.Format("Новое имя {0}", cx);
                if (!IsNameExists(roleName))
                    return roleName;
            }

            return String.Empty;
        }

        private string GenerateUniqueCode()
        {
            for (int cx = 1; cx < 2048; cx++)
            {
                string roleName = string.Format("New code {0}", cx);
                if (!IsCodeExists(roleName))
                    return roleName;
            }

            return String.Empty;
        }

        private RightObjectTreeModel ToRightObjectTreeModel(RightObject r)
        {
            return new RightObjectTreeModel()
            {
                Id = r.Id,
                Name = r.Name,
                Code = r.Code,
                ParentId = r.Parent.Id,
                CheckAndApproveEnable = r.CheckAndApproveEnable                
            };
        }

    }
}

using C1.Win.FlexGrid;
using GrpcWinForms.Controls.UserPermissionsUI.Models;
using GrpcWinForms.Controls.UserPermissionsUI.Services.Interfaces;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GrpcWinForms.GrpcUtils;

namespace GrpcWinForms.Controls.UserPermissionsUI.Services.Implementaions
{
    public class RightObjectsService : IRightObjectsService
    {
        //private IMapper<DataRow, RightObjectTreeModel> _rightObjectTreeMapper;
        private readonly PermissionDbSources _dbSources = new()
        {
            LocalDbName = "cwatis",
            GlobalDbName = "global_db"
        };
        private readonly string _sourceDbName;
        private readonly DbType _typeSource;

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

        public RightObjectsService(DbType source)
        {
            _typeSource = source;
            //_rightObjectTreeMapper = new RightObjectTreeModelMapper();
        }


        /// <summary> Возвращает список объектов прав. </summary>
        public IEnumerable<RightObjectTreeModel> Get()
        {
            return GetAsync().Result;
        }

        public async Task<IEnumerable<RightObjectTreeModel>> GetAsync()
        {
            try
            {
                GetRightObjectsRequest request = new GetRightObjectsRequest()
                {
                    DbSources = _dbSources,
                    DbType = _typeSource
                };

                GetRightObjectsResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Permission.GetRightObjectsAsync(request));


                if (response == null || response.RightObjects == null) 
                    return new List<RightObjectTreeModel>();

                return response.RightObjects.AsEnumerable().Select(r => ToRightObjectTreeModel(r));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return new List<RightObjectTreeModel>();
            }
        }

        /// <summary> Добавляет новый объект права. </summary>
        public RightObjectTreeModel Add(int parentId)
        {
            return AddAsync(parentId).GetAwaiter().GetResult();
        }

        private async Task<RightObjectTreeModel> AddAsync(int parentId)
        {
            try
            {
                RightObject newRightObject = new RightObject()
                {
                    Parent = new() { Id = parentId },
                    Name = (await GenerateUniqueName()),
                    Code = (await GenerateUniqueCode())
                };
                RightObjectRequest request = new RightObjectRequest()
                {
                    DbSources = _dbSources,
                    RightObject = newRightObject,
                    DbType = _typeSource
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
        public void Edit(RightObjectTreeModel model)
        {
            EditAsync(model).GetAwaiter().GetResult();
        }

        private async Task EditAsync(RightObjectTreeModel model)
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
                    RightObject = newRightObject,
                    DbType = _typeSource
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
        public void Delete(RightObjectTreeModel model)
        {
            DeleteAsync(model).GetAwaiter().GetResult();
        }

        private async Task DeleteAsync(RightObjectTreeModel model)
        {
            try
            {
                DeleteRightObjectRequest request = new DeleteRightObjectRequest()
                {
                    DbSources = _dbSources,
                    Id = model.Id,
                    DbType = _typeSource
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
        public void Move(RightObjectTreeModel model, RightObjectTreeModel parentModel)
        {
            MoveAsync(model, parentModel).GetAwaiter().GetResult();
        }

        private async Task MoveAsync(RightObjectTreeModel model, RightObjectTreeModel parentModel)
        {
            try
            {
                MoveRightObjectRequest request = new MoveRightObjectRequest()
                {
                    DbSources = _dbSources,
                    DbType = _typeSource,
                    Id = model.Id,
                    ParentId = parentModel.Id
                };

                BoolResponse response = await GrpcRetry.CallAsync(() =>
                        GrpcClients.GrpcClients.Permission.MoveRightObjectAsync(request));
                if (response == null) throw new ApplicationException();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        /// <summary>
        /// Возвразает true если имя уже существует.
        /// </summary>
        /// <param name="name">Имя для проверки.</param>
        /// <param name="excludeId">Необязательный параметр, указывающий идентификатор записи для исключения проверки.</param>
        public bool IsNameExists(string name, int excludeId = -1)
        {
            return IsNameExistsAsync(name, excludeId).GetAwaiter().GetResult();
        }

        private async Task<bool> IsNameExistsAsync(string name, int excludeId = -1)
        {
            try
            {
                IsRightObjectNameExistsRequest request = new IsRightObjectNameExistsRequest()
                {
                    DbSources = _dbSources,
                    DbType = _typeSource,
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
        public bool IsCodeExists(string code, int excludeId = -1)
        {
            return IsCodeExistsAsync(code, excludeId).GetAwaiter().GetResult();
        }

        private async Task<bool> IsCodeExistsAsync(string code, int excludeId = -1)
        {
            try
            {
                IsRightObjectCodeExistsRequest request = new IsRightObjectCodeExistsRequest()
                {
                    DbSources = _dbSources,
                    DbType = _typeSource,
                    Code = code,
                    ExcludeId = excludeId
                };
                BoolResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Permission.IsRightObjectCodeExistsAsync(request));
                return (bool)response.Response;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return true;
            }
        }

        /// <summary>
        /// Возвращает true если на объект права ссылаются внешние ключи.
        /// </summary>
        public bool HasForeignKey(int id)
        {
            return HasForeignKeyAsync(id).GetAwaiter().GetResult();
        }

        private async Task<bool> HasForeignKeyAsync(int id)
        {
            try
            {
                IsRightObjectHasForeignKeyRequest request = new IsRightObjectHasForeignKeyRequest()
                {
                    DbSources = _dbSources,
                    DbType = _typeSource,
                    Id = id
                };
                BoolResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Permission.IsRightObjectHasForeignKeyAsync(request));
                return (bool)response.Response;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return true;
            }
        }

        /// <summary>
        /// Возвращает true если объект имеет детей.
        /// </summary>
        public bool HasChilds(int id)
        {
            return HasChildsAsync(id).GetAwaiter().GetResult();
        }

        private async Task<bool> HasChildsAsync(int id)
        {
            try
            {
                IsRightObjectHasChildsRequest request = new IsRightObjectHasChildsRequest()
                {
                    DbSources = _dbSources,
                    DbType = _typeSource,
                    Id = id
                };
                BoolResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Permission.IsRightObjectHasChildsAsync(request));
                return (bool)response.Response;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return true;
            }
        }

        private async Task<string> GenerateUniqueName()
        {
            for (int cx = 1; cx < 2048; cx++)
            {
                string roleName = $"Новое имя {cx}";
                if (!(await IsNameExistsAsync(roleName)))
                    return roleName;
            }

            return String.Empty;
        }

        private async Task<string> GenerateUniqueCode()
        {
            for (int cx = 1; cx < 2048; cx++)
            {
                string roleName = $"New code {cx}";
                if (!(await IsCodeExistsAsync(roleName)))
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

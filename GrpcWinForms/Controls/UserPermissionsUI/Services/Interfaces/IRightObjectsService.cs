using GrpcWinForms.Controls.UserPermissionsUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.UserPermissionsUI.Services.Interfaces
{
    public interface IRightObjectsService
    {
        /// <summary> Возвращает список объектов прав. </summary>
        IEnumerable<RightObjectTreeModel> Get();
        Task<IEnumerable<RightObjectTreeModel>> GetAsync();

        /// <summary> Добавляет новый объект права. </summary>
        RightObjectTreeModel Add(int parentId);

        /// <summary> Редактирование объекта права. </summary>
        void Edit(RightObjectTreeModel model);

        /// <summary> Удаление объекта права. </summary>
        void Delete(RightObjectTreeModel model);

        /// <summary> Перемешение объекта по иерархии. </summary>
        /// <param name="model">Перемещаемый объект.</param>
        /// <param name="parentModel">Родительский объект. NULL если нужно переместить в корень.</param>
        void Move(RightObjectTreeModel model, RightObjectTreeModel parentModel);

        /// <summary>
        /// Возвразает true если имя уже существует.
        /// </summary>
        /// <param name="name">Имя для проверки.</param>
        /// <param name="excludeId">Необязательный параметр, указывающий идентификатор записи для исключения проверки.</param>
        bool IsNameExists(string name, int excludeId = -1);

        /// <summary>
        /// Возвразает true если код уже существует.
        /// </summary>
        /// <param name="name">Имя для проверки.</param>
        /// <param name="excludeId">Необязательный параметр, указывающий идентификатор записи для исключения проверки.</param>
        bool IsCodeExists(string code, int excludeId = -1);

        /// <summary>
        /// Возвращает true если на объект права ссылаются внешние ключи.
        /// </summary>
        bool HasForeignKey(int id);

        /// <summary>
        /// Возвращает true если объект имеет детей.
        /// </summary>
        bool HasChilds(int id);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Application = GrpcCommonNet.Library.Common.Application;

namespace GrpcWinForms.Objects.Applications.Repositories
{
    /// <summary>
    /// Доступ к данным приложений (gRPC-сервис).
    /// Все методы выбрасывают исключение, если сервер вернул ошибку.
    /// </summary>
    public interface IApplicationsRepository
    {
        Task<Application> CreateApplicationAsync(Application application);

        Task<Application> UpdateApplicationAsync(Application application);

        Task DeleteApplicationAsync(int applicationId);

        /// <returns>Идентификаторы записей, которые удалить не удалось.</returns>
        Task<List<int>> DeleteApplicationsAsync(List<int> ids);

        Task<List<Application>> GetApplicationsAsync(string name, string db, string product);
    }
}

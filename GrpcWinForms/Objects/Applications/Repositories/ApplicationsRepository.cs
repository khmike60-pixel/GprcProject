using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrpcCommonNet.Library.Application;
using GrpcCommonNet.Library.Common;
using GrpcWinForms.GrpcUtils;
using Application = GrpcCommonNet.Library.Common.Application;

namespace GrpcWinForms.Objects.Applications.Repositories
{
    internal class ApplicationsRepository
    {
        public ApplicationsRepository() { }

        /// <summary>
        /// Создает новое приложение в системе.
        /// </summary>
        /// <param name="application"></param>
        /// <returns>Новое приложение</returns>
        /// <exception cref="Exception"></exception>
        public async Task<Application> CreateApplicationAsync(Application application)
        {
            var request = new CreateApplicationRequest
            {
                Name = application.Name,
                Db = application.Db,
                Product = application.Product
            };
            var response = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Application.CreateApplicationAsync(request).ResponseAsync);

            if (response.Result.Status != Status.Ok)
            {   
                throw new Exception(string.Join(Environment.NewLine,
                    "Добавить данные не удалось.",
                    $"Ошибка при  создании нового приложения: {response.Result.Message}")); 
            }
            return response.Application;
        }

        /// <summary>
        /// Обновляет данные приложения в системе.
        /// </summary>
        /// <param name="application">Приложение для обновления</param>
        /// <returns>Обновленное приложение</returns>
        /// <exception cref="Exception"></exception>
        public async Task<Application> UpdateApplicationAsync(Application application)
        {
            var request = new UpdateApplicationRequest
            {
                Id = application.Id,
                Name = application.Name,
                Db = application.Db,
                Product = application.Product
            };
            var response = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Application.UpdateApplicationAsync(request).ResponseAsync);
            if (response.Result.Status != Status.Ok)
            {
                throw new Exception(string.Join(Environment.NewLine,
                    "Обновить данные не удалось.",
                    $"Ошибка при обновлении приложения: {response.Result.Message}"));
            }
            return response.Application;
        }

        /// <summary>
        /// Удаляет приложение из системы по его идентификатору.
        /// </summary>
        /// <param name="applicationId">Идентификатор приложения для удаления</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task DeleteApplicationAsync(int applicationId)
        {
            var request = new DeleteApplicationRequest
            {
                Id = applicationId
            };
            var response = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Application.DeleteApplicationAsync(request).ResponseAsync);
            if (response.Result.Status != Status.Ok)
            {
                throw new Exception(string.Join(Environment.NewLine,
                    "Удалить данные не удалось.",
                    $"Ошибка при удалении приложения: {response.Result.Message}"));
            }
        }

        /// <summary>
        /// Получает список всех приложений в системе.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Application>> GetApplicationsAsync(string name, string db, string product)
        {
            var request = new ApplicationFilterRequest
            {
                Name = name,
                Db = db,
                Product = product
            };
            var response = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Application.GetListApplicationAsync(request).ResponseAsync);
            if (response.Result.Status != Status.Ok)
            {
                throw new Exception(string.Join(Environment.NewLine,
                    "Не удалось получить список приложений.",
                    $"Ошибка при получении списка приложений: {response.Result.Message}"));
            }
            return response.Applications.ToList();
        }

        public async Task<List<int>> DeleteApplicationsAsync(List<int> ids)
        {
            try
            {
                DeleteIdsApplicationRequest request = new();
                request.Ids.AddRange(ids);

                var response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Application.DeleteIdsApplicationAsync(request).ResponseAsync);

                if (response.Result.Status != Status.Ok)
                {
                    throw new Exception(string.Join(Environment.NewLine,
                   "Удалить данные не удалось.",
                   $"Ошибка при удалении приложений: {response.Result.Message}"));
                }

                return [.. response.UndeletedIds];
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при удалении приложений: {ex.Message}", ex);
            }
        }

    }
}

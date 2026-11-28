using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcCommonNet.Library.Application;
using GrpcCommonNet.Library.Common;
using GrpcWinForms.GrpcUtils;
using Application = GrpcCommonNet.Library.Common.Application;

namespace GrpcWinForms.Objects.Applications.Repositories
{
    public class ApplicationsRepository : IApplicationsRepository
    {
        /// <summary>
        /// Создает новое приложение в системе.
        /// </summary>
        /// <param name="application">Данные нового приложения</param>
        /// <returns>Созданное приложение</returns>
        /// <exception cref="Exception">Сервер вернул ошибку</exception>
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

            EnsureOk(response.Result.Status, response.Result.Message,
                "Добавить данные не удалось.",
                "Ошибка при создании нового приложения");

            return response.Application;
        }

        /// <summary>
        /// Обновляет данные приложения в системе.
        /// </summary>
        /// <param name="application">Приложение для обновления</param>
        /// <returns>Обновленное приложение</returns>
        /// <exception cref="Exception">Сервер вернул ошибку</exception>
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

            EnsureOk(response.Result.Status, response.Result.Message,
                "Обновить данные не удалось.",
                "Ошибка при обновлении приложения");

            return response.Application;
        }

        /// <summary>
        /// Удаляет приложение из системы по его идентификатору.
        /// </summary>
        /// <param name="applicationId">Идентификатор приложения для удаления</param>
        /// <exception cref="Exception">Сервер вернул ошибку</exception>
        public async Task DeleteApplicationAsync(int applicationId)
        {
            var request = new DeleteApplicationRequest
            {
                Id = applicationId
            };
            var response = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Application.DeleteApplicationAsync(request).ResponseAsync);

            EnsureOk(response.Result.Status, response.Result.Message,
                "Удалить данные не удалось.",
                "Ошибка при удалении приложения");
        }

        /// <summary>
        /// Удаляет несколько приложений.
        /// </summary>
        /// <param name="ids">Идентификаторы приложений для удаления</param>
        /// <returns>Идентификаторы приложений, которые удалить не удалось</returns>
        /// <exception cref="Exception">Сервер вернул ошибку</exception>
        public async Task<List<int>> DeleteApplicationsAsync(List<int> ids)
        {
            DeleteIdsApplicationRequest request = new();
            request.Ids.AddRange(ids);

            var response = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Application.DeleteIdsApplicationAsync(request).ResponseAsync);

            EnsureOk(response.Result.Status, response.Result.Message,
                "Удалить данные не удалось.",
                "Ошибка при удалении приложений");

            return [.. response.UndeletedIds];
        }

        /// <summary>
        /// Получает список приложений по фильтру.
        /// </summary>
        /// <returns>Список приложений</returns>
        /// <exception cref="Exception">Сервер вернул ошибку</exception>
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

            EnsureOk(response.Result.Status, response.Result.Message,
                "Не удалось получить список приложений.",
                "Ошибка при получении списка приложений");

            return response.Applications.ToList();
        }

        /// <summary>
        /// Выбрасывает исключение, если сервер вернул статус, отличный от Ok.
        /// </summary>
        private static void EnsureOk(Status status, string serverMessage, string failure, string details)
        {
            if (status == Status.Ok) return;

            throw new Exception(string.Join(Environment.NewLine,
                failure,
                $"{details}: {serverMessage}"));
        }
    }
}

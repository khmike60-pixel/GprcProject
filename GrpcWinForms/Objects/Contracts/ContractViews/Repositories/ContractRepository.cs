using GrpcCommonNet.Library.Contract;
using GrpcWinForms.GrpcUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract = GrpcCommonNet.Library.Contract.Contract;

namespace GrpcWinForms.Objects.Contracts.ContractViews.Repositories
{
    public class ContractRepository
    {
        #region Работа с самим контрактом

        /// <summary>
        /// Получить данные контракта по id вместе со строками
        /// </summary>
        /// <param name="id">Id контракта</param>
        /// <returns>Контракт - Contract</returns>
        /// <exception cref="Exception"></exception>
        public async Task<Contract> GetContractAsync(int id)
        {
            try
            {
                GetContractRequest request = new GetContractRequest() { ContractId = id };
                ContractResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Contract.GetContractFullAsync(request).ResponseAsync
                    ).ConfigureAwait(false);
                if (response.Result.Status == GrpcCommonNet.Library.Common.Status.Ok)
                {
                    return response.Contract;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении контракта: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Обновить данные всего контракта (без строк)
        /// </summary>
        /// <param name="contract">Новый контракт</param>
        /// <returns>Обновленный контракт</returns>
        /// <exception cref="Exception"></exception>
        public static async Task<Contract> UpdateContractAsync(Contract contract)
        {
            try
            {
                ContractRequest request = new ContractRequest();
                request.Contract = contract;
                ContractResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Contract.UpdateContractAsync(request).ResponseAsync
                    ).ConfigureAwait(false);
                if (response.Result.Status == GrpcCommonNet.Library.Common.Status.Ok)
                    return response.Contract;
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при обновлении контракта: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Обновить конкретных полей контракта (без строк)
        /// </summary>
        /// <param name="request">Запрос должен иметь непустой Fields с перечнем обновляемых полей</param>
        /// <returns>Обновленный контракт</returns>
        /// <exception cref="Exception"></exception>
        public static async Task<Contract> UpdateContractAsync(ContractRequest request)
        {
            try
            {
                if(request.FieldMask == null || request.FieldMask.Paths.Count == 0)
                    throw new ($"Неправильное использование метода UpdateContractFieldsAsync");

                ContractResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Contract.UpdateContractAsync(request).ResponseAsync
                    ).ConfigureAwait(false);
                if (response.Result.Status == GrpcCommonNet.Library.Common.Status.Ok)
                    return response.Contract;
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при обновлении контракта: {ex.Message}", ex);
            }
        }
        #endregion

        #region Работа со строками

        /// <summary>
        /// Получение списка строк контракта 
        /// </summary>
        /// <param name="all">Если all = true, то возвращаются все строки. Если all = false, то возвращаются только новые и измененные строки</param>
        /// <returns>Возвращается список List(Line)</returns>
        /// <exception cref="Exception"></exception>
        public static async Task<List<Line>> RefreshLinesAsync(bool all)
        {
            try
            {
                List<Line> lines = new List<Line>();
                ContractLineRequest request = new();
                request.All = all;
                ListContractLinesResponse response = await GrpcRetry.CallAsync(() =>
                GrpcClients.GrpcClients.Contract.GetListContractLinesAsync(request).ResponseAsync).ConfigureAwait(false);
                if (response.Result.Status == GrpcCommonNet.Library.Common.Status.Ok)
                    lines.AddRange(response.Lines);
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении строк контракта: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Удаление строк контракта по списку id
        /// </summary>
        /// <param name="ids">Список id, которые должны быть удалены</param>
        /// <returns>Возвращает список id, которые не были удалены. При полном удалении кол-во элементов в список == 0</returns>
        /// <exception cref="Exception"></exception>
        public static async Task<List<int>> DeleteIdsContractLineAsync(List<int> ids)
        {
            try
            {
                List<int> undeleted = new List<int>();
                DeleteIdsContractLineRequest request = new();
                request.Ids.AddRange(ids);
                UndeletedIdsContractLineResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Contract.DeleteIdsContractLineAsync(request).ResponseAsync).ConfigureAwait(false);
                if (response.Result.Status == GrpcCommonNet.Library.Common.Status.Ok)
                    return undeleted;
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при удалении: {ex.Message}", ex);
            }
        }

        public static async Task<Line> UpdateContractLineAsync(Line line)
        {
            throw new Exception($"Метод пока не реализован: ");
        }
        #endregion

    }
}

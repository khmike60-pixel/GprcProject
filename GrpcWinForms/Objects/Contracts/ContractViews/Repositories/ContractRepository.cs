using GrpcCommonNet.Library.Contract;
using GrpcWinForms.GrpcUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Contracts.ContractViews.Repositories
{
    public class ContractRepository
    {
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


        public static async Task<Contract> UpdateContract(Contract contract)
        {
            try
            {
                ContractRequest request = new ContractRequest();
                request.Contract = contract;
                ContractResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.Contract.UpdateContractAsync(request).ResponseAsync
                    ).ConfigureAwait(false);
                if(response.Result.Status == GrpcCommonNet.Library.Common.Status.Ok)
                {
                    return response.Contract;
                }
                return null;
            }
            catch (Exception ex) {
                throw new Exception($"Ошибка при обновлении контракта: {ex.Message}", ex);
            }
        }
}

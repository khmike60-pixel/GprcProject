using GrpcCommonNet.Library.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Contracts.Models
{
    /// <summary>
    /// класс-посредник для событий
    /// </summary>
    public class ContractEventService
    {
        private static readonly ContractEventService _instance = new ContractEventService();

        public static ContractEventService Instance => _instance;

        private ContractEventService() { }

        // Событие, на которое будут подписываться формы
        public event EventHandler<ContractChangedEventArgs> ContractChanged;

        // Метод для вызова события
        public void RaiseContractChanged(Contract contract, ContractChangeType changeType)
        {
            ContractChanged?.Invoke(this, new ContractChangedEventArgs(contract, changeType));
        }
    }
}

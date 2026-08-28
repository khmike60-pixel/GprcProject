using GrpcCommonNet.Library.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Contracts.Models
{

    /// <summary>
    /// Класс аргументов события (добавлено, создано, удалено)
    /// </summary>
    public class ContractChangedEventArgs
    {
        public Contract Contract { get; }
        public ContractChangeType ChangeType { get; }

        public ContractChangedEventArgs(Contract contract, ContractChangeType changeType)
        {
            Contract = contract;
            ChangeType = changeType;
        }
    }
    public enum ContractChangeType
    {
        Updated,
        Created,
        Deleted
    }
}

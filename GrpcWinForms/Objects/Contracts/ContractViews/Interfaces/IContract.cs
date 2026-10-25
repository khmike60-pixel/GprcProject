using GrpcCommonNet.Library.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract = GrpcCommonNet.Library.Contract.Contract;

namespace GrpcWinForms.Objects.Contracts.ContractViews.Interfaces
{
    public interface IContract
    {
        
        BindingList<Line> Lines { get; set; }           // Строки контракта

        Contract Contract { get; set; }                 // Текущий контракт
        Contract UpdateContract(Contract contract);     // Обновить контракт
        Contract AddContract(Contract contract);        // Добавить новый контракт
        Contract SetStatus(Contract contract);          // Установить статус контракта

        Line UpdateLine(Line line);                     // Обновить строку контракта
        Line AddLine(Line line);                        // Добавить новую строку контракта
        

    }
}

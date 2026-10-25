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


        void RefreshContract();                         // Обновление всего контракта со строками
        Contract UpdateContract(Contract contract);     // Обновить контракт
        Contract AddContract(Contract contract);        // Добавить новый контракт
        Contract SetStatus(Contract contract);          // Установить статус контракта


        void RefreshLines();                            // Обновление строк контракта
        Line UpdateLine(Line line);                     // Обновить строку контракта
        Line AddLine(Line line);                        // Добавить новую строку контракта
        List<int> DeleteLines(List<int> rows);          // Удаление помеченных строк грида. Возвращается неудаленные строки грида.


    }
}

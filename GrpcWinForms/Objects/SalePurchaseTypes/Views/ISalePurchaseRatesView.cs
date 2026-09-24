using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using SmartLib;
using GrpcWinForms.Objects.SalePurchaseTypes.Models;
using System.Collections.Generic;

namespace GrpcWinForms.Objects.SalePurchaseTypes.Views
{
    public interface ISalePurchaseRatesView
    {
        // События: презентер подписывается, view только вызывает
        event Func<CancellationToken, Task> OnLoadAsync;
        event Func<SalePurchaseGridRate, CancellationToken, Task> OnCommitEditAsync; // создаёт/обновляет запись после редактирования в строке
        event Func<IReadOnlyList<int>, CancellationToken, Task> OnDeleteAsync;
        event Func<SalePurchaseGridRate, CancellationToken, Task> OnAppendAsync;
        // UI утилиты
        void SetBusy(bool busy);
        void ShowError(string message);
        void ShowRates(BindingList<SalePurchaseGridRate> rates);
        SmartGrid Grid { get; }
        BindingSource RatesBindingSource { get; }
    }
}

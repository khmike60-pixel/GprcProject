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
        event Func<RateRow, CancellationToken, Task> OnCommitEditAsync; // создаёт/обновляет запись после редактирования в строке
        event Func<IReadOnlyList<int>, CancellationToken, Task> OnDeleteAsync;
        event Func<RateRow, CancellationToken, Task> OnAppendAsync;

        // UI объекты
        DateTime DateStart { get; }
        DateTime DateEnd { get; }
        string CountryCode { get; set; }
        string CurrencyCode { get; set; }
        int SalePurchaseTypeId { get; }

        // UI утилиты
        void SetBusy(bool busy);
        void ShowError(string message);
        void ShowRates(BindingList<RateRow> rates);
        SmartGrid Grid { get; }
        BindingSource RatesBindingSource { get; }
    }
}

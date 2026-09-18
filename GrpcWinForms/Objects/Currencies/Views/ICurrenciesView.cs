using C1.Win.FlexGrid;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Currency;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Currencies.Views
{
    public interface ICurrenciesView
    {
        // Фильтры / состояние UI
        bool IncludeInvisible { get; }
        string CurrencyAbbrev { get; }
        bool DialogMode { get; }

        // Список валют (View владеет BindingList для привязки к гриду)
        BindingList<Currency> Currencies { get; set; }

        // Положение/выделение в гриде
        int RowSel { get; }
        IList<int> SelectedRows { get; }

        // Вспомогательные операции, которые View умеет выполнять
        DialogResult ShowCurrencyDialog(Form form);
        void ShowMessage(string text, string caption = "", MessageBoxButtons buttons = MessageBoxButtons.OK);
        void CloseWithResult(Currency selected);

        // Методы для минимального управления обновлением UI (по необходимости)
        void BeginUpdate();
        void EndUpdate();
    }
}
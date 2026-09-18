using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Currency;
using System;
using System.ComponentModel;

namespace GrpcWinForms.Objects.Currencies.Views
{
    public interface IRatesView
    {
        // Параметры фильтра
        bool IncludeInvisible { get; }
        string Abbrev { get; }
        DateTime DateRates { get; }

        // Коллекции, привязанные к гриду
        BindingList<CurrencyRate> CurrencyRates { get; set; }
        BindingList<Rate> Rates { get; set; }

        // Получить выбранную валюту (или null)
        CurrencyRate GetSelectedCurrencyRate();

        // Управление loader'ом
        void ShowLoader();
        void HideLoader();

        // Показ сообщений
        void ShowMessage(string text, string caption = "");

        // Текущее положение/выбор строки (если нужно)
        int RowSel { get; }
    }
}
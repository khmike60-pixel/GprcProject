using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Currency;
using System;
using System.ComponentModel;

namespace GrpcWinForms.Objects.Currencies.Views.Interfaces
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
        
        //int GetSelectedIndexCurrencyRate(); Не используется

        Rate GetSelectedRate();

        // Управление доступом к UI при обновлении данных
        void SetBusy(bool busy);

        // Показ сообщений
        void ShowMessage(string text, string caption = "");

        /// <summary>
        /// Текущее положение/выбор строки курсов в коллекции
        /// </summary>
        int RowCol { get; }

        /// <summary>
        /// Текущее положение/выбор строки курсов в гриде
        /// </summary>
        int Row { get; set; }

        /// <summary>
        /// Отмеченные курсы валют  в коллекции курсов
        /// </summary>
        List<Rate>  SelectedRates {  get; }

        /// <summary>
        /// Отмеченные строки в гриде курсов
        /// </summary>
        List<int> SelectedRows { get; set; }

        int GetRateId(int index);
    }
}
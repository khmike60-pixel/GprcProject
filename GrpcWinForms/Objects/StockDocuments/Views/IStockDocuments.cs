using GrpcCommonNet.Library.Common;
using SmartLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.StockDocuments.Views
{
    public interface IStockDocuments
    {
        #region Общие Свойства
        bool DialogMode { get; }
        BindingList<StockOperation> Operations { get; set; }
        int Row { get; set; }                   // Строка позиционирования в гриде
        IList<int> SelectedRows { get; set; }   // Список выделенных строк в гриде (номера строк)
        #endregion

        #region Свойства формы зоны фильтрации
        PeriodBox Period { get; set; }
        Contragent ContragentTo {  get; set; }
        Contragent ContragentFrom { get; set; }
        Stock Stock {  get; set; }
        DocumentType Type { get; set; }
        string Number { get; set; }
        #endregion

        #region Методы


        #endregion


    }
}

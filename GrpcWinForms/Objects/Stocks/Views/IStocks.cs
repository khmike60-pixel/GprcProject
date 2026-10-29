using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Geolocation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Stocks.Views
{
    public interface IStocks
    {
        #region Общие свойства и объекты
        BindingList<Stock> Stocks { get; set; }         // Склады
        BindingList<GeoPlace> GeoPlaces { get; set; }   // Места  хранения

        int RowStock { get; set; }                      // Строка позиционирования в гриде складов
        int RowPlace { get; set; }                      // Строка позиционирования в гриде мест храненния
        IList<int> SelectedRowsStock { get; set; }      // Список выделенных строк в гриде складов (номера строк)
        IList<int> SelectedRowsPlace { get; set; }      // Список выделенных строк в гриде мест хранения (номера строк)
        #endregion

        #region Объекты зоны фильтрации
        string NameText { get; }

        #endregion


    }
}

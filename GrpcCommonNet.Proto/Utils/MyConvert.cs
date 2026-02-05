using GrpcCommonNet.Library.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GrpcCommonNet.Proto.Utils
{
    public static class MyConvert 
    {
        public static Decimal ToDecimal(DecimalValue value)
        {
            if (value == null) return 0;
            return (decimal)(value.Units / Math.Pow(10,value.Scale));
        }

        public static DecimalValue ToDecimalValue(decimal? value, int scale)
        {
            if (value == null) 
                return new DecimalValue { Units = 0, Scale = scale };
            return new DecimalValue{ Units = (int)((double)value * Math.Pow(10, scale)), Scale = scale };    
        }

        public static DecimalValue ToDecimalValueField(DbDataReader rdr, string fieldName, DataTable? schema = null)
        {
            if (string.IsNullOrEmpty(fieldName)) return new DecimalValue { };
            if (schema == null) schema = rdr.GetSchemaTable();
            
            for (int i = 0; i < schema.Rows.Count; i++) 
            {
                DataRow row = schema.Rows[i];
                if (row["ColumnName"].ToString() == fieldName)
                {
                    if (rdr[i] == null) break;
                    int scale = Convert.ToInt32(row["NumericScale"].ToString());
                    return new DecimalValue { Units = (long)(rdr.GetDouble(i) * Math.Pow(10, scale)), Scale = scale};
                }
            }
            return new DecimalValue { };
        }

        /// <summary>
        /// Функция возвращает список "неудаленных" строк в gride.
        /// Используется при удалении записей по Ids.
        /// grid - сам grid
        /// data - список изображаемых данных в grid
        /// undeletedList - список не удаленных идентификаторов в данных (по умолчанию "Id")
        /// markedList - список помеченных строк в grid с учетом заголовков
        /// fieldNameId - наименование колонки идентификатора в гриде. По умолчанию "Id"
        /// </summary>
        /// <returns></returns>
        //public static List<int> UndeleteList<T>(C1FlexGrid grid, System.ComponentModel.BindingList<T> data, List<int> undeletedlist, List<int> markedList, string fieldNameId = "Id")
        //{
        //    List<int> _listGrid = new List<int>();

        //    _listGrid.AddRange(markedList); _listGrid.Sort(); // Делаем копию списка помеченных строки в гриде и сортируем

        //    for (int j = _listGrid.Count - 1; j >= 0; j--)
        //    {
        //        int index_grid = _listGrid[j];  // Номер помеченной строки в гриде

        //        int id = Convert.ToInt32(grid.Rows[index_grid][fieldNameId]);  // Значение иденификатора в колонке грида
        //        if (undeletedlist.IndexOf(id) == -1) // Если в списке неудаленных отсутствует, то
        //        {
        //            int countData = grid.Rows.Count - grid.Rows.Fixed - grid.Footers.Descriptions.Count; // кол-во строк данных в гриде
        //            int index_data = index_grid - grid.Rows.Fixed; // номер строки в данных (без заколовков)
        //            if (index_data >= 0 && index_data < countData) 
        //            {
        //                data.RemoveAt(index_data); // Удаляет элемент из данных
        //                _listGrid.RemoveAt(j);    // Удаляктся элемент из помеченых

        //            }
        //        }
        //    }
        //    return _listGrid;
        //}

    }
}

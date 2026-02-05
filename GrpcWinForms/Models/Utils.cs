using C1.Win.FlexGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Models
{
    public static class Utils
    {
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
        public static List<int> UndeleteList<T>(C1FlexGrid grid, System.ComponentModel.BindingList<T> data, List<int> undeletedlist, List<int> markedList, string fieldNameId = "Id")
        {
            List<int> _listGrid = new List<int>();

            _listGrid.AddRange(markedList); _listGrid.Sort(); // Делаем копию списка помеченных строки в гриде и сортируем

            for (int j = _listGrid.Count - 1; j >= 0; j--)
            {
                int index_grid = _listGrid[j];  // Номер помеченной строки в гриде

                int id = Convert.ToInt32(grid.Rows[index_grid][fieldNameId]);  // Значение иденификатора в колонке грида
                if (undeletedlist.IndexOf(id) == -1) // Если в списке неудаленных отсутствует, то
                {
                    int countData = grid.Rows.Count - grid.Rows.Fixed - grid.Footers.Descriptions.Count; // кол-во строк данных в гриде
                    int index_data = index_grid - grid.Rows.Fixed; // номер строки в данных (без заколовков)
                    if (index_data >= 0 && index_data < countData)
                    {
                        data.RemoveAt(index_data); // Удаляет элемент из данных
                        _listGrid.RemoveAt(j);    // Удаляктся элемент из помеченых

                    }
                }
            }
            return _listGrid;
        }
    }
}

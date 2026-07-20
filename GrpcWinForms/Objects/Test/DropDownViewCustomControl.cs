using C1.Win.FlexGrid;
using C1.Win.Input.MultiColumnCombo;
using C1.Win.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GrpcWinForms.Objects.Test
{
    public partial class DropDownViewCustomControl : UserControl, IDropDownView
    {
        BindingList<object> binding = new BindingList<object>();

        public DropDownViewCustomControl()
        {
            InitializeComponent();
        }

        public object Value
        {
            get
            {
                string valueMember = "";
                Control cur = this.Parent;
                while (cur != null)
                {
                    // попытаемся найти поле/свойство, указывающее на хозяина Combo и закрыть его через отражение
                    try
                    {
                        var owningCombo = TryGetOwningComboFromWrapper(cur);
                        if (owningCombo != null)
                        {
                            try
                            {
                                valueMember = owningCombo.ValueMember;
                            }
                            catch { }
                            break;
                        }
                    }
                    catch { }
                    cur = cur.Parent;
                }

                return GetValue(SelectedIndex, GetColumnIndex(valueMember));
            }
        }
        public bool AutoGenerateColumns { get; set; } = false;
        public object DataSource
        {
            get { return grid.DataSource; }
            set { grid.DataSource = value; }
        }
        public string DataMember { get => grid.DataMember; set => grid.DataMember = value; }
        public int SelectedIndex { get; set; }

        public bool HasSelection => this.SelectedIndex > -1;

        public int ItemsCount => this.grid.Rows.Count - this.grid.Rows.Fixed - this.grid.Footers.Descriptions.Count;

        public bool RowTracking { get; set; }
        public bool ShowColumnHeaders { get; set; }
        public int HeaderHeight { get; set; }
        public int DefaultColumnWidth { get; set; }
        public bool ExtendLastColumn { get; set; }
        public int ItemHeight { get; set; }
        public DisplayColumnCollection Columns
        {
            get
            {
                DisplayColumnCollection columns = new DisplayColumnCollection();
                if (DataSource != null)
                {
                    if (AutoGenerateColumns) // автоматически генерировать колонки
                    {
                        // Автоматическое создание колонок на основе свойств объектов
                        var dataType = DataSource.GetType();
                        if (dataType.IsGenericType && dataType.GetGenericTypeDefinition() == typeof(BindingList<>))
                        {
                            var itemType = dataType.GetGenericArguments()[0];
                            var properties = itemType.GetProperties();
                            foreach (var prop in properties)
                            {
                                columns.Add(new DisplayColumn
                                {
                                    Name = prop.Name,
                                    Caption = prop.Name, // Можно использовать атрибуты для более красивых заголовков
                                    Width = -1,
                                    Visible = true
                                });
                            }
                        }
                    }
                    else // Колонки указаны в свойстве грида
                    {
                        foreach (Column col in grid.Cols)
                        {
                            columns.Add(new DisplayColumn
                            {
                                Name = col.Name,
                                Caption = col.Caption,
                                Width = col.Width,
                                Visible = col.Visible,
                                AllowSorting = col.AllowSorting
                            });
                        }

                    }
                }
                return columns;
            }

            set
            {
                DisplayColumnCollection columns = new DisplayColumnCollection();
                if (DataSource == null) return;

                if (AutoGenerateColumns) // Автоматическая генерация колонок
                {
                    // Автоматическое создание колонок на основе свойств объектов
                    var dataType = DataSource.GetType();
                    if (dataType.IsGenericType && dataType.GetGenericTypeDefinition() == typeof(BindingList<>))
                    {
                        var itemType = dataType.GetGenericArguments()[0];
                        var properties = itemType.GetProperties();
                        foreach (var prop in properties)
                        {
                            columns.Add(new DisplayColumn
                            {
                                Name = prop.Name,
                                Caption = prop.Name, // Можно использовать атрибуты для более красивых заголовков
                                Width = -1,
                                Visible = true
                            });
                        }
                    }
                    Columns = columns;
                    return;
                }
                else    // Колонки указаны в свойстве грида
                {
                    value.Clear();
                    foreach (Column col in grid.Cols)
                    {
                        value.Add(new DisplayColumn
                        {
                            Name = col.Name,
                            Caption = col.Caption,
                            Width = col.Width,
                            Visible = col.Visible,
                            AllowSorting = col.AllowSorting
                        });
                    }
                    Columns = value;
                    return;
                }
            }
        }
        public IList<GroupDescription> GroupDescriptions
        {
            get
            {
                List<GroupDescription> groupDescriptions = new List<GroupDescription>();
                for (int i = 0; i < grid.Footers.Descriptions.Count; i++)
                {
                    var footer = grid.Footers.Descriptions[i];
                    groupDescriptions.Add(new GroupDescription(footer.Caption));
                }
                return new List<GroupDescription>();
            }
            set
            { }
        }
        public bool AllowSorting
        {
            get => grid.AllowSorting == AllowSortingEnum.SingleColumn;
            set { if (value) grid.AllowSorting = AllowSortingEnum.SingleColumn; else grid.AllowSorting = AllowSortingEnum.None; }
        }
        public string AddItemSeparator { get; set; }
        IList<GroupDescription> IDropDownView.GroupDescriptions
        {
            get
            {
                IList<GroupDescription> groupDescriptions = new List<GroupDescription>();
                for (int i = 0; i < grid.Footers.Descriptions.Count; i++)
                {
                    var footer = grid.Footers.Descriptions[i];
                    groupDescriptions.Add(new GroupDescription(footer.Caption));
                }
                return groupDescriptions;
            }
            set
            {
                if (value != null)
                {
                    grid.Footers.Descriptions.Clear();
                    foreach (var group in value)
                    {
                        grid.Footers.Descriptions.Add(new C1.Win.FlexGrid.FooterDescription { Caption = group.PropertyName });
                    }
                }
            }
        }

        public event EventHandler SelectionChanged;
        public event EventHandler DataBindingComplete;
        public event EventHandler Sorted;

        public void AddColumnHeaders(string headers)
        {
            // throw new NotImplementedException();
        }

        public void AddItem(string newItem)
        {
            // throw new NotImplementedException();
        }

        public void ApplySearch(string text, bool highlight, bool filter)
        {
            // return;
        }

        public void ApplyStyle(BaseStyle currentTheme)
        {
            // return;
        }

        public void ClearItems()
        {
            // return;
        }

        public int FindString(string value, int startIndex = 0, int columnIndex = -1, bool caseSensitive = false, bool fullMatch = false, bool wrap = false)
        {
            // throw new NotImplementedException();
            return -1;
        }

        public int GetColumnIndex(string columnName)
        {
            // throw new NotImplementedException();
            for (int i = 0; i < this.Columns.Count; i++)
                if (this.Columns[i].Name.ToString().Equals(columnName)) return i;
            return -1;
        }

        public Control GetControl()
        {
            return this;
        }

        public int GetHeight(int itemsCount)
        {
            // throw new NotImplementedException();
            return 200;
        }

        public object GetValue(int rowIndex, int columnIndex)
        {
            // Если нет источника данных или неверный индекс — возвращаем null
            if (DataSource == null || rowIndex < 0) return null;

            object ds = DataSource;

            // Поддержка BindingSource-обёртки: используем реальный список/источник внутри
            if (ds is BindingSource bs)
            {
                if (bs.List != null) ds = bs.List;
                else if (bs.DataSource != null) ds = bs.DataSource;
            }

            // Попытка получить имя колонки из коллекции отображаемых колонок (если оно задано)
            string columnName = null;
            try
            {
                if (this.Columns != null && columnIndex >= 0 && columnIndex < this.Columns.Count)
                    columnName = this.Columns[columnIndex].Name;
            }
            catch { /* игнорируем ошибки получения колонок */ }

            // Если источник — IList (включая BindingList<T>, List<T> и т.п.)
            if (ds is System.Collections.IList list)
            {
                if (rowIndex >= list.Count) return null;
                var item = list[rowIndex];
                var val = GetPropertyValue(item, columnName);
                return val is DBNull ? null : val;
            }

            // Если источник — DataTable
            if (ds is DataTable dt)
            {
                if (rowIndex < 0 || rowIndex >= dt.Rows.Count) return null;
                var row = dt.Rows[rowIndex];
                if (!string.IsNullOrEmpty(columnName) && dt.Columns.Contains(columnName))
                    return row[columnName] is DBNull ? null : row[columnName];
                if (columnIndex >= 0 && columnIndex < dt.Columns.Count)
                    return row[columnIndex] is DBNull ? null : row[columnIndex];
                return null;
            }

            // Если источник — DataView
            if (ds is DataView dv)
            {
                if (rowIndex < 0 || rowIndex >= dv.Count) return null;
                var dr = dv[rowIndex].Row;
                if (!string.IsNullOrEmpty(columnName) && dr.Table.Columns.Contains(columnName))
                    return dr[columnName] is DBNull ? null : dr[columnName];
                if (columnIndex >= 0 && columnIndex < dr.Table.Columns.Count)
                    return dr[columnIndex] is DBNull ? null : dr[columnIndex];
                return null;
            }

            // Общий IEnumerable — проходим итератор до нужной строки
            if (ds is System.Collections.IEnumerable enm)
            {
                var enumerator = enm.GetEnumerator();
                int i = 0;
                while (enumerator.MoveNext())
                {
                    if (i == rowIndex)
                    {
                        var item = enumerator.Current;
                        var val = GetPropertyValue(item, columnName);
                        return val is DBNull ? null : val;
                    }
                    i++;
                }
            }

            // Не удалось извлечь значение — возвращаем null
            return null;
        }

        public int GetWidth()
        {
            //throw new NotImplementedException();
            return this.Width;
        }

        public void InsertItem(string newItem, int rowIndex)
        {
            //throw new NotImplementedException();
        }

        public void RemoveItem(int rowIndex)
        {
            // throw new NotImplementedException();
        }

        public void ScrollToCell(int columnIndex, int rowIndex)
        {
            // throw new NotImplementedException();
        }

        public void Select(object value, string columnName)
        {

            // throw new NotImplementedException();
        }

        public void SetItemData(int rowIndex, int columnIndex, string data)
        {
            // throw new NotImplementedException();
        }

        public void Sort(int columnIndex, SortDirection direction)
        {
            // throw new NotImplementedException();
        }

        public void Sort(string columnName, SortDirection direction)
        {
            // throw new NotImplementedException();
        }

        public void buttonOk_Click(object sender, EventArgs e)
        {
            // Вычисляем выбранный индекс относительно первых фиксированных строк
            int fixedRows = this.grid.Rows.Fixed;
            int footerCount = this.grid.Footers?.Descriptions?.Count ?? 0;
            int lastDataRow = this.grid.Rows.Count - fixedRows - footerCount;
            int currentRow = this.grid.Row;

            if (currentRow >= fixedRows && currentRow <= lastDataRow)
            {
                this.SelectedIndex = currentRow - fixedRows;
            }
            else
            {
                this.SelectedIndex = -1;
            }

            // Ищем C1MultiColumnCombo по цепочке Parent-ов и закрываем ближайший DropDownControl (если есть)
            Control cur = this.Parent;
            while (cur != null)
            {
                // попытаемся найти поле/свойство, указывающее на хозяина Combo и закрыть его через отражение
                try
                {
                    var owningCombo = TryGetOwningComboFromWrapper(cur);
                    if (owningCombo != null)
                    {
                        try { owningCombo.DroppedDown = false; owningCombo.Focus(); } catch { }
                        break;
                    }
                }
                catch { }

                cur = cur.Parent;
            }

            this.SelectionChanged?.Invoke(this, EventArgs.Empty);
        }

        private void CollectControlsRecursive(Control root, List<C1MultiColumnCombo> outCombos)
        {
            if (root == null) return;
            if (root is C1MultiColumnCombo c1) outCombos.Add(c1);
            foreach (Control ch in root.Controls)
                CollectControlsRecursive(ch, outCombos);
        }

        private bool IsAncestor(Control ancestor, Control descendant)
        {
            var cur = descendant;
            while (cur != null)
            {
                if (cur == ancestor) return true;
                cur = cur.Parent;
            }
            return false;
        }

        private bool IsContainedInComboInternal(C1MultiColumnCombo combo, Control candidate)
        {
            // Используем отражение: перебираем поля и свойства, возвращающие Control или содержащие Control
            var t = combo.GetType();

            // Проверяем поля
            foreach (var f in t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                try
                {
                    var val = f.GetValue(combo);
                    if (val is Control ctrl)
                    {
                        if (IsAncestor(ctrl, candidate)) return true;
                    }
                    else if (val is Control[] arr)
                    {
                        foreach (var c in arr) if (c != null && IsAncestor(c, candidate)) return true;
                    }
                }
                catch { }
            }

            // Проверяем свойства с getter
            foreach (var p in t.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if (!p.CanRead) continue;
                try
                {
                    var val = p.GetValue(combo);
                    if (val is Control ctrl)
                    {
                        if (IsAncestor(ctrl, candidate)) return true;
                    }
                    else if (val is Control[] arr)
                    {
                        foreach (var c in arr) if (c != null && IsAncestor(c, candidate)) return true;
                    }
                }
                catch { }
            }

            return false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // Снимаем выделение в гриде (визуально), не изменяя окончательное значение
            try
            {
                this.grid.UnselectAll();
            }
            catch
            {
                // игнорируем
            }

            // Ищем C1MultiColumnCombo по цепочке Parent-ов и закрываем ближайший DropDownControl (если есть)
            Control cur = this.Parent;
            while (cur != null)
            {
                // попытаемся найти поле/свойство, указывающее на хозяина Combo и закрыть его через отражение
                try
                {
                    var owningCombo = TryGetOwningComboFromWrapper(cur);
                    if (owningCombo != null)
                    {
                        try { owningCombo.DroppedDown = false; owningCombo.Focus(); } catch { }
                        return;
                    }
                }
                catch { }

                cur = cur.Parent;
            }
        }

        private C1MultiColumnCombo TryGetOwningComboFromWrapper(Control wrapper)
        {
            if (wrapper == null) return null;
            var t = wrapper.GetType();

            foreach (var f in t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                try
                {
                    var val = f.GetValue(wrapper);
                    if (val is C1MultiColumnCombo combo) return combo;
                }
                catch { }
            }
            return null;
        }

        // Вспомогательная функция: получить значение свойства/поля/ключа словаря по имени
        private object GetPropertyValue(object item, string name)
        {
            if (item == null) return null;
            if (string.IsNullOrEmpty(name)) return item;

            // IDictionary — поиск по ключу (с учётом регистра)
            if (item is System.Collections.IDictionary dict)
            {
                if (dict.Contains(name)) return dict[name];
                foreach (var key in dict.Keys)
                    if (string.Equals(key?.ToString(), name, StringComparison.OrdinalIgnoreCase))
                        return dict[key];
            }

            var t = item.GetType();

            // Поиск свойства (без учёта регистра)
            var prop = t.GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
            if (prop != null) return prop.GetValue(item);

            // Поиск поля (без учёта регистра)
            var field = t.GetField(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
            if (field != null) return field.GetValue(item);

            return null;
        }

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            buttonOk_Click(sender, e);
        }

        private void grid_Click(object sender, EventArgs e)
        {
            buttonOk_Click(sender, e);
        }
    }
}

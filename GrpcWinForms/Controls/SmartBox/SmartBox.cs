using C1.Framework;
using C1.Win.FlexGrid;
using C1.Win.Input;
using Google.Protobuf.WellKnownTypes;
using GrpcWinForms.Objects.Contracts.Forms;
using SmartLib;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Forms;
using static SmartLib.SmartGrid;

namespace GrpcWinForms.Controls.SmartBox
{
    public partial class SmartBox : C1ComboBox
    {
        private ItemBox selectedItemBox;
        private bool _isInitializing;
        private BindingList<ItemBox> itemsBox = new BindingList<ItemBox>();
        private string nameDisplay = string.Empty;

        // Кеш для построенных "геттеров" вложенных свойств: ключ - (Type, путь)
        private static readonly ConcurrentDictionary<(System.Type type, string path), Func<object, object>> _getterCache
            = new ConcurrentDictionary<(System.Type, string), Func<object, object>>();

        public ItemBox SelectedItemBox { get => selectedItemBox; }
        public bool NullEnable {  get; set; } = true;
        public Form ModalForm { get; set; }

        #region Конструкторы и настройки
        public SmartBox()
        {
            InitializeComponent();
            Setup();
        }

        public SmartBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            _isInitializing = true;

            // Настройка кнопок
            this.ButtonsSettings.ModalButton.Visible = true;
            this.ButtonsSettings.DropDownButton.Visible = true;
            this.ButtonsSettings.CustomButton.Visible = true;
            this.ButtonsSettings.CustomButton.Icon = new C1BitmapIcon(null, new Size(16, 16), Color.Transparent, Properties.Resources.icons8_multiply_16);

            // Настройка автоподсказки
            this.AutoSuggestMode = AutoSuggestMode.Contains;
            this.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.AutoCompleteSource = AutoCompleteSource.ListItems;

            // Подписка на события
            Leave += MyBoxBase_Leave;
            SelectedIndexChanged += SmartBox_SelectedIndexChanged;
            CustomButtonClick += SmartBox_CustomButtonClick;

            _isInitializing = false;

        }

        #endregion

        private void SmartBox_ModalButtonClick(object? sender, EventArgs e)
        {
            var dlgResult = ModalForm.ShowDialog();
            if (dlgResult != DialogResult.OK)
                return;

            // Пытаемся прочитать свойство SelectedItem
            var selectedProp = ModalForm.GetType().GetProperty("SelectedItem",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);

            if (selectedProp == null || !selectedProp.CanRead)
                return;

            object? selectedValue;
            try
            {
                selectedValue = selectedProp.GetValue(ModalForm);
            }
            catch
            {
                return;
            }

            if (selectedValue == null)
                return;

            // Вытащить Id и Name (регистронезависимо), безопасно привести Id к int
            var selType = selectedValue.GetType();
            var idProp = selType.GetProperty("Id",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
            var nameProp = selType.GetProperty( nameDisplay,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);

            int id = 0;
            if (idProp != null)
            {
                try
                {
                    var rawId = idProp.GetValue(selectedValue);
                    if (rawId != null)
                        id = rawId is int i ? i : Convert.ToInt32(rawId);
                }
                catch
                {
                    id = 0;
                }
            }

            string name = nameProp != null ? (nameProp.GetValue(selectedValue)?.ToString() ?? string.Empty) : selectedValue.ToString() ?? string.Empty;

            var candidate = new ItemBox { Id = id, Name = name };

            // Если в itemsBox уже есть элемент с таким Id — используем его
            if (itemsBox != null)
            {
                var match = System.Linq.Enumerable.FirstOrDefault(itemsBox, ib => ib != null && ib.Id == candidate.Id);
                if (match != null)
                {
                    selectedItemBox = match;
                    int idx = itemsBox.IndexOf(match);
                    // Синхронизируем SelectedIndex, если возможно
                    if (idx >= 0 && idx < this.Items.Count)
                        this.SelectedIndex = idx;
                    else
                    {
                        this.Text = selectedItemBox.Name;
                        this.SelectedIndex = -1;
                    }
                    return;
                }
            }

            // Нет совпадений — устанавливаем выбранный элемент из candidate
            selectedItemBox = candidate;
            this.Text = selectedItemBox.Name;
            this.SelectedIndex = -1;
        }

        private void SmartBox_CustomButtonClick(object? sender, EventArgs e)
        {
            Value = string.Empty;

        }

        private void SmartBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Text))
            {
                selectedItemBox = null; return;
            }
            int i = SelectedIndex;
            if (i > -1 && i < itemsBox.Count)
                selectedItemBox = itemsBox[i];
            else
            {
                selectedItemBox = null;
                Text = "";
            }

        }

        public BindingList<string> DataSourceList<T>(BindingList<T> source) where T : class, IItemBox
        {
            try
            {
                PropertyInfo[] properties = typeof(T).GetProperties();

                BindingList<string> items = new BindingList<string>();
                itemsBox = new BindingList<ItemBox>();

                foreach (T row in source)
                {
                    ItemBox item = new ItemBox { Id = row.Id, Name = row.Name };
                    foreach (PropertyInfo prop in properties)
                    {
                        if (prop.Name == "Name")
                        {
                            items.Add(prop.GetValue(row).ToString()); break;
                        }
                    }
                    itemsBox.Add(item);
                }

                this.ItemsDataSource = items;

                return items;
            }
            catch { }
            return null;
        }

        public BindingList<string> DataSourceList<T>(IEnumerable<T> source, string nameProperty)
        {
            if (source == null) return null;

            var nameProp = string.IsNullOrWhiteSpace(nameProperty) ? "Name" : nameProperty;
            nameDisplay = nameProp;

            var items = new BindingList<string>();
            itemsBox = new BindingList<ItemBox>();

            // Новое добавление: получаем или создаём геттер для типа T и запрошенного пути
            var getter = _getterCache.GetOrAdd((typeof(T), nameProp), key => BuildPropertyGetter(key.type, key.path));
            //

            foreach (var row in source)
            {
                if (row == null) continue;

                var item = new ItemBox();

                // Новое: безопасно получить значение имени (включая вложенные свойства)
                try
                {
                    var rawName = getter(row);
                    item.Name = rawName?.ToString() ?? string.Empty;
                }
                catch
                {
                    item.Name = string.Empty;
                }
                // 
                
                // Ищем свойство Id (регистронезависимо) у корневого объекта
                var srcType = row.GetType();

                //// Получаем свойство для названия (параметр nameProperty), регистронезависимо
                //var propName = srcType.GetProperty(nameProp, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.IgnoreCase);
                //if (propName != null)
                //{
                //    var nameVal = propName.GetValue(row);
                //    item.Name = nameVal?.ToString();
                //}
                // Ищем свойство Id (регистронезависимо)
                var propId = srcType.GetProperty("Id", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.IgnoreCase);
                if (propId != null)
                {
                    var idVal = propId.GetValue(row);
                    if (idVal != null)
                    {
                        try
                        {
                            // Пытаемся безопасно привести к int
                            item.Id = idVal is int i ? i : Convert.ToInt32(idVal);
                        }
                        catch
                        {
                            item.Id = 0;
                        }
                    }
                }

                itemsBox.Add(item);
                items.Add(item.Name ?? string.Empty);
            }

            this.ItemsDataSource = items;
            return items;
        }

        // Построить геттер для вложенного пути. Если какой-то сегмент не найден — вернуть делегат, который всегда возвращает null.
        private static Func<object, object> BuildPropertyGetter(System.Type rootType, string path)
        {
            if (rootType == null || string.IsNullOrEmpty(path)) return _ => null;

            var segments = path.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            var props = new PropertyInfo[segments.Length];

            System.Type curType = rootType;
            for (int i = 0; i < segments.Length; i++)
            {
                var seg = segments[i];
                var p = curType.GetProperty(seg, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                if (p == null)
                {
                    // если не нашли свойство на этапе построения — возвращаем делегат, который всегда null
                    return _ => null;
                }
                props[i] = p;
                curType = p.PropertyType;
            }

            // делегат последовательно вызывает Props[i].GetValue, безопасно проверяя null
            return (object root) =>
            {
                if (root == null) return null;
                object cur = root;
                for (int i = 0; i < props.Length; i++)
                {
                    if (cur == null) return null;
                    cur = props[i].GetValue(cur);
                }
                return cur;
            };
        }

        public void SetSelectedItemBox<T>(T item) where T : class, IItemBox
        {
            selectedItemBox = new ItemBox() { Id = item.Id, Name = item.Name };
            this.ItemsDisplayMember = selectedItemBox.Name;
            this.ItemsValueMember = selectedItemBox.Id.ToString();
            Text = selectedItemBox.Name;
        }

        public void SetModalForm(Form form)
        {
            try
            {
                ModalForm = form;
                var propDialogMode = form.GetType().GetProperty("DialogMode",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                var propSelectedItem = form.GetType().GetProperty("SelectedItem",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);

                if (propDialogMode == null || !propDialogMode.CanRead) throw new();
                if (propSelectedItem == null || !propSelectedItem.CanRead) throw new();

                bool dialogMode = (bool)propDialogMode.GetValue(form);
                if (dialogMode) this.ModalButtonClick += SmartBox_ModalButtonClick;
                return;

            }
            catch
            {
                MessageBox.Show(string.Join(
                    "Данную форму невозможно запустить в диалоговом режиме.",
                    "Возможно Вы не указали у формы режим DialogMode = true"));
            }
        }

        public void SetSelectedItemBox<T>(T sourceItem, string idPropertyName = "Id")
        {
            if (sourceItem == null) return; 

            string idPropName = string.IsNullOrWhiteSpace(idPropertyName) ? "Id" : idPropertyName;
            var srcType = sourceItem.GetType();

            var idProp = srcType.GetProperty(idPropName, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.IgnoreCase);
            var nameProp = srcType.GetProperty("Name", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.IgnoreCase);

            int idValue = 0;
            if (idProp != null)
            {
                var rawId = idProp.GetValue(sourceItem);
                if (rawId != null)
                {
                    try
                    {
                        idValue = rawId is int i ? i : Convert.ToInt32(rawId);
                    }
                    catch
                    {
                        idValue = 0;
                    }
                }
            }

            string nameValue = null;
            if (nameProp != null)
            {
                var rawName = nameProp.GetValue(sourceItem);
                nameValue = rawName?.ToString();
            }

            // Создаём выбранный элемент локально
            var candidate = new ItemBox { Id = idValue, Name = nameValue ?? string.Empty };

            // Если есть itemsBox — ищем совпадающий элемент по Id и устанавливаем выбор
            if (itemsBox != null && itemsBox.Count > 0)
            {
                var match = System.Linq.Enumerable.FirstOrDefault(itemsBox, ib => ib != null && ib.Id == candidate.Id);
                if (match != null)
                {
                    selectedItemBox = match;
                    int idx = itemsBox.IndexOf(match);
                    // Настраиваем индекс и текст контролa
                    if (idx >= 0 && idx < this.Items.Count)
                    {
                        this.SelectedIndex = idx;
                    }
                    else
                    {
                        // Если ItemsDataSource — список строк, синхронизируем текст напрямую
                        this.Text = selectedItemBox.Name;
                        this.SelectedIndex = -1;
                    }
                    return;
                }
            }

            // Нет совпадений — просто устанавливаем selectedItemBox и текст
            selectedItemBox = candidate;
            this.Text = selectedItemBox.Name;
            this.SelectedIndex = -1;
        }

        public ItemBox GetSelectedItemBox(ItemBox item)
        {
            return selectedItemBox;
        }

        private void MyBoxBase_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Text))
            {
                if (NullEnable) SetSelectedItemBox(new ItemBox() { Id = 0, Name = "" });
                return;
            }
            // Защита от null
            if (itemsBox == null || itemsBox.Count == 0) return;

            string text = this.Text ?? string.Empty;
            var matches = new System.Collections.Generic.List<ItemBox>();

            // Поиск совпадающих элементов (Name начинается с Text), регистронезависимо
            foreach (var it in itemsBox)
            {
                if (it == null || string.IsNullOrEmpty(it.Name)) continue;
                if (it.Name.StartsWith(text, StringComparison.CurrentCultureIgnoreCase))
                    matches.Add(it);
            }

            if (matches.Count == 1)
            {
                // Найден ровно один — сделать его выбранным
                selectedItemBox = matches[0];

                // Синхронизируем SelectedIndex, если индексы соответствуют itemsBox
                int idx = itemsBox.IndexOf(matches[0]);
                if (idx >= 0 && idx < this.Items.Count)
                {
                    this.SelectedIndex = idx;
                }
                else
                {
                    // Иначе снимаем выбор (альтернативно можно оставить предыдущий выбор)
                    this.SelectedIndex = -1;
                }
            }
            else
            {
                // Если совпадений нет или их больше одного — не менять выбор.
                // Можно явно сбросить выбор: this.SelectedIndex = -1;
            }
        }

        public class ItemBox : IItemBox
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }

    public interface IItemBox
    {
        int Id { get; set; }
        string Name { get; set; }
    }

}

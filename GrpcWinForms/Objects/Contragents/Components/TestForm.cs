using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contragent;
using System.ComponentModel;
using C1.Win.Input; // Пакет нового поколения ComponentOne

namespace GrpcWinForms.Objects.Contragents.Components
{
    public partial class TestForm : Form
    {
        private BindingList<Contragent> contragents;
        private bool _isUpdating = false;
        private bool _isNavigating = false; // Флаг, блокирующий изменения текста при навигации стрелками
        private string _userTypedText = string.Empty; // Буфер для хранения реального текста пользователя

        public TestForm()
        {
            InitializeComponent();
            ConfigureC1ComboBox();
        }

        private void ConfigureC1ComboBox()
        {
            // Разрешаем ручной ввод текста (аналог DropDown)
            c1ComboBox1.DropDownStyle = C1.Win.Input.DropDownStyle.Default;

            // Отключаем встроенное локальное автозаполнение WinForms
            c1ComboBox1.AutoCompleteMode = AutoCompleteMode.None;

            c1ComboBox1.TranslateValue= false;

            // Привязываем события изменения текста и нажатия Enter
            c1ComboBox1.TextChanged -= c1ComboBox1_TextChanged;
            c1ComboBox1.TextChanged += c1ComboBox1_TextChanged;

            c1ComboBox1.KeyPress -= c1ComboBox1_KeyPress;
            c1ComboBox1.KeyPress += c1ComboBox1_KeyPress;

            c1ComboBox1.DropDownWidth = c1ComboBox1.Size.Width;
        }

        private async void c1ComboBox1_TextChanged(object sender, EventArgs e)
        {
            // Если идет программное обновление или пользователь перемещается стрелками — полностью игнорируем
            if (_isUpdating || _isNavigating) return;
            if (!c1ComboBox1.Focused) return;

            // Запоминаем то, что пользователь физически ввел руками
            _userTypedText = c1ComboBox1.Text;
            string filterText = _userTypedText.Trim();

            if (string.IsNullOrEmpty(filterText))
            {
                _isUpdating = true;
                c1ComboBox1.Items.Clear();
                c1ComboBox1.DroppedDown = false;
                _isUpdating = false;
                return;
            }

            try
            {
                _isUpdating = true;

                // Подготовка gRPC запроса
                var type = ContragentTypeFilter.All;

                ContragentFilterRequest request = new ContragentFilterRequest()
                {
                    TypeFilter = type,
                    Taxno = String.Empty,
                    Name = filterText,
                    Paging = new Paging()
                    {
                        PageNumber = 1,
                        PageSize = 10
                    }
                };
                request.FieldMask = new Google.Protobuf.WellKnownTypes.FieldMask()
                {
                    Paths = { "id", "name", "taxno" }
                };

                // Асинхронное получение данных из gRPC
                ListContragentResponse response = await GrpcClients.GrpcClients.Contragent.ShortListContragentAsync(request);
                contragents = new BindingList<Contragent>(response.Contragents);

                List<string> suggestions = new List<string>();
                foreach (var contragent in contragents)
                {
                    suggestions.Add($"{contragent.Name}");
                }

                int selectionStart = c1ComboBox1.SelectionStart;

                // Для плавной перерисовки в C1.Win.Input сначала закрываем, чистим и заново открываем DropDown
                c1ComboBox1.DroppedDown = false;
                c1ComboBox1.Items.Clear();

                if (suggestions.Count > 0)
                {
                    foreach (var item in suggestions)
                    {
                        c1ComboBox1.Items.Add(item);
                    }

                    // УСЛОВИЕ 1: Открываем список. Курсор остается в строке ввода, текст НЕ меняется.
                    // Метод SelectedIndex = 0 УБРАН отсюда, так как он затирал текст в C1.Win.Input.
                    c1ComboBox1.DroppedDown = true;
                }
                else
                {
                    c1ComboBox1.DroppedDown = false;
                }

                // Гарантируем восстановление исходного текста пользователя и позиции каретки
                c1ComboBox1.Text = _userTypedText;
                c1ComboBox1.SelectionStart = selectionStart;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка gRPC: {ex.Message}");
            }
            finally
            {
                _isUpdating = false;
            }
        }

        /// <summary>
        /// УСЛОВИЕ 2: Перехват системных клавиш. Позволяет перемещать подсветку в DropDown
        /// строго без изменения содержимого текстового поля.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (c1ComboBox1.Focused || c1ComboBox1.ContainsFocus)
            {
                // Нажатие стрелки ВНИЗ
                if (keyData == Keys.Down)
                {
                    if (!c1ComboBox1.DroppedDown)
                    {
                        c1ComboBox1.DroppedDown = true;
                    }

                    if (c1ComboBox1.Items.Count > 0)
                    {
                        _isNavigating = true; // Блокируем TextChanged

                        // Вычисляем следующий индекс для подсветки
                        int nextIndex = c1ComboBox1.SelectedIndex + 1;
                        if (nextIndex < c1ComboBox1.Items.Count)
                        {
                            c1ComboBox1.SelectedIndex = nextIndex;
                        }

                        // Насильно возвращаем текст пользователя на место, отменяя автоподстановку ComponentOne
                        RestoreUserTextAndCursor();
                        _isNavigating = false;
                    }
                    return true; // Перехватываем нажатие, не даем контролу исказить текст
                }

                // Нажатие стрелки ВВЕРХ
                if (keyData == Keys.Up && c1ComboBox1.DroppedDown)
                {
                    if (c1ComboBox1.Items.Count > 0)
                    {
                        _isNavigating = true;

                        // Вычисляем предыдущий индекс для подсветки
                        int prevIndex = c1ComboBox1.SelectedIndex - 1;
                        if (prevIndex >= 0)
                        {
                            c1ComboBox1.SelectedIndex = prevIndex;
                        }

                        RestoreUserTextAndCursor();
                        _isNavigating = false;
                    }
                    return true; // Перехватываем нажатие
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void RestoreUserTextAndCursor()
        {
            _isUpdating = true; // Блокируем TextChanged на время подмены
            int cursorPosition = c1ComboBox1.SelectionStart;

            // Затираем автоподставленный текст контрола сохраненным пользовательским вводом
            c1ComboBox1.Text = _userTypedText;

            c1ComboBox1.SelectionStart = cursorPosition;
            _isUpdating = false;
        }

        // УСЛОВИЕ 3: При нажатии Enter выбирается подсвеченная строка в DropDown
        private void c1ComboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Глушим системный писк Enter

                c1ComboBox1.DroppedDown = false;

                // Если есть подсвеченный элемент, фиксируем его
                if (c1ComboBox1.SelectedIndex >= 0 && c1ComboBox1.SelectedItem != null)
                {
                    _isUpdating = true;

                    // Переносим финальное текстовое значение в поле комбобокса
                    string selectedValue = c1ComboBox1.SelectedItem.ToString();
                    c1ComboBox1.Text = selectedValue;

                    _isUpdating = false;

                    MessageBox.Show($"Вы выбрали: {selectedValue}");

                    // Дополнительно: Если нужен сам gRPC объект из BindingList:
                    // Contragent currentContragent = contragents[c1ComboBox1.SelectedIndex];
                }
                else if (!string.IsNullOrEmpty(c1ComboBox1.Text))
                {
                    MessageBox.Show($"Вы ввели вручную: {c1ComboBox1.Text}");
                }
            }
        }

        private void c1ComboBox1_Resize(object sender, EventArgs e)
        {
            c1ComboBox1.DropDownWidth = c1ComboBox1.Size.Width;
        }
    }
}

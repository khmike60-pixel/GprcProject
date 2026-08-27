using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GrpcWinForms.Controls.TaskBar
{
    //public class TaskBar : StatusStrip
    public class TaskBar : ToolStrip
    {
        private readonly Dictionary<Form, ToolStripButton> _formButtons = new();
        private Form _mdiParent;
        private Form _activeForm;

        public event EventHandler<Form> FormActivated;
        public event EventHandler<Form> FormClosed;

        public TaskBar()
        {
            // Настройка внешнего вида
            //this.SizingGrip = false;
            this.GripStyle = ToolStripGripStyle.Hidden;
            this.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            this.BackColor = SystemColors.Control;
            this.ForeColor = SystemColors.ControlText;
            this.Dock = DockStyle.Bottom;
            this.AutoSize = true;

            // Разделитель
            this.Items.Add(new ToolStripSeparator());
        }

        // Привязка к MDI-родителю
        public void AttachToMdiParent(Form mdiParent)
        {
            if (_mdiParent != null)
            {
                DetachFromMdiParent();
            }

            _mdiParent = mdiParent;
            _mdiParent.MdiChildActivate += OnMdiChildActivate;

            // Регистрируем существующие дочерние формы
            foreach (Form child in _mdiParent.MdiChildren)
            {
                RegisterForm(child);
            }
        }

        // Отвязка от MDI-родителя
        public void DetachFromMdiParent()
        {
            if (_mdiParent != null)
            {
                _mdiParent.MdiChildActivate -= OnMdiChildActivate;

                var forms = _formButtons.Keys.ToList();
                foreach (var form in forms)
                {
                    UnregisterForm(form);
                }

                _formButtons.Clear();
                _activeForm = null;
                _mdiParent = null;
            }
        }

        // Регистрация формы
        private void RegisterForm(Form form)
        {
            if (form == null || form.IsDisposed || _formButtons.ContainsKey(form))
                return;

            // Создаем кнопку
            var button = new ToolStripButton
            {
                Text = form.Text,
                //ToolTipText = $"Открыть {form.Text}",
                DisplayStyle = ToolStripItemDisplayStyle.Text,
                AutoSize = true,
                Tag = form,
                Checked = false,
                CheckOnClick = false
            };
            
            // Обработчик клика
            button.Click += OnTaskButtonClick;

            // Добавляем в панель
            this.Items.Add(button);
            _formButtons[form] = button;

            // Подписываемся на события формы
            form.FormClosed += OnChildFormClosed;
            form.TextChanged += OnChildFormTextChanged;
            form.VisibleChanged += OnChildFormVisibleChanged;
            form.Resize += OnChildFormResize;
            form.Deactivate += OnChildFormDeactivate;
            form.Activated += OnChildFormActivated;

            // Если форма видима и не свернута, отмечаем кнопку как нажатую
            if (form.Visible && form.WindowState != FormWindowState.Minimized)
            {
                button.Checked = true;
                _activeForm = form;
            }
            else
            {
                button.Checked = false;
                // Если форма свернута, скрываем её из панели задач
                if (form.WindowState == FormWindowState.Minimized)
                {
                    HideFormFromTaskbar(form);
                }
            }
        }

        // Отмена регистрации формы
        private void UnregisterForm(Form form)
        {
            if (form == null)
                return;

            if (_formButtons.TryGetValue(form, out var button))
            {
                button.Click -= OnTaskButtonClick;
                if (this.Items.Contains(button))
                {
                    this.Items.Remove(button);
                }
                _formButtons.Remove(form);

                button.Dispose();
            }

            // Отписываемся от событий
            try
            {
                form.FormClosed -= OnChildFormClosed;
                form.TextChanged -= OnChildFormTextChanged;
                form.VisibleChanged -= OnChildFormVisibleChanged;
                form.Resize -= OnChildFormResize;
                form.Deactivate -= OnChildFormDeactivate;
                form.Activated -= OnChildFormActivated;

                // Восстанавливаем отображение в панели задач
                ShowFormInTaskbar(form);
            }
            catch
            {
                // Форма уже уничтожена
            }

            if (_activeForm == form)
            {
                _activeForm = null;
            }
        }

        // Скрытие формы из панели задач
        private void HideFormFromTaskbar(Form form)
        {
            if (form == null || form.IsDisposed || !form.IsHandleCreated)
                return;

            try
            {
                form.Visible = false;
            }
            catch
            {
                // Игнорируем ошибки
            }
        }

        // Восстановление отображения в панели задач
        private void ShowFormInTaskbar(Form form)
        {
            if (form == null || form.IsDisposed || !form.IsHandleCreated)
                return;

            try
            {
                form.Visible = true;
            }
            catch
            {
                // Игнорируем ошибки
            }
        }

        // Обработчик активации MDI-дочерней формы
        private void OnMdiChildActivate(object sender, EventArgs e)
        {
            var activeForm = _mdiParent?.ActiveMdiChild;

            if (activeForm != null && !activeForm.IsDisposed)
            {
                // Проверяем, зарегистрирована ли форма
                if (!_formButtons.ContainsKey(activeForm))
                {
                    RegisterForm(activeForm);
                }

                // Если форма видима и не свернута, делаем её активной
                if (activeForm.Visible && activeForm.WindowState != FormWindowState.Minimized)
                {
                    SetActiveForm(activeForm);
                }
            }
        }

        // Обработчик активации формы
        private void OnChildFormActivated(object sender, EventArgs e)
        {
            if (sender is Form form && !form.IsDisposed)
            {
                if (form.WindowState != FormWindowState.Minimized)
                {
                    SetActiveForm(form);
                    // Показываем в панели задач
                    ShowFormInTaskbar(form);
                }
            }
        }

        // Установка активной формы
        private void SetActiveForm(Form form)
        {
            if (form == null || form.IsDisposed)
                return;

            // Если это уже активная форма, ничего не делаем
            if (_activeForm == form)
                return;

            // Снимаем выделение с предыдущей активной формы
            if (_activeForm != null && !_activeForm.IsDisposed)
            {
                if (_formButtons.TryGetValue(_activeForm, out var oldButton))
                {
                    oldButton.Checked = false;
                }
            }

            // Устанавливаем новую активную форму
            _activeForm = form;

            if (_formButtons.TryGetValue(form, out var button))
            {
                button.Checked = true;
            }

            // Показываем и активируем форму
            if (!form.Visible || form.WindowState == FormWindowState.Minimized)
            {
                form.WindowState = FormWindowState.Normal;
                form.Show();
                // Показываем в панели задач
                ShowFormInTaskbar(form);
            }

            form.BringToFront();
            form.Activate();

            // Генерируем событие
            FormActivated?.Invoke(this, form);
        }

        // Обработчик клика по кнопке
        private void OnTaskButtonClick(object sender, EventArgs e)
        {
            if (sender is ToolStripButton button && button.Tag is Form form)
            {
                // Проверяем, что форма существует
                if (form == null || form.IsDisposed)
                {
                    RemoveFormFromTaskBar(form);
                    return;
                }

                try
                {
                    // Если форма уже активна, ничего не делаем
                    if (_activeForm == form)
                        return;

                    // Активируем форму
                    SetActiveForm(form);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Ошибка при активации формы: {ex.Message}");
                    RemoveFormFromTaskBar(form);
                }
            }
        }

        // Обработчик деактивации формы
        private void OnChildFormDeactivate(object sender, EventArgs e)
        {
            if (sender is Form form && !form.IsDisposed)
            {
                // Если форма теряет фокус и она свернута
                if (form.WindowState == FormWindowState.Minimized)
                {
                    if (_formButtons.TryGetValue(form, out var button))
                    {
                        button.Checked = false;
                    }

                    if (_activeForm == form)
                    {
                        _activeForm = null;
                    }

                    // Скрываем из панели задач
                    HideFormFromTaskbar(form);
                }
            }
        }

        // Обработчик закрытия формы
        private void OnChildFormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form form)
            {
                RemoveFormFromTaskBar(form);
                FormClosed?.Invoke(this, form);
            }
        }

        // Обработчик изменения текста формы
        private void OnChildFormTextChanged(object sender, EventArgs e)
        {
            if (sender is Form form && _formButtons.TryGetValue(form, out var button))
            {
                if (!form.IsDisposed)
                {
                    button.Text = form.Text;
                    button.ToolTipText = $"Открыть {form.Text}";
                }
            }
        }

        // Обработчик изменения видимости
        private void OnChildFormVisibleChanged(object sender, EventArgs e)
        {
            if (sender is Form form && _formButtons.TryGetValue(form, out var button))
            {
                if (form.IsDisposed)
                {
                    RemoveFormFromTaskBar(form);
                    return;
                }

                // Если форма стала невидимой
                if (!form.Visible)
                {
                    button.Checked = false;
                    if (_activeForm == form)
                    {
                        _activeForm = null;
                    }
                    // Скрываем из панели задач
                    HideFormFromTaskbar(form);
                }
                else
                {
                    // Если форма стала видимой
                    ShowFormInTaskbar(form);
                }
            }
        }

        // Обработчик изменения размера
        private void OnChildFormResize(object sender, EventArgs e)
        {
            if (sender is Form form && !form.IsDisposed)
            {
                // Если форму свернули
                if (form.WindowState == FormWindowState.Minimized)
                {
                    // Снимаем выделение с кнопки
                    if (_formButtons.TryGetValue(form, out var button))
                    {
                        button.Checked = false;
                    }

                    // Если это была активная форма, сбрасываем
                    if (_activeForm == form)
                    {
                        _activeForm = null;
                        // Активируем MDI-родитель, чтобы показать, что нет активной дочерней формы
                        if (_mdiParent != null && !_mdiParent.IsDisposed)
                        {
                            _mdiParent.Focus();
                        }
                    }

                    // Скрываем из панели задач
                    HideFormFromTaskbar(form);
                }
                // Если форму восстанавливают
                else if (form.WindowState == FormWindowState.Normal && form.Visible)
                {
                    // Показываем в панели задач
                    ShowFormInTaskbar(form);
                    // Делаем форму активной
                    SetActiveForm(form);
                }
            }
        }

        // Удаление формы из TaskBar
        private void RemoveFormFromTaskBar(Form form)
        {
            if (form == null)
                return;

            if (_formButtons.TryGetValue(form, out var button))
            {
                button.Click -= OnTaskButtonClick;
                if (this.Items.Contains(button))
                {
                    this.Items.Remove(button);
                }
                _formButtons.Remove(form);

                button.Dispose();
            }

            // Отписываемся от событий
            try
            {
                form.FormClosed -= OnChildFormClosed;
                form.TextChanged -= OnChildFormTextChanged;
                form.VisibleChanged -= OnChildFormVisibleChanged;
                form.Resize -= OnChildFormResize;
                form.Deactivate -= OnChildFormDeactivate;
                form.Activated -= OnChildFormActivated;

                // Восстанавливаем отображение в панели задач
                ShowFormInTaskbar(form);
            }
            catch
            {
                // Форма уже уничтожена
            }

            if (_activeForm == form)
            {
                _activeForm = null;
            }
        }

        // Получение всех зарегистрированных форм
        public List<Form> GetRegisteredForms()
        {
            return _formButtons.Keys.Where(f => !f.IsDisposed).ToList();
        }

        // Получение активной формы
        public Form GetActiveForm()
        {
            if (_activeForm != null && !_activeForm.IsDisposed && _activeForm.Visible)
                return _activeForm;
            return null;
        }

        // Проверка, зарегистрирована ли форма
        public bool IsFormRegistered(Form form)
        {
            return form != null && !form.IsDisposed && _formButtons.ContainsKey(form);
        }

        // Очистка всех ресурсов
        public void Cleanup()
        {
            var forms = _formButtons.Keys.ToList();
            foreach (var form in forms)
            {
                UnregisterForm(form);
            }
            _formButtons.Clear();
            _activeForm = null;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Cleanup();
                DetachFromMdiParent();
            }
            base.Dispose(disposing);
        }
    }
}
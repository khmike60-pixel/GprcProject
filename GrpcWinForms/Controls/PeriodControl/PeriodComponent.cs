using C1.Win.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.PeriodControl
{
    public partial class PeriodComponent : C1DropDownControl
    {
        private DateTime _startDate;
        private DateTime _endDate;
        private PeriodForm _form;
        private bool ensureForm = false;
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                if (_form != null)
                    _form.SetPeriod(_startDate, _endDate);
            }
        }
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                if (_form != null)
                    _form.SetPeriod(_startDate, _endDate);
            }
        }

        public PeriodComponent()
        {
            InitializeComponent();
            // Ленивое создание формы — не создаём её в конструкторе.
        }

        public PeriodComponent(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            _startDate = DateTime.Now.AddDays(-90);
            _endDate = DateTime.Now;
        }

        private void EnsureForm()
        {
            if (_form != null) return;
            if (DesignMode) return;

            _form = new PeriodForm(this);
            var s = _startDate == default ? DateTime.Now.AddDays(-90) : _startDate;
            var e = _endDate == default ? DateTime.Now : _endDate;
            _form.SetPeriod(s, e);

            this.DropDownWidth = _form.Width;
            this.Control = _form;
            ensureForm = true;
        }

        private void PeriodComponent_DropDownButtonClick(object sender, EventArgs e)
        {
            EnsureForm();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            // Подготовим форму при навигации с клавиатуры
            EnsureForm();
            base.OnKeyDown(e);

            // Alt+Down или Space — переключаем состояние
            if ((e.KeyCode == Keys.Down && e.Alt) || e.KeyCode == Keys.Space)
            {
                this.DroppedDown = !this.DroppedDown;
            }
            // Блокируем Ctrl+V (вставку)
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void PeriodComponent_TextChanged(object sender, EventArgs e)
        {
            var form = this.Control as PeriodForm;
            if (form == null) return;
            _startDate = form.StartDate;
            _endDate = form.EndDate;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            // Блокируем ввод любых символов в поле текста
            // (разрешаем только управляющие клавиши, которые не попадают в OnKeyPress)
            e.Handled = true;
            // НЕ вызываем base.OnKeyPress(e) — предотвращаем изменение текста
        }

        // Перехват команд оконного сообщения — запрет вставки через буфер/контекстное меню
        private const int WM_PASTE = 0x0302;
        private const int WM_CUT = 0x0300;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_PASTE || m.Msg == WM_CUT)
            {
                // Игнорируем вставку/вырезание
                return;
            }
            base.WndProc(ref m);
        }
    }
}

using C1.Win.Calendar;
using C1.Win.Input;
using C1.Win.Input.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Controls.PeriodControl
{
    public partial class PeriodDropDownForm : UserControl
    {
        private DateTime _startDate;
        private DateTime _endDate;
        private DateTime _oldStartDate;
        private DateTime _oldEndDate;

        public C1.Win.Input.Base.C1DropDownControlBase DropDownOwner;
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                if (DropDownOwner != null) 
                    DropDownOwner.Text = value.ToShortDateString() + " - " + _endDate.ToShortDateString();
                _startDate = value;
            }
        }
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                if (DropDownOwner != null)
                    DropDownOwner.Text = _startDate.ToShortDateString() + " - " + value.ToShortDateString();
                _endDate = value;
            }
        }
        public List<string> months = new List<string>();
        public List<string> quarters = new List<string>();


        public PeriodDropDownForm()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            months = new List<string>()
                    {
                        "январь ", "февраль ", "март ",
                        "апрель ", "май ", "июнь ",
                        "июль ", "август ", "сентябрь ",
                        "октябрь ", "ноябрь ", "декабрь "
                    };
            editMonth.Items.AddRange(months);

            quarters = new List<string>()
                    {
                        "I квартал ", "II квартал ", "III квартал ", "IV квартал "
                    };
            editQuarter.Items.AddRange(quarters);
            _oldEndDate = _startDate;
            _oldStartDate = _startDate;
        }

        public void SetPeriod(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null)
            {
                startDate = new DateTime(DateTime.Now.Year, 1, 1);
            }

            if (endDate == null)
            {
                endDate = new DateTime(DateTime.Now.Year + 1, 1, 1).AddSeconds(-1);
            }
            _startDate = (DateTime)startDate;
            _endDate = (DateTime)endDate;

            editYear.Value = _endDate.Year;

            editMonth.Items.Clear();
            for (int i = 0; i < 12; i++)
                editMonth.Items.Add(months[i] + $" {_endDate.Year}");
            editMonth.SelectedIndex = _startDate.Month - 1;

            editQuarter.Items.Clear();
            for (int i = 0; i < 4; i++)
                editQuarter.Items.Add(quarters[i] + $" {_endDate.Year}");
            // вычисление индекса квартала: (month-1)/3
            editQuarter.SelectedIndex = (_startDate.Month - 1) / 3;

            editStart.Value = _startDate;
            editEnd.Value = _endDate;

            if (DropDownOwner != null)
                DropDownOwner.Text = _startDate.ToShortDateString() + " - " + _endDate.ToShortDateString();
        }

        public DateTime GetStartPeriod() => _startDate;
        public DateTime GetEndPeriod() => _endDate;

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            if (rbYear.Checked)
            {
                editYear.Enabled = editQuarter.Enabled = editMonth.Enabled = editStart.Enabled = editEnd.Enabled = false;
                editYear.Enabled = true;
            }
            if (rbQuater.Checked)
            {
                editYear.Enabled = editQuarter.Enabled = editMonth.Enabled = editStart.Enabled = editEnd.Enabled = false;
                editQuarter.Enabled = true;
            }
            if (rbMonth.Checked)
            {
                editYear.Enabled = editQuarter.Enabled = editMonth.Enabled = editStart.Enabled = editEnd.Enabled = false;
                editMonth.Enabled = true;
            }
            if (rbFree.Checked)
            {
                editYear.Enabled = editQuarter.Enabled = editMonth.Enabled = editStart.Enabled = editEnd.Enabled = false;
                editStart.Enabled = editEnd.Enabled = true;
            }
        }

        private void editYear_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int year = (int)editYear.Value;

                // Сохраняем текущие выбранные индексы, чтобы восстановить после обновления Items
                int prevMonthIndex = editMonth.SelectedIndex;
                int prevQuarterIndex = editQuarter.SelectedIndex;

                // Обновляем подписи месяцев с новым годом
                editMonth.Items.Clear();
                for (int i = 0; i < 12; i++)
                    editMonth.Items.Add(months[i] + $" {year}");
                if (prevMonthIndex >= 0 && prevMonthIndex < editMonth.Items.Count)
                    editMonth.SelectedIndex = prevMonthIndex;
                else
                    editMonth.SelectedIndex = Math.Max(0, Math.Min(11, _startDate.Month - 1));

                // Обновляем видимый текст месяца (принудительная установка текста + перерисовка)
                if (editMonth.SelectedIndex >= 0 && editMonth.SelectedIndex < editMonth.Items.Count)
                {
                    editMonth.Text = editMonth.Items[editMonth.SelectedIndex].DisplayText; // ?.ToString() ?? string.Empty;
                    editMonth.Refresh();
                }

                // Обновляем подписи кварталов с новым годом
                editQuarter.Items.Clear();
                for (int i = 0; i < 4; i++)
                    editQuarter.Items.Add(quarters[i] + $" {year}");
                if (prevQuarterIndex >= 0 && prevQuarterIndex < editQuarter.Items.Count)
                    editQuarter.SelectedIndex = prevQuarterIndex;
                else
                    editQuarter.SelectedIndex = Math.Max(0, Math.Min(3, (_startDate.Month - 1) / 3));

                // Обновляем видимый текст квартала
                if (editQuarter.SelectedIndex >= 0 && editQuarter.SelectedIndex < editQuarter.Items.Count)
                {
                    editQuarter.Text = editQuarter.Items[editQuarter.SelectedIndex].DisplayText;
                    editQuarter.Refresh();
                }

                // Пересчитываем StartDate/EndDate в зависимости от текущего режима
                if (rbYear.Checked)
                {
                    _startDate = new DateTime(year, 1, 1);
                    _endDate = new DateTime(year + 1, 1, 1).AddSeconds(-1);
                }
                else if (rbQuater.Checked)
                {
                    int q = editQuarter.SelectedIndex >= 0 ? editQuarter.SelectedIndex : (_startDate.Month - 1) / 3;
                    int startMonth = q * 3 + 1;
                    _startDate = new DateTime(year, startMonth, 1);
                    _endDate = _startDate.AddMonths(3).AddSeconds(-1);
                }
                else if (rbMonth.Checked)
                {
                    int m = editMonth.SelectedIndex >= 0 ? editMonth.SelectedIndex + 1 : _startDate.Month;
                    _startDate = new DateTime(year, m, 1);
                    _endDate = _startDate.AddMonths(1).AddSeconds(-1);
                }
                else if (rbFree.Checked)
                {
                    // Меняем только год, корректируя дни (например, 29 февраля)
                    int sMonth = _startDate.Month;
                    int sDay = Math.Min(_startDate.Day, DateTime.DaysInMonth(year, sMonth));
                    StartDate = new DateTime(year, sMonth, sDay, _startDate.Hour, _startDate.Minute, _startDate.Second);

                    int eMonth = _endDate.Month;
                    int eDay = Math.Min(_endDate.Day, DateTime.DaysInMonth(year, eMonth));
                    _endDate = new DateTime(year, eMonth, eDay, _endDate.Hour, _endDate.Minute, _endDate.Second);

                    // Если получилось, что End < Start — корректируем End в конец дня Start+1
                    if (_endDate < StartDate)
                        _endDate = StartDate.AddDays(1).AddSeconds(-1);
                }

                editStart.Value = _startDate;
                editEnd.Value = _endDate;

                if (DropDownOwner != null)
                    DropDownOwner.Text = _startDate.ToShortDateString() + " - " + _endDate.ToShortDateString();

            }
            catch
            {
                // Игнорируем ошибки преобразования/значений, чтобы не ломать UI
            }

            KeepDropDownOpen();

        }

        private void editQuarter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = sender as C1.Win.Input.C1ComboBox;
            try
            {
                if (cb != null && cb.SelectedIndex >= 0)
                {
                    int year = (int)editYear.Value;
                    int quarterIndex = cb.SelectedIndex; // 0..3
                    int startMonth = quarterIndex * 3 + 1;
                    _startDate = new DateTime(year, startMonth, 1);
                    _endDate = _startDate.AddMonths(3).AddSeconds(-1);

                    editStart.Value = _startDate;
                    editEnd.Value = _endDate;

                    if (DropDownOwner != null)
                        DropDownOwner.Text = _startDate.ToShortDateString() + " - " + _endDate.ToShortDateString();
                }
            }
            catch (Exception ex) 
            {

            }
            
            KeepDropDownOpen();
        }

        private void editMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var cb = sender as C1.Win.Input.C1ComboBox;
                if (cb != null && cb.SelectedIndex >= 0)
                {
                    int year = (int)editYear.Value;
                    int month = cb.SelectedIndex + 1;
                    _startDate = new DateTime(year, month, 1);
                    _endDate = _startDate.AddMonths(1).AddSeconds(-1);

                    editStart.Value = _startDate;
                    editEnd.Value = _endDate;

                    if (DropDownOwner != null)
                        DropDownOwner.Text = _startDate.ToShortDateString() + " - " + _endDate.ToShortDateString();
                }
            }
            catch (Exception ex)
            {

            }

            KeepDropDownOpen();
        }

        private void editStart_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (DropDownOwner == null) return;
                _startDate = DateTime.Parse(editStart.Value.ToString());
                if (DropDownOwner != null)
                    DropDownOwner.Text = _startDate.ToShortDateString() + " - " + _endDate.ToShortDateString();
            } catch (Exception ex) { }
            KeepDropDownOpen();

        }

        private void editEnd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (DropDownOwner == null) return;
                _endDate = DateTime.Parse(editEnd.Value.ToString());

                if (DropDownOwner != null)
                    DropDownOwner.Text = _startDate.ToShortDateString() + " - " + _endDate.ToShortDateString();
            } catch (Exception ex) { }
            KeepDropDownOpen();
        }


        /// <summary>
        /// Попытка удержать выпадающую форму открытой после выбора.
        /// Используется BeginInvoke для отложенного восстановления состояния и фокуса.
        /// </summary>
        private void KeepDropDownOpen()
        {
            try
            {
                var dropDownForm = this.Parent as C1.Win.Input.DropDownForm;
                if (dropDownForm == null) return;

                var parentControl = dropDownForm.DropDownOwner as C1.Win.Input.C1DropDownControl;
                // Выполняем асинхронно, чтобы восстановить DroppedDown после того, как текущий обработчик завершится
                this.BeginInvoke((Action)(() =>
                {
                    try
                    {
                        if (parentControl != null)
                            parentControl.DroppedDown = true;
                        // фокусируем саму форму/контролы внутри, чтобы не инициировать закрытие
                        this.Focus();
                    }
                    catch { }
                }));
            }
            catch
            {
                // молча игнорируем ошибки — важнее не ломать поведение
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _startDate = DateTime.Parse(editStart.Value.ToString());
            _endDate = DateTime.Parse(editEnd.Value.ToString());
            PeriodComponent p = (PeriodComponent)(((C1.Win.Input.DropDownForm)this.Parent).DropDownOwner);
            if (p.DroppedDown) p.DroppedDown = false;

            if (DropDownOwner != null)
                DropDownOwner.Text = _startDate.ToShortDateString() + " - " + _endDate.ToShortDateString();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _startDate = _oldStartDate;
            _endDate = _oldEndDate;
            PeriodComponent p = (PeriodComponent)(((C1.Win.Input.DropDownForm)this.Parent).DropDownOwner);
            if (p.DroppedDown) p.DroppedDown = false;

        }

        private void control_Enter(object sender, EventArgs e)
        {
            _startDate = DateTime.Parse(editStart.Value.ToString());
            _endDate = DateTime.Parse(editEnd.Value.ToString());
            if (((C1.Win.Input.DropDownForm)this.Parent) != null)
            {
                PeriodComponent p = (PeriodComponent)(((C1.Win.Input.DropDownForm)this.Parent).DropDownOwner);
                if (p.DroppedDown) p.DroppedDown = false;
            }
        }

    }
}
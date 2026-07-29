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
        public C1.Win.Input.Base.C1DropDownControlBase DropDownOwner;
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
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
            StartDate = (DateTime)startDate;
            EndDate = (DateTime)endDate;

            editYear.Value = EndDate.Year;

            editMonth.Items.Clear();
            for (int i = 0; i < 12; i++)
                editMonth.Items.Add(months[i] + $" {EndDate.Year}");
            editMonth.SelectedIndex = StartDate.Month - 1;

            editQuarter.Items.Clear();
            for (int i = 0; i < 4; i++)
                editQuarter.Items.Add(quarters[i] + $" {EndDate.Year}");
            // вычисление индекса квартала: (month-1)/3
            editQuarter.SelectedIndex = (StartDate.Month - 1) / 3;

            editStart.Value = StartDate;
            editEnd.Value = EndDate;

            if (DropDownOwner != null)
                DropDownOwner.Text = StartDate.ToShortDateString() + " - " + EndDate.ToShortDateString();
        }

        public DateTime GetStartPeriod() => StartDate;
        public DateTime GetEndPeriod() => EndDate;

        private void btnOk_Click(object sender, EventArgs e)
        {
            PeriodComponent p = (PeriodComponent)(((C1.Win.Input.DropDownForm)this.Parent).DropDownOwner);
            if (p.DroppedDown) p.DroppedDown = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PeriodComponent p = (PeriodComponent)(((C1.Win.Input.DropDownForm)this.Parent).DropDownOwner);
            if (p.DroppedDown) p.DroppedDown = false;
        }

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

        private void editQuarter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = sender as C1.Win.Input.C1ComboBox;
            if (cb != null && cb.SelectedIndex >= 0)
            {
                int year = (int)editYear.Value;
                int quarterIndex = cb.SelectedIndex; // 0..3
                int startMonth = quarterIndex * 3 + 1;
                StartDate = new DateTime(year, startMonth, 1);
                EndDate = StartDate.AddMonths(3).AddSeconds(-1);

                editStart.Value = StartDate;
                editEnd.Value = EndDate;

                if (DropDownOwner != null)
                    DropDownOwner.Text = StartDate.ToShortDateString() + " - " + EndDate.ToShortDateString();
            }

            KeepDropDownOpen();
        }

        private void editMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = sender as C1.Win.Input.C1ComboBox;
            if (cb != null && cb.SelectedIndex >= 0)
            {
                int year = (int)editYear.Value;
                int month = cb.SelectedIndex + 1;
                StartDate = new DateTime(year, month, 1);
                EndDate = StartDate.AddMonths(1).AddSeconds(-1);

                editStart.Value = StartDate;
                editEnd.Value = EndDate;

                if (DropDownOwner != null)
                    DropDownOwner.Text = StartDate.ToShortDateString() + " - " + EndDate.ToShortDateString();
            }

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

        private void editQuarter_Leave(object sender, EventArgs e)
        {

        }

        private void editYear_TextChanged(object sender, EventArgs e)
        {
            int year = (int)editYear.Value;
            StartDate = new DateTime(year, StartDate.Month, StartDate.Day);
            EndDate = new DateTime(year, EndDate.Month, EndDate.Day);
            if (DropDownOwner == null) return;

        }
    }
}
using C1.Win.Calendar;
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

        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }

        public PeriodDropDownForm()
        {
            InitializeComponent();

        }

        public void SetPeriod(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null)
            {
                startDate = new DateTime(DateTime.Now.Year, 1,1);
            }

            if (endDate == null)
            {
                endDate = new DateTime(DateTime.Now.Year + 1, 1, 1).AddDays(-1);
            }
            StartDate = (DateTime)startDate;
            EndDate = (DateTime)endDate;

            editYear.Value = EndDate.Year;
            editMonth.SelectedIndex = 1;
            editQuarter.SelectedIndex = 0;
            editStart.Value = StartDate;
            editEnd.Value = EndDate;
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
    }
}

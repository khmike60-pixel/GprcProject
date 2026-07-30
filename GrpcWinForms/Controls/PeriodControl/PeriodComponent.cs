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
        private PeriodDropDownForm form;

        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }


        public PeriodComponent()
        {
            InitializeComponent();
            form = new PeriodDropDownForm();
            form.DropDownOwner = this;
            Control = form;
        }

        public PeriodComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            form = new PeriodDropDownForm();
            form.DropDownOwner = this;
            Control = form;

        }

        private void PeriodComponent_Layout(object sender, LayoutEventArgs e)
        {
            form.SetPeriod(null, null);
            this.DropDownWidth = form.Width;

        }

        private void PeriodComponent_TextChanged(object sender, EventArgs e)
        {
            StartDate = form.StartDate;
            EndDate   = form.EndDate;
        }
    }
}

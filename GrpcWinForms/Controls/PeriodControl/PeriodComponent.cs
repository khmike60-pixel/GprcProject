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
        private PeriodDropDownForm form = new PeriodDropDownForm();

        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }


        public PeriodComponent()
        {
            InitializeComponent();
            form.SetPeriod(null, null);
            Control = form; 
        }

        public PeriodComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            form.SetPeriod(null, null);
            Control = form;


        }

    }
}

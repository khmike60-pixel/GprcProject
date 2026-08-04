using C1.Win.Input;
using GrpcCommonNet.Library.Common;
using GrpcWinForms.Controls.CompanyDropDown;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Controls.PersonDropDown
{
    public partial class PersonDropDown : C1DropDownControl
    {
        public PersonDropDown()
        {
            InitializeComponent();
        }

        public PersonDropDown(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void SetupControl(Person person)
        {

        }
    }
}

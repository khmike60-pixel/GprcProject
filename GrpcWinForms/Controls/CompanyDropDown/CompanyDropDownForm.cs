using C1.Win.Input;
using C1.Win.Themes;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Contragent;
using GrpcWinForms.Controls.CompanyDropDown;
using GrpcWinForms.Objects.Test;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Contragents.Components
{
    public partial class CompanyDropDownForm : UserControl
    {
        private BindingList<Company> _contragents = new BindingList<Company>();
        public BindingList<Company> Contragents { get => _contragents; set => _contragents = value; }
        private Company contragentSelected = null;
        public Company ContragentSelected { get => contragentSelected; set => contragentSelected = value; }

        // public event EventHandler NeedRefreshDataSource;

        //public Company ContragentSelected { get => contragentSelected; set => contragentSelected = value; }

        public CompanyDropDownForm()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {


                int rowIndex = smart1.Row;
                int bindingIndex = smart1.Row - smart1.Rows.Fixed;
                contragentSelected = _contragents[bindingIndex];

                C1DropDownControl parent = (C1DropDownControl)((C1.Win.Input.DropDownForm)this.Parent).DropDownOwner;

                parent.Text = contragentSelected.Name;

                CloseForm();
            }
            catch { }

        }

        #region Методы интерфейса

        public bool Focusable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool InternalFocusMovement { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ApplyStyle(BaseStyle style, int dpi)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void CloseForm()
        {
            C1DropDownControl parent = (C1DropDownControl)((C1.Win.Input.DropDownForm)this.Parent).DropDownOwner;
            parent.DroppedDown = false;
        }

        public void OpenForm()
        {
            C1DropDownControl parent = (C1DropDownControl)((C1.Win.Input.DropDownForm)this.Parent).DropDownOwner;
            parent.DroppedDown = true;

        }
        #endregion

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void smart_DoubleClick(object sender, EventArgs e)
        {
            buttonOk_Click(sender, e);
        }
        
    }
}

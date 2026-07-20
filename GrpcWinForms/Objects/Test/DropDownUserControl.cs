using C1.Framework;
using C1.Win.Input;
using C1.Win.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Test
{
    public partial class DropDownUserControl : UserControl, IDropDownForm
    {
        public DropDownUserControl()
        {
            InitializeComponent();
        }

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

        private void buttonOk_Click(object sender, EventArgs e)
        {
            CloseForm();
            
        }
    }
}

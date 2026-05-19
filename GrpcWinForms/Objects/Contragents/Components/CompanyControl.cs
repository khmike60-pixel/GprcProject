using C1.Win.Input;
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
    public partial class CompanyControl : UserControl
    {
        private C1.Win.Input.C1DropDownControl _ddControl;
        private bool isResizing = false;
        private Point lastMousePos;
        //private StatusStrip statusStrip;


        public CompanyControl()
        {
            InitializeComponent();
        }

        public CompanyControl(C1DropDownControl dd)
        {
            InitializeComponent();

            _ddControl = dd;
        }

        private void statusStrip_MouseMove(object sender, MouseEventArgs e)
        {
            if (isResizing)
            {
                // Рассчитываем, насколько сместилась мышь
                int diffX = e.X - lastMousePos.X;
                int diffY = e.Y - lastMousePos.Y;

                // Меняем размер самого контрола
                _ddControl.DropDownWidth = this.Width + diffX;
                this.Size = new Size(this.Width + diffX, this.Height + diffY);
            }
        }

        private void statusStrip_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isResizing = true;
                lastMousePos = e.Location;
            }

        }

        private void statusStrip_MouseUp(object sender, MouseEventArgs e)
        {
            isResizing = false;
        }

        private void statusStrip_Resize(object sender, EventArgs e)
        {
            int a = 0;
        }
    }
}

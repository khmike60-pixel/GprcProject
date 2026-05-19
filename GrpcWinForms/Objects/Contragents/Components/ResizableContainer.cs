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
    public partial class ResizableContainer : UserControl
    {
        private bool isResizing = false;
        private Point lastMousePos;
        //private StatusStrip statusStrip;

        public ResizableContainer()
        {
            InitializeComponent();
            SetupResizer();
        }

        private void SetupResizer()
        {
            statusStrip.Cursor = Cursors.SizeNWSE;
            this.MinimumSize = new Size(50, 50); // Чтобы не схлопнулся
        }

        private void Resizer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isResizing = true;
                lastMousePos = e.Location;
            }
        }

        private void Resizer_MouseMove(object sender, MouseEventArgs e)
        {
            if (isResizing)
            {
                // Рассчитываем, насколько сместилась мышь
                int diffX = e.X - lastMousePos.X;
                int diffY = e.Y - lastMousePos.Y;

                // Меняем размер самого контрола
                this.Size = new Size(this.Width + diffX, this.Height + diffY);
            }
        }

        private void Resizer_MouseUp(object sender, MouseEventArgs e)
        {
            isResizing = false;
        }

        // Чтобы другие элементы не перекрывали наш "уголок", 
        // можно добавить пустой контейнер (Padding) снизу
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Padding = new Padding(0, 0, 0, statusStrip.Height);
        }
    }
}

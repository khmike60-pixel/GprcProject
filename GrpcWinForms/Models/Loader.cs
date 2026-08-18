using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace GrpcWinForms.Models
{
    public class Loader
    {
        private PictureBox loaderControl;
        public Loader()
        {
            loaderControl = new PictureBox()
            {
                Image = Properties.Resources.icons8_loader,
                SizeMode = PictureBoxSizeMode.CenterImage,
                BackColor = Color.Transparent, 
                Visible = false,
                Dock = DockStyle.Fill // Растягиваем на всю форму или поверх грида
            };

        }
        // Настройка родительского контрола
        public Control? Parent { get => loaderControl.Parent; 
            set 
            {
                if (value != null)
                {
                    value.Controls.Add(loaderControl);
                    loaderControl.BringToFront();
                    loaderControl.Parent = value;
                }
            }
        }

        // Настройка позиции
        public Point Location {
            get => loaderControl.Location;
            set { if (value != null) loaderControl.Location = value; }
        }

        // Настройка размера
        public Size Size
        {
            get => loaderControl.Size;
            set { if (value != null) loaderControl.Size = value; }
        }

        // Методы управления
        public void ShowLoader() => loaderControl.Visible = true;
        public void HideLoader() => loaderControl.Visible = false;
    }
}

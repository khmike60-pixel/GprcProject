using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Controls.FormTemplate
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        public void ShowWithPermission()
        {
            var Permission = new PermissionManager.PermissionManager(this);
            if (!Permission.CanShowForm())
            {
                MessageBox.Show("Доступ запрещен", "У вас нет прав для просмотра данной формы", MessageBoxButtons.OK);
                this.Close();
            }
            else this.Show();
        }

    }
}

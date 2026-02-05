using GrpcCommonNet.Library.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GrpcWinForms.Objects.Users.Forms
{
    public partial class UserForm : Form
    {
        public User User { get; set; } = new User();

        public UserForm()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            User.UserSymbol = textBoxSymbol.Text;
            User.UserLogin = textBoxLogin.Text;
            User.UserPassword = textBoxPassword.Text;
            User.UserName = textBoxShortName.Text;
            User.UserIsBlocked = checkBoxIsBlocked.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            textBoxSymbol.Text = User.UserSymbol;
            textBoxLogin.Text = User.UserLogin;
            textBoxPassword.Text = User.UserPassword;
            textBoxShortName.Text = User.UserName;
            checkBoxIsBlocked.Checked = User.UserIsBlocked;
        }
    }
}

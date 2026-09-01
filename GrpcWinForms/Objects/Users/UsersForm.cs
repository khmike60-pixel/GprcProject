using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Employee;
using GrpcCommonNet.Library.User;
using GrpcWinForms.GrpcUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Users
{
    public partial class UsersForm : Form
    {
        private BindingList<User> users = new BindingList<User>();
        private User selectedItem;
        public bool DialogMode { get; set; } = false;
        public User SelectedItem { get => selectedItem; }

        public UsersForm()
        {
            InitializeComponent();
        }

        private async void RefreshUsers()
        {
            try
            {
                UserFilterRequest request = new UserFilterRequest()
                {
                    FieldMask = new Google.Protobuf.WellKnownTypes.FieldMask()
                    {
                        Paths = { "id", "contragent.name", "user_symbol" }
                    }
                };
                ListUserResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.User.GetListUserAsync(request).ResponseAsync);

                users = new BindingList<User>(response.Users);
                smartGrid.DataSource = users;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении данных");
            }
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            RefreshUsers();
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshUsers();
        }

        private void smartGrid_DoubleClick(object sender, EventArgs e)
        {
            if (!DialogMode) return;
            int row = smartGrid.Row;
            if (row < smartGrid.Rows.Fixed || row > smartGrid.Rows.Count) return;
            User user = smartGrid.Rows[row].DataSource as User;
            selectedItem = user;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void smartGrid_GetUnboundValue(object sender, C1.Win.FlexGrid.UnboundValueEventArgs e)
        {
            User user = smartGrid.Rows[e.Row].DataSource as User;
            switch (smartGrid.Cols[e.Col].Name)
            {
                case "Abbrev":
                    e.Value = user.UserSymbol;
                    break;
                case "Name":
                    e.Value = user.Contragent.Name;
                    break;
            }
        }
    }
}

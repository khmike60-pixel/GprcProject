using GrpcCommonNet.Library.Common;
using GrpcWinForms.Objects.Users.Presenters;
using GrpcWinForms.Objects.Users.Views;
using System.ComponentModel;
using GrpcCommonNet.Library.User;
using System;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Users
{
    public partial class UsersForm : Form, IUsersView
    {
        private readonly UsersPresenter presenter;
        private BindingList<User> users = new BindingList<User>();
        private User selectedItem;
        public bool DialogMode { get; set; } = false;
        public User SelectedItem { get => selectedItem; set => selectedItem = value; }

        public UsersForm()
        {
            InitializeComponent();
            presenter = new UsersPresenter(this);
        }

        // IUsersView impl
        BindingList<User> IUsersView.Users { set { users = value; smartGrid.DataSource = users; } }
        event EventHandler IUsersView.ViewLoaded { add => ViewLoaded += value; remove => ViewLoaded -= value; }
        event EventHandler IUsersView.RefreshRequested { add => RefreshRequested += value; remove => RefreshRequested -= value; }
        event EventHandler IUsersView.ItemDoubleClicked { add => ItemDoubleClicked += value; remove => ItemDoubleClicked -= value; }
        void IUsersView.CloseWithResult(DialogResult result) { DialogResult = result; Close(); }

        // Local events to adapt existing UI events to presenter events
        private event EventHandler ViewLoaded;
        private event EventHandler ItemDoubleClicked;
        private event EventHandler RefreshRequested;

        private void UsersForm_Load(object sender, EventArgs e)
        {
            ViewLoaded?.Invoke(this, EventArgs.Empty);
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            // Вызываем локальное событие, к которому презентер подписан через явную реализацию интерфейса
            RefreshRequested?.Invoke(this, EventArgs.Empty);
        }

        private void smartGrid_DoubleClick(object sender, EventArgs e)
        {
            if (!DialogMode) return;
            int row = smartGrid.Row;
            if (row < smartGrid.Rows.Fixed || row > smartGrid.Rows.Count) return;
            User user = smartGrid.Rows[row].DataSource as User;
            selectedItem = user;
            ItemDoubleClicked?.Invoke(this, EventArgs.Empty);
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
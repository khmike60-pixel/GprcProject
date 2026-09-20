using GrpcCommonNet.Library.Common;
using GrpcWinForms.Models;
using GrpcWinForms.Objects.Users.Presenters;
using GrpcWinForms.Objects.Users.Views;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Users.Forms
{
    public partial class UsersAppForm : Form, IUsersAppView
    {
        private readonly UsersAppPresenter presenter;
        private BindingList<User> users;
        private BindingList<ApplicationUser> applications;

        // Поля загрузчиков — Designer может не содержать их, поэтому объявляем здесь
        private Loader loaderUsers = new Loader();
        private Loader loaderApps = new Loader();

        // Локальные события для презентера
        private event EventHandler ViewLoaded;
        private event EventHandler UsersSelectionChanged;
        private event EventHandler RefreshUsersRequested;

        private event EventHandler CreateUserRequested;
        private event EventHandler EditUserRequested;
        private event EventHandler DeleteUserRequested;

        // События для работы с приложениями (Designer ссылается на методы с такими именами)
        private event EventHandler AppNewRequested;
        private event EventHandler AppDeleteRequested;

        public UsersAppForm()
        {
            InitializeComponent();
            presenter = new UsersAppPresenter(this);

            // Настройка loader'ов как в оригинале
            loaderUsers.Parent = smartGridUsers1;
            loaderApps.Parent = smartGridApps1;
            loaderApps.Location = new System.Drawing.Point(0, 0);
            loaderUsers.Size = smartGridUsers1.Size;
            loaderApps.Size = smartGridApps1.Size;
        }

        // IUsersAppView impl
        BindingList<User> IUsersAppView.Users { set { users = value; smartGridUsers1.DataSource = users; } }
        BindingList<ApplicationUser> IUsersAppView.Applications { set { applications = value; smartGridApps1.DataSource = applications; } }

        void IUsersAppView.ShowUsersLoader() => loaderUsers.ShowLoader();
        void IUsersAppView.HideUsersLoader() => loaderUsers.HideLoader();
        void IUsersAppView.ShowAppsLoader() => loaderApps.ShowLoader();
        void IUsersAppView.HideAppsLoader() => loaderApps.HideLoader();

        // Явные реализации событий интерфейса — презентер подпишется на локальные события
        event EventHandler IUsersAppView.ViewLoaded { add => ViewLoaded += value; remove => ViewLoaded -= value; }
        event EventHandler IUsersAppView.UsersSelectionChanged { add => UsersSelectionChanged += value; remove => UsersSelectionChanged -= value; }
        event EventHandler IUsersAppView.RefreshUsersRequested { add => RefreshUsersRequested += value; remove => RefreshUsersRequested -= value; }

        event EventHandler IUsersAppView.CreateUserRequested { add => CreateUserRequested += value; remove => CreateUserRequested -= value; }
        event EventHandler IUsersAppView.EditUserRequested { add => EditUserRequested += value; remove => EditUserRequested -= value; }
        event EventHandler IUsersAppView.DeleteUserRequested { add => DeleteUserRequested += value; remove => DeleteUserRequested -= value; }

        User IUsersAppView.CurrentSelectedUser
        {
            get
            {
                if (smartGridUsers1.Row < smartGridUsers1.Rows.Fixed) return null;
                return smartGridUsers1.Rows[smartGridUsers1.Row].DataSource as User;
            }
        }

        ApplicationUser IUsersAppView.CurrentSelectedApplicationUser
        {
            get
            {
                if (smartGridApps1.Row < smartGridApps1.Rows.Fixed) return null;
                return smartGridApps1.Rows[smartGridApps1.Row].DataSource as ApplicationUser;
            }
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            ViewLoaded?.Invoke(this, EventArgs.Empty);
            c1ComboBoxIsBlocked.SelectedText = "Все";
        }

        private void smartGridUsers_AfterSelChange(object sender, C1.Win.FlexGrid.RangeEventArgs e)
        {
            UsersSelectionChanged?.Invoke(this, EventArgs.Empty);
        }

        private void toolStripButtonUserRefresh_Click(object sender, EventArgs e)
        {
            RefreshUsersRequested?.Invoke(this, EventArgs.Empty);
        }

        private void toolStripButtonUserNew_Click(object sender, EventArgs e)
        {
            CreateUserRequested?.Invoke(this, EventArgs.Empty);
        }

        private void toolStripButtonUserEdit_Click(object sender, EventArgs e)
        {
            EditUserRequested?.Invoke(this, EventArgs.Empty);
        }

        private void toolStripButtonUserDelete_Click(object sender, EventArgs e)
        {
            DeleteUserRequested?.Invoke(this, EventArgs.Empty);
        }

        // Designer ссылается на эти обработчики — добавлены для компиляции и делегирования логике презентера/вью
        private void toolStripButtonAppNew_Click(object sender, EventArgs e)
        {
            AppNewRequested?.Invoke(this, EventArgs.Empty);
        }

        private void toolStripButtonAppDelete_Click(object sender, EventArgs e)
        {
            AppDeleteRequested?.Invoke(this, EventArgs.Empty);
        }

        // Unbound value handlers — view-логика оставлена
        private void smartGridUsers_GetUnboundValue(object sender, C1.Win.FlexGrid.UnboundValueEventArgs e)
        {
            User user = smartGridUsers1.Rows[e.Row].DataSource as User;
            switch (smartGridUsers1.Cols[e.Col].Name)
            {
                case "colContragentName":
                    if (user.Contragent == null || user.Contragent.Id == 0)
                        e.Value = user.UserName;
                    else
                        e.Value = user.Contragent.Name;
                    break;
                case "colUserIsBlocked":
                    e.Value = user.UserIsBlocked ? true : string.Empty;
                    break;
                case "colShortName":
                    e.Value = user.UserName;
                    break;
            }
        }

        private void smartGridApps_GetUnboundValue(object sender, C1.Win.FlexGrid.UnboundValueEventArgs e)
        {
            ApplicationUser relApp = smartGridApps1.Rows[e.Row].DataSource as ApplicationUser;
            var app = relApp?.Application;
            if (app == null) return;
            switch (smartGridApps1.Cols[e.Col].Name)
            {
                case "colAppId":
                    e.Value = app.Id;
                    break;
                case "colAppName":
                    e.Value = app.Name;
                    break;
                case "colAppDb":
                    e.Value = app.Db;
                    break;
                case "colAppProduct":
                    e.Value = app.Product;
                    break;
            }
        }
    }
}
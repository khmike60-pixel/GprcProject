using GrpcCommonNet.Library.Common;
using System.ComponentModel;

namespace GrpcWinForms.Objects.Users.Views
{
    public interface IUsersAppView
    {
        BindingList<User> Users { set; }
        BindingList<ApplicationUser> Applications { set; }

        void ShowUsersLoader();
        void HideUsersLoader();
        void ShowAppsLoader();
        void HideAppsLoader();

        event EventHandler ViewLoaded;
        event EventHandler UsersSelectionChanged;
        event EventHandler RefreshUsersRequested;

        event EventHandler CreateUserRequested;
        event EventHandler EditUserRequested;
        event EventHandler DeleteUserRequested;

        User CurrentSelectedUser { get; }
        ApplicationUser CurrentSelectedApplicationUser { get; }
    }
}
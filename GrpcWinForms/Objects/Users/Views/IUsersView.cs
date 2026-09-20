using System;
using System.ComponentModel;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.User;

namespace GrpcWinForms.Objects.Users.Views
{
    public interface IUsersView
    {
        bool DialogMode { get; }
        User SelectedItem { get; set; }
        BindingList<User> Users { set; }

        void CloseWithResult(System.Windows.Forms.DialogResult result);

        event EventHandler ViewLoaded;
        event EventHandler RefreshRequested;
        event EventHandler ItemDoubleClicked;
    }
}
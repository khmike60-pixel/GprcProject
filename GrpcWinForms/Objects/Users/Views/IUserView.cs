using System;
using GrpcCommonNet.Library.Common;

namespace GrpcWinForms.Objects.Users.Views
{
    public interface IUserView
    {
        User User { get; set; }

        string UserSymbol { get; }
        string UserLogin { get; }
        string UserPassword { get; }
        string UserName { get; }
        bool UserIsBlocked { get; }

        event EventHandler OkClicked;
        event EventHandler CancelClicked;
        event EventHandler ViewLoaded;

        void CloseWithResult(System.Windows.Forms.DialogResult result);
    }
}
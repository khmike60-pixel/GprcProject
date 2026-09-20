using GrpcCommonNet.Library.Common;
using GrpcWinForms.Objects.Users.Views;
using System;

namespace GrpcWinForms.Objects.Users.Presenters
{
    public class UserPresenter
    {
        private readonly IUserView view;

        public UserPresenter(IUserView view)
        {
            this.view = view ?? throw new ArgumentNullException(nameof(view));
            this.view.OkClicked += OnOkClicked;
            this.view.CancelClicked += (s, e) => view.CloseWithResult(System.Windows.Forms.DialogResult.Cancel);
        }

        private void OnOkClicked(object sender, EventArgs e)
        {
            // Переносим значения из view в модель
            var user = view.User ?? new User();
            user.UserSymbol = view.UserSymbol;
            user.UserLogin = view.UserLogin;
            user.UserPassword = view.UserPassword;
            user.UserName = view.UserName;
            user.UserIsBlocked = view.UserIsBlocked;
            view.User = user;
            view.CloseWithResult(System.Windows.Forms.DialogResult.OK);
        }
    }
}
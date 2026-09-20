using GrpcCommonNet.Library.ApplicationUser;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.User;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Objects.Users.Views;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Users.Presenters
{
    public class UsersAppPresenter
    {
        private readonly IUsersAppView view;

        public UsersAppPresenter(IUsersAppView view)
        {
            this.view = view ?? throw new ArgumentNullException(nameof(view));
            this.view.ViewLoaded += async (s, e) => await RefreshUsersAsync();
            this.view.RefreshUsersRequested += async (s, e) => await RefreshUsersAsync();
            this.view.UsersSelectionChanged += async (s, e) => await RefreshAppsAsync();
            this.view.CreateUserRequested += async (s, e) => await CreateUserAsync();
            this.view.EditUserRequested += async (s, e) => await EditUserAsync();
            this.view.DeleteUserRequested += async (s, e) => await DeleteUserAsync();
        }

        public async Task RefreshUsersAsync()
        {
            try
            {
                view.ShowUsersLoader();

                var request = new UserFilterRequest
                {
                    ApplicationName = string.Empty,
                    UserLogin = string.Empty,
                    ContragentId = 0,
                    FieldMask = new Google.Protobuf.WellKnownTypes.FieldMask()
                    { Paths = { "id", "contragent_id", "user_login", "user_symbol", "user_is_blocked", "user_name", "contragent" } }
                };

                ListUserResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.User.GetListUserAsync(request).ResponseAsync);

                view.Users = new BindingList<User>(response.Users.ToList());
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при получении пользователей");
            }
            finally
            {
                view.HideUsersLoader();
            }
        }

        public async Task RefreshAppsAsync()
        {
            try
            {
                view.ShowAppsLoader();
                var user = view.CurrentSelectedUser;
                if (user == null) return;

                var request = new ApplicationUserFilterRequest
                {
                    UserId = user.Id,
                    FieldMask = new Google.Protobuf.WellKnownTypes.FieldMask()
                    { Paths = { "id", "application.id", "application.name", "application.db", "application.product" } }
                };

                ListApplicationUserResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.ApplicationUser.GetListApplicationUserAsync(request).ResponseAsync);

                view.Applications = new BindingList<ApplicationUser>(response.ApplicationUsers.ToList());
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при получении приложений пользователя");
            }
            finally
            {
                view.HideAppsLoader();
            }
        }

        private async Task CreateUserAsync()
        {
            // Presenter только-что вызывает диалог через view; сам диалог остаётся в view (форме).
            // Для краткости: оставляем реализацию вызова диалога на форме, а здесь только обновим список после создания.
            await RefreshUsersAsync();
        }

        private async Task EditUserAsync()
        {
            await RefreshUsersAsync();
        }

        private async Task DeleteUserAsync()
        {
            await RefreshUsersAsync();
        }
    }
}
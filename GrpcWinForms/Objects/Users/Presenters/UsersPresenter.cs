using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.User;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Objects.Users.Views;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace GrpcWinForms.Objects.Users.Presenters
{
    public class UsersPresenter
    {
        private readonly IUsersView view;

        public UsersPresenter(IUsersView view)
        {
            this.view = view ?? throw new ArgumentNullException(nameof(view));
            this.view.ViewLoaded += async (s, e) => await RefreshUsersAsync();
            this.view.RefreshRequested += async (s, e) => await RefreshUsersAsync();
            this.view.ItemDoubleClicked += OnItemDoubleClicked;
        }

        private void OnItemDoubleClicked(object sender, EventArgs e)
        {
            if (!view.DialogMode) return;
            // view.SelectedItem уже установлен view-ом (формой) при двойном клике
            view.CloseWithResult(System.Windows.Forms.DialogResult.OK);
        }

        public async Task RefreshUsersAsync()
        {
            try
            {
                var request = new UserFilterRequest
                {
                    FieldMask = new Google.Protobuf.WellKnownTypes.FieldMask
                    {
                        Paths = { "id", "contragent.name", "user_symbol" }
                    }
                };

                ListUserResponse response = await GrpcRetry.CallAsync(() =>
                    GrpcClients.GrpcClients.User.GetListUserAsync(request).ResponseAsync);

                view.Users = new BindingList<User>(response.Users);
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при получении данных");
            }
        }
    }
}
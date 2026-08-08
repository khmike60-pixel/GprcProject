using C1.Win.FlexGrid;
using C1.Win.Input;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using GrpcCommonNet.Library.Application;
using GrpcCommonNet.Library.ApplicationUser;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Currency;
using GrpcCommonNet.Library.User;
using GrpcWinForms.GrpcUtils;
using GrpcWinForms.Models;
using GrpcWinForms.Objects.Applications;
//using Microsoft.VisualBasic.ApplicationServices;
using SmartGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = GrpcCommonNet.Library.Common.Application;

namespace GrpcWinForms.Objects.Users.Forms
{
    public partial class UsersForm : Form
    {
        private BindingList<User> users;
        private BindingList<ApplicationUser> applications;
        private Loader loaderUsers = new Loader();
        private Loader loaderApps = new Loader();
        private int rowUser = 0;
        private int rowApp = 0;


        public UsersForm()
        {
            InitializeComponent();

            loaderUsers.Parent = smartGridUsers;
            loaderApps.Parent = smartGridApps;
            loaderUsers.Location = new Point(0, 0);
            loaderApps.Location = new Point(0, 0);
            loaderUsers.Size = smartGridUsers.Size;
            loaderApps.Size = smartGridApps.Size;
        }

        private async void RefreshUsers()
        {

            UserFilterRequest request = new UserFilterRequest()
            {
                ApplicationName = string.Empty,
                UserLogin = string.Empty,
                ContragentId = 0,
                FieldMask = new Google.Protobuf.WellKnownTypes.FieldMask()
                { Paths = { "user_id", "contragent_id", "user_login", "user_symbol", "user_is_blocked", "user_name", "contragent" } }
            };

            request.UserLogin = textAbbrev.Text;
            request.ApplicationName = textBoxApp.Text;
            if (c1ComboBoxIsBlocked.SelectedText == "Блокированы") request.UserIsBlocked = true;
            else if (c1ComboBoxIsBlocked.SelectedText == "Активные") request.UserIsBlocked = false;

            ListUserResponse response = await GrpcRetry.CallAsync(() => 
                GrpcClients.GrpcClients.User.GetListUserAsync(request).ResponseAsync);

            users = new BindingList<User>(response.Users.ToList());
            smartGridUsers.DataSource = users;

        }

        private void UsersForm_Load(object sender, EventArgs e)
        {

            loaderUsers.ShowLoader();
            RefreshUsers();
            c1ComboBoxIsBlocked.SelectedText = "Все";
            loaderUsers.HideLoader();
        }

        private void smartGridUsers_AfterSelChange(object sender, C1.Win.FlexGrid.RangeEventArgs e)
        {
            if (rowUser == smartGridUsers.Row) return;
            else rowUser = smartGridUsers.Row;

            loaderApps.ShowLoader();
            RefreshApps();
            loaderApps.HideLoader();
        }

        private async void RefreshApps()
        {
            if (smartGridUsers.Row < smartGridUsers.Rows.Fixed) return;

            User user = (User)(smartGridUsers.Rows[smartGridUsers.Row].DataSource);
            ApplicationUserFilterRequest request = new ApplicationUserFilterRequest()
            {
                UserId = user.UserId,
                FieldMask = new FieldMask()
                { Paths = { "id", "application.id", "application.name", "application.db", "application.product" } }
            };

            loaderApps.ShowLoader();
            ListApplicationUserResponse response = await GrpcRetry.CallAsync(() => 
                GrpcClients.GrpcClients.ApplicationUser.GetListApplicationUserAsync(request).ResponseAsync);
            applications = new BindingList<ApplicationUser>(response.ApplicationUsers.ToList());
            smartGridApps.DataSource = applications;
            loaderApps.HideLoader();
        }

        private void smartGridUsers_GetUnboundValue(object sender, C1.Win.FlexGrid.UnboundValueEventArgs e)
        {

            User user = smartGridUsers.Rows[e.Row].DataSource as User;

            switch (smartGridUsers.Cols[e.Col].Name)
            {
                case "colContragentName":
                    if (user.Contragent == null || user.Contragent.Id == 0)
                        e.Value = user.UserName;
                    else
                        e.Value = user.Contragent.Name;
                    break;
                case "colUserIsBlocked":
                    e.Value = user.UserIsBlocked ? true : String.Empty;
                    break;
                case "colShortName":
                    e.Value = user.UserName;
                    break;
            }
        }

        private async void toolStripButtonUserNew_Click(object sender, EventArgs e)
        {
            using (UserForm userForm = new UserForm())
            {
                //User user = smartGridUsers.Rows[smartGridUsers.Row].DataSource as User;
                userForm.User = new User();
                userForm.Owner = this;


                if (userForm.ShowDialog() == DialogResult.OK)
                {
                    CreateUserRequest request = new CreateUserRequest
                    {
                        ContragentId = 0,
                        UserLogin = userForm.User.UserLogin,
                        UserPassword = userForm.User.UserPassword,
                        UserSymbol = userForm.User.UserSymbol,
                        UserIsBlocked = userForm.User.UserIsBlocked
                    };

                    UserResponse response = await GrpcRetry.CallAsync(() => 
                        GrpcClients.GrpcClients.User.CreateUserAsync(request).ResponseAsync);
                    if (response.Result.Status != Status.Ok || response.User == null)
                    {
                        MessageBox.Show("Добавить данные не удалось.");
                        return;
                    }
                    else
                    {
                        int rowsel = smartGridUsers.RowSel;
                        users.Insert(smartGridUsers.RowSel - smartGridUsers.Rows.Fixed, response.User);
                        smartGridUsers.Row = rowsel;
                    }
                }
            }
        }

        private async void toolStripButtonUserEdit_Click(object sender, EventArgs e)
        {
            using (UserForm userForm = new UserForm())
            {
                userForm.User = smartGridUsers.Rows[smartGridUsers.Row].DataSource as User;

                if (userForm.ShowDialog() == DialogResult.OK)
                {
                    UpdateUserRequest request = new UpdateUserRequest
                    {
                        UserId = userForm.User.UserId,
                        //ContragentId = userForm.User.Contragent.Id,
                        UserLogin = userForm.User.UserLogin,
                        UserPassword = userForm.User.UserPassword,
                        UserSymbol = userForm.User.UserSymbol,
                        UserIsBlocked = userForm.User.UserIsBlocked
                    };
                    if (userForm.User.Contragent?.CalculateSize() > 0) request.ContragentId = userForm.User.Contragent.Id;

                    UserResponse response = await GrpcRetry.CallAsync(() => 
                        GrpcClients.GrpcClients.User.UpdateUserAsync(request).ResponseAsync);
                    if (response.Result.Status != Status.Ok || response.User == null)
                    {
                        MessageBox.Show("Добавить данные не удалось.");
                        return;
                    }
                    else
                    {
                        int rowsel = smartGridUsers.RowSel;
                        users[rowsel - smartGridUsers.Rows.Fixed] = response.User;
                    }
                }
            }

        }

        private void toolStripButtonUserRefresh_Click(object sender, EventArgs e)
        {
            RefreshUsers();
        }

        private async void toolStripButtonUserDelete_Click(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();
            List<int> oldList = new List<int>();
            List<int> newMarked = new List<int>();
            if (smartGridUsers.SelectedRows.Count == 0) // Удаляется одна запись
            {
                DialogResult result = MessageBox.Show("Удалить текущую строку данных?", "Удаление", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    DeleteUserRequest request = new DeleteUserRequest()
                    {
                        UserId = (int)smartGridUsers.Rows[smartGridUsers.RowSel]["UserId"]
                    };
                    DeleteUserResponse response = await GrpcRetry.CallAsync(() => 
                        GrpcClients.GrpcClients.User.DeleteUserAsync(request).ResponseAsync);
                    int i = smartGridUsers.RowSel - smartGridUsers.Rows.Fixed;
                    if (response.Result.Status == Status.Ok)
                    {
                        users.RemoveAt(i);
                    }
                    else
                        MessageBox.Show("Ошибка при удалении: " + response.Result.Message);
                }
            }
            else // Был режим выделения
            {

                DialogResult result = MessageBox.Show($"Вы отметили {smartGridUsers.SelectedRows.Count} строк." + Environment.NewLine + "Удалить отмеченные строки?", "Удаление", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {

                    oldList.AddRange(smartGridUsers.SelectedRows);
                    newMarked.AddRange(smartGridUsers.SelectedRows);

                    foreach (var index in oldList)
                    {
                        User user = (User)(smartGridUsers.Rows[index].DataSource);
                        ids.Add(user.UserId);
                    }

                    DeleteIdsUserRequest request = new DeleteIdsUserRequest();
                    request.Ids.AddRange(ids);

                    UndeleteIdsUserResponse response = new UndeleteIdsUserResponse();
                    response = await GrpcRetry.CallAsync(() => 
                        GrpcClients.GrpcClients.User.DeleteIdsUserAsync(request).ResponseAsync);

                    List<int> undelIds = new List<int>();
                    foreach (var item in response.UndeletedIds) undelIds.Add(Convert.ToInt32(item));

                    List<int> testList = Utils.UndeleteList<User>((C1FlexGrid)smartGridUsers, users, undelIds, smartGridUsers.SelectedRows, "Id");
                    smartGridUsers.SelectedRows = testList;

                    if (response.Result.Status != Status.Ok)
                        MessageBox.Show("Ошибка при удалении: " + response.Result.Message);
                    else if (response.UndeletedIds.Count > 0)
                        MessageBox.Show("Данные, которые не удалось удалить остались выделенными.");
                }
            }
            return;

        }

        private async void toolStripButtonAppNew_Click(object sender, EventArgs e)
        {
            using (ApplicationsForm appsForm = new ApplicationsForm())
            {
                appsForm.Owner = this;
                appsForm.IsChoiceMode = true;

                if (appsForm.ShowDialog() == DialogResult.OK)
                {
                    if (appsForm.SelectedApps.Count == 0)
                    {
                        Application app = appsForm.SelectedApplication;

                        AddApplicationUserRequest request = new AddApplicationUserRequest();
                        request.UserId = ((User)(smartGridUsers.Rows[smartGridUsers.Row].DataSource)).UserId;
                        request.ApplicationId = app.Id;
                        AddApplicationUserResponse response = await GrpcRetry.CallAsync(() => 
                            GrpcClients.GrpcClients.ApplicationUser.AddApplicationUserAsync(request).ResponseAsync);
                        if (response.Result.Status != Status.Ok || response.ApplicationUser == null)
                        {
                            MessageBox.Show("Добавить приложение пользователю не удалось.");
                            return;
                        }
                        else
                        {
                            int rowsel = smartGridApps.RowSel;
                            applications.Insert(smartGridApps.RowSel - smartGridApps.Rows.Fixed, response.ApplicationUser);
                            smartGridApps.Row = rowsel;
                        }
                    }
                    else
                    {
                        AddIdsApplicationUserRequest request = new AddIdsApplicationUserRequest();

                        AddIdsApplicationUserResponse response = new AddIdsApplicationUserResponse();

                        foreach (var appId in appsForm.SelectedApps)
                            request.ApplicationIds.Add(appId.Id);
                        User user = (User)smartGridUsers.Rows[smartGridUsers.Row].DataSource;
                        request.UserId = user.UserId;

                        response = await GrpcRetry.CallAsync(() => 
                            GrpcClients.GrpcClients.ApplicationUser.AddIdsApplicationUserAsync(request).ResponseAsync);

                        foreach (ApplicationUser app_user in response.ApplicationUsers)
                        {
                            int rowsel = smartGridApps.RowSel;
                            applications.Insert(smartGridApps.RowSel - smartGridApps.Rows.Fixed, app_user);
                            smartGridApps.Row = rowsel;

                        }

                    }
                }
            }
        }

        private void toolStripButtonAppDelete_Click(object sender, EventArgs e)
        {

        }

        private void smartGridApps_GetUnboundValue(object sender, UnboundValueEventArgs e)
        {

            ApplicationUser relApp = (ApplicationUser)(smartGridApps.Rows[e.Row].DataSource);

            Application app = relApp.Application;

            switch (smartGridApps.Cols[e.Col].Name)
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

        private void smartGridUsers_Resize(object sender, EventArgs e)
        {

        }
    }
}
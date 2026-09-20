using GrpcCommonNet.Library.Common;
using GrpcWinForms.Objects.Users.Presenters;
using GrpcWinForms.Objects.Users.Views;
using System;
using System.Windows.Forms;

namespace GrpcWinForms.Objects.Users.Forms
{
    public partial class UserForm : Form, IUserView
    {
        private readonly UserPresenter presenter;
        public User User { get; set; } = new User();

        public UserForm()
        {
            InitializeComponent();
            presenter = new UserPresenter(this);
        }

        // IUserView — свойства отображения
        string IUserView.UserSymbol => textBoxSymbol.Text;
        string IUserView.UserLogin => textBoxLogin.Text;
        string IUserView.UserPassword => textBoxPassword.Text;
        string IUserView.UserName => textBoxShortName.Text;
        bool IUserView.UserIsBlocked => checkBoxIsBlocked.Checked;

        // Явная реализация событий интерфейса — маппинг на локальные события
        event EventHandler IUserView.OkClicked { add => OkClicked += value; remove => OkClicked -= value; }
        event EventHandler IUserView.CancelClicked { add => CancelClicked += value; remove => CancelClicked -= value; }
        event EventHandler IUserView.ViewLoaded { add => ViewLoaded += value; remove => ViewLoaded -= value; }

        User IUserView.User { get => User; set => User = value; }
        void IUserView.CloseWithResult(DialogResult result) { DialogResult = result; Close(); }

        // Локальные события (Presenter подписывается на них через явную реализацию интерфейса)
        private event EventHandler OkClicked;
        private event EventHandler CancelClicked;
        private event EventHandler ViewLoaded;

        private void UserForm_Load(object sender, EventArgs e)
        {
            // Инициализация полей формы из модели
            textBoxSymbol.Text = User.UserSymbol;
            textBoxLogin.Text = User.UserLogin;
            textBoxPassword.Text = User.UserPassword;
            textBoxShortName.Text = User.UserName;
            checkBoxIsBlocked.Checked = User.UserIsBlocked;

            ViewLoaded?.Invoke(this, EventArgs.Empty);
        }

        // Эти методы обязаны существовать — Designer ссылается на них
        private void buttonOk_Click(object sender, EventArgs e)
        {
            // Передаём событие презентеру
            OkClicked?.Invoke(this, EventArgs.Empty);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
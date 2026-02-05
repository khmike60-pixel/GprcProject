using Grpc.Core;
using GrpcCommonNet.Library.Auth;
using Status = GrpcCommonNet.Library.Common.Status;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GrpcWinForms.Models;

namespace GrpcWinForms.Forms
{
    public partial class LoginForm : Form
    {
        private readonly string _application = Program.Configuration["Application:Name"].ToString();
        private Loader loaderAuth = new Loader();
        //private readonly string _serverAddress = Program.Configuration["Grpc:ServerAddress"].ToString();
        //private readonly AuthServices.AuthServicesClient _client;


        public LoginForm()
        {
            loaderAuth.Parent = this;
            try
            {
                // Читаем имя приложения и адрес службы из конфигурации
                MainClass.GrpcAddress = Program.Configuration["Grpc:ServerAddress"].ToString();

                InitializeComponent();

                // Получаем имя хоста от службы и сохраняем в MainClass, приложение, адрес сервера
                MainClass.HostName = GrpcClients.GrpcClients.Auth.NameHost(new NameHostRequest()).NameHost;

                this.Text = $"Авторизация: {MainClass.AppName} ({MainClass.HostName})";
                labelError.Text = "Ошибка  авторизации. Попробуйте еще раз";
                labelError.Visible = false;
            }
            catch (RpcException ex)
            {
                MessageBox.Show("gRPC ошибка: Служба недоступна: \n " + ex.Status.Detail, "Ошибка");
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка в формы авторизации: \n" + ex.Message, "Ошибка");
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            labelError.Visible = false;
            loaderAuth.ShowLoader();
            try
            {
                // Формируем запрос
                var req = new AuthRequest
                {
                    Username = loginTextBox.Text,
                    Password = passwordTextBox.Text,
                    Application = _application
                };

                // реальный вызов gRPC Auth
                AuthResponse resp = await GrpcClients.GrpcClients.Auth.AuthAsync(req);
                loaderAuth.HideLoader();

                if (resp.Result?.Status == Status.Ok)
                {
                    Token token = resp.Token;

                    if (string.IsNullOrWhiteSpace(token.AccessToken))
                    {
                        MessageBox.Show("Сервер вернул пустой токен", "Ошибка");
                        return;
                    }

                    // сохраняем токен в фабрике клиента
                    MainClass.Token = token.AccessToken;

                    //MessageBox.Show("Авторизация успешна!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    labelError.Text = "Ошибка  авторизации. Попробуйте еще раз";
                    labelError.Visible = true;
                }
            }
            catch (RpcException ex)
            {
                labelError.Text = "gRPC ошибка";
                labelError.Visible = true;
                MessageBox.Show("gRPC ошибка: " + ex.Status.Detail);
            }
            catch (Exception ex)
            {
                labelError.Text = "Ошибка";
                labelError.Visible = true;
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

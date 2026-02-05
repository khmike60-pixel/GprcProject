
using System;
using System.Windows.Forms;
using GrpcWinForms.Models;
using Microsoft.Extensions.Configuration;

namespace GrpcWinForms
{
    internal static class Program
    {
        public static IConfiguration Configuration { get; private set; }

        [STAThread]
        static void Main()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainClass.AppName = Program.Configuration["Application:Name"];

            using (var loginForm = new Forms.LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Forms.MainForm());
//                    Application.Run(new Forms.TestForm());
                }
            }
        }
    }
}

using Grpc.Core;
using GrpcWinForms.Forms;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcWinForms.GrpcUtils
{
    public static class GrpcRetry
    {
        /// <summary>
        /// Для фабрики, возвращающей AsyncUnaryCall<T> (стандартный gRPC async метод).
        /// </summary>
        public static async Task<T> CallAsync<T>(Func<AsyncUnaryCall<T>> grpcCallFactory, int maxRetries = 1)
        {
            int attempts = 0;
            while (true)
            {
                try
                {
                    var call = grpcCallFactory();
                    return await call.ResponseAsync.ConfigureAwait(false);
                }
                catch (RpcException ex) when (ex.StatusCode == StatusCode.Unauthenticated)
                {
                    if (attempts >= maxRetries) throw;
                    attempts++;
                    Authorization();
                    await Task.Yield();
                }
            }
        }

        /// <summary>
        /// Для фабрики, возвращающей Task<T>
        /// </summary>
        public static async Task<T> CallAsync<T>(Func<Task<T>> func, int maxRetries = 1)
        {
            int attempts = 0;
            while (true)
            {
                try
                {
                    return await func().ConfigureAwait(false);
                }
                catch (RpcException ex) when (ex.StatusCode == StatusCode.Unauthenticated)
                {
                    if (attempts >= maxRetries) throw;
                    attempts++;
                    Authorization();
                    await Task.Yield();
                }
            }
        }

        public static async Task CallAsync(Func<Task> func, int maxRetries = 1)
        {
            int attempts = 0;
            while (true)
            {
                try
                {
                    await func().ConfigureAwait(false);
                    return;
                }
                catch (RpcException ex) when (ex.StatusCode == StatusCode.Unauthenticated)
                {
                    if (attempts >= maxRetries) throw;
                    attempts++;
                    Authorization();
                    await Task.Yield();
                }
            }
        }

        public static T Call<T>(Func<T> func, int maxRetries = 1)
        {
            int attempts = 0;
            while (true)
            {
                try
                {
                    return func();
                }
                catch (RpcException ex) when (ex.StatusCode == StatusCode.Unauthenticated)
                {
                    if (attempts >= maxRetries) throw;
                    attempts++;
                    Authorization();
                }
            }
        }

        public static void Call(Action action, int maxRetries = 1)
        {
            int attempts = 0;
            while (true)
            {
                try
                {
                    action();
                    return;
                }
                catch (RpcException ex) when (ex.StatusCode == StatusCode.Unauthenticated)
                {
                    if (attempts >= maxRetries) throw;
                    attempts++;
                    Authorization();
                }
            }
        }

        public static bool Authorization()
        {
            bool exit = false;
            LoginForm loginForm = new LoginForm();
            while (!exit)
            {
                if (MessageBox.Show("Вы долго не работали в приложении и Вам необходимо авторизоваться! Готовы?\n" +
                    "Если Вы ответит Cancel, то приложение будет закрыто", "Необходима авторизация",
                    MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    Application.Exit();
                if (loginForm.ShowDialog() == DialogResult.OK) exit = true;
            }
            return exit;
        }
    }
}
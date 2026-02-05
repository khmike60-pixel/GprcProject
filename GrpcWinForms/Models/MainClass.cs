using Grpc.Core;
using Grpc.Core.Interceptors;
using Grpc.Net.Client;
using GrpcCommonNet.Library.Auth;
using GrpcCommonNet.Library.Currency;
using GrpcCommonNet.Library.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWinForms.Models
{
    public static class MainClass
    {
        private static GrpcChannel _channel;
        private static CallInvoker _invoker;

        public static string Token { get; set; } = string.Empty;

        public static string AppName { get; set; } // Наименование приложения
        public static string HostName { get; set; } // Ниаменование службы
        public static string GrpcAddress { get; set; }

        public static GrpcChannel Channel =>
            _channel ??= GrpcChannel.ForAddress(GrpcAddress,
                new GrpcChannelOptions
                {
                    HttpHandler = new SocketsHttpHandler
                    {
                        EnableMultipleHttp2Connections = true
                    }
                });

        public static CallInvoker Invoker =>
            _invoker ??= Channel.Intercept(new JwtInterceptor(() => Token));

    }

}

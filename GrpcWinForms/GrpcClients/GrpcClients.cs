using GrpcCommonNet.Library.Auth;
using GrpcCommonNet.Library.Common;
using GrpcCommonNet.Library.Currency;
using GrpcWinForms.Models;
using GrpcCommonNet.Library.Unit;
using GrpcCommonNet.Library.Contragent;
using GrpcCommonNet.Library.Application;
using GrpcCommonNet.Library.User;
using GrpcCommonNet.Library.Product;
using GrpcCommonNet.Library.Geolocation;
using GrpcCommonNet.Library.Contract;
using GrpcCommonNet.Library.ApplicationUser;


namespace GrpcWinForms.GrpcClients
{
    public static class GrpcClients
    {
        private static ApplicationServices.ApplicationServicesClient _application;
        private static ApplicationUserServices.ApplicationUserServicesClient _application_user;
        private static AuthServices.AuthServicesClient _auth;
        private static ContractServices.ContractServicesClient _contract;
        private static ContragentServices.ContragentServicesClient _contragent;
        private static CurrencyServices.CurrencyServicesClient _currency;
        private static GeolocationServices.GeolocationServicesClient _geolocation;
        private static ProductServices.ProductServicesClient _product;
        private static UnitServices.UnitServicesClient _unit;
        private static UserServices.UserServicesClient _user;

        public static ApplicationServices.ApplicationServicesClient Application =>
            _application ??= new ApplicationServices.ApplicationServicesClient(MainClass.Invoker);
        public static ApplicationUserServices.ApplicationUserServicesClient ApplicationUser =>
            _application_user ??= new ApplicationUserServices.ApplicationUserServicesClient(MainClass.Invoker);
        public static ContractServices.ContractServicesClient Contract =>
            _contract ??= new ContractServices.ContractServicesClient(MainClass.Invoker);
        public static ContragentServices.ContragentServicesClient Contragent =>
            _contragent ??= new ContragentServices.ContragentServicesClient(MainClass.Invoker);
        public static CurrencyServices.CurrencyServicesClient Currency =>
            _currency ??= new CurrencyServices.CurrencyServicesClient(MainClass.Invoker);
        public static GeolocationServices.GeolocationServicesClient Geolocation =>
            _geolocation ??= new GeolocationServices.GeolocationServicesClient(MainClass.Invoker);
        public static ProductServices.ProductServicesClient Product =>
            _product ??= new ProductServices.ProductServicesClient(MainClass.Invoker);
        public static UnitServices.UnitServicesClient Unit =>
            _unit ??= new UnitServices.UnitServicesClient(MainClass.Invoker);
        public static UserServices.UserServicesClient User =>
            _user ??= new UserServices.UserServicesClient(MainClass.Invoker);


        public static AuthServices.AuthServicesClient Auth =>
            _auth ??= new AuthServices.AuthServicesClient(MainClass.Channel); // без интерцептора!

    }
}

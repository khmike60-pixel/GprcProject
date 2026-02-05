using Grpc.Core;
using System.Security.Claims;

namespace GrpcCommonNet.Service.Models
{
    public class UserData
    {
        public string User { get; set; } = "";
        public string Application { get; set; } = "";   
        public string Token { get; set; } = ""; 

        public UserData GetUserData(ServerCallContext context)
        {
            ClaimsPrincipal user = context.GetHttpContext().User;
            UserData userData = new UserData()
            {
                User = user.FindFirst(ClaimTypes.Name)?.Value,
                Application = user.FindFirst(ClaimTypes.UserData)?.Value
            };
            return userData;
        }
    }
}

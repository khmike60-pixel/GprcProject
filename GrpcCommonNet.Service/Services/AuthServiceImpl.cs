using Grpc.Core;
using GrpcCommonNet.Library.Auth;
using GrpcCurrencyNet.Service.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Result = GrpcCommonNet.Library.Common.Result;
using Status = GrpcCommonNet.Library.Common.Status;

public class AuthServiceImpl : AuthServices.AuthServicesBase
{
    private readonly JwtOptions _jwt;
    private readonly AuthRepository _repo;
    private readonly ILogger<AuthServiceImpl> _logger;
    private readonly IConfiguration _config;

    public AuthServiceImpl(ILogger<AuthServiceImpl> logger, JwtOptions jwt, AuthRepository repo, IConfiguration config)
    {
        _jwt = jwt;
        _repo = repo;
        _logger = logger;
        _config = config;
    }

    public override async Task<AuthResponse> Auth(AuthRequest request, ServerCallContext context)
    {
        _logger.LogDebug($"Auth called: Login: {request.Username}, Application: {request.Application}");
        string cryptPassword = GrpcCommonNet.Library.Unit.Crypt.getMd5Hash(request.Password.Trim() + request.Username.Trim().ToUpper());

        try
        {
            if (!await _repo.AuthToken(request.Username, cryptPassword, request.Application))
            {
                _logger.LogWarning("Invalid login attempt for {user}", request.Username);
                return new AuthResponse { Result = new Result { Status = Status.NotFound } };
            }

            int qty_minutes_in_hour = request.ExpireMinutes == 0 ? 60 : request.ExpireMinutes;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, request.Username),
                new Claim(ClaimTypes.UserData, request.Application)
        };

            var token = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(qty_minutes_in_hour / 60),
                signingCredentials: creds
            );

            return new AuthResponse
            {
                Result = new Result { Status = Status.Ok },

                Token = new Token()
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                    TokenType = "Bearer",
                    ExpiresIn = request.ExpireMinutes
                }
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new AuthResponse { Result = new Result { Status = Status.BadRequest, Message = ex.Message } };

        }
    }

    public override async Task<NameHostResponse> NameHost(NameHostRequest request, ServerCallContext context)
    {
        _logger.LogDebug($"NameHost called: {request}");

        return new NameHostResponse
        {
            NameHost  = _config["Kestrel:Endpoints:Grpc:Name"] //"Localhost"
        };
    }
}

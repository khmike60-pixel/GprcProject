using System.Text;
using GrpcCurrencyNet.Service.Models;        // JwtOptions
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using Serilog;
using GrpcCommonNet.Service.Repository;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // ----------------------------------------------------
    // Basic configuration & Serilog (early)
    // ----------------------------------------------------
    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File("logs/app.log", rollingInterval: Serilog.RollingInterval.Day)
        .CreateLogger();

    builder.Host.UseSerilog();

    // ----------------------------------------------------
    // Bind JwtOptions from configuration and register in DI
    // ----------------------------------------------------
    // appsettings.json section:
    // "Jwt": { "Key": "...", "Issuer": "...", "Audience": "..." }
    builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
    // Expose strongly typed value for direct injection
    builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<JwtOptions>>().Value);

    // ----------------------------------------------------
    // Kestrel endpoints (explicit). gRPC (HTTP/2) on 5055, HTTP/1 on 5056
    // ----------------------------------------------------
    // If you prefer reading from appsettings.json, you can remove this and use builder.WebHost.ConfigureKestrel(...)
    builder.WebHost.ConfigureKestrel(options =>
    {
        options.Configure(builder.Configuration.GetSection("Kestrel"));
    });

    // ----------------------------------------------------
    // Register gRPC FIRST (required)
    // ----------------------------------------------------
    builder.Services.AddGrpc();

    // ----------------------------------------------------
    // Register other framework services
    // ----------------------------------------------------
    
    /*
    builder.Services.AddControllers(); // if you use REST controllers (AuthController etc.)  ===================
    */

    // OpenTelemetry metrics (Prometheus exporter)
    builder.Services.AddOpenTelemetry()
        .WithMetrics(metrics =>
        {
            metrics
                .SetResourceBuilder(OpenTelemetry.Resources.ResourceBuilder.CreateDefault().AddService("GrpcCurrencyNet.Service"))
                .AddAspNetCoreInstrumentation()
                .AddRuntimeInstrumentation()
                .AddPrometheusExporter();
        });

    // ----------------------------------------------------
    // Authentication: JWT Bearer (reads JwtOptions from config)
    // ----------------------------------------------------
    var jwtOpts = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();
    if (jwtOpts == null || string.IsNullOrWhiteSpace(jwtOpts.Key))
    {
        throw new Exception("Jwt configuration missing or Jwt:Key empty in appsettings.json");
    }

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false; // true in prod
        options.SaveToken = true;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtOpts.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtOpts.Audience,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOpts.Key))
        };

        // If you need to support receiving token in gRPC metadata as "authorization",
        // the Grpc.Net.Client adds the Authorization header on HTTP level when using HttpClient handlers,
        // so JwtBearer will read it automatically. No extra event wiring needed here.
    });

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("DefaultPolicy", policy =>
        {
            policy.RequireAuthenticatedUser();
        });
    });

    // ----------------------------------------------------
    // Application services (repositories, etc.)
    // ----------------------------------------------------
    // Register repository and other dependencies that services use.
    // Choose lifetimes according to thread-safety: typically AddSingleton or AddScoped.
    builder.Services.AddSingleton<ApplicationRepository>();
    builder.Services.AddSingleton<ApplicationUserRepository>();
    builder.Services.AddSingleton<AuthRepository>();
    builder.Services.AddSingleton<BankRepository>();
    builder.Services.AddSingleton<ContractRepository>();
    builder.Services.AddSingleton<ContragentRepository>();
    builder.Services.AddSingleton<CurrencyRepository>(); // or AddScoped<...>()
    builder.Services.AddSingleton<DepartmentRepository>(); // or AddScoped<...>()
    builder.Services.AddSingleton<GeolocationRepository>();
    builder.Services.AddSingleton<ProductRepository>();
    builder.Services.AddSingleton<UnitRepository>();
    builder.Services.AddSingleton<UserRepository>();
    builder.Services.AddSingleton<DocumentTypeRepository>();

    // Register gRPC service classes if they have constructor dependencies (DI will resolve them).
    // Note: you don't "Add" the service classes here; MapGrpcService will resolve them from DI.

    // Windows Service support (optional)
    if (OperatingSystem.IsWindows())
    {
        builder.Host.UseWindowsService();
    }

    // ----------------------------------------------------
    // Build the app
    // ----------------------------------------------------
    var app = builder.Build();

    // Middlewares for auth
    app.UseAuthentication();
    app.UseAuthorization();

    // ----------------------------------------------------
    // Map gRPC services (only after Build)
    // ----------------------------------------------------
    // AuthServiceImpl — unauthenticated methods (issue tokens) -> allow anonymous
    app.MapGrpcService<AuthServiceImpl>().AllowAnonymous();

    // CurrencyServiceImpl — protected by JWT
    app.MapGrpcService<ApplicationServiceImpl>().RequireAuthorization("DefaultPolicy");
    app.MapGrpcService<ApplicationUserServiceImpl>().RequireAuthorization("DefaultPolicy");
    app.MapGrpcService<BankServiceImpl>().RequireAuthorization("DefaultPolicy");
    app.MapGrpcService<ContractServiceImpl>().RequireAuthorization("DefaultPolicy");
    app.MapGrpcService<ContragentServiceImpl>().RequireAuthorization("DefaultPolicy");
    app.MapGrpcService<CurrencyServiceImpl>().RequireAuthorization("DefaultPolicy");
    app.MapGrpcService<DepartmentServiceImpl>().RequireAuthorization("DefaultPolicy");
    app.MapGrpcService<GeolocationServiceImpl>().RequireAuthorization("DefaultPolicy");
    app.MapGrpcService<ProductServiceImpl>().RequireAuthorization("DefaultPolicy");
    app.MapGrpcService<UnitServiceImpl>().RequireAuthorization("DefaultPolicy");
    app.MapGrpcService<UserServiceImpl>().RequireAuthorization("DefaultPolicy");
    app.MapGrpcService<DocumentTypeServiceImpl>().RequireAuthorization("DefaultPolicy");

    // If you also expose REST controllers (e.g. AuthController), enable mapping

    /*
    app.MapControllers(); // optional: only if you have controllers  =========================================
    */

    // Prometheus scraping endpoint (exposed on the HTTP/1 endpoint)
    app.MapPrometheusScrapingEndpoint("/metrics");

    // Health / root
    app.MapGet("/", () => "GrpcCommonNet Service running");

    // Run
    app.Run();

    // End of try
}
catch (Exception ex)
{
    // Fatal startup logging
    Log.Fatal(ex, "Application start-up failed");
    throw;
}
finally
{
    Log.CloseAndFlush();
}

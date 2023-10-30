using System.Text;
using CarsManagement.Server.Application;
using CarsManagement.Server.Application.Repositories;
using CarsManagement.Server.Domain;
using CarsManagement.Server.Domain.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

namespace CarsManagement.Server.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        #region Setup DI

        // Add mapper
        builder.Services.AddAutoMapper(cfg => cfg.AddProfile<ServerMapperProfile>(), typeof(Program));

        // Add the DbContext to the services
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
#if DEBUG
            options.UseInMemoryDatabase("CarsManagement");
#else
            var connectionString = builder.Configuration.GetSection("ConnectionString").Value;
            options.UseSqlServer(connectionString);
#endif
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        });

        builder.Services.AddScoped<IRepository<ManagerModel>, ManagersRepository>();
        builder.Services.AddScoped<IRepository<LotModel>, ParkingLotsRepository>();
        builder.Services.AddScoped<IRepository<SpotModel>, ParkingSpotsRepository>();

        #endregion

        #region Services Setup

        // Add simple logging
        builder.Logging.AddConsole();
        builder.Logging.SetMinimumLevel(LogLevel.Debug);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();

        // Add configuration to the container.
        builder.Configuration.AddJsonFile("appsettings.json");
        builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

        // Add response compression services
        builder.Services.AddResponseCompression(opts =>
        {
            opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                new[] { "application/octet-stream" });
        });

        // Add Swagger services
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cars Management API", Version = "v1" });
        });

        // Configure cookie-based authentication
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/auth/login";
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Ensure cookies are sent only over HTTPS
            });

        builder.Services.AddEndpointsApiExplorer();

        #endregion

        var app = builder.Build();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers(); // Ensure controllers are being mapped
        });

        app.UseHsts();
        app.UseHttpsRedirection();
        app.UseCors(policy => policy.WithOrigins("*").AllowAnyMethod().WithHeaders(HeaderNames.ContentType));

        app.UseWebAssemblyDebugging();
        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();

        app.UseResponseCompression();

        app.UseSwagger();
        app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cars Management API v1"); });

        app.MapFallbackToFile("index.html");

        app.Run();
    }
}

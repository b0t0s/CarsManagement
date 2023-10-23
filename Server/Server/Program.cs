using CarsManagement.Server.Application;
using CarsManagement.Server.Application.Repositories;
using CarsManagement.Server.Domain;
using CarsManagement.Server.Domain.Entities;
using CarsManagement.Shared.DTO;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

namespace CarsManagement.Server.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add simple logging
            builder.Logging.AddConsole();
            builder.Logging.SetMinimumLevel(LogLevel.Debug);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            // Add configuration to the container.
            builder.Configuration.AddJsonFile("appsettings.json");

            // Add mapper
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
            builder.Services.AddScoped<IRepository<CarModel>, CarsRepository>();
            builder.Services.AddScoped<IRepository<TicketModel>, TicketsRepository>();

            //Add auth
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = "/auth/login";
                });

            // Add health checks
            builder.Services.AddHealthChecks();

            // Add Swagger services
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Cars Management API", Version = "v1" });

                // Define the OAuth2 scheme for Swagger
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
                });

                // Apply the security requirements
                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference { Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new string[] { }
                    }
                });
            });

            // Add response compression services
            builder.Services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });

            var app = builder.Build();

            app.UseAuthentication();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();  // Add this line

            // Use response compression middleware
            app.UseResponseCompression();

            app.UseHttpsRedirection();

            // Use Swagger middleware
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cars Management API v1");
            });

            // Use health checks middleware
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");
                endpoints.MapControllers();
            });

            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}

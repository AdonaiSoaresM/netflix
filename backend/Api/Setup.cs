using Data.Context;
using Data.Repositories;
using Data.Seeder;
using Data.Services;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace backend
{
    public static class Setup
    {
        public static void AddDependecyInjectionConfiguration(this IServiceCollection service)
        {
            service.AddTransient<IRepositoryUser, RepositoryUser>();
            service.AddTransient<IRepositoryMovie, RepositoryMovie>();
        }

        public static void AddMediatRConfiguration(this IServiceCollection service)
        {
            var assembly = AppDomain.CurrentDomain.Load("Domain");
            service.AddMediatR(options => options.RegisterServicesFromAssembly(assembly));
        }

        public static void AddDbContextConfiguration(this IServiceCollection service, IWebHostEnvironment environment)
        {
            var builder = WebApplication.CreateBuilder();
            String ConnectionType;

            if (environment.EnvironmentName == "Docker") {
                ConnectionType = "SqlServerDocker";
                }
            else {
                ConnectionType = "SqlServerWindows";
            };

            service.AddDbContext<ProjectContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(ConnectionType)));
        }

        public async static void UseDataBaseConfiguration(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<ProjectContext>();
            if (context != null) { 
                await context!.Database.MigrateAsync();
                await Seeder.CreateAdminUser(context);
            }
        }
        public static void AddJwtBearerConfiguration(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddSingleton<IJWTService, JWTService>();
            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "localhost",
                    ValidAudience = "localhost",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["SecurityKey"]))
                };
            });
        }
    }
}
using Data.Context;
using Data.Repositories;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace backend
{
    public static class Setup
    {
        public static void AddDependecyInjectionConfiguration(this IServiceCollection service)
        {
            service.AddTransient<IRepositoryUser, RepositoryUser>();
            Console.WriteLine("Opa");
        }

        public static void AddMediatRConfiguration(this IServiceCollection service)
        {
            var assembly = AppDomain.CurrentDomain.Load("Domain");
            service.AddMediatR(options => options.RegisterServicesFromAssembly(assembly));
        }

        public static void AddDbContextConfiguration(this IServiceCollection service)
        {
            var builder = WebApplication.CreateBuilder();
            service.AddDbContext<ProjectContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerWindows")));
        }
    }
}
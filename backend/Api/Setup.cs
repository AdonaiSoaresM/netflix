using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend
{
    public static class Setup
    {
        public static void AddDbContextConfiguration(this IServiceCollection service)
        {
            var builder = WebApplication.CreateBuilder();
            service.AddDbContext<ProjectContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerWindows")));
        }
    }
}
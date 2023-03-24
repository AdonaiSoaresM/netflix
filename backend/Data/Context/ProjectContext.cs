using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern;

namespace Data.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //}
    }
}
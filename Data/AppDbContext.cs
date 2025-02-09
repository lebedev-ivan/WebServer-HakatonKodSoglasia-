using Microsoft.EntityFrameworkCore;
using WebServer.Models;

namespace YourNamespace.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; } // Ваша сущность Project
    }
}
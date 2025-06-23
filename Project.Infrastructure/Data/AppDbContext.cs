
using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;


namespace Project.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Users> Users { get; set; }
    }
}
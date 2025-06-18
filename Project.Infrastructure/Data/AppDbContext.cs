using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;


namespace Project.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        DbSet<Users> Users { get; set; }
    }
}
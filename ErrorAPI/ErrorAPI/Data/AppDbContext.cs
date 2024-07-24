using ErrorAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace ErrorAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { 
        }
        public DbSet<Error> Errors { get; set; }
    }
}

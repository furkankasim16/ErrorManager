using ErrorAPI.DTO;
using Microsoft.EntityFrameworkCore;
namespace ErrorAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { 
        }
        public DbSet<ErrorDto> Errors { get; set; }
    }
}

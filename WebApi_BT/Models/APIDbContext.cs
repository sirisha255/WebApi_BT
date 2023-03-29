using Microsoft.EntityFrameworkCore;

namespace WebApi_BT.Models
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<Product> Products { get; set; }
    }
}

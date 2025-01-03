using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.Entities;

namespace ShopManagement.Infrastructures.Db
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}

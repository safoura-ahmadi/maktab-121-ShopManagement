using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.Entities;

namespace ShopManagement.Infrastructures.Db
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=(localdb)\\MSSQLLocalDB; Initial catalog=TehranShop");
            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<Product> Products { get; set; }

    }
}

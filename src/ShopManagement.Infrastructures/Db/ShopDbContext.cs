using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.Entities;

namespace ShopManagement.Infrastructures.Db
{
    public class ShopDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public ShopDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}

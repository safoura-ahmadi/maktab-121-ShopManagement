using Microsoft.EntityFrameworkCore;

namespace ShopManagement.Infrastructures.Db;

public class MarketingDbContext : DbContext
{
    public MarketingDbContext(DbContextOptions options) : base(options)
    {

    }
}
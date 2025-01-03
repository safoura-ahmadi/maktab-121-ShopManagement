using Microsoft.EntityFrameworkCore;

namespace ShopManagement.Infrastructures.Db;

public class CrmDbContext : DbContext
{
    public CrmDbContext(DbContextOptions options) : base(options)
    {

    }
}
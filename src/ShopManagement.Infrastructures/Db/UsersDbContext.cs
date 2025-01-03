using Microsoft.EntityFrameworkCore;

namespace ShopManagement.Infrastructures.Db;

public class UsersDbContext : DbContext
{
    public UsersDbContext(DbContextOptions options) : base(options)
    {

    }
}
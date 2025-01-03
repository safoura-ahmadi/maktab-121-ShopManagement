using ShopManagement.Domain.Entities;
using ShopManagement.Domain.Repositories;
using ShopManagement.Infrastructures.Db;

namespace ShopManagement.Infrastructures.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopDbContext _dbContext;

        public ProductRepository(ShopDbContext db)
        {
            _dbContext = db;
        }

        public async Task<List<Product>> GetProducts()
        {
            List<Product> products = _dbContext.Products.ToList();
            return products;
        }
    }
}

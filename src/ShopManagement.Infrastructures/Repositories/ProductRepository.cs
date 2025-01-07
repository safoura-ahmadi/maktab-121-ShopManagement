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
        public  void AddProducts(string name, int price, int quantity)
        {
            var prc = new Product()
            {
                Title = name,
                Price = price,
                Qty = quantity
            };
            _dbContext.Products.Add(prc);
          _dbContext.SaveChanges();
        }
    }
}

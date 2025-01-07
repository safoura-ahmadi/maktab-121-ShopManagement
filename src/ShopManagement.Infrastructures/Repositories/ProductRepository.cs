using ShopManagement.Domain.Contracts;
using ShopManagement.Domain.Entities;
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

        public Product GetProductDetails(int productId)
        {
            // todo : complete this task
            return new Product()
            {
                Id = productId,
                Qty = 0,
                Price = 0,
                Title = "از دیتابیس بخون"
            };
            throw new NotImplementedException();
        }

        public void AddProducts(string name, int price, int quantity)
        {
            Product prc = new()
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

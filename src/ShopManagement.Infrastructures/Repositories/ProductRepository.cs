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
            List<Product> products = _dbContext.Products.Where(w => w.IsDeleted == false).ToList();
            return products;
        }

        public Product GetProductDetails(int productId)
        {
            var result = _dbContext.Products.Where(w => w.Id == productId).FirstOrDefault();
            return result;
        }

        public int AddProducts(string name, int price, int quantity, int userId)
        {
            Product prc = new()
            {
                Title = name,
                Price = price,
                Qty = quantity,
                CreatedAt = DateTime.Now,
                CreatedBy = userId,
                IsDeleted = false,
            };
            _dbContext.Products.Add(prc);
            _dbContext.SaveChanges();
            return prc.Id;
        }

        public int EditProducts(int id, string name, int price, int quantity, int userId)
        {
            var p = _dbContext.Products.FirstOrDefault(x => x.Id == id);
            p.Title = name;
            p.Price = price;
            p.Qty = quantity;
            p.LastModifiedBy = userId;
            p.LastModifiedAt = DateTime.Now;
            _dbContext.SaveChanges();
            return p.Id;
        }
    }
}

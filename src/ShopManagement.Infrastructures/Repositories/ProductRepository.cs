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
            var result = _dbContext.Products.Where(w => w.Id == productId).FirstOrDefault();
            return result;
        }

        public int AddProducts(string name, int price, int quantity)
        {
            Product prc = new()
            {
                Title = name,
                Price = price,
                Qty = quantity
            };
            _dbContext.Products.Add(prc);
            _dbContext.SaveChanges();
            return prc.Id;
        }

        public void EditProducts(int id , string name, int price, int quantity)
        {
         
            var p = _dbContext.Products.FirstOrDefault(x => x.Id == id);
            p.Title = name;
            p.Price = price;
            p.Qty = quantity;  
            _dbContext.SaveChanges();
        
    }
    }
}

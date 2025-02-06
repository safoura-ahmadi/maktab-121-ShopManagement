using ShopManagement.Domain.Contracts;
using ShopManagement.Domain.Entities;

namespace ShopManagement.AppServices
{
    public class ProductAppServices : IProductAppServices
    {
        private readonly IProductRepository _productRepository;

        public ProductAppServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetListOfProducts()
        {
            List<Product> products = await _productRepository.GetProducts();
            return products;
        }

        public Product GetProductDetails(int productId)
        {
            return _productRepository.GetProductDetails(productId);
        }


        public int AddProducts(string name, int price, int quantity, int userId)
        {
            // validate
           return _productRepository.AddProducts(name, price, quantity, userId);
        }

        public void EditProducts(int id, string name, int price, int quantity, int userId)
        {
            _productRepository.EditProducts(id, name, price, quantity, userId);
        }
    }
}

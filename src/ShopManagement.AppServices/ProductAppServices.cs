using ShopManagement.AppServices.Contracts;
using ShopManagement.Domain.Entities;
using ShopManagement.Domain.Repositories;

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
        public void AddProducts(string name, int price, int quantity)
        {
          _productRepository.AddProducts(name, price, quantity);
           
        }
    }
}

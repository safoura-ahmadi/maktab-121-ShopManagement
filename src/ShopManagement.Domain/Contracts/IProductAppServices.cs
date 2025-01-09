using ShopManagement.Domain.Entities;

namespace ShopManagement.Domain.Contracts;

public interface IProductAppServices
{
    Task<List<Product>> GetListOfProducts();
    Product GetProductDetails(int productId);
    public void AddProducts(string name, int price, int quantity);
    public void EditProducts(int id ,string name, int price, int quantity);
}
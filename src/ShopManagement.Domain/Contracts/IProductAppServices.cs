using ShopManagement.Domain.Entities;

namespace ShopManagement.AppServices.Contracts;

public interface IProductAppServices
{
    Task<List<Product>> GetListOfProducts();
    public void AddProducts(string name, int price, int quantity);
}
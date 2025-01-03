using ShopManagement.Domain.Entities;

namespace ShopManagement.AppServices.Contracts;

public interface IProductAppServices
{
    Task<List<Product>> GetListOfProducts();
}
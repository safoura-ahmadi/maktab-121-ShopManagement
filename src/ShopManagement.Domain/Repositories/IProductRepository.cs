using ShopManagement.Domain.Entities;

namespace ShopManagement.Domain.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetProducts();
}
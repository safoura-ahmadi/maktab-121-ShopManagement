using ShopManagement.Domain.Entities;

namespace ShopManagement.Domain.Contracts;

public interface IProductRepository
{
    Task<List<Product>> GetProducts();
    Product GetProductDetails(int productId);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="price"></param>
    /// <param name="quantity"></param>
    /// <returns>ProductId</returns>
    public int AddProducts(string name, int price, int quantity);
    public void EditProducts(int id , string name, int price, int quantity);
}
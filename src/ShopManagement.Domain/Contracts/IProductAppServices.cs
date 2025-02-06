using ShopManagement.Domain.Entities;

namespace ShopManagement.Domain.Contracts;

public interface IProductAppServices
{
    Task<List<Product>> GetListOfProducts();
    Product GetProductDetails(int productId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="price"></param>
    /// <param name="quantity"></param>
    /// <returns>ProductId</returns>
    public int AddProducts(string name, int price, int quantity, int userId);
    public void EditProducts(int id ,string name, int price, int quantity, int userId);
}
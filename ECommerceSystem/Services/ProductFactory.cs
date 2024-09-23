using ECommerceSystem.Models;

namespace ECommerceSystem.Services
{
    public class ProductFactory
    {
        public Product CreateProduct(int productId, string name, decimal price, int stock)
        {
            return new Product(productId, name, price, stock);
        }
    }
}

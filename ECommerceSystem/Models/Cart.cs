using System.Collections.Generic;

namespace ECommerceSystem.Models
{
    public class Cart
    {
        public List<Product> Products { get; set; }

        public Cart()
        {
            Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }

        public decimal GetTotalPrice()
        {
            decimal total = 0;
            foreach (var product in Products)
            {
                total += product.Price;
            }
            return total;
        }

        public override string ToString()
        {
            return $"Cart has {Products.Count} products.";
        }
    }
}

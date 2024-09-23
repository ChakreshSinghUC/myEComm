using System.Collections.Generic;
using ECommerceSystem.Models;

namespace ECommerceSystem.Services
{
    public class InventoryManager
    {
        private static InventoryManager _instance;
        private Dictionary<int, Product> _inventory;

        private InventoryManager()
        {
            _inventory = new Dictionary<int, Product>();
        }

        // Singleton pattern to ensure only one instance
        public static InventoryManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InventoryManager();
                }
                return _instance;
            }
        }

        public void AddProduct(Product product)
        {
            if (!_inventory.ContainsKey(product.ProductId))
            {
                _inventory.Add(product.ProductId, product);
            }
        }

        public bool IsProductAvailable(int productId, int quantity)
        {
            if (_inventory.ContainsKey(productId) && _inventory[productId].Stock >= quantity)
            {
                return true;
            }
            return false;
        }

        public void ReduceStock(int productId, int quantity)
        {
            if (_inventory.ContainsKey(productId))
            {
                _inventory[productId].Stock -= quantity;
            }
        }

        public bool TryGetProduct(int productId, out Product? product)
        {
            if (_inventory.ContainsKey(productId))
            {
                product = _inventory[productId];
                return true;
            }

            product = null;
            return false;
        }

        public void DisplayInventory()
        {
            foreach (var product in _inventory.Values)
            {
                System.Console.WriteLine(product);
            }
        }
    }
}

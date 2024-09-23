using ECommerceSystem.Models;

namespace ECommerceSystem.Services
{
    public class OrderFactory
    {
        public Order CreateOrder(int orderId, User user, Cart cart)
        {
            return new Order(orderId, user, cart);
        }
    }
}

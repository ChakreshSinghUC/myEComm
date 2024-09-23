using System.Collections.Generic;
using System.Linq;
using ECommerceSystem.Models;

namespace ECommerceSystem.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly List<Order> _orders = new List<Order>();

        public IEnumerable<Order> GetAll()
        {
            return _orders;
        }

        public Order GetById(int id)
        {
            return _orders.FirstOrDefault(o => o.OrderId == id);
        }

        public void Add(Order order)
        {
            _orders.Add(order);
        }

        public void Update(Order order)
        {
            var existingOrder = GetById(order.OrderId);
            if (existingOrder != null)
            {
                existingOrder.OrderStatus = order.OrderStatus;
                existingOrder.TotalAmount = order.TotalAmount;
            }
        }

        public void Remove(int id)
        {
            var order = GetById(id);
            if (order != null)
            {
                _orders.Remove(order);
            }
        }
    }
}

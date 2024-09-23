using ECommerceSystem.Models;

namespace ECommerceSystem.Repositories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly UserRepository _userRepository = new UserRepository();
        private readonly ProductRepository _productRepository = new ProductRepository();
        private readonly OrderRepository _orderRepository = new OrderRepository();

        public IRepository<User> GetUserRepository()
        {
            return _userRepository;
        }

        public IRepository<Product> GetProductRepository()
        {
            return _productRepository;
        }

        public IRepository<Order> GetOrderRepository()
        {
            return _orderRepository;
        }
    }
}

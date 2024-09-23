using ECommerceSystem.Models;

namespace ECommerceSystem.Repositories
{
    public interface IRepositoryFactory
    {
        IRepository<User> GetUserRepository();
        IRepository<Product> GetProductRepository();
        IRepository<Order> GetOrderRepository();
    }
}

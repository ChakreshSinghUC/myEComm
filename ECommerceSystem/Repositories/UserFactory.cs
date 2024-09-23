using ECommerceSystem.Models;

namespace ECommerceSystem.Services
{
    public class UserFactory
    {
        public User CreateUser(int userId, string name, string email)
        {
            return new User(userId, name, email);
        }
    }
}

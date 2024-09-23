using System;
using ECommerceSystem.Models;
using ECommerceSystem.Repositories;
using ECommerceSystem.Services;

namespace ECommerceSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the RepositoryFactory
            RepositoryFactory repositoryFactory = new RepositoryFactory();

            // Get repositories from the factory
            IRepository<User> userRepository = repositoryFactory.GetUserRepository();
            IRepository<Product> productRepository = repositoryFactory.GetProductRepository();
            IRepository<Order> orderRepository = repositoryFactory.GetOrderRepository();

            // Use UserFactory to create a user
            UserFactory userFactory = new UserFactory();
            User user = userFactory.CreateUser(1, "John Doe", "john.doe@example.com");
            userRepository.Add(user);
            Console.WriteLine("User added.");

            // Use the ProductFactory to create products
            ProductFactory productFactory = new ProductFactory();
            Product product1 = productFactory.CreateProduct(1, "Laptop", 999.99m, 10);
            Product product2 = productFactory.CreateProduct(2, "Smartphone", 499.99m, 5);

            // Add products to repository via factory
            productRepository.Add(product1);
            productRepository.Add(product2);
            Console.WriteLine("Products added.");

            // Display products
            Console.WriteLine("Current Products:");
            foreach (var product in productRepository.GetAll())
            {
                Console.WriteLine(product);
            }

            // Create a cart
            Cart cart = new Cart();

            // Add products to cart if available
            Product? productLaptop = productRepository.GetById(1);
            if (productLaptop != null && productLaptop.Stock > 0)
            {
                cart.AddProduct(productLaptop);
            }

            Product? productSmartphone = productRepository.GetById(2);
            if (productSmartphone != null && productSmartphone.Stock > 0)
            {
                cart.AddProduct(productSmartphone);
            }

            Console.WriteLine(cart);

            // Display total price of the cart
            Console.WriteLine($"Total Price: {cart.GetTotalPrice()}");

            // Use OrderFactory to create an order
            OrderFactory orderFactory = new OrderFactory();
            Order order = orderFactory.CreateOrder(1, user, cart);
            orderRepository.Add(order);
            Console.WriteLine("Order added.");

            // Process payment
            Payment payment = new Payment(1, order);
            bool paymentStatus = payment.ProcessPayment();
            Console.WriteLine(payment);

            // Final status
            Console.WriteLine($"Order Final Status: {order.OrderStatus}");

            // Display all orders
            Console.WriteLine("Orders:");
            foreach (var ord in orderRepository.GetAll())
            {
                Console.WriteLine(ord);
            }
        }
    }
}

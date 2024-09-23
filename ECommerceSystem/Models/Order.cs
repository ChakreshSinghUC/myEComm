namespace ECommerceSystem.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public User User { get; set; }
        public Cart Cart { get; set; }
        public string OrderStatus { get; set; }
        public decimal TotalAmount { get; set; }

        public Order(int orderId, User user, Cart cart)
        {
            OrderId = orderId;
            User = user;
            Cart = cart;
            TotalAmount = cart.GetTotalPrice();
            OrderStatus = "Pending";
        }

        public void CompleteOrder()
        {
            OrderStatus = "Completed";
        }

        public override string ToString()
        {
            return $"Order: {OrderId}, Status: {OrderStatus}, Total: {TotalAmount}";
        }
    }
}

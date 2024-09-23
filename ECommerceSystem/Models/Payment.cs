namespace ECommerceSystem.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public Order Order { get; set; }
        public string PaymentStatus { get; set; }

        public Payment(int paymentId, Order order)
        {
            PaymentId = paymentId;
            Order = order;
            PaymentStatus = "Pending";
        }

        public bool ProcessPayment()
        {
            // For simplicity, let's assume the payment always succeeds.
            PaymentStatus = "Completed";
            Order.CompleteOrder();
            return true;
        }

        public override string ToString()
        {
            return $"Payment: {PaymentId}, Status: {PaymentStatus}, Order ID: {Order.OrderId}";
        }
    }
}

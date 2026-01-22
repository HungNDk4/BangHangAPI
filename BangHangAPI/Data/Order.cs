namespace BangHangAPI.Data
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public OrderStatus Status { get; set; }

        public int? UserId { get; set; }   // có thể null (khách vãng lai)
        public User? User { get; set; }

        public decimal TotalAmount { get; set; }

        public string? Note { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new();
    }
}


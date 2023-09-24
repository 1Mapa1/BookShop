namespace OnlineShop.db.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }

        public Product Product { get; set; }

        public Order Order { get; set; }

        public int Count { get; set; }
    }
}

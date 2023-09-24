

namespace OnlineShop.db.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public UserInfo UserInfo { get; set; }
        public string Address { get; set; }
        public string Payment { get; set; }
        public string Receipt { get; set; }
        public DateTime DateTime { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public OrderStatuses Status { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}

using System;

namespace OnlineShopWebApp.Models
{
    public class OrderItemViewModel
    {
        public Guid Id { get; set; }

        public ProductViewModal Product { get; set; }

        public int Count { get; set; }
    }
}

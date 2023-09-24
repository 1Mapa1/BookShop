using System;

namespace OnlineShopWebApp.Models
{
    public class CartItemViewModel
    {
        public Guid Id { get; set; }
        public ProductViewModal Product { get; set; }
        public int Count { get; set; }
    }
}
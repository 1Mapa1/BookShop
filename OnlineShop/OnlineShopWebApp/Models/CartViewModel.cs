using System;
using System.Collections.Generic;


namespace OnlineShopWebApp.Models
{
    public class CartViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }
    }
}

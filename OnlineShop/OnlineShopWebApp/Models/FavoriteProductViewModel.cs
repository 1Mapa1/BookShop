using System;

namespace OnlineShopWebApp.Models
{
    public class FavoriteProductViewModel
    {
        public Guid Id { get; set; }
        public ProductViewModal Product { get; set; }
    }
}

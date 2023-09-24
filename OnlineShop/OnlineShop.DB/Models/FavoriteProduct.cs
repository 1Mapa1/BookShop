

namespace OnlineShop.db.Models
{
    public class FavoriteProduct
    {
        public Guid Id { get; set; }
        public Favorite Favorite { get; set; }
        public Product Product { get; set; }
    }
}

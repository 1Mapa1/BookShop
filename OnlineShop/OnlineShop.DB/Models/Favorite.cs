namespace OnlineShop.db.Models
{
    public class Favorite
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<FavoriteProduct> Products { get; set; }
        public Favorite()
        {
            Products = new List<FavoriteProduct>();
        }
    }
}

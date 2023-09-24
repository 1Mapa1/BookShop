using OnlineShopWebApp.Models;
using System.Diagnostics.CodeAnalysis;

namespace OnlineShop.db.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        [MaybeNull]
        public string ImgPath { get; set; }

        public List<CartItem> CartItems { get; set; }

        public List<Review> Reviews { get; set; }

        public List<FavoriteProduct> FavoriteProducts { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public Product()
        {
            Reviews = new List<Review>();
            CartItems = new List<CartItem>();
            FavoriteProducts = new List<FavoriteProduct>();
            OrderItems = new List<OrderItem>();
        }
        public Product(Guid id, string name, string author, string genre, decimal cost, string description)
        {
            Id = id;
            Name = name;
            Author = author;
            Genre = genre;
            Cost = cost;
            Description= description;
        }
    }
}
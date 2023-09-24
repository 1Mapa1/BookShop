

using Microsoft.EntityFrameworkCore;
using OnlineShop.db;
using OnlineShop.db.Interfaces;
using OnlineShop.db.Models;

namespace OnlineShopWebApp.Models
{
    public class FavoriteStorage : IFavoriteStorage
    {
        private readonly DatabaseContext databaseContext;

        public FavoriteStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public Favorite TryGetByUserId(Guid userId)
        {
            return databaseContext.Favorites.Include(x => x.Products).ThenInclude(x => x.Product).FirstOrDefault(favorite => favorite.UserId == userId);
        }
        public void Add(Product product, Guid userId)
        {
            var existingFavorite = TryGetByUserId(userId);
            if (existingFavorite == null)
            {
                var newFavorite = new Favorite
                {
                    UserId = userId
                };
                newFavorite.Products = new List<FavoriteProduct>
                    {
                        new FavoriteProduct
                        {
                            Product = product,
                            Favorite = newFavorite
                        }
                    };

                databaseContext.Favorites.Add(newFavorite);
            }
            else
            {
                existingFavorite.Products.Add(new FavoriteProduct
                {
                    Product = product,
                    Favorite = existingFavorite
                });
            }
            databaseContext.SaveChanges();
        }
        public void Remove(Product product, Guid userId)
        {
            var existingFavorite = TryGetByUserId(userId);
            var existingProduct = existingFavorite.Products.FirstOrDefault(p => p.Product.Id == product.Id);
            existingFavorite.Products.Remove(existingProduct);
            databaseContext.SaveChanges();
        }
    }
}

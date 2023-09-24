using OnlineShop.db.Models;

namespace OnlineShop.db.Interfaces
{
    public interface IFavoriteStorage
    {
        Favorite TryGetByUserId(Guid userId);
        void Add(Product product, Guid userId);
        void Remove(Product product, Guid userId);
    }
}

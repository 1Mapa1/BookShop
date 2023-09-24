using OnlineShop.db.Models;


namespace OnlineShop.db.Interfaces
{
    public interface ICartStorage
    {
        public Cart TryGetByUserId(Guid userId);
        public void Add(Product product, Guid userId);
        public void Remove(Product product, Guid userId);
        public void Clear(Guid userId);
    }
}

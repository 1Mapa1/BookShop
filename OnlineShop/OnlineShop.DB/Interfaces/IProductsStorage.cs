using OnlineShop.db.Models;

namespace OnlineShop.db.Interfaces
{
    public interface IProductsStorage
    {
        void Remove(Guid productId);
        void Append(Product product);
        List<Product> GetAll();
        Product TryGet(Guid id);
        void Redact(Product product);
    }
}

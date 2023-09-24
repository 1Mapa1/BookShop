

using Microsoft.EntityFrameworkCore;
using OnlineShop.db.Interfaces;
using OnlineShop.db.Models;

namespace OnlineShop.db.Storages
{
    public class ProductsStorage : IProductsStorage
    {
        public readonly DatabaseContext databaseContext;

        public ProductsStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Append(Product product)
        {
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();

        }
        public void Remove(Guid productId)
        {
            databaseContext.Products.Remove(TryGet(productId));
            databaseContext.SaveChanges();
        }
        public void Redact(Product product)
        {
            var redactProduct = databaseContext.Products.FirstOrDefault(p => p.Id == product.Id);
            redactProduct.Name = product.Name;
            redactProduct.Cost = product.Cost;
            redactProduct.Description = product.Description;
            redactProduct.Author = product.Author;
            redactProduct.Genre = product.Genre;
            redactProduct.Reviews = product.Reviews;
            redactProduct.ImgPath = product.ImgPath;
            databaseContext.SaveChanges();
        }
        public List<Product> GetAll()
        {
            return databaseContext.Products.ToList();
        }
        public Product TryGet(Guid id)
        {
            return databaseContext.Products.Include(x => x.Reviews).FirstOrDefault(product => product.Id == id);
        }
    }
}

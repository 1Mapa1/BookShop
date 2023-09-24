using Microsoft.EntityFrameworkCore;
using OnlineShop.db.Interfaces;
using OnlineShop.db.Models;


namespace OnlineShop.db.Storages
{
    public class CartStorage : ICartStorage
    {
        public readonly DatabaseContext databaseContext;

        public CartStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public Cart TryGetByUserId(Guid userId)
        {
            return databaseContext.Carts.Include(x => x.CartItems).ThenInclude(x => x.Product).FirstOrDefault(cart => cart.UserId == userId);
        }
        public void Add(Product product, Guid userId)
        {
            var existingCart = TryGetByUserId(userId);
            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    UserId = userId
                };
                newCart.CartItems = new List<CartItem>
                    {
                        new CartItem
                        {
                            Product = product,
                            Count = 1,
                            Cart = newCart
                        }
                    };

                databaseContext.Carts.Add(newCart);
            }
            else
            {

                var existingCartItem = existingCart.CartItems.FirstOrDefault(item => item.Product.Id == product.Id);
                if (existingCartItem != null)
                {
                    existingCartItem.Count++;
                }
                else
                {
                    existingCart.CartItems.Add(new CartItem
                    {
                        Product = product,
                        Count = 1,
                        Cart = existingCart
                    });
                }
            }
            databaseContext.SaveChanges();
        }
        public void Remove(Product product, Guid userId)
        {
            var existingCart = TryGetByUserId(userId);
            var existingCartItem = existingCart.CartItems.FirstOrDefault(item => item.Product.Id == product.Id);
            if (existingCartItem.Count == 1)
            {
                existingCart.CartItems.Remove(existingCartItem);
            }
            else
            {
                existingCartItem.Count--;
            }
            databaseContext.SaveChanges();
        }
        public void Clear(Guid userId)
        {
            var existingCart = TryGetByUserId(userId);
            databaseContext.Carts.Remove(existingCart);
            databaseContext.SaveChanges();
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.db.Interfaces;
using OnlineShop.db.Models;
using System;
using System.Linq;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{
    public class Cart : ViewComponent
    {
        private readonly ICartStorage cartStorage;
        private readonly UserManager<User> userManager;

        public Cart(ICartStorage cartStorage, UserManager<User> userManager)
        {
            this.cartStorage = cartStorage;
            this.userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            int productCount = 0;
            if (User.Identity.IsAuthenticated)
            {
                var cart = cartStorage.TryGetByUserId(Guid.Parse(userManager.FindByNameAsync(User.Identity.Name).Result.Id));
                if (cart != null)
                {
                    productCount = cart.CartItems.Sum(p => p.Count);
                }
            }

            return View("Cart", productCount);
        }
    }
}

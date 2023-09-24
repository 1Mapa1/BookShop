using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using OnlineShop.db.Interfaces;
using OnlineShop.db.Models;
using OnlineShopWebApp.Interfaces;
using System;
using System.Linq;

namespace OnlineShopWebApp.Views.Shared.Components.ButtonCart
{
    [Authorize]
    public class ButtonCart : ViewComponent
    {
        private readonly ICartStorage cartStorage;
        private readonly UserManager<User> userManager;

        public ButtonCart(ICartStorage cartStorage, UserManager<User> userManager)
        {
            this.cartStorage = cartStorage;
            this.userManager = userManager;
        }

        public IViewComponentResult Invoke(Guid productId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var item = cartStorage.TryGetByUserId(Guid.Parse(userManager.FindByNameAsync(User.Identity.Name).Result.Id))?
                    .CartItems.FirstOrDefault(p => p.Product.Id == productId);
                if (item != null)
                {
                    return View("InCart");
                }
            }
            
            return View("OutCart", productId);
           
            
        }
    }
}

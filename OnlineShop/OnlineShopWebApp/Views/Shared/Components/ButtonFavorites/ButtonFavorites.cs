using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.db.Interfaces;
using OnlineShop.db.Models;
using System;
using System.Linq;

namespace OnlineShopWebApp.Views.Shared.Components.ButtonFavorites
{
    public class ButtonFavorites : ViewComponent
    {
        private readonly IFavoriteStorage favoriteStorage;
        private readonly UserManager<User> userManager;

        public ButtonFavorites(IFavoriteStorage favoriteStorage, UserManager<User> userManager)
        {
            this.favoriteStorage = favoriteStorage;
            this.userManager = userManager;
        }

        public IViewComponentResult Invoke(Guid productId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var item = favoriteStorage.TryGetByUserId(Guid.Parse(userManager.FindByNameAsync(User.Identity.Name).Result.Id))?
                    .Products.FirstOrDefault(p => p.Product.Id == productId);
                if (item != null)
                {
                    return View("InFavorites");
                }
            }
            return View("OutFavorites", productId);
        }
    }
}

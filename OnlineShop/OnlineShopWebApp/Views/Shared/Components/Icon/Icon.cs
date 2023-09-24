using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShop.db.Models;
using System;

namespace OnlineShopWebApp.Views.Shared.Components.Icon
{
    public class Icon : ViewComponent
    {
        private readonly UserManager<User> userManager;
        private readonly IMemoryCache memoryCache;

        public Icon(UserManager<User> userManager, IMemoryCache memoryCache)
        {
            this.userManager = userManager;
            this.memoryCache = memoryCache;
        }
        public IViewComponentResult Invoke() 
        { 
            var userName = User.Identity.Name;
            if (userName != null) 
            {
                string userImg = null;
                if (!memoryCache.TryGetValue(userName, out userImg))
                {
                    userImg = userManager.FindByNameAsync(User.Identity.Name).Result.ImgPath;
                    var user = userManager.FindByNameAsync(userName).Result;
                    memoryCache.Set(userName, userImg,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(30)));
                }
                return View("Icon", userImg);
            }
            return null;
        }
    }
}

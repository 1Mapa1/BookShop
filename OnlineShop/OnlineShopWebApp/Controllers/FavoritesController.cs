using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.db.Interfaces;
using OnlineShop.db.Models;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class FavoritesController : Controller
    {
        private readonly IFavoriteStorage favoriteStorage;
        private readonly IProductsStorage productsStorage;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public FavoritesController(IFavoriteStorage favoriteStorage, IProductsStorage productsStorage, UserManager<User> userManager, IMapper mapper)
        {
            this.favoriteStorage = favoriteStorage;
            this.productsStorage = productsStorage;
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public IActionResult Index(int optionsRadio)
        {
            ViewBag.Sorting = optionsRadio;
            var favoriteDb = favoriteStorage.TryGetByUserId(Guid.Parse(userManager.FindByNameAsync(User.Identity.Name).Result.Id));
            if (favoriteDb?.Products.Count == 0 || favoriteDb == null)
            {
                return View("Empty");
            }
            return View(mapper.Map<List<FavoriteProductViewModel>>(favoriteDb.Products));
        }
        public IActionResult AddProduct(Guid productId)
        {
            var product = productsStorage.TryGet(productId);
            var userId = Guid.Parse(userManager.FindByNameAsync(User.Identity.Name).Result.Id);
            if (favoriteStorage.TryGetByUserId(userId).Products.FirstOrDefault(p => p.Id == productId) == null)
            {
                favoriteStorage.Add(product, userId);
            }
            return RedirectToAction("Index", "Favorites");
        }
        public IActionResult RemoveProduct(Guid productId)
        {
            var product = productsStorage.TryGet(productId);
            
            favoriteStorage.Remove(product, Guid.Parse(userManager.FindByNameAsync(User.Identity.Name).Result.Id));
            return RedirectToAction("Index", "Favorites");
        }
    }
}

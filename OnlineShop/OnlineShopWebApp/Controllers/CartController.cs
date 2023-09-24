using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.db.Interfaces;
using OnlineShop.db.Models;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartStorage cartStorage;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IProductsStorage productsStorage;
        public CartController(IProductsStorage productsStorage, ICartStorage cartStorage, UserManager<User> userManager, IMapper mapper)
        {
            this.productsStorage = productsStorage;
            this.cartStorage = cartStorage;
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var cartDb = cartStorage.TryGetByUserId(Guid.Parse(userManager.FindByNameAsync(User.Identity.Name).Result.Id));
            if(cartDb == null || cartDb.CartItems.Count == 0)
            {
                return View("Empty");
            }
            return View(mapper.Map<List<CartItemViewModel>>(cartDb.CartItems));
        }
        public IActionResult AddProduct(Guid productId)
        {
            var product = productsStorage.TryGet(productId);
            
            cartStorage.Add(product, Guid.Parse(userManager.FindByNameAsync(User.Identity.Name).Result.Id));
            return RedirectToAction("Index", "Cart");
        }
        public IActionResult RemoveProduct(Guid productId)
        {
            var product = productsStorage.TryGet(productId);
            
            cartStorage.Remove(product, Guid.Parse(userManager.FindByNameAsync(User.Identity.Name).Result.Id));
            return RedirectToAction("Index", "Cart");
        }
        public IActionResult Clear()
        {
            cartStorage.Clear(Guid.Parse(userManager.FindByNameAsync(User.Identity.Name).Result.Id));
            return RedirectToAction("Index", "Cart");
        }

    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShop.db;
using OnlineShop.db.Interfaces;
using OnlineShop.db.Models;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsStorage productsStorage;
        private readonly IMapper mapper;
        private readonly IMemoryCache memoryCache;

        public HomeController(IProductsStorage productsStorage, IMapper mapper, IMemoryCache memoryCache)
        {
            this.productsStorage = productsStorage;
            this.mapper = mapper;
            this.memoryCache = memoryCache;
        }
        public IActionResult Index()
        {
            memoryCache.TryGetValue<List<Product>>(Constans.KeyCacheAllProducts, out var products);
            return View(mapper.Map<List<ProductViewModal>>(products));
        }
        public IActionResult SearchProduct(string search)
        {
            var searchProducts = productsStorage.GetAll().Where(p => p.Name.ToLower().Contains(search)).ToList();
            return View(searchProducts);
        }
    }
}

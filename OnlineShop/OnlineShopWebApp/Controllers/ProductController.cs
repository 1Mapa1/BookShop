using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShop.db;
using OnlineShop.db.Interfaces;
using OnlineShop.db.Models;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;


namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsStorage productsStorage;
        private readonly IMapper mapper;
        private readonly IMemoryCache memoryCache;

        public ProductController(IProductsStorage productsStorage, IMapper mapper, IMemoryCache memoryCache)
        {
            this.productsStorage = productsStorage;
            this.mapper = mapper;
            this.memoryCache = memoryCache;
        }

        public IActionResult Index(Guid productId)
        {
            memoryCache.TryGetValue<Product>(productId, out var product);
            return View(mapper.Map<ProductViewModal>(product));
        }
        
        [HttpPost]
        public IActionResult LeaveReview(ReviewViewModel review, Guid productId)
        {
            var product = productsStorage.TryGet(productId);

            product.Reviews.Add(mapper.Map<Review>(review));

            productsStorage.Redact(product);

            return RedirectToAction("Index", "Product", new { productId });
        }
    }
}

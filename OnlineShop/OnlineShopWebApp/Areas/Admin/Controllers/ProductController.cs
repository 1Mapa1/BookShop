using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using OnlineShop.db.Interfaces;
using OnlineShop.db.Models;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Constans.AdminRoleName)]
    public class ProductController : Controller
    {
        private readonly IProductsStorage productsStorage;
        private readonly IWebHostEnvironment appEnvironment;
        private readonly IMapper mapper;

        public ProductController(IProductsStorage productsStorage, IWebHostEnvironment appEnvironment, IMapper mapper)
        {
            this.productsStorage = productsStorage;
            this.appEnvironment = appEnvironment;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var products = productsStorage.GetAll();

            return View(mapper.Map<List<ProductViewModal>>(products));
        }
        [HttpPost]
        public IActionResult Add(ProductViewModal product)
        {
            if (ModelState.IsValid)
            {
                string productImgPath = Path.Combine(appEnvironment.WebRootPath + "/images/products/");
                if (!Directory.Exists(productImgPath)) 
                { 
                    Directory.CreateDirectory(productImgPath);
                }

                var fileName = Guid.NewGuid() + "." + product.UploadedFile.FileName.Split('.').Last();
                using (var fileStream = new FileStream(productImgPath + fileName, FileMode.Create))
                {
                    product.UploadedFile.CopyTo(fileStream);
                }
                product.ImgPath = "/images/products/" + fileName;
                productsStorage.Append(mapper.Map<Product>(product));
            }
            
            return RedirectToAction("Index", "Product");
        }
        public IActionResult Remove(Guid productId)
        {
            productsStorage.Remove(productId);
            return RedirectToAction("Index", "Product");
        }
        [HttpPost]
        public IActionResult Redact(ProductViewModal product)
        {
            if (ModelState.IsValid)
            {
                if(product.UploadedFile != null)
                {
                    string productImgPath = Path.Combine(appEnvironment.WebRootPath + "/images/products/");
                    var fileName = Guid.NewGuid() + "." + product.UploadedFile.FileName.Split('.').Last();
                    if (System.IO.File.Exists(fileName))
                    {
                        System.IO.File.Delete(appEnvironment.WebRootPath + product.ImgPath);
                    }
                    using (var fileStream = new FileStream(productImgPath + fileName, FileMode.Create))
                    {
                        product.UploadedFile.CopyTo(fileStream);
                    }
                    product.ImgPath = "/images/products/" + fileName;
                }
                productsStorage.Redact(mapper.Map<Product>(product));
            }
            return View("Index", mapper.Map<List<ProductViewModal>>(productsStorage.GetAll()));
        }
    }
}

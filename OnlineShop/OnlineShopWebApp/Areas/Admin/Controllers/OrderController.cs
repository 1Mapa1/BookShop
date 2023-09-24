using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.db.Interfaces;
using OnlineShop.db.Models;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderStorage orderStorage;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public OrderController(IOrderStorage orderStorage, UserManager<User> userManager, IMapper mapper)
        {
            this.orderStorage = orderStorage;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var b = orderStorage.GetAll();
            var a = mapper.Map<List<OrderViewModel>>(orderStorage.GetAll());
            return View(mapper.Map<List<OrderViewModel>>(orderStorage.GetAll()));
        }
        public IActionResult Show(Guid orderID)
        {
            var order = orderStorage.GetAll().FirstOrDefault(order => order.Id == orderID);
            return View(mapper.Map<OrderViewModel>(order));
        }
        public IActionResult SaveStatus(Guid orderId, int codeStatus)
        {
            if (codeStatus != 0)
            {
                orderStorage.ChangeStatus(orderId, codeStatus);
            }
            return RedirectToAction("Show", new { orderID = orderId });
        }
    }
}
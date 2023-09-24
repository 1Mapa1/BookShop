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
    public class OrderingController : Controller
    {
        private readonly ICartStorage cartStorage;
        private readonly IOrderStorage orderStorage;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public OrderingController(ICartStorage cartStorage, IOrderStorage orderStorage, UserManager<User> userManager, IMapper mapper)
        {
            this.cartStorage = cartStorage;
            this.orderStorage = orderStorage;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public IActionResult Index(OrderViewModel order)
        {
            var userNow = userManager.FindByNameAsync(User.Identity.Name).Result;
            order.OrderItems = mapper.Map<List<OrderItemViewModel>>(cartStorage.TryGetByUserId(Guid.Parse(userNow.Id)).CartItems);
            order.UserInfo = new UserInfoViewModel();
            order.UserInfo.LastName = userNow.LastName;
            order.UserInfo.FirstName = userNow.FirstName;
            order.UserInfo.PhoneNumber = userNow.PhoneNumber;
            order.UserInfo.Email = userNow.Email;
            return View(order);
        }
        
        [HttpPost]
        public IActionResult Save(OrderViewModel order)
        {
            var redact = userManager.FindByNameAsync(User.Identity.Name).Result;
            redact.Email = order.UserInfo.Email;
            redact.PhoneNumber = order.UserInfo.PhoneNumber;
            redact.FirstName = order.UserInfo.FirstName;
            redact.LastName = order.UserInfo.LastName;
            userManager.UpdateAsync(redact).Wait();
            order.OrderItems = mapper.Map<List<OrderItemViewModel>>(cartStorage.TryGetByUserId(Guid.Parse(redact.Id)).CartItems);
            order.UserId = Guid.Parse(redact.Id);
            orderStorage.Append(mapper.Map<Order>(order));
            cartStorage.Clear(Guid.Parse(redact.Id));
            return View();
        }
    }
}

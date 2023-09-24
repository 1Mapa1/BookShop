using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.db.Interfaces;
using OnlineShop.db.Models;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Views.Shared.Components.OrderList
{
    public class OrderList : ViewComponent
    {
        private readonly IOrderStorage orderStorage;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public OrderList(IOrderStorage orderStorage, UserManager<User> userManager, IMapper mapper)
        {
            this.orderStorage = orderStorage;
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var ordersUser = orderStorage.TryGetByUserId(Guid.Parse(userManager.FindByNameAsync(User.Identity.Name).Result.Id));
            if(ordersUser.Count == 0) 
            { 
                return View("Empty");
            }
            return View("OrderList", mapper.Map<List<OrderProfile>>(ordersUser)); 
        }
    }
}

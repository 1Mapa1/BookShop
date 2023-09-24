
using OnlineShop.db.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public UserInfoViewModel UserInfo { get; set; }
        public string Receipt { get; set; }
        public string Address { get; set; }
        public string Payment { get; set; }

        public DateTime DateTime { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }

        public OrderStatuses Status { get; set; }
    }
}

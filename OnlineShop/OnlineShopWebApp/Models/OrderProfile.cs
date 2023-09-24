using OnlineShop.db.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace OnlineShopWebApp.Models
{
    public class OrderProfile
    {
        public Guid Id { get; set; }

        public DateTime DateTime { get; set; }

        public List<OrderItemViewModel> OrderItems { get; set; }

        public OrderStatuses Status { get; set; }
    }
}

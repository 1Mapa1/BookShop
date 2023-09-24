using Microsoft.EntityFrameworkCore;
using OnlineShop.db.Interfaces;
using OnlineShop.db.Models;

namespace OnlineShop.db.Storages
{
    public class OrderStorage : IOrderStorage
    {
        private readonly DatabaseContext databaseContext;
        private readonly IProductsStorage productsStorage;

        public OrderStorage(DatabaseContext databaseContext, IProductsStorage productsStorage)
        {
            this.databaseContext = databaseContext;
            this.productsStorage = productsStorage;
        }
        public void Append(Order order)
        {
            foreach (var orderItem in order.OrderItems)
            {
                orderItem.Order = order;
                orderItem.Product = productsStorage.TryGet(orderItem.Product.Id);
            }
            databaseContext.Orders.Add(order);
            databaseContext.SaveChanges();
        }
        public void ChangeStatus(Guid orderID, int status)
        {
            var redactOrder = databaseContext.Orders.FirstOrDefault(o => o.Id == orderID);
            redactOrder.Status = (OrderStatuses)status;
            databaseContext.SaveChanges();

        }
        public List<Order> GetAll()
        {
            return databaseContext.Orders.Include(x => x.OrderItems).ThenInclude(x => x.Product).Include(x => x.UserInfo).ToList();
        }
        public List<Order> TryGetByUserId(Guid userId)
        {
            return databaseContext.Orders.Include(x => x.OrderItems).ThenInclude(x => x.Product)?.Where(user => user.UserId == userId).ToList() ;
        }
    }
}

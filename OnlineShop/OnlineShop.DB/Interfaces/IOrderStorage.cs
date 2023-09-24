using OnlineShop.db.Models;

namespace OnlineShop.db.Interfaces
{
    public interface IOrderStorage
    {
        public List<Order> GetAll();
        public void Append(Order order);
        public void ChangeStatus(Guid orderID, int status);
        public List<Order> TryGetByUserId(Guid userId);
    }
}

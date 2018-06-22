using MultiflexersShop.Models.Entities;

namespace MultiflexersShop.Models.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}

using MultiflexersShop.Models.Data;
using MultiflexersShop.Models.Entities;
using MultiflexersShop.Models.Interfaces;
using System;

namespace MultiflexersShop.Models.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly ShoppingCart shoppingCart;

        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            this.appDbContext = appDbContext;
            this.shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            appDbContext.Orders.Add(order);

            var shoppingCartItems = shoppingCart.ShoppingCartItems;

            foreach(var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = item.Amount,
                    DeviceId = item.Device.DeviceId,
                    OrderId = order.OrderId,
                    Price = item.Device.Price
                };

                appDbContext.OrderDetails.Add(orderDetail);
            }

            appDbContext.SaveChanges();
        }
    }
}

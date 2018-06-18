using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopNetCore2.Models.Data;
using WebShopNetCore2.Models.Entities;
using WebShopNetCore2.Models.Interfaces;

namespace WebShopNetCore2.Models.Repositories
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
            foreach (var item in shoppingCartItems)
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

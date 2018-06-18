using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopNetCore2.Models.Entities;

namespace WebShopNetCore2.Models.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}

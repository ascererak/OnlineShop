using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopNetCore2.Models.Entities
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int DeviceId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public virtual Device Device { get; set; }
        public virtual Order Order { get; set; }
    }
}

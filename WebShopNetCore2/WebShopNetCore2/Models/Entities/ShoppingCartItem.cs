using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShopNetCore2.Models.Entities
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Device Device { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}

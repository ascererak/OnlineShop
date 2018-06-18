using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopNetCore2.Models.Entities;

namespace WebShopNetCore2.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}

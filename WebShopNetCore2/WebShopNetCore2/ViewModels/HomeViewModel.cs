using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopNetCore2.Models.Entities;

namespace WebShopNetCore2.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Device> PopularDevices { get; set; }
    }
}

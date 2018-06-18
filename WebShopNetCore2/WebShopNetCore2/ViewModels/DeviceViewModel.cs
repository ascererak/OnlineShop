using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopNetCore2.Models.Entities;

namespace WebShopNetCore2.ViewModels
{
    public class DeviceViewModel
    {
        public string Title { get; set; }
        public List<Device> Devices { get; set; }
        public string CurrentCategory { get; set; }
    }
}

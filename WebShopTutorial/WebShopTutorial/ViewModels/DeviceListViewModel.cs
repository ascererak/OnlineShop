using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopTutorial.Data.Models;

namespace WebShopTutorial.ViewModels
{
    public class DeviceListViewModel
    {
        public IEnumerable<Device> Devices { get; set; }
        public string CurrentCategory { get; set; }
    }
}

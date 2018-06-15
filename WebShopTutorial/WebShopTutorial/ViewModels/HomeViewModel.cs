using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopTutorial.Data.Models;

namespace WebShopTutorial.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Device> PopularDevices { get; set; }
    }
}

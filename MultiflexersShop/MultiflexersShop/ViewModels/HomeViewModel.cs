using MultiflexersShop.Models.Entities;
using System.Collections.Generic;

namespace MultiflexersShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Device> PopularDevices { get; set; }
    }
}

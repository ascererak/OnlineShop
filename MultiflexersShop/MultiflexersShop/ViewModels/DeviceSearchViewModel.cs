using MultiflexersShop.Models.Entities;
using System.Collections.Generic;

namespace MultiflexersShop.ViewModels
{
    public class DeviceSearchViewModel
    {
        public IEnumerable<Device> Devices { get; set; }
        public string SearchString { get; set; }
    }
}

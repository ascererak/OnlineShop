using MultiflexersShop.Models.Entities;
using System.Collections.Generic;

namespace MultiflexersShop.ViewModels
{
    public class DeviceViewModel
    {
        public string Title { get; set; }
        public List<Device> Devices { get; set; }
        public string CurrentCategory { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShopNetCore2.Models.Entities;
using WebShopNetCore2.Models.Interfaces;
using WebShopNetCore2.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebShopNetCore2.Controllers
{
    [Route("api/[controller]")]
    public class DeviceDataController : Controller
    {
        private readonly IDeviceRepository deviceRepository;

        public DeviceDataController(IDeviceRepository deviceRepository)
        {
            this.deviceRepository = deviceRepository;
        }

        [HttpGet]
        public IEnumerable<DeviceDataViewModel> LoadMoreDevices()
        {
            IEnumerable<Device> dbDevices = null;

            dbDevices = deviceRepository.Devices.OrderBy(p => p.DeviceId).Take(10);

            List<DeviceDataViewModel> devices = new List<DeviceDataViewModel>();

            foreach (var dbDevice in dbDevices)
            {
                devices.Add(MapDbDeviceToDeviceDataViewModel(dbDevice));
            }

            return devices;
        }

        private DeviceDataViewModel MapDbDeviceToDeviceDataViewModel(Device device)
        {
            return new DeviceDataViewModel()
            {
                DeviceId = device.DeviceId,
                Name = device.Name,
                Price = device.Price,
                ShortDescription = device.ShortDescription,
                ImageThumbnailUrl = device.ImageThumbnailUrl
            };
        }
    }
}

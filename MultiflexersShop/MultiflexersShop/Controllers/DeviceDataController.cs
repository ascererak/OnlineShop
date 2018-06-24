using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MultiflexersShop.Models.Entities;
using MultiflexersShop.Models.Interfaces;
using MultiflexersShop.ViewModels;

namespace MultiflexersShop.Controllers
{
    [Route("api/[controller]")]
    public class DeviceDataController : Controller
    {
        private readonly IDeviceRepository deviceRepository;

        public DeviceDataController(IDeviceRepository deviceRepository)
        {
            this.deviceRepository = deviceRepository;
        }

        [HttpGet("{id?}")]
        public IActionResult GetDevices(int id)
        {
            IEnumerable<Device> dbDevices = null;

            dbDevices = deviceRepository.Devices.OrderBy(p => p.DeviceId);

            List<DeviceDataViewModel> devices = new List<DeviceDataViewModel>();

            foreach (var dbDevice in dbDevices)
            {
                devices.Add(MapDbDeviceToDeviceDataViewModel(dbDevice));
            }

            if (id == 0)
            {
                return Ok(devices);
            }
            else
            {
                var device = devices.SingleOrDefault(s => s.DeviceId == id);
                return Ok(device);
            }
        }

        [HttpPost]
        public IActionResult GetSorted([FromBody]string parameter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<Device> dbDevices = null;

            dbDevices = deviceRepository.Devices;
            List<DeviceDataViewModel> devices = new List<DeviceDataViewModel>();

            foreach (var dbDevice in dbDevices)
            {
                devices.Add(MapDbDeviceToDeviceDataViewModel(dbDevice));
            }

            switch (parameter.ToLower())
            {
                case "expensive":
                    return Ok(devices.OrderByDescending(s => s.Price).ToList());
                case "cheap":
                    return Ok(devices.OrderBy(s => s.Price));
                case "popular":
                    return Ok(devices.OrderByDescending(s => s.Bought));
                case "new":
                    return Ok(devices.OrderByDescending(s => s.AddDate));
                case "promotional":
                    return Ok(devices.OrderByDescending(s => s.Promotional));
                default:
                    return Ok(devices.OrderBy(s => s.DeviceId));
            }
        }

        private DeviceDataViewModel MapDbDeviceToDeviceDataViewModel(Device device)
        {
            return new DeviceDataViewModel()
            {
                DeviceId = device.DeviceId,
                Name = device.Name,
                Price = device.Price,
                ShortDescription = device.ShortDescription,
                LongDescription = device.LongDescription,
                ImageThumbnailUrl = device.ImageThumbnailUrl,
                ImageUrl = device.ImageUrl,
                InStok = device.InStok,
                IsPopular = device.IsPopular,
                Bought = device.Bought,
                CategoryId = device.CategoryId,
                Promotional = device.Promotional
            };
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiflexersShop.Models.Entities;
using MultiflexersShop.Models.Interfaces;
using MultiflexersShop.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiflexersShop.Controllers
{
    public class DeviceController : Controller
    {
        private readonly IDeviceRepository deviceRepository;
        private readonly ICategoryRepository categoryRepository;

        public DeviceController(IDeviceRepository deviceRepository, ICategoryRepository categoryRepository)
        {
            this.deviceRepository = deviceRepository;
            this.categoryRepository = categoryRepository;
        }

        public IActionResult List(string category)
        {
            IEnumerable<Device> devices;
            string currentCategory = string.Empty;
            if (string.IsNullOrEmpty(category))
            {
                devices = deviceRepository.Devices.OrderBy(n => n.DeviceId);
                currentCategory = "All devices";
            }
            else
            {
                switch (category)
                {
                    case "Smartphones":
                        devices = deviceRepository.Devices.Where(n => n.Category.CategoryName.Equals("Smartphones")).OrderBy(n => n.DeviceId);
                        break;
                    case "Tablets":
                        devices = deviceRepository.Devices.Where(n => n.Category.CategoryName.Equals("Tablets")).OrderBy(n => n.DeviceId);
                        break;
                    case "Laptops":
                        devices = deviceRepository.Devices.Where(n => n.Category.CategoryName.Equals("Laptops")).OrderBy(n => n.DeviceId);
                        break;
                    case "Wearable Technology":
                        devices = deviceRepository.Devices.Where(n => n.Category.CategoryName.Equals("Wearable Technology")).OrderBy(n => n.DeviceId);
                        break;
                    case "Game consoles":
                        devices = deviceRepository.Devices.Where(n => n.Category.CategoryName.Equals("Game consoles")).OrderBy(n => n.DeviceId);
                        break;
                    default:
                        devices = new List<Device>();
                        break;
                }
                currentCategory = category;
            }

            var deviceViewModel = new DeviceViewModel
            {
                Devices = devices.ToList(),
                CurrentCategory = currentCategory
            };

            return View(deviceViewModel);
        }

        public IActionResult Details(int DeviceId)
        {
            Device device = deviceRepository.GetDeviceById(DeviceId);
            return View(device);
        }

        public IActionResult Search(string searchString)
        {
            var devices = deviceRepository.Devices;

            if (!string.IsNullOrEmpty(searchString))
            {
                devices = devices.Where(s => s.Name.ToLower().Contains(searchString.ToLower()));
            }

            DeviceSearchViewModel deviceSearchViewModel = new DeviceSearchViewModel
            {
                Devices = devices,
                SearchString = searchString
            };

            return View(deviceSearchViewModel);
        }
    }
}

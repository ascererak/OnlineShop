using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopTutorial.Data.Interfaces;
using WebShopTutorial.Data.Models;
using WebShopTutorial.ViewModels;

namespace WebShopTutorial.Controllers
{
    public class DeviceController : Controller
    {
        private readonly IDeviceRepository deviceRepository;
        private readonly ICategoryRepository categoryRepository;

        public DeviceController(ICategoryRepository categoryRepository, IDeviceRepository deviceRepository)
        {
            this.categoryRepository = categoryRepository;
            this.deviceRepository = deviceRepository;
        }

        public ViewResult Index(string category)
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

            var deviceListViewModel = new DeviceListViewModel
            {
                Devices = devices,
                CurrentCategory = currentCategory
            };

            return View(deviceListViewModel);

            //DeviceListViewModel vm = new DeviceListViewModel();
            //vm.Devices = deviceRepository.Devices;
            //vm.CurrentCategory = "Smartphones";

            //return View(vm);
        }
    }
}

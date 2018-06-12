using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShopTutorial.Data.Interfaces;
using WebShopTutorial.ViewModels;

namespace WebShopTutorial.Controllers
{
    public class DeviceController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IDeviceRepository deviceRepository;

        public DeviceController(ICategoryRepository categoryRepository, IDeviceRepository deviceRepository)
        {
            this.categoryRepository = categoryRepository;
            this.deviceRepository = deviceRepository;
        }

        public ViewResult Index()
        {
            

            DeviceListViewModel vm = new DeviceListViewModel();
            vm.Devices = deviceRepository.Devices;
            vm.CurrentCategory = "DeviceCategory";

            return View(vm);
        }
    }
}
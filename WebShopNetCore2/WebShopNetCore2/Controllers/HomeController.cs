using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShopNetCore2.Models.Interfaces;
using WebShopNetCore2.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebShopNetCore2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDeviceRepository deviceRepository;
        public HomeController(IDeviceRepository deviceRepository)
        {
            this.deviceRepository = deviceRepository;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel { PopularDevices = deviceRepository.PopularDevices };

            return View(homeViewModel);
        }
    }
}

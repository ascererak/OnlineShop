using Microsoft.AspNetCore.Mvc;
using MultiflexersShop.Models.Interfaces;
using MultiflexersShop.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiflexersShop.Controllers
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

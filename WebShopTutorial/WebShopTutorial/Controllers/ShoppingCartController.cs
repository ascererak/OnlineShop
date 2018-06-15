using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShopTutorial.Data.Interfaces;
using WebShopTutorial.Data.Models;
using WebShopTutorial.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebShopTutorial.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IDeviceRepository deviceRepository;
        private readonly ShoppingCart shoppingCart;

        public ShoppingCartController(IDeviceRepository deviceRepository, ShoppingCart shoppingCart)
        {
            this.deviceRepository = deviceRepository;
            this.shoppingCart = shoppingCart;
        }

        public ViewResult Cart()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;

            var sCVM = new ShoppingCartViewModel
            {
                ShoppingCart = shoppingCart,
                ShoppingCartTotal = shoppingCart.GetShoppingCartTotal()
            };

            return View(sCVM);
        }

        public RedirectToActionResult AddToShoppingCart(int deviceId)
        {
            var selectedDevice = deviceRepository.Devices.FirstOrDefault(p => p.DeviceId == deviceId);

            if (selectedDevice != null)
            {
                shoppingCart.AddToCart(selectedDevice, 1);
            }

            return RedirectToAction("Cart");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int deviceId)
        {
            var selectedDevice = deviceRepository.Devices.FirstOrDefault(p => p.DeviceId == deviceId);

            if (selectedDevice != null)
            {
                shoppingCart.RemoveFromCart(selectedDevice);
            }

            return RedirectToAction("Cart");
        }
    }
}

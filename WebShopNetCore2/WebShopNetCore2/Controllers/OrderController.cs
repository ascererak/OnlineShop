﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShopNetCore2.Models.Entities;
using WebShopNetCore2.Models.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebShopNetCore2.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly ShoppingCart shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            this.orderRepository = orderRepository;
            this.shoppingCart = shoppingCart;
        }

        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Checkout(Order order)
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;

            if (shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some devices first");
            }

            if (ModelState.IsValid)
            {
                orderRepository.CreateOrder(order);
                shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order!";
            return View();
        }
    }
}

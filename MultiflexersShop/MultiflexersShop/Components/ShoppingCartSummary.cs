using Microsoft.AspNetCore.Mvc;
using MultiflexersShop.Models.Entities;
using MultiflexersShop.ViewModels;

namespace MultiflexersShop.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private ShoppingCart shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;

            var shopingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = shoppingCart,
                ShoppingCartTotal = shoppingCart.GetShoppingCartTotal()
            };

            return View(shopingCartViewModel);
        }
    }
}

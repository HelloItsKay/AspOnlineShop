namespace ASP.NET_Core_OnlineShop.Controllers
{
    using System.Linq;
    using ASP.NET_Core_OnlineShop.Data;
    using ASP.NET_Core_OnlineShop.Models.ShoppingCart;
    using ASP.NET_Core_OnlineShop.Services.ShoppingCart;
    using Microsoft.AspNetCore.Mvc;

    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService shopingCart;
        public ShoppingCartController( IShoppingCartService shopingCart)
        {
            this.shopingCart = shopingCart;

        }

        public IActionResult MyCart()
        {
            var items = shopingCart.GetShoppingCartItems();
            shopingCart.ModelAppropriation(items);


            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = shopingCart.GiveCartToView(),
                ShoppingCartTotal = shopingCart.GetShoppingCartTotal()
            };


            return View(shoppingCartViewModel);
        }

        public IActionResult AddToShoppingCart(string drinkId)
        {
            var selectedDrink = shopingCart.SelectedDrink(drinkId);
            if (selectedDrink != null)
            {
                shopingCart.AddToCart(selectedDrink, 1);
            }


            return RedirectToAction("MyCart");
        }

        public IActionResult RemoveFromShoppingCart(string drinkId)
        {
            var selectedDrink = shopingCart.SelectedDrink(drinkId);
            if (selectedDrink != null)
            {
                shopingCart.RemoveFromCart(selectedDrink);
            }



            return RedirectToAction("MyCart");
        }
    }
}

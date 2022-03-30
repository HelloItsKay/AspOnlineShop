using System;
using System.Collections.Generic;
using ASP.NET_Core_OnlineShop.Data.Models;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Data;
using ASP.NET_Core_OnlineShop.Models.ShoppingCart;
using ASP.NET_Core_OnlineShop.Services.ShoppingCart;
//using ASP.NET_Core_OnlineShop.Services.ShoppingCart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_OnlineShop.Controllers
{
    public class ShoppingCartController:Controller
    {
        private readonly OnlineShopDbContext data;
        //private readonly ShoppingCart shopingCart;
        private readonly IShoppingCartService shopingCart;
        public ShoppingCartController(OnlineShopDbContext data, IShoppingCartService shopingCart)
        {
            this.data = data;
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
            var selectedDrink = data.Drinks.FirstOrDefault(p => p.Id == drinkId);
            if (selectedDrink != null)
            {
                shopingCart.AddToCart(selectedDrink, 1);
            }


            return RedirectToAction("MyCart");
        }

        public IActionResult RemoveFromShoppingCart(string drinkId)
        {
            var selectedDrink = data.Drinks.FirstOrDefault(p => p.Id == drinkId);
            if (selectedDrink != null)
            {
                shopingCart.RemoveFromCart(selectedDrink);
            }



            return RedirectToAction("MyCart");
        }
    }
}

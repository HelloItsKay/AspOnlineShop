using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Controllers;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Test.Mocks;
using Xunit;

namespace OnlineShop.Test.Controllers
{
   public class ShoppingCartControllerTest
    {
        [Fact]
        public void CheckoutCompleteShouldReturnView()
        {
            var cart = MockShopingCartService.Instance;
            var controller = new ShoppingCartController(cart);

            var result = controller.MyCart();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void AddToCartShouldReturnVeiw()
        {
            var cart = MockShopingCartService.Instance;
            var controller = new ShoppingCartController(cart);

            var result = controller.AddToShoppingCart("test");
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void RemoveFromShoppingCart()
        {
            var cart = MockShopingCartService.Instance;
            var controller = new ShoppingCartController(cart);

            var result = controller.RemoveFromShoppingCart("test");
            Assert.IsType<RedirectToActionResult>(result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Controllers;
using ASP.NET_Core_OnlineShop.Data.Models;
using ASP.NET_Core_OnlineShop.Services.Drinks;
using ASP.NET_Core_OnlineShop.Services.Orders;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Test.Mocks;
using Xunit;

namespace OnlineShop.Test.Controllers
{
   public class OrdersControllerTest
    {
        [Fact]
        public void EmptyCartShouldReturnBadRequest()
        {
             var orderService  = MockOrderService.Instance;

            var cart = MockShopingCartService.Instance;
            var hash=MockHashingService.HomeServiceMoc.Instance;
            var controller = new OrderController(orderService,cart,hash);

            var result = controller.EmptyCart();
            Assert.IsType<BadRequestResult>(result);
        }


        [Fact]
        public void MyOrdersShouldReturnView()
        {
            var orderService = MockOrderService.Instance;

            var cart = MockShopingCartService.Instance;
            var hash = MockHashingService.HomeServiceMoc.Instance;
            var controller = new OrderController(orderService, cart, hash);

            var result = controller.MyOrders("flag");
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void CheckoutCompleteShouldReturnViewBadRequest()
        {
            var orderService = MockOrderService.Instance;

            var cart = MockShopingCartService.Instance;
            var hash = MockHashingService.HomeServiceMoc.Instance;
            var controller = new OrderController(orderService, cart, hash);

            var result = controller.CheckoutComplete();
            Assert.IsType<BadRequestResult>(result);
        }


        [Fact]
        public void CheckoutShouldReturnView()
        {
            var orderService = MockOrderService.Instance;

            var cart = MockShopingCartService.Instance;
            var hash = MockHashingService.HomeServiceMoc.Instance;
            var controller = new OrderController(orderService, cart, hash);

            var result = controller.Checkout();
            Assert.IsType<ViewResult>(result);
        }
    }
}

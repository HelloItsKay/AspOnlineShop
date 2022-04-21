using ASP.NET_Core_OnlineShop.Models.Orders;
using ASP.NET_Core_OnlineShop.Services;

namespace ASP.NET_Core_OnlineShop.Controllers
{
    using System.Collections.Generic;
    using ASP.NET_Core_OnlineShop.Data.Models;
    using ASP.NET_Core_OnlineShop.Services.Orders;
    using ASP.NET_Core_OnlineShop.Services.ShoppingCart;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IShoppingCartService shoppingCartService;
        private readonly IHashingService hashingService;

        public OrderController(IOrderService orderService, IShoppingCartService shoppingCartService, IHashingService hashingService)
        {
            this.orderService = orderService;
            this.shoppingCartService = shoppingCartService;
            this.hashingService = hashingService;
        }

        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Checkout(OrdersFormViewModel order)
        {
            order.Email = User.Identity.Name;
            var items = shoppingCartService.GetShoppingCartItems();
            if (items.Count == 0)
            {
                return RedirectToAction("EmptyCart");
            }

            if (ModelState.IsValid)
            {
                orderService.CreateOrder(order);
                shoppingCartService.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }
        [Authorize]
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order! :) ";
            return View();
        }
        [Authorize]
        public IActionResult MyOrders(string username)
        {
            username = hashingService.Decrypt(username);
            List<string> orderId = orderService.GetMyOrderId(username);

            var myOrders = orderService.MyOrders(orderId);
            return View(myOrders);
        }

        public IActionResult EmptyCart()
        {
            return View();
        }
    }
}

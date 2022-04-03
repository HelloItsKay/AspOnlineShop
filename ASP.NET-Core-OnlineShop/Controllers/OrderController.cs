using System.Collections.Generic;
using ASP.NET_Core_OnlineShop.Data.Models;
using ASP.NET_Core_OnlineShop.Services.Orders;
using ASP.NET_Core_OnlineShop.Services.ShoppingCart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_OnlineShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IShoppingCartService shoppingCartService;

        public OrderController(IOrderService orderService, IShoppingCartService shoppingCartService)
        {
           this. orderService = orderService;
           this. shoppingCartService = shoppingCartService;
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
           // order.Email = User.Identity.Name;
             var items = shoppingCartService.GetShoppingCartItems();
            if (items.Count == 0)
            {
                ModelState.AddModelError("", "Your card is empty, add some drinks first");
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
            List<string> orderId=  orderService.GetMyOrderId(username);

            var myOrders=  orderService.MyOrders(orderId);
            return View(myOrders);
        }

    }
}

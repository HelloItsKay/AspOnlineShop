
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Data.Models;
using ASP.NET_Core_OnlineShop.Services.Orders;
using ASP.NET_Core_OnlineShop.Services.ShoppingCart;

namespace DrinkAndGo.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderRepository;
        private readonly IShoppingCartService _shoppingCart;

        public OrderController(IOrderService orderRepository, IShoppingCartService shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
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
            var items = _shoppingCart.GetShoppingCartItems();
            if (items.Count == 0)
            {
                ModelState.AddModelError("", "Your card is empty, add some drinks first");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order! :) ";
            return View();
        }
    }
}

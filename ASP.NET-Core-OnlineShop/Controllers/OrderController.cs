

namespace ASP.NET_Core_OnlineShop.Controllers
{
    using System.Collections.Generic;
    using ASP.NET_Core_OnlineShop.Data.Models;
    using ASP.NET_Core_OnlineShop.Services.Orders;
    using ASP.NET_Core_OnlineShop.Services.ShoppingCart;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using ASP.NET_Core_OnlineShop.Models.Orders;
    using ASP.NET_Core_OnlineShop.Services;

    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IShoppingCartService shoppingCartService;
        private readonly IHashingService hashingService;
        public static bool flag = false;
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
                flag = true;
                return RedirectToAction("EmptyCart");
            }

            if (ModelState.IsValid)
            {
                flag = true;
                orderService.CreateOrder(order);
                shoppingCartService.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }
        [Authorize]
        public IActionResult CheckoutComplete()
        {
            if (flag.Equals(false))
            {

                return BadRequest();
            }

            flag = false;
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
        [Authorize]
        public IActionResult EmptyCart()
        {
            if (flag.Equals(false))
            {
                return BadRequest();
            }

            flag = false;
            var cartItems = shoppingCartService.GetShoppingCartItems();
            var cartItemsCount = shoppingCartService.CountCartItems(cartItems);

            if (cartItemsCount > 0)
            {
                return Redirect("~/ShoppingCart/MyCart");
            }
            return View();
        }
    }
}

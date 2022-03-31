using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Data;
using ASP.NET_Core_OnlineShop.Data.Models;
using ASP.NET_Core_OnlineShop.Services.ShoppingCart;

namespace ASP.NET_Core_OnlineShop.Services.Orders
{
    public class OrderService : IOrderService
    {
        readonly IShoppingCartService cart;
        private readonly OnlineShopDbContext data;

        public OrderService(IShoppingCartService cart, OnlineShopDbContext data)
        {
            this.cart = cart;
            this.data = data;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            var shoppingCartItems = cart.GetShoppingCartItems();

            foreach (var item in shoppingCartItems)
            {
                order.OrderTotal += item.Drink.Price;
            }

            data.Orders.Add(order);



            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    DrinkId = shoppingCartItem.Drink.Id,
                    OrderId = order.OrderId,
                    Price = shoppingCartItem.Drink.Price
                };

                data.OrderDetails.Add(orderDetail);
            }

            data.SaveChanges();
        }
    }
}

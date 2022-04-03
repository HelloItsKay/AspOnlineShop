using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Data;
using ASP.NET_Core_OnlineShop.Data.Models;
using ASP.NET_Core_OnlineShop.Models;
using ASP.NET_Core_OnlineShop.Models.Drinks;
using ASP.NET_Core_OnlineShop.Models.ShoppingCart;
using ASP.NET_Core_OnlineShop.Services.ShoppingCart;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

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

        public List<string> GetMyOrderId(string Username)
        {
            return data.Orders.Where(x => x.Email == Username).Select(x => x.OrderId).ToList();
        }

        public List<MyOrdersViewModel> MyOrders(List<string> myOrdersId)
        {
            

             return data.OrderDetails.Where(x => myOrdersId.Contains(x.OrderId)).Select(x => new MyOrdersViewModel
            {
                DrinkName = x.Drink.Name,
                Amount = x.Amount,
                Price = x.Price,
                OrderDate = data.Orders.Where(o=>o.OrderId.Contains(x.OrderId)).Select(x=>x.OrderPlaced).FirstOrDefault()

            }).OrderByDescending(x=>x.OrderDate).ToList();


        }
    }
}


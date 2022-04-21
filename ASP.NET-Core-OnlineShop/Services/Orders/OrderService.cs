using ASP.NET_Core_OnlineShop.Models.Orders;

namespace ASP.NET_Core_OnlineShop.Services.Orders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ASP.NET_Core_OnlineShop.Data;
    using ASP.NET_Core_OnlineShop.Data.Models;
    using ASP.NET_Core_OnlineShop.Models;
    using ASP.NET_Core_OnlineShop.Services.ShoppingCart;

    public class OrderService : IOrderService
    {
        readonly IShoppingCartService cart;
        private readonly OnlineShopDbContext data;

        public OrderService(IShoppingCartService cart, OnlineShopDbContext data)
        {
            this.cart = cart;
            this.data = data;
        }
        public void CreateOrder(OrdersFormViewModel order)
        {
            
            var currentOrderTime=DateTime.Now;
            
            var shoppingCartItems = cart.GetShoppingCartItems();

            decimal totalOrder = 0;
            foreach (var item in shoppingCartItems)
            {
                totalOrder += item.Drink.Price;
            }

            var newOrder = new Order()
            {
                OrderId = order.OrderId,
                FirstName = order.FirstName,
                LastName = order.LastName,
                AddressLine1 = order.AddressLine1,
                AddressLine2 = order.AddressLine2,
                ZipCode = order.ZipCode,
                State = order.State,
                Country = order.Country,
                PhoneNumber = order.PhoneNumber,
                Email = order.Email,
                OrderTotal = totalOrder,
                OrderPlaced = currentOrderTime
            };

            data.Orders.Add(newOrder);



            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    
                    Amount = shoppingCartItem.Amount,
                    DrinkId = shoppingCartItem.Drink.Id,
                    OrderId = order.OrderId,
                    Price = shoppingCartItem.Drink.Price,
                    
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
                ImageUrl = x.Drink.ImageThumbnailUrl,
                Category = x.Drink.Category.CategoryName,
                DrinkName = x.Drink.Name,
                Amount = x.Amount,
                Price = (x.Price)*x.Amount,
                OrderDate = data.Orders.Where(o => o.OrderId.Contains(x.OrderId)).Select(x => x.OrderPlaced).FirstOrDefault()

            }).OrderByDescending(x => x.OrderDate).ToList();


        }
    }
}


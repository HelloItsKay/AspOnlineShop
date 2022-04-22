﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Data.Models;
using ASP.NET_Core_OnlineShop.Models;
using ASP.NET_Core_OnlineShop.Models.Drinks;
using ASP.NET_Core_OnlineShop.Models.Orders;
using ASP.NET_Core_OnlineShop.Services.Drinks;
using ASP.NET_Core_OnlineShop.Services.Orders;
using ASP.NET_Core_OnlineShop.Services.ShoppingCart;
using OnlineShop.Test.Mocks;
using Xunit;

namespace OnlineShop.Test.Services
{
  public  static class OrderServiceTest
    {
        [Fact]
        public static void GetMyOrderIdShouldReturnValidResult()
        {
            using var data = DatabaseMock.Instance;
            var cart = MockShopingCartService.Instance;

            data.Orders.Add(new Order()
            {
                OrderId = "1",
                Email = "flag@flag.com"
            });
            data.SaveChanges();

            var orderService = new OrderService(cart,data);
            string username = "flag@flag.com";
            var result=  orderService.GetMyOrderId(username);

            Assert.Equal("1",result.FirstOrDefault());
            Assert.IsType<List<string>>(orderService.GetMyOrderId(username));

        }

        [Fact]
        public static void GetMyOrderIdShouldReturnNothingWhenIdDoesNotExists()
        {
            using var data = DatabaseMock.Instance;
            var cart = MockShopingCartService.Instance;


            data.Orders.Add(new Order()
            {
                OrderId = "1",
                Email = "flag@flag.com"
            });
            data.SaveChanges();

            var orderService = new OrderService(cart, data);
            string username = "flag@flag.com";
            var result = orderService.GetMyOrderId($"flag@asd.com");

            Assert.Equal(0,result.Count);


        }

        [Fact]
        public static void MyOrdersShouldReturnListWithOrders()
        {
            using var data = DatabaseMock.Instance;
            var cart = MockShopingCartService.Instance;

            data.Orders.Add(new Order()
            {
                FirstName = "flag",
                LastName = "flag",
                AddressLine1 = "flag",
                AddressLine2 = "flag",
                Email = "flag",
                Country = "flag",
                ZipCode = "flag",
                OrderId = "flag",

            });
            data.OrderDetails.Add(new OrderDetail()
            {
                Amount = 2,
                OrderId = "flag",
            });
            data.SaveChanges();

            var orderService = new OrderService(cart, data);

            string username = "flag";
            List<string> id = new List<string>();
            id.Add(username);
            var result=   orderService.MyOrders(id);

             Assert.Equal(1,result.Count);
            Assert.IsType<List<MyOrdersViewModel>>(result);
        }

        [Fact]
        public static void MyOrdersShouldReturnEmptyListWhenNotExistingParam()
        {
            using var data = DatabaseMock.Instance;
            var cart = MockShopingCartService.Instance;

            data.Orders.Add(new Order()
            {
                FirstName = "flag",
                LastName = "flag",
                AddressLine1 = "flag",
                AddressLine2 = "flag",
                Email = "flag",
                Country = "flag",
                ZipCode = "flag",
                OrderId = "flag",

            });
            data.OrderDetails.Add(new OrderDetail()
            {
                Amount = 2,
                OrderId = "flag",
            });
            data.SaveChanges();

            var orderService = new OrderService(cart, data);

            string username = "flag";
            List<string> id = new List<string>();
            id.Add(username);
            var result = orderService.MyOrders(null);

            Assert.Equal(0, result.Count);
            Assert.IsType<List<MyOrdersViewModel>>(result);
        }

    }
}

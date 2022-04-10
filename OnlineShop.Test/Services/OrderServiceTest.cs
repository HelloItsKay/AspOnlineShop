using System;
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
        public static void GetMyOrderIdReturnTypeList()
        {
            using var data = DatabaseMock.Instance;
            var cart = MockShopingCartService.Instance;

          

            var orderService = new OrderService(cart,data);

            string username = "test@test.com";
            orderService.GetMyOrderId(username);

            Assert.Equal(0, data.Orders.Count());
            Assert.IsType<List<string>>(orderService.GetMyOrderId(username));

        }
        [Fact]
        public static void GetMyORdersReturnValue1IfthereIsOrder()
        {
            using var data = DatabaseMock.Instance;
            var cart = MockShopingCartService.Instance;

            data.Orders.Add(new Order()
            {
                FirstName = "test",
                LastName = "test",
                AddressLine1 = "test",
                AddressLine2 = "test",
                Email = "test",
                Country = "test",
                ZipCode = "test",

            });
            data.SaveChanges();

            var orderService = new OrderService(cart, data);

            string username = "test";
            orderService.GetMyOrderId(username);

            Assert.Equal(1, data.Orders.Count());
            Assert.IsType<List<string>>(orderService.GetMyOrderId(username));
        }
        [Fact]
        public static void MyOrdersShouldReturnListWithOrders()
        {
            using var data = DatabaseMock.Instance;
            var cart = MockShopingCartService.Instance;

            data.Orders.Add(new Order()
            {
                FirstName = "test",
                LastName = "test",
                AddressLine1 = "test",
                AddressLine2 = "test",
                Email = "test",
                Country = "test",
                ZipCode = "test",
                OrderId = "test",

            });
            data.OrderDetails.Add(new OrderDetail()
            {
                Amount = 2,
                OrderId = "test",
            });
            data.SaveChanges();

            var orderService = new OrderService(cart, data);

            string username = "test";
            List<string> id = new List<string>();
            id.Add(username);


            var mok= data.OrderDetails.Where(x => id.Contains(x.OrderId)).Select(x => new MyOrdersViewModel
            {
                DrinkName = x.Drink.Name,
                Amount = x.Amount,
                Price = x.Price,
                OrderDate = data.Orders.Where(o => o.OrderId.Contains(x.OrderId)).Select(x => x.OrderPlaced).FirstOrDefault()

            }).OrderByDescending(x => x.OrderDate).ToList();
            var result=   orderService.MyOrders(id);

          Assert.Equal(1,result.Count);
            Assert.IsType<List<MyOrdersViewModel>>(result);
        }
    }
}

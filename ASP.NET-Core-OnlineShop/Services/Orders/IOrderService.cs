using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Data.Models;
using ASP.NET_Core_OnlineShop.Models;
using ASP.NET_Core_OnlineShop.Models.Drinks;
using ASP.NET_Core_OnlineShop.Models.ShoppingCart;

namespace ASP.NET_Core_OnlineShop.Services.Orders
{
   public interface IOrderService
   {
       public void CreateOrder(Order order);
       public List<string> GetMyOrderId(string Username);

       public List<MyOrdersViewModel> MyOrders(List<string> idmyOrdersId);



   }
}

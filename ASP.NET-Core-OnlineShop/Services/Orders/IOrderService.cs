using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Data.Models;

namespace ASP.NET_Core_OnlineShop.Services.Orders
{
   public interface IOrderService
   {
       public void CreateOrder(Order order);
   }
}

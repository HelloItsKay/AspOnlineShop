using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Services.Drinks;
using ASP.NET_Core_OnlineShop.Services.Orders;
using Moq;

namespace OnlineShop.Test.Mocks
{
  public static class MockOrderService
    {
        public static IOrderService Instance
        {
            get
            {
                var homeServiceMoq = new Mock<IOrderService>();
                return homeServiceMoq.Object;
            }

        }
    }
}

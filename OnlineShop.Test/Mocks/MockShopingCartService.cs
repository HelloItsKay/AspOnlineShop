using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Services.Drinks;
using ASP.NET_Core_OnlineShop.Services.ShoppingCart;
using Moq;

namespace OnlineShop.Test.Mocks
{
  public  static class MockShopingCartService
    {
        public static IShoppingCartService Instance
        {
            get
            {
                var homeServiceMoq = new Mock<IShoppingCartService>();
                return homeServiceMoq.Object;
            }

        }
    }
}

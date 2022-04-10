using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Services.Drinks;
using ASP.NET_Core_OnlineShop.Services.Home;
using Moq;

namespace OnlineShop.Test.Mocks
{
   public class MockDrinkService
    {
        public static IDrinkService Instance
        {
            get
            {
                var homeServiceMoq = new Mock<IDrinkService>();
                return homeServiceMoq.Object;
            }

        }
    }
}

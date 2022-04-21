using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Services;
using ASP.NET_Core_OnlineShop.Services.Home;
using Moq;

namespace OnlineShop.Test.Mocks
{
  public  class MockHashingService
    {
        public static class HomeServiceMoc
        {
            public static IHashingService Instance
            {
                get
                {
                    var hashingService = new Mock<IHashingService>();
                    return hashingService.Object;
                }

            }
        }
    }
}

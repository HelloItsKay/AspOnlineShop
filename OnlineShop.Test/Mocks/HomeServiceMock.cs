using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Services.Home;
using Moq;

namespace OnlineShop.Test.Mocks
{
   public static class  HomeServiceMoc
    {
        public static IHomeService Instance
        {
            get
            {
                var homeServiceMoq = new Mock<IHomeService>();
                return homeServiceMoq.Object;
            }

        }
    }
}

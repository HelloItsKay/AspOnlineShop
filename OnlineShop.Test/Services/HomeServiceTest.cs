using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Data.Models;
using ASP.NET_Core_OnlineShop.Models.Drinks;
using ASP.NET_Core_OnlineShop.Services.Drinks;
using ASP.NET_Core_OnlineShop.Services.Home;
using OnlineShop.Test.Mocks;
using Xunit;

namespace OnlineShop.Test.Services
{
   public class HomeServiceTest
    {
        [Fact]
        public void GetDrinksForCarocelShouldReturnModel()
        {
            using var data = DatabaseMock.Instance;

            var testId = "testId";
            data.Add(new Drink { Id = testId });
            data.SaveChanges();
            var homeService = new HomeService(data);

            
            var result = homeService.GetDrinksForCarosel();

            Assert.NotNull(result);
            Assert.IsType<List<DrinksListingViewModel>>(result);

        }
    }
}

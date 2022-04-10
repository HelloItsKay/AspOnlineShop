using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Controllers;
using ASP.NET_Core_OnlineShop.Services.Home;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace OnlineShop.Test.Controller
{
    public class HomeControllerTest
    {
        [Fact]
        public void IndexShouldReturnView()
        {
            
            var homeController = new HomeController(Mock.Of<IHomeService>());
            
            var result = homeController.Index();
            
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);

        }
    }
}

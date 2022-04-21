using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Controllers;
using ASP.NET_Core_OnlineShop.Data.Models;
using ASP.NET_Core_OnlineShop.Services.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using OnlineShop.Test.Mocks;
using Xunit;
using IHomeService = ASP.NET_Core_OnlineShop.Services.Home.IHomeService;

namespace OnlineShop.Test.Controllers
{
    public class AboutControllerTest
    {
        [Fact]
        public void ShouldReturnCorrectModelAndView()
        {
            var controller = new AboutController();
            var result = controller.AboutUs();

            Assert.IsType<ViewResult>(result);
        }

    }
}

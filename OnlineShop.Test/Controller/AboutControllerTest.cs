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
    public class AboutControllerTest
    {
        [Fact]
        public void AboutUsShouldReturnView()
        {

            var aboutController = new AboutController();

            var result = aboutController.AboutUs();

            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);

        }
    }
    
}

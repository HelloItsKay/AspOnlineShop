using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Controllers;
using ASP.NET_Core_OnlineShop.Services.Drinks;
using ASP.NET_Core_OnlineShop.Services.Home;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace OnlineShop.Test.Controller
{
   public class DrinksControllerTest
    {
        [Fact]
        public void Delete_Should_Return_On_Action_Result()
        {

            var drinksController = new DrinksController(Mock.Of<IDrinkService>());

            
            var result = drinksController.Delete(null);

            Assert.NotNull(result);
            Assert.IsType<RedirectToActionResult>(result);

        } 
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Areas.Admin.Controllers;
using ASP.NET_Core_OnlineShop.Controllers;
using ASP.NET_Core_OnlineShop.Data.Models;
using ASP.NET_Core_OnlineShop.Services.Drinks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Test.Mocks;
using Xunit;
using DrinksController = ASP.NET_Core_OnlineShop.Areas.Admin.Controllers.DrinksController;

namespace OnlineShop.Test.Controllers.Admin
{
  public  class DrinkControllerTest
    {
        [Fact]
        public void AllDrinksShouldReturnView()
        {
            var data = DatabaseMock.Instance;
            var service = new DrinkService(data);
            var controller = new DrinksController(service);

            var result = controller.Add();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void EditDrinksShouldReturnView()
        {
            var data = DatabaseMock.Instance;
            var service = new DrinkService(data);
            var controller = new DrinksController(service);
            var drink = data.Drinks.Add(new Drink()
            {
                Id = "test"
            });
            data.SaveChanges();

            var result = controller.Edit("test");
            Assert.IsType<ViewResult>(result);
        }


        [Fact]
        public void DeleteDrinksShouldReturnView()
        {
            var data = DatabaseMock.Instance;
            var service = new DrinkService(data);
            var controller = new DrinksController(service);
            var drink = data.Drinks.Add(new Drink()
            {
                Id = "test"
            });
            data.SaveChanges();

            var result = controller.Delete("test");
            Assert.IsType<RedirectResult>(result);
        }
    }
}

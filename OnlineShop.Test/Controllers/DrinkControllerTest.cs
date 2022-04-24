using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Controllers;
using ASP.NET_Core_OnlineShop.Data.Models;
using ASP.NET_Core_OnlineShop.Services.Drinks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Test.Mocks;
using Xunit;

namespace OnlineShop.Test.Controllers
{
   public class DrinkControllerTest
    {
        [Fact]
        public void AllDrinksShouldReturnView()
        {
            var data = DatabaseMock.Instance;
            var service = new DrinkService(data);
            var controller = new DrinksController(service);

            var result = controller.AllDrinks(1);
          Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void AlchoholDrinksShouldReturnView()
        {
            var data = DatabaseMock.Instance;
            var service = new DrinkService(data);
            var controller = new DrinksController(service);

            var result = controller.AlcoholicDrinks(1);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void NonAlchoholDrinksShouldReturnView()
        {
            var data = DatabaseMock.Instance;
            var service = new DrinkService(data);
            var controller = new DrinksController(service);

            var result = controller.NonAlcoholicDrinks(1);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void DetailsShouldReturnView()
        {
            var data = DatabaseMock.Instance;
            var service = new DrinkService(data);
            var controller = new DrinksController(service);

          var drink=  data.Drinks.Add(new Drink()
            {
                Id = "flag"
            });

            var result = controller.Details("flag");
            Assert.IsType<ViewResult>(result);
        }
    }
}

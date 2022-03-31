using ASP.NET_Core_OnlineShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Data;
using ASP.NET_Core_OnlineShop.Models.Drinks;
using ASP.NET_Core_OnlineShop.Services.Home;

namespace ASP.NET_Core_OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        public readonly IHomeService data;
        public HomeController(IHomeService data)
        {
            this.data = data;
        }
        public IActionResult Index()
        {
            data.GetDrinksForCarosel();

            var allDrinks = data.GetDrinksForCarosel();
            var caroselDrinks =new List<DrinksListingViewModel>();
            for (int i = 0; i < allDrinks.Count-1; i++)
            {
                caroselDrinks.Add(allDrinks[i]);
            }


            return View(caroselDrinks);

            
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

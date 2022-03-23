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

namespace ASP.NET_Core_OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        public readonly OnlineShopDbContext data;
        public HomeController(OnlineShopDbContext data)
        {
            this.data = data;
        }
        public IActionResult Index()
        {
            List<DrinksListingViewModel> allDrinks = data
                .Drinks
                .OrderByDescending(d => d.Id)
                .Select(d => new DrinksListingViewModel()
                {
                    Name = d.Name,
                    ImageThumbnailUrl = d.ImageThumbnailUrl,
                    Price = d.Price,
                    Category = d.Category.CategoryName,
                    ShortDescription = d.ShortDescription
                }).Reverse().ToList();

            var caroselDrinks =new List<DrinksListingViewModel>();
            for (int i = 0; i < allDrinks.Count-1; i++)
            {
                caroselDrinks.Add(allDrinks[i]);
            }


            return View(caroselDrinks);

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

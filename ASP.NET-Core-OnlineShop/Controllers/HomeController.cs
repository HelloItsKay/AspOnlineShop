using System;
using System.Collections.Generic;
using System.Linq;
using ASP.NET_Core_OnlineShop.Data;
using ASP.NET_Core_OnlineShop.Models.Drinks;
using Microsoft.Extensions.Caching.Memory;

namespace ASP.NET_Core_OnlineShop.Controllers
{
    using ASP.NET_Core_OnlineShop.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using ASP.NET_Core_OnlineShop.Services.Home;
    using static ASP.NET_Core_OnlineShop.WebConstants;
    public class HomeController : Controller
    {
        public readonly IHomeService service;
        private readonly IMemoryCache cache;
        public HomeController(IHomeService service, IMemoryCache cache)
        {
            this.service = service;
            this.cache = cache;
        }
        public IActionResult Index()
        {
          
            var chacheDrinks = this.cache.Get<List<DrinksListingViewModel>>(LatestDrinkCacheKey);
            if (chacheDrinks==null)
            {
                chacheDrinks = service.GetDrinksForCarosel().ToList();
              var  chachEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));
            this.cache.Set(LatestDrinkCacheKey, chacheDrinks, chachEntryOptions);
            }
            return View(chacheDrinks);


        }
    }
}

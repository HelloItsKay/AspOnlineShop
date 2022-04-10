namespace ASP.NET_Core_OnlineShop.Controllers
{
    using ASP.NET_Core_OnlineShop.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using ASP.NET_Core_OnlineShop.Services.Home;
    public class HomeController : Controller
    {
        public readonly IHomeService service;
        public HomeController(IHomeService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            var allDrinks = service.GetDrinksForCarosel();
            return View(allDrinks);


        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

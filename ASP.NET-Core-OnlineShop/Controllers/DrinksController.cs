using ASP.NET_Core_OnlineShop.Areas.Admin.Models;

namespace ASP.NET_Core_OnlineShop.Controllers
{
    using ASP.NET_Core_OnlineShop.Models;
    using ASP.NET_Core_OnlineShop.Models.Drinks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ASP.NET_Core_OnlineShop.Services.Drinks;
    using static ASP.NET_Core_OnlineShop.WebConstants;
    public class DrinksController : Controller
    {
        private readonly IDrinkService service;

        public DrinksController(IDrinkService service)
        {
            this.service = service;
        }

        public IActionResult Serch(string serchingTerm)
        {

            var drinks = service.Serch(serchingTerm);

            if (!string.IsNullOrEmpty(serchingTerm) && drinks.Count == 0)
            {
                return View("Error", new ErrorViewModel()
                {
                    SerchingTerm = serchingTerm
                });
            }

            return View("AllDrinks", drinks);
        }
        public IActionResult Details(string id)
        {
            var drink = service.GetDrinkDetails(id);
            return View(drink);
        }

        public IActionResult AllDrinks()
        {
            var allDrinks = service.GetAllDrinks();
            return View(allDrinks);
        }

        public IActionResult AlcoholicDrinks()
        {
            var allDrinks = service.GetAlchoholDrinks();
            return View(allDrinks);
        }

        public IActionResult NonAlcoholicDrinks()
        {
            var allDrinks = service.GetAllNonAlchoholDrinks();


            return View(allDrinks);
        }

    }

}

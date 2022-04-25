namespace ASP.NET_Core_OnlineShop.Controllers
{
    using ASP.NET_Core_OnlineShop.Models;
    using ASP.NET_Core_OnlineShop.Models.Drinks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ASP.NET_Core_OnlineShop.Services.Drinks;
    using static ASP.NET_Core_OnlineShop.WebConstants;
    using System.Linq;
    using ASP.NET_Core_OnlineShop.Areas.Admin.Models;
    using X.PagedList;
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

        public IActionResult AllDrinks(int? page)
        {
            var pageNumber = page ?? 1;
            int pageSize = 6;
            var allDrinks = service.GetAllDrinks();
            var onePageOfAllDrinks = allDrinks.ToPagedList(pageNumber, pageSize);
            return View(onePageOfAllDrinks);
        }

        public IActionResult AlcoholicDrinks(int? page)
        {

            var pageNumber = page ?? 1;
            int pageSize = 6;
            var allDrinks = service.GetAlchoholDrinks();
            var onePageOfAlcoholDrinks = allDrinks.ToPagedList(pageNumber, pageSize);
            return View(onePageOfAlcoholDrinks);
        }

        public IActionResult NonAlcoholicDrinks(int? page)
        {



            var pageNumber = page ?? 1;
            int pageSize = 6;
            var allDrinks = service.GetAllNonAlchoholDrinks();
            var onePageOfNonAlcoholDrinks = allDrinks.ToPagedList(pageNumber, pageSize);


            return View(onePageOfNonAlcoholDrinks);
        }

    }

}

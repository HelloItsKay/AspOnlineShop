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
        [Authorize]
        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult Delete(string id)
        {
            var drink = service.GetDrinkById(id);
            service.DeleteDrink(drink);
            return RedirectToAction("AllDrinks", "Drinks");
        }

        [Authorize]
        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult Edit(string id)
        {
            var drink = service.GetDrinkById(id);
            var edit = service.EditDrink(drink);
            edit.Categories = service.GetDrinkCategories();
            return View(edit);
        }

        [Authorize]
        [Authorize(Roles = AdministratorRoleName)]

        [HttpPost]
        public IActionResult Edit(DrinkFormModel drink)
        {
            if (!service.DoesCategoryExist(drink))
            {
                this.ModelState.AddModelError(nameof(drink.CategoryId), "Category does not exists.");
            }
            if (!ModelState.IsValid)
            {
                drink.Categories = service.GetDrinkCategories();
                return View(drink);
            }

            var edit = service.EditDrinkPost(drink);

            return RedirectToAction("AllDrinks", "Drinks");

        }

        public IActionResult Serch(string serchingTerm)
        {

            var drinks = service.Serch(serchingTerm);

            if (!string.IsNullOrEmpty(serchingTerm) && drinks.Count == 0)
            {
                return View("Error", new ErrorViewModel()
                {
                    RequestId = "The desired drink is not available"
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
        [Authorize]
        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult Add() => View(new DrinkFormModel()
        {
            Categories = service.GetDrinkCategories()
        });
        [Authorize]
        [Authorize(Roles = AdministratorRoleName)]
        [HttpPost]
        public IActionResult Add(DrinkFormModel drink)
        {
            if (!service.DoesCategoryExist(drink))
            {
                this.ModelState.AddModelError(nameof(drink.CategoryId), "Category does not exists.");
            }
            if (!ModelState.IsValid)
            {
                drink.Categories = service.GetDrinkCategories();
                return View(drink);
            }

            service.CreateDrink(drink);

            return RedirectToAction("AllDrinks", "Drinks");
        }

    }

}

namespace ASP.NET_Core_OnlineShop.Areas.Admin.Controllers
{
    using ASP.NET_Core_OnlineShop.Areas.Admin.Models;
    using ASP.NET_Core_OnlineShop.Services.Drinks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static ASP.NET_Core_OnlineShop.WebConstants;
    public class DrinksController:AdminController
    {
        private readonly IDrinkService service;

        public DrinksController(IDrinkService service)
        {
            this.service = service;
        }


        public IActionResult Add() => View(new DrinkFormModel()
        {
            Categories = service.GetDrinkCategories()
        });
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

            return Redirect("/Drinks/AllDrinks");
        }


        public IActionResult Edit(string id)
        {
            var drink = service.GetDrinkById(id);
            var edit = service.EditDrink(drink);
            edit.Categories = service.GetDrinkCategories();
            return View(edit);
        }


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

            return Redirect("/Drinks/AllDrinks");

        }


        public IActionResult Delete(string id)
        {
            var drink = service.GetDrinkById(id);
            service.DeleteDrink(drink);
            return Redirect("/Drinks/AllDrinks");
        }


    }
}

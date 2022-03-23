using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Data;
using ASP.NET_Core_OnlineShop.Data.Models;
using ASP.NET_Core_OnlineShop.Models.Drinks;
using ASP.NET_Core_OnlineShop.Services.Drinks.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_OnlineShop.Controllers
{
    public class DrinksController:Controller
    {
        private readonly OnlineShopDbContext data;
        

        public DrinksController(OnlineShopDbContext data)
        {
            this.data = data;
        }

        public IActionResult Details(string id)
        {
            var drink = data.Drinks.Where(d => d.Id == id).Select(d=> new DrinksListingViewModel()
            {   
                Name = d.Name,
                ImageUrl = d.ImageUrl,
                LongDescription = d.LongDescription,

            });
            return View(drink);
        }
        
        public IActionResult AllDrinks()
        {
            List<DrinksListingViewModel> allDrinks = data
                .Drinks
                .OrderByDescending(d => d.Id)
                .Select(d => new DrinksListingViewModel()
                {
                    Id=d.Id,
                    Name = d.Name,
                    ImageThumbnailUrl = d.ImageThumbnailUrl,
                    Price = d.Price,
                    ShortDescription = d.ShortDescription
                }).ToList();


            return View(allDrinks);
        }

        public IActionResult AlcoholicDrinks()
        {
            List<DrinksListingViewModel> allDrinks = data
                .Drinks
                .OrderByDescending(d => d.Id)
                .Where(d=>d.Category.CategoryName== "Alcoholic")
                .Select(d => new DrinksListingViewModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                    ImageThumbnailUrl = d.ImageThumbnailUrl,
                    Price = d.Price,
                    ShortDescription = d.ShortDescription
                }).ToList();


            return View(allDrinks);
        }

        public IActionResult NonAlcoholicDrinks()
        {
            List<DrinksListingViewModel> allDrinks = data
                .Drinks
                .OrderByDescending(d => d.Id)
                .Where(d => d.Category.CategoryName == "Non-alcoholic")
                .Select(d => new DrinksListingViewModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                    ImageThumbnailUrl = d.ImageThumbnailUrl,
                    Price = d.Price,
                    ShortDescription = d.ShortDescription
                }).ToList();


            return View(allDrinks);
        }
        [Authorize]
        public IActionResult Add() => View(new AddDrinkFormModel()
        {
            Categories = this.GetDrinkCategories()
        });
        [Authorize]
        [HttpPost]
        public IActionResult Add(AddDrinkFormModel drink)
        {
            if (!this.data.Categories.Any(d => d.Id == drink.CategoryId))
            {
                this.ModelState.AddModelError(nameof(drink.CategoryId), "Category does not exists.");
            }
            if (!ModelState.IsValid)
            {
                drink.Categories = this.GetDrinkCategories();
                return View(drink);
            }

            var newDrink = new Drink
            {
                Name = drink.Name,
                Price = drink.Price,
                ShortDescription = drink.ShortDescription,
                LongDescription = drink.LongDescription,
                CategoryId = drink.CategoryId,
                ImageThumbnailUrl = drink.ImageThumbnailUrl,
                ImageUrl = drink.ImageUrl


            };
            data.Drinks.Add(newDrink);
            data.SaveChanges();

            return RedirectToAction("AllDrinks", "Drinks");
        }
        private IEnumerable<DrinksCategoryServiceModel> GetDrinkCategories() =>
            data.Categories
                .Select(drink => new DrinksCategoryServiceModel
                {
                    Id = drink.Id,
                    Name = drink.CategoryName
                }).ToList();
    }

}

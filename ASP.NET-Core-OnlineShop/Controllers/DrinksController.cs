using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Data;
using ASP.NET_Core_OnlineShop.Data.Models;
using ASP.NET_Core_OnlineShop.Models;
using ASP.NET_Core_OnlineShop.Models.Drinks;
using ASP.NET_Core_OnlineShop.Services.Drinks.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using static ASP.NET_Core_OnlineShop.WebConstants;
namespace ASP.NET_Core_OnlineShop.Controllers
{
    public class DrinksController : Controller
    {
        private readonly OnlineShopDbContext data;

        public DrinksController(OnlineShopDbContext data)
        {
            this.data = data;
        }
        [Authorize]
        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult Delete(string id)
        {
            var drink = data.Drinks.Where(d => d.Id == id).FirstOrDefault();


            foreach (var element in data.ShoppingCartItems)
            {
                if (element.Drink.Id.Equals(drink.Id))
                {
                    data.ShoppingCartItems.Remove(element);
                }
            }



            data.Drinks.Remove(drink);
            data.SaveChanges();
            return RedirectToAction("AllDrinks", "Drinks");
        }

        [Authorize]
        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult Edit(string id)
        {
            var drink = data.Drinks.Find(id);
            var edit = new DrinkFormModel()
            {
                Id = drink.Id,
                Name = drink.Name,
                Price = drink.Price,
                ShortDescription = drink.ShortDescription,
                LongDescription = drink.LongDescription,
                CategoryId = drink.CategoryId,
                ImageThumbnailUrl = drink.ImageThumbnailUrl,
                ImageUrl = drink.ImageUrl
            };
            edit.Categories = this.GetDrinkCategories();
            return View(edit);
        }

        [Authorize]
        [Authorize(Roles = AdministratorRoleName)]

        [HttpPost]
        public IActionResult Edit(DrinkFormModel drink)
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

            var edit = data.Drinks.Where(d => d.Id == drink.Id).Select(d => new Drink
            {
                Id = drink.Id,
                Name = drink.Name,
                Price = drink.Price,
                ShortDescription = drink.ShortDescription,
                LongDescription = drink.LongDescription,
                CategoryId = drink.CategoryId,
                ImageThumbnailUrl = drink.ImageThumbnailUrl,
                ImageUrl = drink.ImageUrl
            }).FirstOrDefault();

            data.Drinks.Update(edit);
            data.SaveChanges();

            return RedirectToAction("AllDrinks", "Drinks");

        }

        public IActionResult Serch(string serchingTerm)
        {

            List<DrinksListingViewModel> drinks;
            if (string.IsNullOrEmpty(serchingTerm))
            {
                drinks = data.Drinks.OrderBy(d => d.Id).Select(d => new DrinksListingViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    ImageThumbnailUrl = d.ImageThumbnailUrl,
                    Price = d.Price,
                    ShortDescription = d.ShortDescription

                }).ToList();
            }
            else
            {
                drinks = data.Drinks.Where(d => d.Name.ToLower().Contains(serchingTerm.ToLower())).Select(d => new DrinksListingViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    ImageThumbnailUrl = d.ImageThumbnailUrl,
                    Price = d.Price,
                    ShortDescription = d.ShortDescription

                }).ToList(); ;
            }

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
            var drink = data.Drinks.Where(d => d.Id == id).Select(d => new DrinksListingViewModel()
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
                    Id = d.Id,
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
                .Where(d => d.Category.CategoryName == "Alcoholic")
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
        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult Add() => View(new DrinkFormModel()
        {
            Categories = this.GetDrinkCategories()
        });
        [Authorize]
        [Authorize(Roles = AdministratorRoleName)]
        [HttpPost]
        public IActionResult Add(DrinkFormModel drink)
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

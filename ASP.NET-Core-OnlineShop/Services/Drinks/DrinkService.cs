namespace ASP.NET_Core_OnlineShop.Services.Drinks
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using ASP.NET_Core_OnlineShop.Data.Models;
    using ASP.NET_Core_OnlineShop.Models.Drinks;
    using Models;

    public class DrinkService : IDrinkService
    {
        private readonly OnlineShopDbContext data;

        public DrinkService(OnlineShopDbContext data)
        {
            this.data = data;

        }
        public Drink GetDrinkById(string id)
        {
            return data.Drinks.Where(d => d.Id == id).FirstOrDefault();
        }

        public void DeleteDrink(Drink drink)
        {
            foreach (var element in data.ShoppingCartItems)
            {
                if (element.Drink.Id.Equals(drink.Id))
                {
                    data.ShoppingCartItems.Remove(element);
                }
            }

            data.Drinks.Remove(drink);
            data.SaveChanges();
        }

        public DrinkFormModel EditDrink(Drink drink)
        {
            return new DrinkFormModel
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
        }

        public Drink EditDrinkPost(DrinkFormModel drink)
        {
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
            return edit;
        }

        public List<DrinksListingViewModel> Serch(string serchingTerm)
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

            return drinks;
        }

        public IQueryable<DrinksListingViewModel> GetDrinkDetails(string id)
        {
            return data.Drinks.Where(d => d.Id == id).Select(d => new DrinksListingViewModel
            {
                Id = d.Id,
                Name = d.Name,
                ImageUrl = d.ImageUrl,
                LongDescription = d.LongDescription,

            });
        }

        public List<DrinksListingViewModel> GetAllDrinks()
        {
            return data
                 .Drinks
                 .OrderByDescending(d => d.Id)
                 .Select(d => new DrinksListingViewModel
                 {
                     Id = d.Id,
                     Name = d.Name,
                     ImageThumbnailUrl = d.ImageThumbnailUrl,
                     Price = d.Price,
                     ShortDescription = d.ShortDescription
                 }).ToList();
        }

        public List<DrinksListingViewModel> GetAlchoholDrinks()
        {
          return    data
                  .Drinks
                  .OrderByDescending(d => d.Id)
                  .Where(d => d.Category.CategoryName == "Alcoholic")
                  .Select(d => new DrinksListingViewModel
                  {
                      Id = d.Id,
                      Name = d.Name,
                      ImageThumbnailUrl = d.ImageThumbnailUrl,
                      Price = d.Price,
                      ShortDescription = d.ShortDescription
                  }).ToList();
             
        }

        public List<DrinksListingViewModel> GetAllNonAlchoholDrinks()
        {

            return data
                .Drinks
                .OrderByDescending(d => d.Id)
                .Where(d => d.Category.CategoryName == "Non-alcoholic")
                .Select(d => new DrinksListingViewModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    ImageThumbnailUrl = d.ImageThumbnailUrl,
                    Price = d.Price,
                    ShortDescription = d.ShortDescription
                }).ToList();
        }

        public Drink CreateDrink(DrinkFormModel drink)
        {
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

            return newDrink;
        }

        public IEnumerable<DrinksCategoryServiceModel> GetDrinkCategories()
        {

            return data.Categories
                     .Select(drink => new DrinksCategoryServiceModel
                     {
                         Id = drink.Id,
                         Name = drink.CategoryName
                     }).ToList();
        }

        public bool DoesCategoryExist(DrinkFormModel drink)
        {
            return data.Categories.Any(d => d.Id == drink.CategoryId);
        }
    }
}

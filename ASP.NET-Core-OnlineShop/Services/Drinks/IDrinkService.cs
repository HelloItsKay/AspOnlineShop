namespace ASP.NET_Core_OnlineShop.Services.Drinks
{
    using System.Collections.Generic;
    using System.Linq;
    using ASP.NET_Core_OnlineShop.Data.Models;
    using ASP.NET_Core_OnlineShop.Models.Drinks;
    using ASP.NET_Core_OnlineShop.Services.Drinks.Models;
    public interface IDrinkService
    {
        public Drink GetDrinkById(string id);
        public void DeleteDrink(Drink drink);
        public DrinkFormModel EditDrink(Drink drink);
        public Drink EditDrinkPost(DrinkFormModel drink);

        public List<DrinksListingViewModel> Serch(string serchingTerm);
        public IQueryable<DrinksListingViewModel> GetDrinkDetails(string id);
        public List<DrinksListingViewModel> GetAllDrinks();
        public List<DrinksListingViewModel> GetAlchoholDrinks();
        public List<DrinksListingViewModel> GetAllNonAlchoholDrinks();
        public Drink CreateDrink(DrinkFormModel drink);
        public IEnumerable<DrinksCategoryServiceModel> GetDrinkCategories();
        bool DoesCategoryExist(DrinkFormModel drink);
    }
}



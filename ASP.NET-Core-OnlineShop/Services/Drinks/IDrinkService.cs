

namespace ASP.NET_Core_OnlineShop.Services.Drinks
{
    using System.Collections.Generic;
    using System.Linq;
    using ASP.NET_Core_OnlineShop.Data.Models;
    using ASP.NET_Core_OnlineShop.Models.Drinks;
    using ASP.NET_Core_OnlineShop.Services.Drinks.Models;
    using ASP.NET_Core_OnlineShop.Areas.Admin.Models;
    public interface IDrinkService
    {
        public Drink GetDrinkById(string id);
        public List<DrinksListingViewModel> Serch(string serchingTerm);
        public IQueryable<DrinksListingViewModel> GetDrinkDetails(string id);
        public List<DrinksListingViewModel> GetAllDrinks();
        public List<DrinksListingViewModel> GetAlchoholDrinks();
        public List<DrinksListingViewModel> GetAllNonAlchoholDrinks();

        public IEnumerable<DrinksCategoryServiceModel> GetDrinkCategories();
        bool DoesCategoryExist(DrinkFormModel drink);

        //Admin Identity User
        public void DeleteDrink(Drink drink);
        public Drink CreateDrink(DrinkFormModel drink);
        public DrinkFormModel EditDrink(Drink drink);
        public Drink EditDrinkPost(DrinkFormModel drink);
    }
}



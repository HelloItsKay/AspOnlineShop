namespace ASP.NET_Core_OnlineShop.Services.Home
{
    using System.Collections.Generic;
    using ASP.NET_Core_OnlineShop.Models.Drinks;
    public interface IHomeService
    {
        public List<DrinksListingViewModel> GetDrinksForCarosel();
    }
}

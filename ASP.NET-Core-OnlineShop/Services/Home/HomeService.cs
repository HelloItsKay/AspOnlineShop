namespace ASP.NET_Core_OnlineShop.Services.Home
{
    using System.Collections.Generic;
    using System.Linq;
    using ASP.NET_Core_OnlineShop.Data;
    using ASP.NET_Core_OnlineShop.Models.Drinks;

    public class HomeService : IHomeService
    {
        private readonly OnlineShopDbContext data;
        public HomeService(OnlineShopDbContext data)
        {
            this.data = data;
        }
        public List<DrinksListingViewModel> GetDrinksForCarosel()
        {
            return data
                  .Drinks
                  .OrderByDescending(d => d.Id)
                  .Select(d => new DrinksListingViewModel()
                  {
                      Name = d.Name,
                      ImageThumbnailUrl = d.ImageThumbnailUrl,
                      Price = d.Price,
                      Category = d.Category.CategoryName,
                      ShortDescription = d.ShortDescription,
                      Id = d.Id,
                  }).Reverse().ToList();
        }
    }
}

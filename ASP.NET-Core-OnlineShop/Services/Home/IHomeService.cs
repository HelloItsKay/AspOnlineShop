using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Models.Drinks;

namespace ASP.NET_Core_OnlineShop.Services.Home
{
  public  interface IHomeService
    {
        public List<DrinksListingViewModel> GetDrinksForCarosel();
    }
}

namespace ASP.NET_Core_OnlineShop.Models.Drinks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;
    using ASP.NET_Core_OnlineShop.Services.Drinks.Models;
    public class DrinksListingViewModel
    {
        public string Id { get; set; }
        public string Name { get; init; }
        public string ShortDescription { get; init; }
        public string LongDescription { get; init; }
        public decimal Price { get; init; }
        public string ImageUrl { get; init; }
        public string ImageThumbnailUrl { get; init; }
        public string Category { get; set; }
    }
}

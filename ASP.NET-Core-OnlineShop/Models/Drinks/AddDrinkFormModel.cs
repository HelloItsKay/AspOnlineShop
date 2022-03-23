using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Data.Models;
using ASP.NET_Core_OnlineShop.Services.Drinks.Models;

namespace ASP.NET_Core_OnlineShop.Models.Drinks
{
    public class AddDrinkFormModel
    {
        [Required]
        public string Name { get; init; }
        [Required]
        public string ShortDescription { get; init; }
        [Required]
        public string LongDescription { get; init; }
        [Required]
        [Range(0.05, 1000)]
        [Column(TypeName = "money")]
        public decimal Price { get; init; }
        [Required]
        public string ImageUrl { get; init; }
        [Required]
        public string ImageThumbnailUrl { get; init; }
        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        public IEnumerable<DrinksCategoryServiceModel> Categories { get; set; }

    }
}

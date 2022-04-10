using ASP.NET_Core_OnlineShop.Data;

namespace ASP.NET_Core_OnlineShop.Models.Drinks
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ASP.NET_Core_OnlineShop.Services.Drinks.Models;
    using static DataConstants;
    public class DrinkFormModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = DrinkNameErrorMassage)]
        [MinLength(DrinkNameMinLength)]
        [MaxLength(DrinkNameMaxLenght)]
        public string Name { get; init; }
        [Required(ErrorMessage = ShortDescriptionErrorMassage)]
        [MinLength(ShortDescriptionMinLength)]
        [MaxLength(ShortDescriptionMaxLength)]
        public string ShortDescription { get; init; }
        [Required(ErrorMessage = LongDescriptionErrorMassage)]
        [MinLength(LongDescriptionMinLength)]
        [MaxLength(LongDescriptionMaxLength)]
        public string LongDescription { get; init; }
        [Required(ErrorMessage = PriceError)]
        [Range(PriceMinValue, PriceMaxValue)]
        [Column(TypeName = PriceType)]
        public decimal Price { get; init; }
        [Required]
        [Url]
        public string ImageUrl { get; init; }
        [Required]
        [Url]
        public string ImageThumbnailUrl { get; init; }
        [Display(Name = CategoryName)]
        public int CategoryId { get; init; }

        public IEnumerable<DrinksCategoryServiceModel> Categories { get; set; }

    }
}

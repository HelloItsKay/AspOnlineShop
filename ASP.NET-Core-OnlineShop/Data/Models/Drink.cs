namespace ASP.NET_Core_OnlineShop.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static DataConstants;
    public class Drink
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(DrinkNameMaxLenght)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ShortDescriptionMaxLength)]
        public string ShortDescription { get; set; }
        [Required]
        [MaxLength(LongDescriptionMaxLength)]
        public string LongDescription { get; set; }

        [Required]
        [Range(PriceMinValue, PriceMaxValue)]
        [Column(TypeName = PriceType)]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string ImageThumbnailUrl { get; set; }
       
        public int CategoryId { get; set; }

        public Category Category { get; init; }
    }
}


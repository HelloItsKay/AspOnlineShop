using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_OnlineShop.Data.Models
{
    public class Drink
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string ShortDescription { get; set; }
        [Required]
        [MaxLength(500)]
        public string LongDescription { get; set; }
        [Required]
        [Range(0.05, 1000)]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string ImageThumbnailUrl { get; set; }
        //public bool IsPreferredDrink { get; set; }
        //[Required]
        //public bool InStock { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; init; }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_OnlineShop.Data.Models
{
    public class Category
    {
        public int Id { get; set; } 
        public string CategoryName { get; set; }
        public IEnumerable<Drink> Drinks { get; init; } = new List<Drink>();
    }
}

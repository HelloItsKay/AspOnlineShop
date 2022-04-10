namespace ASP.NET_Core_OnlineShop.Data.Models
{
    using System.Collections.Generic;

    public class Category
    {
        public int Id { get; set; } 
        public string CategoryName { get; set; }
        public IEnumerable<Drink> Drinks { get; init; } = new List<Drink>();
    }
}

namespace ASP.NET_Core_OnlineShop.Models
{
    using System;

    public class MyOrdersViewModel
    {

        public string DrinkName { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }

        public string ImageUrl { get; set; }
        public string Category { get; set; }
    }
}

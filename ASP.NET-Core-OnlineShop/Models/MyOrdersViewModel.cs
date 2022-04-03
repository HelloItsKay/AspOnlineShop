using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_OnlineShop.Models
{
    public class MyOrdersViewModel
    {
        public string DrinkName { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_OnlineShop.Data.Models
{
    public class OrderDetail
    {
        public string OrderDetailId { get; set; } = Guid.NewGuid().ToString();
        public string OrderId { get; set; }
        public string DrinkId { get; set; }
        public int Amount { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public virtual Drink Drink { get; set; }
        public virtual Order Order { get; set; }
    }
}

namespace ASP.NET_Core_OnlineShop.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using static DataConstants;

    public class OrderDetail
    {
        public string OrderDetailId { get; set; } = Guid.NewGuid().ToString();
        public string OrderId { get; set; }
        public string DrinkId { get; set; }
        public int Amount { get; set; }
        [Column(TypeName = PriceType)]
        public decimal Price { get; set; }
        public virtual Drink Drink { get; set; }
        public virtual Order Order { get; set; }
    }
}

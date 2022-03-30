
//using ASP.NET_Core_OnlineShop.Services.ShoppingCart;

namespace ASP.NET_Core_OnlineShop.Models.ShoppingCart
{ using ASP.NET_Core_OnlineShop.Data.Models;

    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}

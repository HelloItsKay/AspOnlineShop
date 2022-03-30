using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_OnlineShop.Services.ShoppingCart
{
    using ASP.NET_Core_OnlineShop.Data.Models;

    public interface IShoppingCartService
    {
        // ShoppingCart GetCart(IServiceProvider services);
        void AddToCart(Drink drink, int amount);
         int RemoveFromCart(Drink drink);
        List<ShoppingCartItem> GetShoppingCartItems();
         void ModelAppropriation(List<ShoppingCartItem> item);
         void ClearCart();
         decimal GetShoppingCartTotal();
         public ShoppingCart GiveCartToView();
    }
}

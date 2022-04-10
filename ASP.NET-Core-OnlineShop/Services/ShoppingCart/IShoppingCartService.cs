namespace ASP.NET_Core_OnlineShop.Services.ShoppingCart
{
    using System.Collections.Generic;
    using ASP.NET_Core_OnlineShop.Data.Models;

    public interface IShoppingCartService
    {
        void AddToCart(Drink drink, int amount);
         int RemoveFromCart(Drink drink);
        List<ShoppingCartItem> GetShoppingCartItems();
         void ModelAppropriation(List<ShoppingCartItem> item);
         void ClearCart();
         decimal GetShoppingCartTotal();
         public ShoppingCart GiveCartToView();
         public Drink SelectedDrink(string drinkId);
    }
}

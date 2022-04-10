namespace ASP.NET_Core_OnlineShop.Data.Models
{
    using System.Collections.Generic;

    public class ShoppingCart
    {
        private readonly OnlineShopDbContext data;

        public ShoppingCart(OnlineShopDbContext data)
        {
            this.data = data;
        }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

       
    }
}

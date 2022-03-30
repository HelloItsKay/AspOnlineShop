using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Data;
using ASP.NET_Core_OnlineShop.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ASP.NET_Core_OnlineShop.Services.ShoppingCart
{
    using ASP.NET_Core_OnlineShop.Data.Models;

    public class ShoppingCartService : IShoppingCartService

    {
        private readonly ShoppingCart cart;
        private readonly OnlineShopDbContext data;
        public ShoppingCartService(OnlineShopDbContext data, ShoppingCart cart)
        {
            this.data = data;
            this.cart = cart;
        }
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            
           

            var context = services.GetService<OnlineShopDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);
            
            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }



        public void AddToCart(Drink drink, int amount)
        {
            var shoppingCartItem =
                    data.ShoppingCartItems.SingleOrDefault(
                        s => s.Drink.Id == drink.Id && s.ShoppingCartId == cart.ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = cart.ShoppingCartId,
                    Drink = drink,
                    Amount = 1
                };

                data.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            data.SaveChanges();
        }

        public int RemoveFromCart(Drink drink)
        {
            var shoppingCartItem =
                    data.ShoppingCartItems.SingleOrDefault(
                        s => s.Drink.Id == drink.Id && s.ShoppingCartId == cart.ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    data.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            data.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return cart.ShoppingCartItems ??
                   (cart.ShoppingCartItems =
                       data.ShoppingCartItems.Where(c => c.ShoppingCartId == cart.ShoppingCartId)
                           .Include(s => s.Drink)
                           .ToList());
        }

        public void ModelAppropriation(List<ShoppingCartItem> item)
        {
            cart.ShoppingCartItems = item;
        }

        public void ClearCart()
        {
            var cartItems = data
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == cart.ShoppingCartId);

            data.ShoppingCartItems.RemoveRange(cartItems);

            data.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = data.ShoppingCartItems.Where(c => c.ShoppingCartId == cart.ShoppingCartId)
                .Select(c => c.Drink.Price * c.Amount).Sum();
            return total;
        }

        public ShoppingCart GiveCartToView()
        {
            return cart;
        }
    }
}

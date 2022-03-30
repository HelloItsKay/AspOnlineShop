using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace ASP.NET_Core_OnlineShop.Data.Models
{
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

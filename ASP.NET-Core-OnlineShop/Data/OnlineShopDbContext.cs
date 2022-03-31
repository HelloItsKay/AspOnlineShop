using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ASP.NET_Core_OnlineShop.Data.Models;

namespace ASP.NET_Core_OnlineShop.Data
{
    public class OnlineShopDbContext : IdentityDbContext<User>
    {
        
        public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options)
            : base(options)
        {
        }
        public DbSet<Drink> Drinks { get; init; }
        public DbSet<Category> Categories { get; init; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Drink>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Drinks)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}

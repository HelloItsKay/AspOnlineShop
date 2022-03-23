using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Data;
using ASP.NET_Core_OnlineShop.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace ASP.NET_Core_OnlineShop.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            var data = scopedServices.ServiceProvider.GetService<OnlineShopDbContext>();
            data.Database.Migrate();
           SeedCategories(data);
            return app;
        }

        private static void SeedCategories(OnlineShopDbContext data)
        {
            if (data.Categories.Any())
            {
                return;
            }

            data.Categories.AddRange(new []
            {
                new Category { CategoryName = "Alcoholic" },
                new Category { CategoryName = "Non-alcoholic"}
            });
            data.SaveChanges();
        }
    }
}

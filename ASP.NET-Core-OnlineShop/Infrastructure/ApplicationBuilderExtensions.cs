using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Data;
using ASP.NET_Core_OnlineShop.Data.Models;
using Humanizer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static ASP.NET_Core_OnlineShop.WebConstants;
namespace ASP.NET_Core_OnlineShop.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            var serviceProvider = scopedServices.ServiceProvider;

            MigrateDatabase(serviceProvider);
            SeedCategories(serviceProvider);
            SeedAdministrator(serviceProvider);

            return app;
        }
        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<OnlineShopDbContext>();

            data.Database.Migrate();
        }
        private static void SeedCategories(IServiceProvider services)
        {
            var data = services.GetRequiredService<OnlineShopDbContext>();
            if (data.Categories.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
            {
                new Category { CategoryName = "Alcoholic" },
                new Category { CategoryName = "Non-alcoholic"}
            });
            data.SaveChanges();
        }


        private static void SeedAdministrator(
            IServiceProvider services)
        {
            var userManager = services.GetService<UserManager<User>>();
            var roleManager = services.GetService<RoleManager<IdentityRole>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                {
                    return;
                }
                var role = new IdentityRole { Name = AdministratorRoleName };
                await roleManager.CreateAsync(role);


                var user = new User()
                {
                    Email = "admin@admin.com",
                    UserName = "admin@admin.com",
                    FullName = "Admin",
                };
                await userManager.CreateAsync(user, "123qwe");
                await userManager.AddToRoleAsync(user, role.Name);
            })
                .GetAwaiter()
                .GetResult();


        }

        
    }
}

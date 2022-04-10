namespace ASP.NET_Core_OnlineShop.Infrastructure
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using ASP.NET_Core_OnlineShop.Data;
    using ASP.NET_Core_OnlineShop.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using static ASP.NET_Core_OnlineShop.WebConstants;
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            var serviceProvider = scopedServices.ServiceProvider;

            MigrateDatabase(serviceProvider);
            SeedCategories(serviceProvider);
            SeedAdministrator(serviceProvider);
            SeedDrinks(serviceProvider);

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

        private static void SeedDrinks(IServiceProvider services)
        {
            var data = services.GetRequiredService<OnlineShopDbContext>();
            if (data.Drinks.Any())
            {
                return;
            }
            data.Drinks.AddRange(new[]
            {
                new Drink
                {
                    Name = "Beer",
                    Price = 3.95M,
                    ShortDescription = "The most widely consumed alcohol",
                    LongDescription = "Beer is the world's oldest and most widely consumed alcoholic drink; it is the third most popular drink overall, after water and tea. The production of beer is called brewing, which involves the fermentation of starches, mainly derived from cereal grains—most commonly malted barley, although wheat, maize (corn), and rice are widely used.",
                    CategoryId = 1,
                    ImageUrl = "https://cdn.apartmenttherapy.info/image/upload/f_jpg,q_auto:eco,c_fill,g_auto,w_1500,ar_1:1/stock%2FStocksy_txpb658f17ffBl200_Medium_908642",
                    ImageThumbnailUrl = "http://cdn.ecommercedns.uk/files/8/226758/0/16719490/dont-worry-pale-ale.png"
                },

                new Drink
                {
                    Name = "Rum",
                    Price = 9.99M,
                    ShortDescription = "Sweet alcoholic drink loved by the pirates",
                    LongDescription = "Beer is the world's oldest and most widely consumed alcoholic drink; it is the third most popular drink overall, after water and tea. The production of beer is called brewing, which involves the fermentation of starches, mainly derived from cereal grains—most commonly malted barley, although wheat, maize (corn), and rice are widely used.",
                    CategoryId = 1,
                    ImageUrl = "https://rockfallrum.com/wp-content/uploads/2021/02/rockfall-hero-above.jpg",
                    ImageThumbnailUrl = "https://images.squarespace-cdn.com/content/v1/602269b367a7cf6c05dcb5ef/1613578506729-SD3WQMJJCH5PXB9GCVMG/Ron+Piet+50cl+-+1500x1500+pixels.jpg?format=1500w"
                },


                new Drink
                {
                    Name = "Coke",
                    Price = 1.99M,
                    ShortDescription = "Sweet fizzy drink",
                    LongDescription = "Coca-Cola, or Coke, is a carbonated soft drink manufactured by the Coca-Cola Company. Originally marketed as a temperance drink and intended as a patent medicine, it was invented in the late 19th century by John Stith Pemberton in Atlanta, Georgia. In 1888 Pemberton sold Coca-Cola's ownership rights to Asa Griggs Candler, a businessman, whose marketing tactics led Coca-Cola to its dominance of the global soft-drink market throughout the 20th and 21st century.",
                    CategoryId = 2,
                    ImageUrl = "https://www.baconismagic.ca/wp-content/uploads/2020/03/charro-negro-recipe.jpg",
                    ImageThumbnailUrl = "https://storage.googleapis.com/images-bks-prd-1385851.bks.prd.v8.commerce.mi9cloud.com/product-images/zoom/c7597303-48c7-4363-aa0f-ee4b856b1433.jpeg"
                },


                new Drink
                {
                    Name = "Tequila",
                    Price = 5.99M,
                    ShortDescription = "Beverage made from the blue agave plant.",
                    LongDescription = "Tequila (Spanish About this sound is a regionally specific name for a distilled beverage made from the blue agave plant, primarily in the area surrounding the city of Tequila, 65 km (40 mi) northwest of Guadalajara, and in the highlands (Los Altos) of the central western Mexican state of Jalisco. Although tequila is similar to mezcal, modern tequila differs somewhat in the method of its production, in the use of only blue agave plants, as well as in its regional specificity.",
                    CategoryId = 1,
                    ImageUrl = "https://m.media-amazon.com/images/I/81hniaHXgtS._AC_SL1500_.jpgb49bb.jpg",
                    ImageThumbnailUrl = "https://i.pinimg.com/originals/e0/e6/48/e0e64868f685fe35df3a5514790b49bb.jpg"
                },

                new Drink
                {
                    Name = "Apple juice",
                    Price = 5.99M,
                    ShortDescription = "Naturally contained in apples",
                    LongDescription = "Apple juice is a fruit juice made by the maceration and pressing of an apple. The resulting expelled juice may be further treated by enzymatic and centrifugal clarification to remove the starch and pectin, which holds fine particulate in suspension, and then pasteurized for packaging in glass, metal, or aseptic processing system containers, or further treated by dehydration processes to a concentrate.",
                    CategoryId = 2,
                    ImageUrl = "https://nutritionfacts.org/app/uploads/2019/01/pexels-photo-1536868.jpeg",
                    ImageThumbnailUrl = "https://storage.googleapis.com/images-dun-prd-85c8a53.dun.prd.v8.commerce.mi9cloud.com/product-images/zoom/100205077_1.jpg"
                },

                new Drink
                {
                    Name = "Orange juice",
                    Price = 5.99M,
                    ShortDescription = "Naturally contained in oranges",
                    LongDescription = "Apple juice is a fruit juice made by the maceration and pressing of an apple. The resulting expelled juice may be further treated by enzymatic and centrifugal clarification to remove the starch and pectin, which holds fine particulate in suspension, and then pasteurized for packaging in glass, metal, or aseptic processing system containers, or further treated by dehydration processes to a concentrate.",
                    CategoryId = 2,
                    ImageUrl = "https://m.media-amazon.com/images/I/71GmQbcr0CL._SL1500_.jpg",
                    ImageThumbnailUrl = "https://20fd661yccar325znz1e9bdl-wpengine.netdna-ssl.com/wp-content/uploads/2020/09/ocean-spray-100-orange-juice-boxes-40-pack-orange-juice.jpg"
                },


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

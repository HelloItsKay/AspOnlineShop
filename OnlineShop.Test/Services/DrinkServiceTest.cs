﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Areas.Admin.Models;
using ASP.NET_Core_OnlineShop.Data;
using ASP.NET_Core_OnlineShop.Data.Models;
using ASP.NET_Core_OnlineShop.Models.Drinks;
using ASP.NET_Core_OnlineShop.Services.Drinks;
using ASP.NET_Core_OnlineShop.Services.Drinks.Models;
using OnlineShop.Test.Mocks;
using Xunit;

namespace OnlineShop.Test.Services
{
    public class DrinkServiceTest
    {
        [Fact]
        public void GetDrinkByIdShouldReturnDrinkById()
        {
            using var data = DatabaseMock.Instance;

            var testId = "testId";
            data.Add(new Drink { Id = testId });
            data.SaveChanges();
            var drinkService = new DrinkService(data);

            var result = drinkService.GetDrinkById(testId);

            Assert.NotNull(result);
            Assert.IsType<Drink>(result);

        }

        [Fact]
        public void GetDrinkByIdShouldReturnNullWhenTheIdWeNeedIsNotInTheDatabase()
        {
            using var data = DatabaseMock.Instance;

            string testId = "test1";
            data.Add(new Drink
            {
                Id = testId
            });
            data.SaveChanges();
            var drinkService = new DrinkService(data);

            var result = drinkService.GetDrinkById("test2");
            Assert.Null(result);
            Assert.Throws<NullReferenceException>((() => result.Id));

        }

        [Fact]
        public void DeleteDrinkShouldRemoveGivenDrink()
        {
            using var data = DatabaseMock.Instance;

            string testId = "test1";

            Drink drink = new Drink
            {
                Id = testId
            };

            data.Add(drink);
            data.SaveChanges();
            var drinkService = new DrinkService(data);

            drinkService.DeleteDrink(drink);

            Assert.Equal(0, data.Drinks.Count());

        }

        [Fact]
        public void DeleteDrinkShouldThrowErrorWhenDeleteNullDrink()
        {


            using var data = DatabaseMock.Instance;

            string testId = "test1";

            Drink drink = new Drink
            {
                Id = testId
            };

            Drink drink2 = new Drink
            {
                Id = "123"
            };

            data.Add(drink);
            data.SaveChanges();
            var drinkService = new DrinkService(data);
            try
            {
                drinkService.DeleteDrink(drink2);
            }
            catch (Exception e)
            {
                Assert.NotNull(e);

            }

        }


        [Fact]
        public void EditDrinkShouldReturnDrinkFormModel()
        {
            using var data = DatabaseMock.Instance;


            Drink drink = new Drink
            {
                Name = "asd"
            };

            data.Add(drink);
            data.SaveChanges();
            var drinkService = new DrinkService(data);


            var result = drinkService.EditDrink(drink);

            Assert.IsType<DrinkFormModel>(result);

        }

        [Fact]
        public void EditDrinkShouldThrowExceptionWhenWeAttemptToEditNotExistingDrink()
        {
            using var data = DatabaseMock.Instance;


            Drink drink = new Drink
            {
                Name = "asd"
            };


            Drink drink2 = new Drink
            {
                Name = "123"
            };
            data.Add(drink);
            data.SaveChanges();
            var drinkService = new DrinkService(data);


            try
            {
                var result = drinkService.EditDrink(drink2);
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
            }

        }

        [Fact]
        public void SerchShouldReturnNothingWhenTermDoesNotExist()
        {
            using var data = DatabaseMock.Instance;


            Drink drink = new Drink
            {
                Name = "asd"
            };

            data.Add(drink);
            data.SaveChanges();
            var drinkService = new DrinkService(data);


            var result = drinkService.Serch("bbb");

            Assert.Equal(0, result.Count);

        }


        [Fact]
        public void GetDrinkDetailsSHouldReturnValidQuerry()
        {
            using var data = DatabaseMock.Instance;


            Drink drink = new Drink
            {
                Id = "1",
                Name = "asd"
            };
            Drink drink1 = new Drink
            {
                Id = "2",
                Name = "bsd"
            };
            Drink drink2 = new Drink
            {
                Id = "3",
                Name = "csd"
            };
            data.Add(drink);
            data.Add(drink1);
            data.Add(drink2);
            data.SaveChanges();
            var drinkService = new DrinkService(data);


            var result = drinkService.GetDrinkDetails("1");
            var actual = result.Count();

            Assert.Equal(1, actual);

        }


        [Fact]
        public void GetDrinkDetailsShouldReturnNothingWhenNullParam()
        {
            using var data = DatabaseMock.Instance;


            Drink drink = new Drink
            {
                Id = "1",
                Name = "asd"
            };
            Drink drink1 = new Drink
            {
                Id = "2",
                Name = "bsd"
            };
            Drink drink2 = new Drink
            {
                Id = "3",
                Name = "csd"
            };
            data.Add(drink);
            data.Add(drink1);
            data.Add(drink2);
            data.SaveChanges();
            var drinkService = new DrinkService(data);


            var result = drinkService.GetDrinkDetails(null);
            var actual = result.Count();

            Assert.Equal(0, actual);

        }

        [Fact]
        public void GetDrinkDetailsShouldReturnNothingWhenNonExistingParam()
        {
            using var data = DatabaseMock.Instance;


            Drink drink = new Drink
            {
                Id = "1",
                Name = "asd"
            };
            Drink drink1 = new Drink
            {
                Id = "2",
                Name = "bsd"
            };
            Drink drink2 = new Drink
            {
                Id = "3",
                Name = "csd"
            };
            data.Add(drink);
            data.Add(drink1);
            data.SaveChanges();
            var drinkService = new DrinkService(data);


            var result = drinkService.GetDrinkDetails("3");
            var actual = result.Count();

            Assert.Equal(0, actual);

        }


        [Fact]
        public void GetAllDrinksShouldReturnNothingWhenDbEmpty()
        {
            using var data = DatabaseMock.Instance;


            var drinkService = new DrinkService(data);


            var result = drinkService.GetAllDrinks();
            var actual = result.Count();

            Assert.Equal(0, actual);
            Assert.IsType<List<DrinksListingViewModel>>(result);

        }
        [Fact]
        public void CreateNewDrinkShouldReturnDrinkModel()
        {
            using var data = DatabaseMock.Instance;


            var drinkService = new DrinkService(data);
            DrinkFormModel drink = new DrinkFormModel()
            {

                Name = "flag",
                Price = 11,
                ShortDescription = "alsidhjaklsjdhakjsdhalsjdhalskjdhalskjdhalsjdhalksjdhla",
                LongDescription = "alsidhjaklsjdhakjsdhalsjdhalskjdhalskjdhalsjdhalksjdhla",
                CategoryId = 1,
                ImageThumbnailUrl = null,
                ImageUrl = null,
            };
            var result = drinkService.CreateDrink(drink);

            Assert.IsType<Drink>(result);
            Assert.Equal(1, data.Drinks.Count());

        }


        [Fact]
        public void GetDrinkCategoriesShouldReturnFalse()
        {
            using var data = DatabaseMock.Instance;
            Drink drink = new Drink()
            {

                Name = "flag",
                Price = 11,
                ShortDescription = "alsidhjaklsjdhakjsdhalsjdhalskjdhalskjdhalsjdhalksjdhla",
                LongDescription = "alsidhjaklsjdhakjsdhalsjdhalskjdhalskjdhalsjdhalksjdhla",
                CategoryId = 1,
                ImageThumbnailUrl = null,
                ImageUrl = null,
            }; Drink drink2 = new Drink()
            {
                Id = "1",
                Name = "flag",
                Price = 11,
                ShortDescription = "alsidhjaklsjdhakjsdhalsjdhalskjdhalskjdhalsjdhalksjdhla",
                LongDescription = "alsidhjaklsjdhakjsdhalsjdhalskjdhalskjdhalsjdhalksjdhla",
                CategoryId = 1,
                ImageThumbnailUrl = null,
                ImageUrl = null,
            };
            data.Add(drink);
            data.Add(drink2);
            data.SaveChanges();

            var drinkService = new DrinkService(data);

            DrinkFormModel model = new DrinkFormModel()
            {
                Id = "1",
                Name = "flag",
                Price = 11,
                ShortDescription = "alsidhjaklsjdhakjsdhalsjdhalskjdhalskjdhalsjdhalksjdhla",
                LongDescription = "alsidhjaklsjdhakjsdhalsjdhalskjdhalskjdhalsjdhalksjdhla",
                CategoryId = 1,
                ImageThumbnailUrl = null,
                ImageUrl = null,
            };
            var result = drinkService.DoesCategoryExist(model);


            Assert.Equal(drink2.CategoryId, model.CategoryId);
            Assert.False(result);
        }

        [Fact]
        public void GetDrinkCategoriesShoulnModel()
        {
            using var data = DatabaseMock.Instance;
            Drink drink = new Drink()
            {

                Name = "flag",
                Price = 11,
                ShortDescription = "alsidhjaklsjdhakjsdhalsjdhalskjdhalskjdhalsjdhalksjdhla",
                LongDescription = "alsidhjaklsjdhakjsdhalsjdhalskjdhalskjdhalsjdhalksjdhla",
                CategoryId = 1,
                ImageThumbnailUrl = null,
                ImageUrl = null,
            }; Drink drink2 = new Drink()
            {
                Id = "1",
                Name = "flag",
                Price = 11,
                ShortDescription = "alsidhjaklsjdhakjsdhalsjdhalskjdhalskjdhalsjdhalksjdhla",
                LongDescription = "alsidhjaklsjdhakjsdhalsjdhalskjdhalskjdhalsjdhalksjdhla",
                CategoryId = 1,
                ImageThumbnailUrl = null,
                ImageUrl = null,
            };
            data.Add(drink);
            data.Add(drink2);
            data.SaveChanges();

            var drinkService = new DrinkService(data);

            DrinkFormModel model = new DrinkFormModel()
            {
                Id = "1",
                Name = "flag",
                Price = 11,
                ShortDescription = "alsidhjaklsjdhakjsdhalsjdhalskjdhalskjdhalsjdhalksjdhla",
                LongDescription = "alsidhjaklsjdhakjsdhalsjdhalskjdhalskjdhalsjdhalksjdhla",
                CategoryId = 1,
                ImageThumbnailUrl = null,
                ImageUrl = null,
            };
            var result = drinkService.GetDrinkCategories().FirstOrDefault();


            Assert.IsNotType<DrinksCategoryServiceModel>(result);
        }
    }
}

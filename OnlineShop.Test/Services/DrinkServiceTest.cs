using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Data.Models;
using ASP.NET_Core_OnlineShop.Models.Drinks;
using ASP.NET_Core_OnlineShop.Services.Drinks;
using OnlineShop.Test.Mocks;
using Xunit;

namespace OnlineShop.Test.Services
{
  public  class DrinkServiceTest
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
           data.Add(new Drink { Id = testId });
           data.SaveChanges();
            var drinkService = new DrinkService(data);

            var result = drinkService.GetDrinkById("test2");
            Assert.Null(result);
            
            
            
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


          var result=  drinkService.EditDrink(drink);

          Assert.IsType<DrinkFormModel>(result);

        } 
        
        [Fact]
        public void SerchShouldReturnListWithItems()
        {
            using var data = DatabaseMock.Instance;


            Drink drink = new Drink
            {
                Name = "asd"
            };

            data.Add(drink);
            data.SaveChanges();
            var drinkService = new DrinkService(data);


          var result=  drinkService.Serch("asd");

          Assert.Equal(1,result.Count);

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
        public void SerchShouldReturnEveruthingWhenNull()
        {
            using var data = DatabaseMock.Instance;


            Drink drink = new Drink
            {
                Name = "asd"
            };
            Drink drink1 = new Drink
            {
                Name = "bsd"
            };
            Drink drink2 = new Drink
            {
                Name = "csd"
            };
            data.Add(drink);
            data.Add(drink1);
            data.Add(drink2);
            data.SaveChanges();
            var drinkService = new DrinkService(data);


            var result = drinkService.Serch(null);

            Assert.Equal(3, result.Count);

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
           var actual= result.Count();

            Assert.Equal(1,actual);

        }


        [Fact]
        public void GetDrinkDetailsShouldReturnNothing()
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
        public void GetAllDrinksShouldReturnListWithItems()
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


            var result = drinkService.GetAllDrinks();
            var actual = result.Count();

            Assert.Equal(3, actual);
            Assert.IsType<List<DrinksListingViewModel>>(result);

        }
        [Fact]
        public void GetAllDrinksShouldReturnNothing()
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

                Name = "test",
                Price = 11,
                ShortDescription = "alsidhjaklsjdhakjsdhalsjdhalskjdhalskjdhalsjdhalksjdhla",
                LongDescription = "alsidhjaklsjdhakjsdhalsjdhalskjdhalskjdhalsjdhalksjdhla",
                CategoryId = 1,
                ImageThumbnailUrl = null,
                ImageUrl = null,
            };
            var result=  drinkService.CreateDrink(drink);

            Assert.IsType<Drink>(result);
            Assert.Equal(1,data.Drinks.Count());

        }


        [Fact]
        public void GetDrinkCategoriesShouldReturnFalse()
        {
            using var data = DatabaseMock.Instance;
            Drink drink = new Drink()
            {

                Name = "test",
                Price = 11,
                ShortDescription = "alsidhjaklsjdhakjsdhalsjdhalskjdhalskjdhalsjdhalksjdhla",
                LongDescription = "alsidhjaklsjdhakjsdhalsjdhalskjdhalskjdhalsjdhalksjdhla",
                CategoryId = 1,
                ImageThumbnailUrl = null,
                ImageUrl = null,
            }; Drink drink2 = new Drink()
            {
                Id="1",
                Name = "test",
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
                Name = "test",
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
    }
}

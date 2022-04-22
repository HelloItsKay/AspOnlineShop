using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Data.Models;
using ASP.NET_Core_OnlineShop.Services.ShoppingCart;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineShop.Test.Mocks;
using Xunit;

namespace OnlineShop.Test.Services
{
    public static class ShoppingCartServiceTest
    {

        [Fact]
        public static void GeiveCartToViwSouldReturnCartModel()
        {
            var data = DatabaseMock.Instance;

            var cart = new ShoppingCart(data);
            var shoppingCartService = new ShoppingCartService(data, cart);



            Drink drink = new Drink()
            {
                Id = "flag",
                Name = "flag"
            };
            data.Add(drink);
            data.SaveChanges();

            data.ShoppingCartItems.Add(new ShoppingCartItem()
            {
                Drink = drink,
                Amount = 3,
                ShoppingCartId = "123",
                ShoppingCartItemId = 13,
            });
            data.SaveChanges();

            cart.ShoppingCartId = "123";

            var result = shoppingCartService.GiveCartToView();

            Assert.IsType<ShoppingCart>(result);


        }

        [Fact]
        public static void ModelApropriationShouldReturnSameResultAsExpectedOne()
        {
            var data = DatabaseMock.Instance;

            var cart = new ShoppingCart(data);
            var shoppingCartService = new ShoppingCartService(data, cart);



            Drink drink = new Drink()
            {
                Id = "flag",
                Name = "flag"
            };
            data.Add(drink);
            data.SaveChanges();

            data.ShoppingCartItems.Add(new ShoppingCartItem()
            {
                Drink = drink,
                Amount = 3,
                ShoppingCartId = "123",
                ShoppingCartItemId = 13,
            });
            data.SaveChanges();

            cart.ShoppingCartId = "123";

            var list = data.ShoppingCartItems.ToList();
          shoppingCartService.ModelAppropriation(list);

          Assert.Equal(list ,cart.ShoppingCartItems);
        }
        [Fact]
        public static void SelectDriShouldReturnValidDrinknk()
        {
            var data = DatabaseMock.Instance;

            var cart = new ShoppingCart(data);
            var shoppingCartService = new ShoppingCartService(data, cart);



            Drink drink = new Drink()
            {
                Id = "flag",
                Name = "flag"
            };
            data.Add(drink);
            data.SaveChanges();

            data.ShoppingCartItems.Add(new ShoppingCartItem()
            {
                Drink = drink,
                Amount = 3,
                ShoppingCartId = "123",
                ShoppingCartItemId = 13,
            });
            data.SaveChanges();

            cart.ShoppingCartId = "123";

            
           var actual=  shoppingCartService.SelectedDrink("flag");
           var expected= data.Drinks.FirstOrDefault(p => p.Id == "flag");


            Assert.Equal(expected, actual);
        }


        [Fact]
        public static void GetShoppingCartItemsReturnValueLikeLIstShopingCartItem()
        {
            var data = DatabaseMock.Instance;

            var cart = new ShoppingCart(data);
            var shoppingCartService = new ShoppingCartService(data, cart);



            Drink drink = new Drink()
            {
                Id = "flag",
                Name = "flag"
            };
            data.Add(drink);
            data.SaveChanges();

            data.ShoppingCartItems.Add(new ShoppingCartItem()
            {
                Drink = drink,
                Amount = 3,
                ShoppingCartId = "123",
                ShoppingCartItemId = 13,
            });
            data.SaveChanges();

            cart.ShoppingCartId = "123";

            var result = shoppingCartService.GetShoppingCartItems();


            Assert.Equal(1, result.Count);
            Assert.IsType<List<ShoppingCartItem>>(result);


        }

        [Fact]
        public static void AddItemChekIfItemInCartIsSameAsAdded()
        {
            var data = DatabaseMock.Instance;

            var cart = new ShoppingCart(data);
            var shoppingCartService = new ShoppingCartService(data, cart);



            Drink drink = new Drink()
            {
                Id = "flag",
                Name = "flag"
            };

            Drink drink2 = new Drink()
            {
                Id = "test2",
                Name = "flag"
            };
            data.Add(drink);
            data.Add(drink2);
            data.SaveChanges();



            shoppingCartService.AddToCart(drink2, 2);
            var actual = shoppingCartService.GetShoppingCartItems().ToList();

            Assert.Equal(drink2,actual[0].Drink);



        }
        [Fact] public static void AddItemToCartShouldIncreaseValue()
        {
            var data = DatabaseMock.Instance;

            var cart = new ShoppingCart(data);
            var shoppingCartService = new ShoppingCartService(data, cart);



            Drink drink = new Drink()
            {
                Id = "flag",
                Name = "flag"
            };

            Drink drink2 = new Drink()
            {
                Id = "test2",
                Name = "flag"
            };
            data.Add(drink);
            data.Add(drink2);
            data.SaveChanges();



           shoppingCartService.AddToCart(drink,2);
           shoppingCartService.AddToCart(drink2,4);


            Assert.Equal(2,data.ShoppingCartItems.Count());
            


        }



        [Fact]
        public static void AddItemToCartShouldAddNewItemIfDoesNotExist()
        {
            var data = DatabaseMock.Instance;

            var cart = new ShoppingCart(data);
            var shoppingCartService = new ShoppingCartService(data, cart);



            Drink drink = new Drink()
            {
                Id = "flag",
                Name = "flag"
            };

            Drink drink2 = new Drink()
            {
                Id = "test2",
                Name = "flag"
            };
            data.Add(drink);
            data.SaveChanges();

            
         shoppingCartService.AddToCart(drink2, 4);
         Assert.Equal(1, data.ShoppingCartItems.Count());
         Assert.Equal(1, data.ShoppingCartItems.Select(x=>x.Amount).ToList().FirstOrDefault());
         
        }

        [Fact]
        public static void RemoveItemFromCartShouldReturnvalidResult()
        {
            var data = DatabaseMock.Instance;

            var cart = new ShoppingCart(data);
            var shoppingCartService = new ShoppingCartService(data, cart);



            Drink drink = new Drink()
            {
                Id = "flag",
                Name = "flag"
            };


            Drink drink2 = new Drink()
            {
                Id = "test2",
                Name = "flag"
            };
            data.Add(drink);
            data.Add(drink2);
            data.SaveChanges();

           


            shoppingCartService.AddToCart(drink, 1);
            shoppingCartService.AddToCart(drink2, 1);
            shoppingCartService.RemoveFromCart(drink);
            

            var result = data.ShoppingCartItems;


            Assert.Equal(1, result.Count());



        }

        [Fact]
        public static void RemoveItemFromCartShouldRemoveNothingAndReturn0IfItemDoesNotExist()
        {
            var data = DatabaseMock.Instance;

            var cart = new ShoppingCart(data);
            var shoppingCartService = new ShoppingCartService(data, cart);



            Drink drink = new Drink()
            {
                Id = "flag",
                Name = "flag"
            };


            Drink drink2 = new Drink()
            {
                Id = "test2",
                Name = "flag"
            };
            data.Add(drink);
            data.SaveChanges();




          var result=  shoppingCartService.RemoveFromCart(drink2);



            Assert.Equal(0, result);



        }

        [Fact]
        public static void GetShopingCartItemsShouldReturnValues()
        {
            var data = DatabaseMock.Instance;

            var cart = new ShoppingCart(data);
            var shoppingCartService = new ShoppingCartService(data, cart);



            Drink drink = new Drink()
            {
                Id = "flag",
                Name = "flag"
            };


            Drink drink2 = new Drink()
            {
                Id = "test2",
                Name = "flag"
            };
            data.Add(drink);
            data.Add(drink2);
            data.SaveChanges();




            shoppingCartService.AddToCart(drink, 1);
            shoppingCartService.AddToCart(drink2, 1);


            var result = shoppingCartService.GetShoppingCartItems();


            Assert.Equal(2, result.Count);
            Assert.Contains(drink.Id, result[0].Drink.Id);
            Assert.Contains(drink2.Id, result[1].Drink.Id);
            
        }



        [Fact]
        public static void GetShopingCartItemsShouldReturnProperObject()
        {
            var data = DatabaseMock.Instance;

            var cart = new ShoppingCart(data);
            var shoppingCartService = new ShoppingCartService(data, cart);



            Drink drink = new Drink()
            {
                Id = "flag",
                Name = "flag"
            };


            Drink drink2 = new Drink()
            {
                Id = "test2",
                Name = "flag"
            };
            data.Add(drink);
            data.Add(drink2);
            data.SaveChanges();




            shoppingCartService.AddToCart(drink, 1);

            var expected = shoppingCartService.GetShoppingCartItems().ToList();
            var result = shoppingCartService.GetShoppingCartItems();


            Assert.Equal(expected[0], result[0]);

        }
        [Fact]
        public static void ClearShoppingCartShouldReturnZero()
        {
            var data = DatabaseMock.Instance;

            var cart = new ShoppingCart(data);
            var shoppingCartService = new ShoppingCartService(data, cart);



            Drink drink = new Drink()
            {
                Id = "flag",
                Name = "flag"
            };


            Drink drink2 = new Drink()
            {
                Id = "test2",
                Name = "flag"
            };
            data.Add(drink);
            data.Add(drink2);
            data.SaveChanges();




            shoppingCartService.AddToCart(drink, 1);
            shoppingCartService.AddToCart(drink2, 1);


             shoppingCartService.ClearCart();


            Assert.Equal(0, shoppingCartService.GetShoppingCartItems().Count);
            





        }
        
        [Fact]
        public static void GetShoppingCartTotalPriceShouldReturnSumOfAllPrice()
        {
            var data = DatabaseMock.Instance;

            var cart = new ShoppingCart(data);
            var shoppingCartService = new ShoppingCartService(data, cart);



            Drink drink = new Drink()
            {
                Id = "flag",
                Name = "flag",
                Price = 10
            };


            Drink drink2 = new Drink()
            {
                Id = "test2",
                Name = "flag",
                Price = 20,
            };
            data.Add(drink);
            data.Add(drink2);
            data.SaveChanges();




            shoppingCartService.AddToCart(drink, 1);
            shoppingCartService.AddToCart(drink2, 1);


          var result=   shoppingCartService.GetShoppingCartTotal();


            Assert.Equal(30, result);
            





        }

        [Fact]
        public static void GiveCartToViewSHouldReturnShoppingCar()
        {
            var data = DatabaseMock.Instance;

            var cart = new ShoppingCart(data);
            var shoppingCartService = new ShoppingCartService(data, cart);



            Drink drink = new Drink()
            {
                Id = "flag",
                Name = "flag",
                Price = 10
            };


            Drink drink2 = new Drink()
            {
                Id = "test2",
                Name = "flag",
                Price = 20,
            };
            data.Add(drink);
            data.Add(drink2);
            data.SaveChanges();




            shoppingCartService.AddToCart(drink, 1);
            shoppingCartService.AddToCart(drink2, 1);


            var result = shoppingCartService.GiveCartToView();


            Assert.IsType<ShoppingCart>(result);

        }

        [Fact]
        public static void SelectDrinkShouldReturnDesiredDrink()
        {
            var data = DatabaseMock.Instance;

            var cart = new ShoppingCart(data);
            var shoppingCartService = new ShoppingCartService(data, cart);



            Drink drink = new Drink()
            {
                Id = "flag",
                Name = "flag",
                Price = 10
            };


            Drink drink2 = new Drink()
            {
                Id = "test2",
                Name = "flag",
                Price = 20,
            };
            data.Add(drink);
            data.Add(drink2);
            data.SaveChanges();




            shoppingCartService.AddToCart(drink, 1);
            shoppingCartService.AddToCart(drink2, 1);


          var result=   shoppingCartService.SelectedDrink("test2");


          Assert.Equal("test2",result.Id);
          Assert.IsType<Drink>(result);



        }
        [Fact]
        public static void SelectDrinkShouldReturnNull()
        {
            var data = DatabaseMock.Instance;

            var cart = new ShoppingCart(data);
            var shoppingCartService = new ShoppingCartService(data, cart);



            Drink drink = new Drink()
            {
                Id = "flag",
                Name = "flag",
                Price = 10
            };


            Drink drink2 = new Drink()
            {
                Id = "test2",
                Name = "flag",
                Price = 20,
            };
            data.Add(drink);
            data.SaveChanges();


            var result = shoppingCartService.SelectedDrink(null);


            Assert.Null(result);
            



        }


        [Fact]
        public static void CountShouldReturnValidAmountCount()
        {
            var data = DatabaseMock.Instance;

            var cart = new ShoppingCart(data);
            var shoppingCartService = new ShoppingCartService(data, cart);



            Drink drink = new Drink()
            {
                Id = "flag",
                Name = "flag",
                Price = 10
            };


            Drink drink2 = new Drink()
            {
                Id = "test2",
                Name = "flag",
                Price = 20,
            };
            data.Add(drink);
            data.SaveChanges();


            var result = shoppingCartService.CountCartItems(shoppingCartService.GetShoppingCartItems());


            Assert.NotNull(result);
            Equals(1, result);




        }

        [Fact]
        public static void CountShouldReturnInt()
        {
            var data = DatabaseMock.Instance;

            var cart = new ShoppingCart(data);
            var shoppingCartService = new ShoppingCartService(data, cart);



            Drink drink = new Drink()
            {
                Id = "flag",
                Name = "flag",
                Price = 10
            };


            Drink drink2 = new Drink()
            {
                Id = "test2",
                Name = "flag",
                Price = 20,
            };
            data.Add(drink);
            data.SaveChanges();


            var result = shoppingCartService.CountCartItems(shoppingCartService.GetShoppingCartItems());

            var expected = result.GetType();
            Assert.Equal(typeof(int),expected);
        }



        [Fact]
        public static void CountShouldReturnError()
        {
            var data = DatabaseMock.Instance;

            var cart = new ShoppingCart(data);
            var shoppingCartService = new ShoppingCartService(data, cart);



            var result = shoppingCartService.CountCartItems(shoppingCartService.GetShoppingCartItems());

            Assert.NotNull(result);
           Assert.Equal(0,result);




        }
    }
}

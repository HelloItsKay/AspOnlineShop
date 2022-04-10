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
        public static void GetShoppingCartItemsReturnValueLikeLIstShopingCartItem()
        {
            var data = DatabaseMock.Instance;

            var cart = new ShoppingCart(data);
            var shoppingCartService = new ShoppingCartService(data, cart);



            Drink drink = new Drink()
            {
                Id = "test",
                Name = "test"
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

        [Fact] public static void AddItemToCartShouldIncreaseValue()
        {
            var data = DatabaseMock.Instance;

            var cart = new ShoppingCart(data);
            var shoppingCartService = new ShoppingCartService(data, cart);



            Drink drink = new Drink()
            {
                Id = "test",
                Name = "test"
            };

            Drink drink2 = new Drink()
            {
                Id = "test2",
                Name = "test"
            };
            data.Add(drink);
            data.Add(drink2);
            data.SaveChanges();



           shoppingCartService.AddToCart(drink,2);
           shoppingCartService.AddToCart(drink2,4);


            Assert.Equal(2,data.ShoppingCartItems.Count());
            


        }

        [Fact]
        public static void RemoveItemFromCart()
        {
            var data = DatabaseMock.Instance;

            var cart = new ShoppingCart(data);
            var shoppingCartService = new ShoppingCartService(data, cart);



            Drink drink = new Drink()
            {
                Id = "test",
                Name = "test"
            };


            Drink drink2 = new Drink()
            {
                Id = "test2",
                Name = "test"
            };
            data.Add(drink);
            data.Add(drink2);
            data.SaveChanges();

           


            shoppingCartService.AddToCart(drink, 1);
            shoppingCartService.AddToCart(drink2, 1);
            shoppingCartService.RemoveFromCart(drink);
            

            var result = data.ShoppingCartItems;


            Assert.Equal(1, data.ShoppingCartItems.Count());



        }

        [Fact]
        public static void GetShopingCartItemsShouldReturnValues()
        {
            var data = DatabaseMock.Instance;

            var cart = new ShoppingCart(data);
            var shoppingCartService = new ShoppingCartService(data, cart);



            Drink drink = new Drink()
            {
                Id = "test",
                Name = "test"
            };


            Drink drink2 = new Drink()
            {
                Id = "test2",
                Name = "test"
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
        public static void ClearShoppingCartShouldReturnZero()
        {
            var data = DatabaseMock.Instance;

            var cart = new ShoppingCart(data);
            var shoppingCartService = new ShoppingCartService(data, cart);



            Drink drink = new Drink()
            {
                Id = "test",
                Name = "test"
            };


            Drink drink2 = new Drink()
            {
                Id = "test2",
                Name = "test"
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
                Id = "test",
                Name = "test",
                Price = 10
            };


            Drink drink2 = new Drink()
            {
                Id = "test2",
                Name = "test",
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
                Id = "test",
                Name = "test",
                Price = 10
            };


            Drink drink2 = new Drink()
            {
                Id = "test2",
                Name = "test",
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
                Id = "test",
                Name = "test",
                Price = 10
            };


            Drink drink2 = new Drink()
            {
                Id = "test2",
                Name = "test",
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
    }
}

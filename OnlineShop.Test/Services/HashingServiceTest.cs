using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Data.Models;
using ASP.NET_Core_OnlineShop.Services;
using ASP.NET_Core_OnlineShop.Services.Drinks;
using Moq;
using OnlineShop.Test.Mocks;
using Xunit;

namespace OnlineShop.Test.Services
{
    public class HashingServiceTest
    {
        [Fact]
        public void ReturnedStringShouldBeEqualIfDecrypt()
        {

            var service = new HashingService();

            var testName = "TestURLName123";


            var resultA = service.Encrypt(testName);
            var resultB = service.Decrypt(resultA);

            Assert.Equal(testName, resultB);

        }


    }
}

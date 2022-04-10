using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_Core_OnlineShop.Data;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Test.Mocks
{
    public static class DatabaseMock
    {
        public static OnlineShopDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<OnlineShopDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
                return new OnlineShopDbContext(dbContextOptions);
            }
        }
    }
}

namespace ASP.NET_Core_OnlineShop.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ASP.NET_Core_OnlineShop.Areas.Admin.Controllers;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Routing;
    public static class EndPointRouteBuilderExtensions
    {
        public static void MapDefaultAreaRoute(this IEndpointRouteBuilder endpoints)
            => endpoints.MapControllerRoute(
                name: "Areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );

    }
}

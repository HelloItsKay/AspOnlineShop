#pragma checksum "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\AllDrinks.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "449091b6668b4f28bfa84a18f722980db85905ab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Drinks_AllDrinks), @"mvc.1.0.view", @"/Views/Drinks/AllDrinks.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\_ViewImports.cshtml"
using ASP.NET_Core_OnlineShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\_ViewImports.cshtml"
using ASP.NET_Core_OnlineShop.Models.ShoppingCart;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\_ViewImports.cshtml"
using ASP.NET_Core_OnlineShop.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\_ViewImports.cshtml"
using ASP.NET_Core_OnlineShop.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\_ViewImports.cshtml"
using ASP.NET_Core_OnlineShop.Models.Drinks;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\_ViewImports.cshtml"
using ASP.NET_Core_OnlineShop.Data.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\_ViewImports.cshtml"
using static ASP.NET_Core_OnlineShop.WebConstants;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\AllDrinks.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\AllDrinks.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\AllDrinks.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"449091b6668b4f28bfa84a18f722980db85905ab", @"/Views/Drinks/AllDrinks.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fdceb0796ee2e6fe392c83e262425f23adb63d9", @"/Views/_ViewImports.cshtml")]
    public class Views_Drinks_AllDrinks : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IPagedList<DrinksListingViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\AllDrinks.cshtml"
Write(Html.PagedListPager((IPagedList)Model, page => Url.Action("AllDrinks", new { page = page }),
    new X.PagedList.Mvc.Common.PagedListRenderOptions
    {
        DisplayItemSliceAndTotal = true,
        ContainerDivClasses = new[] { "navigation" },
        LiElementClasses = new[] { "page-item" },
        PageClasses = new[] { "page-link" },
    }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 14 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\AllDrinks.cshtml"
Write(Html.Partial("VisualiseDrinksListingViewModelPartial"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 16 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\AllDrinks.cshtml"
Write(Html.PagedListPager((IPagedList)Model, page => Url.Action("AllDrinks", new { page = page }),
    new X.PagedList.Mvc.Common.PagedListRenderOptions
    {
        DisplayItemSliceAndTotal = true,
        ContainerDivClasses = new[] { "navigation" },
        LiElementClasses = new[] { "page-item" },
        PageClasses = new[] { "page-link" },
    }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IPagedList<DrinksListingViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591

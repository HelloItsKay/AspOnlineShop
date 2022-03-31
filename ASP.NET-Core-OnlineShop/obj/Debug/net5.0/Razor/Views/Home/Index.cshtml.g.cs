#pragma checksum "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0663040dbdc341a32d7837a2cafbfea41d1c1a5b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
using ASP.NET_Core_OnlineShop.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\_ViewImports.cshtml"
using ASP.NET_Core_OnlineShop.Models.Drinks;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\_ViewImports.cshtml"
using ASP.NET_Core_OnlineShop.Data.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\_ViewImports.cshtml"
using static ASP.NET_Core_OnlineShop.WebConstants;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Home\Index.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0663040dbdc341a32d7837a2cafbfea41d1c1a5b", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a63184b9156780b8dcb06ba19922a4e443b52940", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DrinksListingViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 4 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Home\Index.cshtml"
 if (!Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1>Currently there are no available drinks in the store. Contact Moderator to Add drinks.</h1>\n");
#nullable restore
#line 7 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>Our Latest Drinks</h1>\n<div class=\"mb-5\"></div>\n    <div id=\"carouselExampleControls\" class=\"carousel slide\" data-ride=\"carousel\">\n        <div class=\"carousel-inner\">\n");
#nullable restore
#line 13 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Home\Index.cshtml"
             for (int i = 0; i < Model.Count; i++)
            {
                var drink = Model[i];
                

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div");
            BeginWriteAttribute("class", " class=\"", 501, "\"", 558, 2);
            WriteAttributeValue("", 509, "carousel-item", 509, 13, true);
#nullable restore
#line 17 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Home\Index.cshtml"
WriteAttributeValue(" ", 522, i == 0 ? "active" : string.Empty, 523, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                    <div class=\"container\">\n                        <img class=\"d-block \"");
            BeginWriteAttribute("src", " src=\"", 650, "\"", 680, 1);
#nullable restore
#line 19 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Home\Index.cshtml"
WriteAttributeValue("", 656, drink.ImageThumbnailUrl, 656, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" >\n\n                        <h5>");
#nullable restore
#line 21 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Home\Index.cshtml"
                       Write(drink.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 21 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Home\Index.cshtml"
                                   Write(drink.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 21 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Home\Index.cshtml"
                                                   Write(drink.Price.ToString("C", CultureInfo.GetCultureInfo("bg-BG")));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n                    </div>\n                </div>\n");
#nullable restore
#line 24 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Home\Index.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </div>
        <a class=""carousel-control-prev"" href=""#carouselExampleControls"" role=""button"" data-slide=""prev"">
            <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
            <span class=""sr-only"">Previous</span>
        </a>
        <a class=""carousel-control-next"" href=""#carouselExampleControls"" role=""button"" data-slide=""next"">
            <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
            <span class=""sr-only"">Next</span>
        </a>
    </div>

    <h1>This is online store for getting drinks. Some of the drinks contain alcohol so u need to be 18+ to buy one. Unless you are from Bulgaria then u don`t need age restriction. </h1>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DrinksListingViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\AlcoholicDrinks.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2d1be21a7af0ea61fac1dc648f9f3ada2a89542b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Drinks_AlcoholicDrinks), @"mvc.1.0.view", @"/Views/Drinks/AlcoholicDrinks.cshtml")]
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
#line 1 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\AlcoholicDrinks.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d1be21a7af0ea61fac1dc648f9f3ada2a89542b", @"/Views/Drinks/AlcoholicDrinks.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57802b602c90b62850637cb80ad7ffc6fb96bef8", @"/Views/_ViewImports.cshtml")]
    public class Views_Drinks_AlcoholicDrinks : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DrinksListingViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Drinks", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"row\">\r\n");
#nullable restore
#line 4 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\AlcoholicDrinks.cshtml"
     foreach (var drink in Model)
    {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"body col-md-3\">\r\n            <div class=\"card\">\r\n                <img class=\"card-img-top\" style=\"width: 100%; height: 30%;\"");
            BeginWriteAttribute("src", " src=\"", 273, "\"", 303, 1);
#nullable restore
#line 9 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\AlcoholicDrinks.cshtml"
WriteAttributeValue("", 279, drink.ImageThumbnailUrl, 279, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 304, "\"", 358, 3);
#nullable restore
#line 9 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\AlcoholicDrinks.cshtml"
WriteAttributeValue("", 310, drink.Name, 310, 11, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\AlcoholicDrinks.cshtml"
WriteAttributeValue(" ", 321, drink.Price, 322, 12, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\AlcoholicDrinks.cshtml"
WriteAttributeValue(" ", 334, drink.ShortDescription, 335, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"card-body\">\r\n                    <h2 class=\"card-title\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2d1be21a7af0ea61fac1dc648f9f3ada2a89542b6633", async() => {
#nullable restore
#line 12 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\AlcoholicDrinks.cshtml"
                                                                                            Write(drink.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 12 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\AlcoholicDrinks.cshtml"
                                                                          WriteLiteral(drink.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
#nullable restore
#line 13 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\AlcoholicDrinks.cshtml"
                   Write(drink.Price.ToString("C", CultureInfo.GetCultureInfo("bg-BG")));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </h2>\r\n                    <h5 class=\"card-body\"> ");
#nullable restore
#line 15 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\AlcoholicDrinks.cshtml"
                                      Write(drink.ShortDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h5>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2d1be21a7af0ea61fac1dc648f9f3ada2a89542b10121", async() => {
                WriteLiteral("View");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 16 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\AlcoholicDrinks.cshtml"
                                                                      WriteLiteral(drink.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 20 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\AlcoholicDrinks.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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

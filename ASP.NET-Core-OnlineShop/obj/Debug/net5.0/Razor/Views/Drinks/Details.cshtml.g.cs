#pragma checksum "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8583f3832133d6046a9613169535c1f5a56e3c67"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Drinks_Details), @"mvc.1.0.view", @"/Views/Drinks/Details.cshtml")]
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
#line 7 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\_ViewImports.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8583f3832133d6046a9613169535c1f5a56e3c67", @"/Views/Drinks/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a63184b9156780b8dcb06ba19922a4e443b52940", @"/Views/_ViewImports.cshtml")]
    public class Views_Drinks_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IQueryable<DrinksListingViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("cartButton"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ShoppingCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToShoppingCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\Details.cshtml"
 foreach (var Model in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"body col-md-4\">\n    <div class=\"card\">\n        <img class=\"card-img-top\"");
            BeginWriteAttribute("src", "  src=\"", 159, "\"", 181, 1);
#nullable restore
#line 7 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\Details.cshtml"
WriteAttributeValue("", 166, Model.ImageUrl, 166, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 182, "\"", 223, 2);
#nullable restore
#line 7 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\Details.cshtml"
WriteAttributeValue("", 188, Model.Name, 188, 11, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\Details.cshtml"
WriteAttributeValue("  ", 199, Model.LongDescription, 201, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n        <div class=\"card-body\">\n\n            <h5 class=\"card-body\"> ");
#nullable restore
#line 10 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\Details.cshtml"
                              Write(Model.LongDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h5>\n\n        </div>\n        <p class=\"button \">\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8583f3832133d6046a9613169535c1f5a56e3c677348", async() => {
                WriteLiteral("\n            Add to cart\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-drinkId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 14 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\Details.cshtml"
                                                                                                                       WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["drinkId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-drinkId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["drinkId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    </div>\n</div>\n");
#nullable restore
#line 19 "C:\Users\krust\source\repos\!ASP.NET-Core-OnlineShop\AspOnlineShop\ASP.NET-Core-OnlineShop\Views\Drinks\Details.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IQueryable<DrinksListingViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\ASUS\source\repos\MultiShopBackEndProject\MultiShopBackEndProject\Views\Shared\_ClothePartialView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "798c095fa5e3974963473630e4db8e4ffda25c99"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ClothePartialView), @"mvc.1.0.view", @"/Views/Shared/_ClothePartialView.cshtml")]
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
#line 1 "C:\Users\ASUS\source\repos\MultiShopBackEndProject\MultiShopBackEndProject\Views\_ViewImports.cshtml"
using MultiShopBackEndProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\ASUS\source\repos\MultiShopBackEndProject\MultiShopBackEndProject\Views\Shared\_ClothePartialView.cshtml"
using MultiShopBackEndProject.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"798c095fa5e3974963473630e4db8e4ffda25c99", @"/Views/Shared/_ClothePartialView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"45d6d94f4230fdda81a660da39d1b96165898c30", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__ClothePartialView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Clothe>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid w-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-dark btn-square"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "addcart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("    <div class=\"container-fluid pt-5 pb-3\">\r\n        <h2 class=\"section-title position-relative text-uppercase mx-xl-5 mb-4\"><span class=\"bg-secondary pr-3\">Featured Products</span></h2>\r\n        <div class=\"row px-xl-5\">\r\n");
#nullable restore
#line 6 "C:\Users\ASUS\source\repos\MultiShopBackEndProject\MultiShopBackEndProject\Views\Shared\_ClothePartialView.cshtml"
         foreach (Clothe item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("               <div class=\"col-lg-3 col-md-4 col-sm-6 pb-1\">\r\n                <div class=\"product-item bg-light mb-4\">\r\n                    <div class=\"product-img position-relative overflow-hidden\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "798c095fa5e3974963473630e4db8e4ffda25c995874", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 598, "~/assets/img/", 598, 13, true);
#nullable restore
#line 11 "C:\Users\ASUS\source\repos\MultiShopBackEndProject\MultiShopBackEndProject\Views\Shared\_ClothePartialView.cshtml"
AddHtmlAttributeValue("", 611, item.ClotheImages.FirstOrDefault(c=>c.IsMain == true).Image, 611, 60, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <div class=\"product-action\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "798c095fa5e3974963473630e4db8e4ffda25c997690", async() => {
                WriteLiteral("<i class=\"fa fa-shopping-cart\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 13 "C:\Users\ASUS\source\repos\MultiShopBackEndProject\MultiShopBackEndProject\Views\Shared\_ClothePartialView.cshtml"
                                                                                                                    WriteLiteral(item.Id);

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
            WriteLiteral("\r\n                            <a class=\"btn btn-outline-dark btn-square\"");
            BeginWriteAttribute("href", " href=\"", 985, "\"", 992, 0);
            EndWriteAttribute();
            WriteLiteral("><i class=\"far fa-heart\"></i></a>\r\n                            <a class=\"btn btn-outline-dark btn-square\"");
            BeginWriteAttribute("href", " href=\"", 1098, "\"", 1105, 0);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-sync-alt\"></i></a>\r\n                            <a class=\"btn btn-outline-dark btn-square\"");
            BeginWriteAttribute("href", " href=\"", 1213, "\"", 1220, 0);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-search\"></i></a>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"text-center py-4\">\r\n                        <a class=\"h6 text-decoration-none text-truncate\"");
            BeginWriteAttribute("href", " href=\"", 1440, "\"", 1447, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 20 "C:\Users\ASUS\source\repos\MultiShopBackEndProject\MultiShopBackEndProject\Views\Shared\_ClothePartialView.cshtml"
                                                                            Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                        <div class=\"d-flex align-items-center justify-content-center mt-2\">\r\n                            <h5>$");
#nullable restore
#line 22 "C:\Users\ASUS\source\repos\MultiShopBackEndProject\MultiShopBackEndProject\Views\Shared\_ClothePartialView.cshtml"
                            Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5><h6 class=""text-muted ml-2""><del></del></h6>
                        </div>
                        <div class=""d-flex align-items-center justify-content-center mb-1"">
                            <small class=""fa fa-star text-primary mr-1""></small>
                            <small class=""fa fa-star text-primary mr-1""></small>
                            <small class=""fa fa-star text-primary mr-1""></small>
                            <small class=""fa fa-star text-primary mr-1""></small>
                            <small class=""fa fa-star text-primary mr-1""></small>
                            <small>(99)</small>
                        </div>
                    </div>
                </div>
            </div>
");
#nullable restore
#line 35 "C:\Users\ASUS\source\repos\MultiShopBackEndProject\MultiShopBackEndProject\Views\Shared\_ClothePartialView.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n    </div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Clothe>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

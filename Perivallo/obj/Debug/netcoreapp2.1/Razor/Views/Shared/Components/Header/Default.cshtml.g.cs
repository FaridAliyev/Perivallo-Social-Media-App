#pragma checksum "E:\Projects\Perivallo\Views\Shared\Components\Header\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "acba7cf13beb1d13e0f9fb8d617f8a12dd41e446"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Header_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Header/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/Header/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_Header_Default))]
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
#line 1 "E:\Projects\Perivallo\Views\_ViewImports.cshtml"
using Perivallo.Models;

#line default
#line hidden
#line 2 "E:\Projects\Perivallo\Views\_ViewImports.cshtml"
using Perivallo.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acba7cf13beb1d13e0f9fb8d617f8a12dd41e446", @"/Views/Shared/Components/Header/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6889e9cd2d00d20df89ea5837d4da3a2ecb2ef6", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Header_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NavbarVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Search/Filter"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Profile Picture"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/profile-placeholder.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(17, 166, true);
            WriteLiteral("\r\n<nav id=\"navbar\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-3\">\r\n                <div class=\"logo\">\r\n                    ");
            EndContext();
            BeginContext(183, 57, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "93f85fc74db3473e8bc771890a647f27", async() => {
                BeginContext(227, 9, true);
                WriteLiteral("Perivallo");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(240, 141, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"col-5\">\r\n                <div class=\"search-bar\">\r\n                    ");
            EndContext();
            BeginContext(381, 754, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "22865465898544bfb3f31d80d9c04198", async() => {
                BeginContext(424, 704, true);
                WriteLiteral(@"
                        <div class=""form-group justify-content-center"">
                            <div class=""search-field-wrapper"">
                                <input type=""text"" name=""search"" class=""search-field"" id=""nav-search"" placeholder=""Search"" autocomplete=""off"">
                                <ul class=""search-results-list"">
                                    
                                </ul>
                                <span class=""search-icon""><i class=""fas fa-search""></i></span>
                                <span class=""clear-icon""><i class=""fas fa-times""></i></span>
                            </div>
                        </div>
                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1135, 449, true);
            WriteLiteral(@"
                </div>
                <div class=""search-bar-mb"">
                    <a href=""/Search/Index"">
                        <div class=""icon-wrapper"">
                            <i class=""fas fa-search""></i>
                        </div>
                    </a>
                </div>
            </div>
            <div class=""col-4"">
                <div class=""nav-items"">
                    <ul class=""navigation"">
");
            EndContext();
#line 37 "E:\Projects\Perivallo\Views\Shared\Components\Header\Default.cshtml"
                          string controller = @ViewContext.RouteData.Values["controller"].ToString();

#line default
#line hidden
            BeginContext(1688, 24, true);
            WriteLiteral("                        ");
            EndContext();
#line 38 "E:\Projects\Perivallo\Views\Shared\Components\Header\Default.cshtml"
                         if (controller == "Home")
                        {

#line default
#line hidden
            BeginContext(1767, 99, true);
            WriteLiteral("                            <li class=\"nav-item active-nav-item\">\r\n                                ");
            EndContext();
            BeginContext(1866, 161, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac612f0b0e6648c49cae73bd471a407d", async() => {
                BeginContext(1910, 113, true);
                WriteLiteral("\r\n                                    <i class=\"fas fa-home nav-item-icon\"></i>\r\n                                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2027, 37, true);
            WriteLiteral("\r\n                            </li>\r\n");
            EndContext();
#line 45 "E:\Projects\Perivallo\Views\Shared\Components\Header\Default.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(2148, 83, true);
            WriteLiteral("                            <li class=\"nav-item\">\r\n                                ");
            EndContext();
            BeginContext(2231, 161, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f49c4f19002e4539969aa4bed8a6eaba", async() => {
                BeginContext(2275, 113, true);
                WriteLiteral("\r\n                                    <i class=\"fas fa-home nav-item-icon\"></i>\r\n                                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2392, 37, true);
            WriteLiteral("\r\n                            </li>\r\n");
            EndContext();
#line 53 "E:\Projects\Perivallo\Views\Shared\Components\Header\Default.cshtml"
                        }

#line default
#line hidden
            BeginContext(2456, 6120, true);
            WriteLiteral(@"                        <li class=""nav-item"">
                            <a href=""#"">
                                <i class=""fas fa-envelope nav-item-icon""></i>
                                <!-- <i class=""fas fa-circle new-icon""></i> -->
                            </a>
                        </li>
                        <li class=""nav-item"">
                            <a href=""#"" class=""notification"">
                                <i class=""fas fa-bell nav-item-icon""></i>
                                <!-- <i class=""fas fa-circle new-icon""></i> -->
                            </a>
                            <ul class=""notification-dropdown"">
                                <li class=""follow-request-item"">
                                    <div class=""follow-request-wrapper"">
                                        <div class=""request-caption"">
                                            <h6>Follow Requests</h6>
                                        </div>
                 ");
            WriteLiteral(@"                       <div class=""request-body"">
                                            <a href=""#"">
                                                <img src=""img/profile-placeholder.png"" alt=""Profile"">
                                            </a>
                                            <a href=""#"" class=""username"">_farid__aliyev_</a>
                                            <div class=""action-buttons"">
                                                <button type=""button""
                                                        class=""confirm-button action-btn"">
                                                    Confirm
                                                </button>
                                                <button type=""button""
                                                        class=""ignore-button action-btn"">
                                                    Ignore
                                                </button>
                              ");
            WriteLiteral(@"              </div>
                                        </div>
                                        <div class=""request-body"">
                                            <a href=""#"">
                                                <img src=""img/profile-placeholder.png"" alt=""Profile"">
                                            </a>
                                            <a href=""#"" class=""username"">_farid__aliyev_</a>
                                            <div class=""action-buttons"">
                                                <button type=""button""
                                                        class=""confirm-button action-btn"">
                                                    Confirm
                                                </button>
                                                <button type=""button""
                                                        class=""ignore-button action-btn"">
                                                    Ignore
  ");
            WriteLiteral(@"                                              </button>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                                <li class=""notification-item"">
                                    <a href=""#"">
                                        <div class=""notification-wrapper"">
                                            <div class=""noti-profile-pic"">
                                                <img src=""img/profile-placeholder.png"" alt=""Profile"">
                                            </div>
                                            <div class=""text"">
                                                <h6 class=""username"">_farid__aliyev_</h6>
                                                <p class=""action"">liked your photo</p>
                                            </div>
                                        </div>
                    ");
            WriteLiteral(@"                </a>
                                </li>
                                <li class=""notification-item"">
                                    <a href=""#"">
                                        <div class=""notification-wrapper"">
                                            <div class=""noti-profile-pic"">
                                                <img src=""img/profile-placeholder.png"" alt=""Profile"">
                                            </div>
                                            <div class=""text"">
                                                <h6 class=""username"">_farid__aliyev_</h6>
                                                <p class=""action"">liked your photo</p>
                                            </div>
                                            <!-- <div class=""image"">
                            <img src=""img/profile-placeholder.png"" alt="""">
                        </div> -->
                                            <!-- <div class=""butt");
            WriteLiteral(@"on-wrapper"">
                            <button type=""button"" class=""follow-button action-btn"">Follow</button>
                            <button type=""button"" class=""following-button action-btn"">Following</button>
                            <button type=""button"" class=""requested-button action-btn"">Requested</button>
                        </div> -->
                                        </div>
                                    </a>
                                </li>
                                <li class=""see-all-item"">
                                    <a href=""#"" class=""see-all"">
                                        See All <i class=""fas fa-angle-double-right see-all-icon""></i>
                                    </a>
                                </li>
                            </ul>
                            <div class=""triangle""></div>
                        </li>
                        <li class=""nav-item"">
                            ");
            EndContext();
            BeginContext(8576, 693, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "21fed689e61643c99f71618338b8f419", async() => {
                BeginContext(8664, 61, true);
                WriteLiteral("\r\n                                <div class=\"profile-pic\">\r\n");
                EndContext();
#line 150 "E:\Projects\Perivallo\Views\Shared\Components\Header\Default.cshtml"
                                     if (Model.User.Avatar != null)
                                    {

#line default
#line hidden
                BeginContext(8833, 40, true);
                WriteLiteral("                                        ");
                EndContext();
                BeginContext(8873, 58, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f5b50d86fc1949ec855d6f511ad6b043", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 8883, "~/img/", 8883, 6, true);
#line 152 "E:\Projects\Perivallo\Views\Shared\Components\Header\Default.cshtml"
AddHtmlAttributeValue("", 8889, Model.User.Avatar, 8889, 18, false);

#line default
#line hidden
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(8931, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 153 "E:\Projects\Perivallo\Views\Shared\Components\Header\Default.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
                BeginContext(9053, 40, true);
                WriteLiteral("                                        ");
                EndContext();
                BeginContext(9093, 63, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a79586464e194bb0b97c7e84a6ac9169", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(9156, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 157 "E:\Projects\Perivallo\Views\Shared\Components\Header\Default.cshtml"
                                    }

#line default
#line hidden
                BeginContext(9197, 68, true);
                WriteLiteral("                                </div>\r\n                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-username", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 148 "E:\Projects\Perivallo\Views\Shared\Components\Header\Default.cshtml"
                                                                                   WriteLiteral(User.Identity.Name);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["username"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-username", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["username"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(9269, 280, true);
            WriteLiteral(@"
                        </li>
                    </ul>
                    <div class=""nav-res-btn"">
                        <i class=""fas fa-bars collapse-icon""></i>
                    </div>
                </div>
            </div>
        </div>
    </div>
</nav>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NavbarVM> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "E:\Projects\Perivallo\Views\Account\Friends.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "05a464d7f9e3a35f8f15a3434ed7fc56542ae7e9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Friends), @"mvc.1.0.view", @"/Views/Account/Friends.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/Friends.cshtml", typeof(AspNetCore.Views_Account_Friends))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05a464d7f9e3a35f8f15a3434ed7fc56542ae7e9", @"/Views/Account/Friends.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6889e9cd2d00d20df89ea5837d4da3a2ecb2ef6", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Friends : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AccountVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/cover.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Cover"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/profile-placeholder.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Profile Picture"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Friends", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("follower-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
  
    ViewData["Title"] = "Friends";

#line default
#line hidden
            BeginContext(61, 102, true);
            WriteLiteral("\r\n<main id=\"profile\">\r\n    <section id=\"profile-cover\">\r\n        <div class=\"profile-cover-wrapper\">\r\n");
            EndContext();
#line 9 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
             if (Model.User.Cover == null)
            {

#line default
#line hidden
            BeginContext(222, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(238, 39, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "77f68883e8bb4dfcb7eadf935827bef0", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(277, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 12 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(327, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(343, 47, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ea254819ab694cfdb5e07983cfecbd0d", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 353, "~/img/", 353, 6, true);
#line 15 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
AddHtmlAttributeValue("", 359, Model.User.Cover, 359, 17, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(390, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 16 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
            }

#line default
#line hidden
            BeginContext(407, 295, true);
            WriteLiteral(@"        </div>
    </section>
    <section id=""profile-info"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-4 col-md-4 col-sm-12"">
                    <div class=""left-side-wrapper"">
                        <div class=""profile-avatar"">
");
            EndContext();
#line 25 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
                             if (Model.User.Avatar == null)
                            {

#line default
#line hidden
            BeginContext(794, 32, true);
            WriteLiteral("                                ");
            EndContext();
            BeginContext(826, 63, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "0e6867e9632d4f6097b304bbddf69236", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(889, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 28 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
                            }
                            else
                            {

#line default
#line hidden
            BeginContext(987, 32, true);
            WriteLiteral("                                ");
            EndContext();
            BeginContext(1019, 58, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "408c435132ed40e298fcf9fbea3a44b7", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1029, "~/img/", 1029, 6, true);
#line 31 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
AddHtmlAttributeValue("", 1035, Model.User.Avatar, 1035, 18, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1077, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 32 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
                            }

#line default
#line hidden
            BeginContext(1110, 290, true);
            WriteLiteral(@"                        </div>
                    </div>
                </div>
                <div class=""col-lg-8 col-md-8 col-sm-12"">
                    <div class=""right-side-wrapper"">
                        <div class=""head"">
                            <h2 class=""username"">");
            EndContext();
            BeginContext(1401, 19, false);
#line 39 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
                                            Write(Model.User.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(1420, 565, true);
            WriteLiteral(@"</h2>
                            <div class=""actions"">
                                <button type=""button"" class=""action-btn follow-button"">Follow</button>
                                <div class=""profile-dropdown"">
                                    <div class=""profile-dropdown-button"">
                                        <i class=""fas fa-ellipsis-h""></i>
                                    </div>
                                    <div class=""profile-dropdown-menu"">
                                        <div class=""dropdown-content"">
");
            EndContext();
#line 48 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
                                             if (User.Identity.Name != Model.User.UserName)
                                            {

#line default
#line hidden
            BeginContext(2125, 1235, true);
            WriteLiteral(@"                                                <a href=""#"" class=""profile-dropdown-item"">
                                                    <div class=""media"">
                                                        <i class=""fas fa-ban""></i>
                                                        <div class=""media-content"">
                                                            <h3>Block</h3>
                                                        </div>
                                                    </div>
                                                </a>
                                                <div class=""profile-dropdown-item"" data-toggle=""modal"" data-target=""#user-modal"" data-userid=""3"">
                                                    <div class=""media"">
                                                        <i class=""far fa-flag""></i>
                                                        <div class=""media-content"">
                                              ");
            WriteLiteral("              <h3>Report</h3>\r\n                                                        </div>\r\n                                                    </div>\r\n                                                </div>\r\n");
            EndContext();
#line 66 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
            BeginContext(3504, 593, true);
            WriteLiteral(@"                                                <a href=""#"" class=""profile-dropdown-item"">
                                                    <div class=""media"">
                                                        <i class=""far fa-bookmark""></i>
                                                        <div class=""media-content"">
                                                            <h3>Saved</h3>
                                                        </div>
                                                    </div>
                                                </a>
");
            EndContext();
#line 77 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
                                            }

#line default
#line hidden
            BeginContext(4144, 132, true);
            WriteLiteral("                                        </div>\r\n                                    </div>\r\n                                </div>\r\n");
            EndContext();
#line 81 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
                                 if (User.Identity.Name == Model.User.UserName)
                                {

#line default
#line hidden
            BeginContext(4392, 279, true);
            WriteLiteral(@"                                    <div class=""profile-settings-button"" data-toggle=""modal""
                                         data-target=""#settings-modal"">
                                        <i class=""fas fa-cog""></i>
                                    </div>
");
            EndContext();
#line 87 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
                                }

#line default
#line hidden
            BeginContext(4706, 147, true);
            WriteLiteral("                            </div>\r\n                        </div>\r\n                        <div class=\"stats\">\r\n                            <span>");
            EndContext();
            BeginContext(4854, 17, false);
#line 91 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
                             Write(ViewBag.PostCount);

#line default
#line hidden
            EndContext();
            BeginContext(4871, 49, true);
            WriteLiteral(" Posts</span>\r\n                            <span>");
            EndContext();
            BeginContext(4920, 124, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8a0c7c09987e428e93dbe4914c876314", async() => {
                BeginContext(5012, 20, false);
#line 92 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
                                                                                                                        Write(ViewBag.FriendsCount);

#line default
#line hidden
                EndContext();
                BeginContext(5032, 8, true);
                WriteLiteral(" Friends");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-username", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 92 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
                                                                                           WriteLiteral(Model.User.UserName);

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
            BeginContext(5044, 116, true);
            WriteLiteral("</span>\r\n                        </div>\r\n                        <div class=\"bio\">\r\n                            <h4>");
            EndContext();
            BeginContext(5161, 15, false);
#line 95 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
                           Write(Model.User.Name);

#line default
#line hidden
            EndContext();
            BeginContext(5176, 7, true);
            WriteLiteral("</h4>\r\n");
            EndContext();
#line 96 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
                             if (Model.User.About != null)
                            {

#line default
#line hidden
            BeginContext(5274, 73, true);
            WriteLiteral("                                <p>\r\n                                    ");
            EndContext();
            BeginContext(5348, 16, false);
#line 99 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
                               Write(Model.User.About);

#line default
#line hidden
            EndContext();
            BeginContext(5364, 40, true);
            WriteLiteral("\r\n                                </p>\r\n");
            EndContext();
#line 101 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
                            }

#line default
#line hidden
            BeginContext(5435, 445, true);
            WriteLiteral(@"                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section id=""profile-followers"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-12"">
                    <div class=""box-heading"">
                        <div class=""text"">
                            <h3>Friends</h3>
                        </div>
");
            EndContext();
            BeginContext(6206, 109, true);
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n            <div class=\"row f-row\">\r\n");
            EndContext();
#line 126 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
                 foreach (User item in Model.Friends)
                {

#line default
#line hidden
            BeginContext(6389, 86, true);
            WriteLiteral("                    <div class=\"col-lg-3 col-md-4 col-sm-6\">\r\n                        ");
            EndContext();
            BeginContext(6475, 787, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "560244e9d2dd41c9982dda9f3ab7a889", async() => {
                BeginContext(6580, 60, true);
                WriteLiteral("\r\n                            <div class=\"avatar-wrapper\">\r\n");
                EndContext();
#line 131 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
                                 if (item.Avatar == null)
                                {

#line default
#line hidden
                BeginContext(6734, 36, true);
                WriteLiteral("                                    ");
                EndContext();
                BeginContext(6770, 63, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "814080cb05c74c52804435c26f52337e", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(6833, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 134 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
                                }
                                else
                                {

#line default
#line hidden
                BeginContext(6943, 36, true);
                WriteLiteral("                                    ");
                EndContext();
                BeginContext(6979, 52, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d1860374a5e74147af87d1d9375eaab1", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 6989, "~/img/", 6989, 6, true);
#line 137 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
AddHtmlAttributeValue("", 6995, item.Avatar, 6995, 12, false);

#line default
#line hidden
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(7031, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 138 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
                                }

#line default
#line hidden
                BeginContext(7068, 85, true);
                WriteLiteral("                            </div>\r\n                            <h3 class=\"username\">");
                EndContext();
                BeginContext(7154, 13, false);
#line 140 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
                                            Write(item.UserName);

#line default
#line hidden
                EndContext();
                BeginContext(7167, 51, true);
                WriteLiteral("</h3>\r\n                            <p class=\"name\">");
                EndContext();
                BeginContext(7219, 9, false);
#line 141 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
                                       Write(item.Name);

#line default
#line hidden
                EndContext();
                BeginContext(7228, 30, true);
                WriteLiteral("</p>\r\n                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-username", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 129 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
                                                                               WriteLiteral(item.UserName);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["username"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-username", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["username"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(7262, 30, true);
            WriteLiteral("\r\n                    </div>\r\n");
            EndContext();
#line 144 "E:\Projects\Perivallo\Views\Account\Friends.cshtml"
                }

#line default
#line hidden
            BeginContext(7311, 61, true);
            WriteLiteral("            </div>\r\n        </div>\r\n    </section>\r\n</main>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AccountVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
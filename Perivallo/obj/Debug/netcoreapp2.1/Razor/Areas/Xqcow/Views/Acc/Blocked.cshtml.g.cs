#pragma checksum "E:\Projects\Perivallo\Areas\Xqcow\Views\Acc\Blocked.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f7d9c4f06612dc801d2a613d10d90d50b677bacd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Xqcow_Views_Acc_Blocked), @"mvc.1.0.view", @"/Areas/Xqcow/Views/Acc/Blocked.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Xqcow/Views/Acc/Blocked.cshtml", typeof(AspNetCore.Areas_Xqcow_Views_Acc_Blocked))]
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
#line 1 "E:\Projects\Perivallo\Areas\Xqcow\Views\_ViewImports.cshtml"
using Perivallo.Models;

#line default
#line hidden
#line 2 "E:\Projects\Perivallo\Areas\Xqcow\Views\_ViewImports.cshtml"
using Perivallo.ViewModels;

#line default
#line hidden
#line 3 "E:\Projects\Perivallo\Areas\Xqcow\Views\_ViewImports.cshtml"
using Perivallo.Areas.Xqcow.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7d9c4f06612dc801d2a613d10d90d50b677bacd", @"/Areas/Xqcow/Views/Acc/Blocked.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb88bdc4ae525210ea001a6294d9dce2789433ea", @"/Areas/Xqcow/Views/_ViewImports.cshtml")]
    public class Areas_Xqcow_Views_Acc_Blocked : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ApUserVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Activate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-icon-text"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "E:\Projects\Perivallo\Areas\Xqcow\Views\Acc\Blocked.cshtml"
  
    ViewData["Title"] = "Blocked Users";

#line default
#line hidden
            BeginContext(79, 1199, true);
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-lg-12 grid-margin stretch-card"">
        <div class=""card"">
            <div class=""card-body"">
                <h4 class=""card-title"">User List</h4>
                <p class=""card-description"">
                    Here you can see all admin users
                </p>
                <div class=""table-responsive pt-3"">
                    <table class=""table table-bordered"">
                        <thead>
                            <tr>
                                <th>
                                    Username
                                </th>
                                <th>
                                    Name
                                </th>
                                <th>
                                    Email
                                </th>
                                <th>
                                    Role
                                </th>
                                <th>
          ");
            WriteLiteral("                          Action\r\n                                </th>\r\n                            </tr>\r\n                        </thead>\r\n                        <tbody>\r\n");
            EndContext();
#line 36 "E:\Projects\Perivallo\Areas\Xqcow\Views\Acc\Blocked.cshtml"
                             if (Model.Count() > 0)
                            {
                                

#line default
#line hidden
#line 38 "E:\Projects\Perivallo\Areas\Xqcow\Views\Acc\Blocked.cshtml"
                                 foreach (ApUserVM item in Model)
                                {
                                    

#line default
#line hidden
#line 40 "E:\Projects\Perivallo\Areas\Xqcow\Views\Acc\Blocked.cshtml"
                                     if (User.Identity.Name != item.Username)
                                    {

#line default
#line hidden
            BeginContext(1582, 144, true);
            WriteLiteral("                                        <tr>\r\n                                            <td>\r\n                                                ");
            EndContext();
            BeginContext(1727, 13, false);
#line 44 "E:\Projects\Perivallo\Areas\Xqcow\Views\Acc\Blocked.cshtml"
                                           Write(item.Username);

#line default
#line hidden
            EndContext();
            BeginContext(1740, 151, true);
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
            EndContext();
            BeginContext(1892, 9, false);
#line 47 "E:\Projects\Perivallo\Areas\Xqcow\Views\Acc\Blocked.cshtml"
                                           Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1901, 151, true);
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
            EndContext();
            BeginContext(2053, 10, false);
#line 50 "E:\Projects\Perivallo\Areas\Xqcow\Views\Acc\Blocked.cshtml"
                                           Write(item.Email);

#line default
#line hidden
            EndContext();
            BeginContext(2063, 151, true);
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
            EndContext();
            BeginContext(2215, 9, false);
#line 53 "E:\Projects\Perivallo\Areas\Xqcow\Views\Acc\Blocked.cshtml"
                                           Write(item.Role);

#line default
#line hidden
            EndContext();
            BeginContext(2224, 151, true);
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
            EndContext();
            BeginContext(2375, 310, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "39f1cc22ffe84e01a8a4ae427814d0d8", async() => {
                BeginContext(2462, 219, true);
                WriteLiteral("\r\n                                                    Activate\r\n                                                    <i class=\"mdi mdi-account-check btn-icon-append\"></i>\r\n                                                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 56 "E:\Projects\Perivallo\Areas\Xqcow\Views\Acc\Blocked.cshtml"
                                                                           WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2685, 100, true);
            WriteLiteral("\r\n                                            </td>\r\n                                        </tr>\r\n");
            EndContext();
#line 62 "E:\Projects\Perivallo\Areas\Xqcow\Views\Acc\Blocked.cshtml"
                                    }

#line default
#line hidden
#line 62 "E:\Projects\Perivallo\Areas\Xqcow\Views\Acc\Blocked.cshtml"
                                     
                                }

#line default
#line hidden
#line 63 "E:\Projects\Perivallo\Areas\Xqcow\Views\Acc\Blocked.cshtml"
                                 
                            }
                            else
                            {

#line default
#line hidden
            BeginContext(2955, 265, true);
            WriteLiteral(@"                                <tr>
                                    <td colspan=""5"" class=""text-center"">
                                        <h1>OOPS... Nothing here</h1>
                                    </td>
                                </tr>
");
            EndContext();
#line 72 "E:\Projects\Perivallo\Areas\Xqcow\Views\Acc\Blocked.cshtml"
                            }

#line default
#line hidden
            BeginContext(3251, 146, true);
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ApUserVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591

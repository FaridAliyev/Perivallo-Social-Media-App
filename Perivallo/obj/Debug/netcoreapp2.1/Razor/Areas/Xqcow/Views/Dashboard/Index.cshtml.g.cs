#pragma checksum "E:\Projects\Perivallo\Areas\Xqcow\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "de42ba42a8ba9f7930d7af2061e9efbf92ec93a2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Xqcow_Views_Dashboard_Index), @"mvc.1.0.view", @"/Areas/Xqcow/Views/Dashboard/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Xqcow/Views/Dashboard/Index.cshtml", typeof(AspNetCore.Areas_Xqcow_Views_Dashboard_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de42ba42a8ba9f7930d7af2061e9efbf92ec93a2", @"/Areas/Xqcow/Views/Dashboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb88bdc4ae525210ea001a6294d9dce2789433ea", @"/Areas/Xqcow/Views/_ViewImports.cshtml")]
    public class Areas_Xqcow_Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "E:\Projects\Perivallo\Areas\Xqcow\Views\Dashboard\Index.cshtml"
  
    ViewData["Title"] = "Admin Panel";

#line default
#line hidden
            BeginContext(49, 271, true);
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-md-12 grid-margin"">
        <div class=""d-flex justify-content-between flex-wrap"">
            <div class=""d-flex align-items-end flex-wrap"">
                <div class=""mr-md-3 mr-xl-5"">
                    <h2>Welcome back, ");
            EndContext();
            BeginContext(321, 18, false);
#line 11 "E:\Projects\Perivallo\Areas\Xqcow\Views\Dashboard\Index.cshtml"
                                 Write(User.Identity.Name);

#line default
#line hidden
            EndContext();
            BeginContext(339, 2320, true);
            WriteLiteral(@"</h2>
                </div>
            </div>
        </div>
    </div>
</div>
<div class=""row"">
    <div class=""col-md-12 grid-margin stretch-card"">
        <div class=""card"">
            <div class=""card-body dashboard-tabs p-0"">
                <ul class=""nav nav-tabs px-4"" role=""tablist"">
                    <li class=""nav-item"">
                        <a class=""nav-link active"" id=""overview-tab"" data-toggle=""tab"" href=""#overview"" role=""tab"" aria-controls=""overview"" aria-selected=""true"">Overview</a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link"" id=""sales-tab"" data-toggle=""tab"" href=""#sales"" role=""tab"" aria-controls=""sales"" aria-selected=""false"">Users</a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link"" id=""purchases-tab"" data-toggle=""tab"" href=""#purchases"" role=""tab"" aria-controls=""purchases"" aria-selected=""false"">Activity</a>
                    </li>
   ");
            WriteLiteral(@"             </ul>
                <div class=""tab-content py-0 px-0"">
                    <div class=""tab-pane fade show active"" id=""overview"" role=""tabpanel"" aria-labelledby=""overview-tab"">
                        <div class=""d-flex flex-wrap justify-content-xl-between"">
                            <div class=""d-none d-xl-flex border-md-right flex-grow-1 align-items-center justify-content-center p-3 item"">
                                <i class=""mdi mdi-calendar-heart icon-lg mr-3 text-primary""></i>
                                <div class=""d-flex flex-column justify-content-around"">
                                    <small class=""mb-1 text-muted"">Start date</small>
                                    <h5 class=""mr-2 mb-0"">10/10/2020</h5>
                                </div>
                            </div>
                            <div class=""d-flex border-md-right flex-grow-1 align-items-center justify-content-center p-3 item"">
                                <i class=""mdi mdi-acc");
            WriteLiteral(@"ount mr-3 icon-lg text-danger""></i>
                                <div class=""d-flex flex-column justify-content-around"">
                                    <small class=""mb-1 text-muted"">Total Users</small>
                                    <h5 class=""mr-2 mb-0"">");
            EndContext();
            BeginContext(2660, 22, false);
#line 46 "E:\Projects\Perivallo\Areas\Xqcow\Views\Dashboard\Index.cshtml"
                                                     Write(ViewBag.TotalUserCount);

#line default
#line hidden
            EndContext();
            BeginContext(2682, 551, true);
            WriteLiteral(@"</h5>
                                </div>
                            </div>
                            <div class=""d-flex border-md-right flex-grow-1 align-items-center justify-content-center p-3 item"">
                                <i class=""mdi mdi-share-variant mr-3 icon-lg text-success""></i>
                                <div class=""d-flex flex-column justify-content-around"">
                                    <small class=""mb-1 text-muted"">Total posts shared</small>
                                    <h5 class=""mr-2 mb-0"">");
            EndContext();
            BeginContext(3234, 22, false);
#line 53 "E:\Projects\Perivallo\Areas\Xqcow\Views\Dashboard\Index.cshtml"
                                                     Write(ViewBag.TotalPostCount);

#line default
#line hidden
            EndContext();
            BeginContext(3256, 541, true);
            WriteLiteral(@"</h5>
                                </div>
                            </div>
                            <div class=""d-flex border-md-right flex-grow-1 align-items-center justify-content-center p-3 item"">
                                <i class=""mdi mdi-comment mr-3 icon-lg text-warning""></i>
                                <div class=""d-flex flex-column justify-content-around"">
                                    <small class=""mb-1 text-muted"">Total comments</small>
                                    <h5 class=""mr-2 mb-0"">");
            EndContext();
            BeginContext(3798, 25, false);
#line 60 "E:\Projects\Perivallo\Areas\Xqcow\Views\Dashboard\Index.cshtml"
                                                     Write(ViewBag.TotalCommentCount);

#line default
#line hidden
            EndContext();
            BeginContext(3823, 550, true);
            WriteLiteral(@"</h5>
                                </div>
                            </div>
                            <div class=""d-flex py-3 border-md-right flex-grow-1 align-items-center justify-content-center p-3 item"">
                                <i class=""mdi mdi-message-text mr-3 icon-lg text-danger""></i>
                                <div class=""d-flex flex-column justify-content-around"">
                                    <small class=""mb-1 text-muted"">Total messages</small>
                                    <h5 class=""mr-2 mb-0"">");
            EndContext();
            BeginContext(4374, 25, false);
#line 67 "E:\Projects\Perivallo\Areas\Xqcow\Views\Dashboard\Index.cshtml"
                                                     Write(ViewBag.TotalMessageCount);

#line default
#line hidden
            EndContext();
            BeginContext(4399, 795, true);
            WriteLiteral(@"</h5>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""tab-pane fade"" id=""sales"" role=""tabpanel"" aria-labelledby=""sales-tab"">
                        <div class=""d-flex flex-wrap justify-content-xl-between"">
                            <div class=""d-none d-xl-flex border-md-right flex-grow-1 align-items-center justify-content-center p-3 item"">
                                <i class=""mdi mdi-account icon-lg mr-3 text-primary""></i>
                                <div class=""d-flex flex-column justify-content-around"">
                                    <small class=""mb-1 text-muted"">Total Users</small>
                                    <h5 class=""mr-2 mb-0"">");
            EndContext();
            BeginContext(5195, 22, false);
#line 78 "E:\Projects\Perivallo\Areas\Xqcow\Views\Dashboard\Index.cshtml"
                                                     Write(ViewBag.TotalUserCount);

#line default
#line hidden
            EndContext();
            BeginContext(5217, 537, true);
            WriteLiteral(@"</h5>
                                </div>
                            </div>
                            <div class=""d-flex border-md-right flex-grow-1 align-items-center justify-content-center p-3 item"">
                                <i class=""mdi mdi-account-key mr-3 icon-lg text-warning""></i>
                                <div class=""d-flex flex-column justify-content-around"">
                                    <small class=""mb-1 text-muted"">Admins</small>
                                    <h5 class=""mr-2 mb-0"">");
            EndContext();
            BeginContext(5755, 18, false);
#line 85 "E:\Projects\Perivallo\Areas\Xqcow\Views\Dashboard\Index.cshtml"
                                                     Write(ViewBag.AdminCount);

#line default
#line hidden
            EndContext();
            BeginContext(5773, 544, true);
            WriteLiteral(@"</h5>
                                </div>
                            </div>
                            <div class=""d-flex border-md-right flex-grow-1 align-items-center justify-content-center p-3 item"">
                                <i class=""mdi mdi-account-search mr-3 icon-lg text-success""></i>
                                <div class=""d-flex flex-column justify-content-around"">
                                    <small class=""mb-1 text-muted"">Moderators</small>
                                    <h5 class=""mr-2 mb-0"">");
            EndContext();
            BeginContext(6318, 16, false);
#line 92 "E:\Projects\Perivallo\Areas\Xqcow\Views\Dashboard\Index.cshtml"
                                                     Write(ViewBag.ModCount);

#line default
#line hidden
            EndContext();
            BeginContext(6334, 545, true);
            WriteLiteral(@"</h5>
                                </div>
                            </div>
                            <div class=""d-flex border-md-right flex-grow-1 align-items-center justify-content-center p-3 item"">
                                <i class=""mdi mdi-account-circle mr-3 icon-lg text-danger""></i>
                                <div class=""d-flex flex-column justify-content-around"">
                                    <small class=""mb-1 text-muted"">Normal Users</small>
                                    <h5 class=""mr-2 mb-0"">");
            EndContext();
            BeginContext(6880, 23, false);
#line 99 "E:\Projects\Perivallo\Areas\Xqcow\Views\Dashboard\Index.cshtml"
                                                     Write(ViewBag.NormalUserCount);

#line default
#line hidden
            EndContext();
            BeginContext(6903, 540, true);
            WriteLiteral(@"</h5>
                                </div>
                            </div>
                            <div class=""d-flex py-3 border-md-right flex-grow-1 align-items-center justify-content-center p-3 item"">
                                <i class=""mdi mdi-flag mr-3 icon-lg text-danger""></i>
                                <div class=""d-flex flex-column justify-content-around"">
                                    <small class=""mb-1 text-muted"">Banned Users</small>
                                    <h5 class=""mr-2 mb-0"">");
            EndContext();
            BeginContext(7444, 24, false);
#line 106 "E:\Projects\Perivallo\Areas\Xqcow\Views\Dashboard\Index.cshtml"
                                                     Write(ViewBag.BannedUsersCount);

#line default
#line hidden
            EndContext();
            BeginContext(7468, 825, true);
            WriteLiteral(@"</h5>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""tab-pane fade"" id=""purchases"" role=""tabpanel"" aria-labelledby=""purchases-tab"">
                        <div class=""d-flex flex-wrap justify-content-xl-between"">
                            <div class=""d-none d-xl-flex border-md-right flex-grow-1 align-items-center justify-content-center p-3 item"">
                                <i class=""mdi mdi-calendar-today icon-lg mr-3 text-primary""></i>
                                <div class=""d-flex flex-column justify-content-around"">
                                    <small class=""mb-1 text-muted"">Registers in past 24 hours</small>
                                    <h5 class=""mr-2 mb-0"">");
            EndContext();
            BeginContext(8294, 17, false);
#line 117 "E:\Projects\Perivallo\Areas\Xqcow\Views\Dashboard\Index.cshtml"
                                                     Write(ViewBag.RegsToday);

#line default
#line hidden
            EndContext();
            BeginContext(8311, 555, true);
            WriteLiteral(@"</h5>
                                </div>
                            </div>
                            <div class=""d-flex border-md-right flex-grow-1 align-items-center justify-content-center p-3 item"">
                                <i class=""mdi mdi-calendar-blank mr-3 icon-lg text-danger""></i>
                                <div class=""d-flex flex-column justify-content-around"">
                                    <small class=""mb-1 text-muted"">Registers in past week</small>
                                    <h5 class=""mr-2 mb-0"">");
            EndContext();
            BeginContext(8867, 16, false);
#line 124 "E:\Projects\Perivallo\Areas\Xqcow\Views\Dashboard\Index.cshtml"
                                                     Write(ViewBag.RegsWeek);

#line default
#line hidden
            EndContext();
            BeginContext(8883, 562, true);
            WriteLiteral(@"</h5>
                                </div>
                            </div>
                            <div class=""d-flex border-md-right flex-grow-1 align-items-center justify-content-center p-3 item"">
                                <i class=""mdi mdi-calendar-today mr-3 icon-lg text-success""></i>
                                <div class=""d-flex flex-column justify-content-around"">
                                    <small class=""mb-1 text-muted"">Post shared in past 24 hours</small>
                                    <h5 class=""mr-2 mb-0"">");
            EndContext();
            BeginContext(9446, 18, false);
#line 131 "E:\Projects\Perivallo\Areas\Xqcow\Views\Dashboard\Index.cshtml"
                                                     Write(ViewBag.PostsToday);

#line default
#line hidden
            EndContext();
            BeginContext(9464, 559, true);
            WriteLiteral(@"</h5>
                                </div>
                            </div>
                            <div class=""d-flex border-md-right flex-grow-1 align-items-center justify-content-center p-3 item"">
                                <i class=""mdi mdi-calendar-today mr-3 icon-lg text-warning""></i>
                                <div class=""d-flex flex-column justify-content-around"">
                                    <small class=""mb-1 text-muted"">Comments in past 24 hours</small>
                                    <h5 class=""mr-2 mb-0"">");
            EndContext();
            BeginContext(10024, 21, false);
#line 138 "E:\Projects\Perivallo\Areas\Xqcow\Views\Dashboard\Index.cshtml"
                                                     Write(ViewBag.CommentsToday);

#line default
#line hidden
            EndContext();
            BeginContext(10045, 568, true);
            WriteLiteral(@"</h5>
                                </div>
                            </div>
                            <div class=""d-flex py-3 border-md-right flex-grow-1 align-items-center justify-content-center p-3 item"">
                                <i class=""mdi mdi-calendar-today mr-3 icon-lg text-danger""></i>
                                <div class=""d-flex flex-column justify-content-around"">
                                    <small class=""mb-1 text-muted"">Messages sent in past 24 hours</small>
                                    <h5 class=""mr-2 mb-0"">");
            EndContext();
            BeginContext(10614, 21, false);
#line 145 "E:\Projects\Perivallo\Areas\Xqcow\Views\Dashboard\Index.cshtml"
                                                     Write(ViewBag.MessagesToday);

#line default
#line hidden
            EndContext();
            BeginContext(10635, 300, true);
            WriteLiteral(@"</h5>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class=""row"">
    <div class=""col-4"">
        <h5>Active Post Reports: ");
            EndContext();
            BeginContext(10936, 24, false);
#line 157 "E:\Projects\Perivallo\Areas\Xqcow\Views\Dashboard\Index.cshtml"
                            Write(ViewBag.PostReportsCount);

#line default
#line hidden
            EndContext();
            BeginContext(10960, 80, true);
            WriteLiteral("</h5>\r\n    </div>\r\n    <div class=\"col-4\">\r\n        <h5>Active Comment Reports: ");
            EndContext();
            BeginContext(11041, 27, false);
#line 160 "E:\Projects\Perivallo\Areas\Xqcow\Views\Dashboard\Index.cshtml"
                               Write(ViewBag.CommentReportsCount);

#line default
#line hidden
            EndContext();
            BeginContext(11068, 77, true);
            WriteLiteral("</h5>\r\n    </div>\r\n    <div class=\"col-4\">\r\n        <h5>Active User Reports: ");
            EndContext();
            BeginContext(11146, 24, false);
#line 163 "E:\Projects\Perivallo\Areas\Xqcow\Views\Dashboard\Index.cshtml"
                            Write(ViewBag.UserReportsCount);

#line default
#line hidden
            EndContext();
            BeginContext(11170, 29, true);
            WriteLiteral("</h5>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

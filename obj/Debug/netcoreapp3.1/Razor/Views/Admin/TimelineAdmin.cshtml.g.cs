#pragma checksum "/Users/nipun/Desktop/kmutt x covid/Views/Admin/TimelineAdmin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0c8b599c726b61fc8c84da678a5b55f710662290"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_TimelineAdmin), @"mvc.1.0.view", @"/Views/Admin/TimelineAdmin.cshtml")]
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
#line 1 "/Users/nipun/Desktop/kmutt x covid/Views/_ViewImports.cshtml"
using kmutt_x_covid;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/nipun/Desktop/kmutt x covid/Views/_ViewImports.cshtml"
using kmutt_x_covid.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c8b599c726b61fc8c84da678a5b55f710662290", @"/Views/Admin/TimelineAdmin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f830025a68a917ee44d43e1633830686ece8b5a", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_TimelineAdmin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<kmutt_x_covid.Models.BuildingStampIn>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "TimelineAdmin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/Users/nipun/Desktop/kmutt x covid/Views/Admin/TimelineAdmin.cshtml"
  
    ViewData["Title"] = "Timeline";
    Layout="~/Views/Shared/_Layout.cshtml";


#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>All Data</h2>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c8b599c726b61fc8c84da678a5b55f7106622904072", async() => {
                WriteLiteral("\n    <p>\n        <input type=\"text\" name=\"id\"/>\n        <input type=\"submit\" value=\"Search\" class=\"btn btn-dark\" />\n    </p>\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<hr>
<div class=""text-center"">
    
    
    <table class=""table"">
        <thead>
        <tr style=""background-color: orange; border-radius:2rem"">
            <th>ID</th>
            <th>Name</th>
            <th>Date</th>
            <th>Time</th>
            <th>Building</th>
            <th>Floors</th>
        </tr>
        </thead>
        <tbody>
            
");
#nullable restore
#line 32 "/Users/nipun/Desktop/kmutt x covid/Views/Admin/TimelineAdmin.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\n                    <td>\n                        ");
#nullable restore
#line 36 "/Users/nipun/Desktop/kmutt x covid/Views/Admin/TimelineAdmin.cshtml"
                   Write(Html.DisplayFor(modelItem => item.IdNavigation.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </td>\n                    <td>\n                        ");
#nullable restore
#line 39 "/Users/nipun/Desktop/kmutt x covid/Views/Admin/TimelineAdmin.cshtml"
                   Write(Html.DisplayFor(modelItem => item.IdNavigation.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </td>\n                    <td>\n                        <span>\n                        ");
#nullable restore
#line 43 "/Users/nipun/Desktop/kmutt x covid/Views/Admin/TimelineAdmin.cshtml"
                   Write(Html.DisplayFor(modelItem => item.TimeIn.Day));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </span>/\n                        <span>\n                            ");
#nullable restore
#line 46 "/Users/nipun/Desktop/kmutt x covid/Views/Admin/TimelineAdmin.cshtml"
                       Write(Html.DisplayFor(modelItem => item.TimeIn.Month));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </span>/\n                        <span>\n                            ");
#nullable restore
#line 49 "/Users/nipun/Desktop/kmutt x covid/Views/Admin/TimelineAdmin.cshtml"
                       Write(Html.DisplayFor(modelItem => item.TimeIn.Year));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </span>\n                    </td>\n                    <td>\n                        <span>\n                            ");
#nullable restore
#line 54 "/Users/nipun/Desktop/kmutt x covid/Views/Admin/TimelineAdmin.cshtml"
                       Write(Html.DisplayFor(modelItem => item.TimeIn.Hour));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </span>:\n                        <span>\n                            ");
#nullable restore
#line 57 "/Users/nipun/Desktop/kmutt x covid/Views/Admin/TimelineAdmin.cshtml"
                       Write(Html.DisplayFor(modelItem => item.TimeIn.Minute));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </span>:\n                        <span>\n                            ");
#nullable restore
#line 60 "/Users/nipun/Desktop/kmutt x covid/Views/Admin/TimelineAdmin.cshtml"
                       Write(Html.DisplayFor(modelItem => item.TimeIn.Second));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </span>\n                    </td>\n                    \n                    <td>\n                        ");
#nullable restore
#line 65 "/Users/nipun/Desktop/kmutt x covid/Views/Admin/TimelineAdmin.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Building.BuildingName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </td>\n                    <td>\n                        ");
#nullable restore
#line 68 "/Users/nipun/Desktop/kmutt x covid/Views/Admin/TimelineAdmin.cshtml"
                   Write(Html.DisplayFor(modelItem=> item.Floors));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </td>\n                    \n                   \n                    \n                \n                </tr>\n");
#nullable restore
#line 75 "/Users/nipun/Desktop/kmutt x covid/Views/Admin/TimelineAdmin.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\n    </table>\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<kmutt_x_covid.Models.BuildingStampIn>> Html { get; private set; }
    }
}
#pragma warning restore 1591

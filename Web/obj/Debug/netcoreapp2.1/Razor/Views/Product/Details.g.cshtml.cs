#pragma checksum "C:\Users\Korisnik\Desktop\New folder (4)\proj_v3\proj\Web\Views\Product\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6c418bfa54083cde34f830a00f551c13f8d1f0ed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Details), @"mvc.1.0.view", @"/Views/Product/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Product/Details.cshtml", typeof(AspNetCore.Views_Product_Details))]
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
#line 1 "C:\Users\Korisnik\Desktop\New folder (4)\proj_v3\proj\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#line 2 "C:\Users\Korisnik\Desktop\New folder (4)\proj_v3\proj\Web\Views\_ViewImports.cshtml"
using Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6c418bfa54083cde34f830a00f551c13f8d1f0ed", @"/Views/Product/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b0619e1a302f0598271da1847e697c39d57b88", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Application.DTO.ProductDTO>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(35, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Korisnik\Desktop\New folder (4)\proj_v3\proj\Web\Views\Product\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(127, 20, true);
            WriteLiteral("\r\n<h2>Details</h2>\r\n");
            EndContext();
#line 9 "C:\Users\Korisnik\Desktop\New folder (4)\proj_v3\proj\Web\Views\Product\Details.cshtml"
 if (Model == null)
{


#line default
#line hidden
            BeginContext(173, 33, true);
            WriteLiteral("    <h1>Produkt ne postoji</h1>\r\n");
            EndContext();
#line 13 "C:\Users\Korisnik\Desktop\New folder (4)\proj_v3\proj\Web\Views\Product\Details.cshtml"

}
else
{


#line default
#line hidden
            BeginContext(222, 102, true);
            WriteLiteral("<div>\r\n    <h4>ProductDTO</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(325, 38, false);
#line 23 "C:\Users\Korisnik\Desktop\New folder (4)\proj_v3\proj\Web\Views\Product\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(363, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(407, 34, false);
#line 26 "C:\Users\Korisnik\Desktop\New folder (4)\proj_v3\proj\Web\Views\Product\Details.cshtml"
       Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(441, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(485, 47, false);
#line 29 "C:\Users\Korisnik\Desktop\New folder (4)\proj_v3\proj\Web\Views\Product\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ProductName));

#line default
#line hidden
            EndContext();
            BeginContext(532, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(576, 43, false);
#line 32 "C:\Users\Korisnik\Desktop\New folder (4)\proj_v3\proj\Web\Views\Product\Details.cshtml"
       Write(Html.DisplayFor(model => model.ProductName));

#line default
#line hidden
            EndContext();
            BeginContext(619, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(663, 46, false);
#line 35 "C:\Users\Korisnik\Desktop\New folder (4)\proj_v3\proj\Web\Views\Product\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SupplierId));

#line default
#line hidden
            EndContext();
            BeginContext(709, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(753, 42, false);
#line 38 "C:\Users\Korisnik\Desktop\New folder (4)\proj_v3\proj\Web\Views\Product\Details.cshtml"
       Write(Html.DisplayFor(model => model.SupplierId));

#line default
#line hidden
            EndContext();
            BeginContext(795, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(839, 45, false);
#line 41 "C:\Users\Korisnik\Desktop\New folder (4)\proj_v3\proj\Web\Views\Product\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.UnitPrice));

#line default
#line hidden
            EndContext();
            BeginContext(884, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(928, 41, false);
#line 44 "C:\Users\Korisnik\Desktop\New folder (4)\proj_v3\proj\Web\Views\Product\Details.cshtml"
       Write(Html.DisplayFor(model => model.UnitPrice));

#line default
#line hidden
            EndContext();
            BeginContext(969, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1013, 43, false);
#line 47 "C:\Users\Korisnik\Desktop\New folder (4)\proj_v3\proj\Web\Views\Product\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Package));

#line default
#line hidden
            EndContext();
            BeginContext(1056, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1100, 39, false);
#line 50 "C:\Users\Korisnik\Desktop\New folder (4)\proj_v3\proj\Web\Views\Product\Details.cshtml"
       Write(Html.DisplayFor(model => model.Package));

#line default
#line hidden
            EndContext();
            BeginContext(1139, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1183, 50, false);
#line 53 "C:\Users\Korisnik\Desktop\New folder (4)\proj_v3\proj\Web\Views\Product\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IsDiscontinued));

#line default
#line hidden
            EndContext();
            BeginContext(1233, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1277, 46, false);
#line 56 "C:\Users\Korisnik\Desktop\New folder (4)\proj_v3\proj\Web\Views\Product\Details.cshtml"
       Write(Html.DisplayFor(model => model.IsDiscontinued));

#line default
#line hidden
            EndContext();
            BeginContext(1323, 36, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n");
            EndContext();
            BeginContext(1365, 11, true);
            WriteLiteral("<div>\r\n    ");
            EndContext();
            BeginContext(1377, 68, false);
#line 64 "C:\Users\Korisnik\Desktop\New folder (4)\proj_v3\proj\Web\Views\Product\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { /* id = Model.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1445, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1453, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f495c7125514e39a6e9e90fa6eea5d2", async() => {
                BeginContext(1475, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1491, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
#line 67 "C:\Users\Korisnik\Desktop\New folder (4)\proj_v3\proj\Web\Views\Product\Details.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Application.DTO.ProductDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591

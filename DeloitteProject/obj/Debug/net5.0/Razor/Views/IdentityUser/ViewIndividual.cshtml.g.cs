#pragma checksum "C:\Users\User\Desktop\.net core mvc authentication\DeloitteProject\DeloitteProject\Views\IdentityUser\ViewIndividual.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dbb39d10302bec29c13b56555ee050ba8c1824a0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_IdentityUser_ViewIndividual), @"mvc.1.0.view", @"/Views/IdentityUser/ViewIndividual.cshtml")]
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
#line 1 "C:\Users\User\Desktop\.net core mvc authentication\DeloitteProject\DeloitteProject\Views\_ViewImports.cshtml"
using DeloitteProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\.net core mvc authentication\DeloitteProject\DeloitteProject\Views\_ViewImports.cshtml"
using DeloitteProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dbb39d10302bec29c13b56555ee050ba8c1824a0", @"/Views/IdentityUser/ViewIndividual.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b1c3c888827366f7100326d0290b44c7c6a64b2", @"/Views/_ViewImports.cshtml")]
    public class Views_IdentityUser_ViewIndividual : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\User\Desktop\.net core mvc authentication\DeloitteProject\DeloitteProject\Views\IdentityUser\ViewIndividual.cshtml"
  
    ViewData["Title"] = "ViewIndividual";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<br />

<!--
    <ul>
    foreach (var record in ViewData[""entries""] as IList<UserUpload>)
    {
    <li>
        record.Name
    </li>
    <li>
        record.CreatedDate
    </li>
    <li>
        record.fileName
    </li>
    }
</ul>
-->

<div class=""col-md-8"">
    <div class=""card mb-3 small"">
        <div class=""card-body"">

");
#nullable restore
#line 29 "C:\Users\User\Desktop\.net core mvc authentication\DeloitteProject\DeloitteProject\Views\IdentityUser\ViewIndividual.cshtml"
             foreach (var record in ViewData["entries"] as IList<UserUpload>)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"row\">\r\n                    <div class=\"col-sm-3\">\r\n                        <h6 class=\"mb-0\">Uploaded by:</h6>\r\n                    </div>\r\n                    <div class=\"col-sm-9 text-secondary\">\r\n                        ");
#nullable restore
#line 36 "C:\Users\User\Desktop\.net core mvc authentication\DeloitteProject\DeloitteProject\Views\IdentityUser\ViewIndividual.cshtml"
                   Write(record.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                </div>
                <hr>
                <div class=""row"">
                    <div class=""col-sm-3"">
                        <h6 class=""mb-0"">Created on:</h6>
                    </div>
                    <div class=""col-sm-9 text-secondary"">
                        ");
#nullable restore
#line 45 "C:\Users\User\Desktop\.net core mvc authentication\DeloitteProject\DeloitteProject\Views\IdentityUser\ViewIndividual.cshtml"
                   Write(record.CreatedDate.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                </div>
                <hr>
                <div class=""row"">
                    <div class=""col-sm-3"">
                        <h6 class=""mb-0"">File Info</h6>
                    </div>
                    <div class=""col-sm-9 text-secondary"">
                        ");
#nullable restore
#line 54 "C:\Users\User\Desktop\.net core mvc authentication\DeloitteProject\DeloitteProject\Views\IdentityUser\ViewIndividual.cshtml"
                   Write(record.fileName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 57 "C:\Users\User\Desktop\.net core mvc authentication\DeloitteProject\DeloitteProject\Views\IdentityUser\ViewIndividual.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <h4>Results:</h4>\r\n</div>\r\n");
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
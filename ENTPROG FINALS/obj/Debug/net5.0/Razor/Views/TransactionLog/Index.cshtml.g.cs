#pragma checksum "D:\School Files\ENTPROG\GitHub Repo\Final Project 6\ENTPROG FINALS\Views\TransactionLog\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5f122e62ae36755fceb01d97e75b8e53c217753f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TransactionLog_Index), @"mvc.1.0.view", @"/Views/TransactionLog/Index.cshtml")]
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
#line 1 "D:\School Files\ENTPROG\GitHub Repo\Final Project 6\ENTPROG FINALS\Views\_ViewImports.cshtml"
using ENTPROG_FINALS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\School Files\ENTPROG\GitHub Repo\Final Project 6\ENTPROG FINALS\Views\_ViewImports.cshtml"
using ENTPROG_FINALS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5f122e62ae36755fceb01d97e75b8e53c217753f", @"/Views/TransactionLog/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c675c18ad7fec7acfccc42cab63ddd7cdebb47f4", @"/Views/_ViewImports.cshtml")]
    public class Views_TransactionLog_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ENTPROG_FINALS.Models.Transaction>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\School Files\ENTPROG\GitHub Repo\Final Project 6\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Transaction Log</h1>\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 14 "D:\School Files\ENTPROG\GitHub Repo\Final Project 6\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.TransactionID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "D:\School Files\ENTPROG\GitHub Repo\Final Project 6\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Table));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "D:\School Files\ENTPROG\GitHub Repo\Final Project 6\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.RecordID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "D:\School Files\ENTPROG\GitHub Repo\Final Project 6\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "D:\School Files\ENTPROG\GitHub Repo\Final Project 6\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.User));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "D:\School Files\ENTPROG\GitHub Repo\Final Project 6\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.TransactionMade));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 32 "D:\School Files\ENTPROG\GitHub Repo\Final Project 6\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Anonymous));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 38 "D:\School Files\ENTPROG\GitHub Repo\Final Project 6\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 41 "D:\School Files\ENTPROG\GitHub Repo\Final Project 6\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.TransactionID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 44 "D:\School Files\ENTPROG\GitHub Repo\Final Project 6\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Table));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 47 "D:\School Files\ENTPROG\GitHub Repo\Final Project 6\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.RecordID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 50 "D:\School Files\ENTPROG\GitHub Repo\Final Project 6\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 53 "D:\School Files\ENTPROG\GitHub Repo\Final Project 6\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.User));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 56 "D:\School Files\ENTPROG\GitHub Repo\Final Project 6\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.TransactionMade));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n");
#nullable restore
#line 59 "D:\School Files\ENTPROG\GitHub Repo\Final Project 6\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
             if (item.Table.Equals("Donations"))
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "D:\School Files\ENTPROG\GitHub Repo\Final Project 6\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
           Write(item.Anonymous);

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "D:\School Files\ENTPROG\GitHub Repo\Final Project 6\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
                               
            }
            else
            {
                

#line default
#line hidden
#nullable disable
            WriteLiteral(" N/A ");
#nullable restore
#line 65 "D:\School Files\ENTPROG\GitHub Repo\Final Project 6\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
                                  
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </td>\r\n        </tr>\r\n");
#nullable restore
#line 69 "D:\School Files\ENTPROG\GitHub Repo\Final Project 6\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ENTPROG_FINALS.Models.Transaction>> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\cheet\Source\Repos\ENPROG-FinalProject\ENTPROG FINALS\Views\TransactionLog\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f6b41e28b5e6f6a34bea7b84ed55301d937130b5"
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
#line 1 "C:\Users\cheet\Source\Repos\ENPROG-FinalProject\ENTPROG FINALS\Views\_ViewImports.cshtml"
using ENTPROG_FINALS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\cheet\Source\Repos\ENPROG-FinalProject\ENTPROG FINALS\Views\_ViewImports.cshtml"
using ENTPROG_FINALS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6b41e28b5e6f6a34bea7b84ed55301d937130b5", @"/Views/TransactionLog/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c675c18ad7fec7acfccc42cab63ddd7cdebb47f4", @"/Views/_ViewImports.cshtml")]
    public class Views_TransactionLog_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ENTPROG_FINALS.Models.Transaction>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/datatables/js/jquery.dataTables.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/datatables/js/dataTables.bootstrap4.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\cheet\Source\Repos\ENPROG-FinalProject\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Transaction Log</h1>\r\n\r\n\r\n<table id=\"records\" class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 14 "C:\Users\cheet\Source\Repos\ENPROG-FinalProject\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.TransactionID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\cheet\Source\Repos\ENPROG-FinalProject\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Table));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "C:\Users\cheet\Source\Repos\ENPROG-FinalProject\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.RecordID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "C:\Users\cheet\Source\Repos\ENPROG-FinalProject\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "C:\Users\cheet\Source\Repos\ENPROG-FinalProject\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.User));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "C:\Users\cheet\Source\Repos\ENPROG-FinalProject\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.TransactionMade));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 32 "C:\Users\cheet\Source\Repos\ENPROG-FinalProject\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Anonymous));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 37 "C:\Users\cheet\Source\Repos\ENPROG-FinalProject\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 41 "C:\Users\cheet\Source\Repos\ENPROG-FinalProject\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.TransactionID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 44 "C:\Users\cheet\Source\Repos\ENPROG-FinalProject\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Table));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 47 "C:\Users\cheet\Source\Repos\ENPROG-FinalProject\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.RecordID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 50 "C:\Users\cheet\Source\Repos\ENPROG-FinalProject\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 53 "C:\Users\cheet\Source\Repos\ENPROG-FinalProject\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.User));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 56 "C:\Users\cheet\Source\Repos\ENPROG-FinalProject\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.TransactionMade));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
#nullable restore
#line 59 "C:\Users\cheet\Source\Repos\ENPROG-FinalProject\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
                     if (item.Table.Equals("Donations"))
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "C:\Users\cheet\Source\Repos\ENPROG-FinalProject\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
                   Write(item.Anonymous);

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "C:\Users\cheet\Source\Repos\ENPROG-FinalProject\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
                                       
                    }
                    else
                    {
                        

#line default
#line hidden
#nullable disable
            WriteLiteral(" N/A ");
#nullable restore
#line 65 "C:\Users\cheet\Source\Repos\ENPROG-FinalProject\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
                                          
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n            </tr>\r\n");
#nullable restore
#line 69 "C:\Users\cheet\Source\Repos\ENPROG-FinalProject\ENTPROG FINALS\Views\TransactionLog\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6b41e28b5e6f6a34bea7b84ed55301d937130b510659", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6b41e28b5e6f6a34bea7b84ed55301d937130b511759", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <script>\r\n        $(document).ready(function () {\r\n            $(\'#records\').DataTable();\r\n        });\r\n\r\n    </script>\r\n");
            }
            );
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

#pragma checksum "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Role\Update.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4a1bbfb902cb804708c8d6a7ddd26cb283accaca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Role_Update), @"mvc.1.0.view", @"/Views/Role/Update.cshtml")]
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
#line 1 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\_ViewImports.cshtml"
using Vidly;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\_ViewImports.cshtml"
using Vidly.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Role\Update.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a1bbfb902cb804708c8d6a7ddd26cb283accaca", @"/Views/Role/Update.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e5f1cd008877cdb7a8309a52d389048c655f591a", @"/Views/_ViewImports.cshtml")]
    public class Views_Role_Update : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RoleEdit>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<h1>Permissions</h1>\r\n<h4>Update <a style=\"color:#00bc8c\">");
#nullable restore
#line 12 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Role\Update.cshtml"
                               Write(Model.User.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\'s</a> permissions</h4>\r\n<hr />\r\n<br/>\r\n\r\n<div class=\"row\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4a1bbfb902cb804708c8d6a7ddd26cb283accaca4877", async() => {
                WriteLiteral("\r\n        <div class=\"col-md-4\">\r\n        <section>\r\n            <h2>Add roles to user</h2>\r\n            <table class=\"table\" id=\"AddPermissions\">\r\n");
#nullable restore
#line 22 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Role\Update.cshtml"
                 if (Model.NonMembers.Count() == 0)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <td style=\"color: #00bc8c;\">\r\n                            This user has all permissions\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 29 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Role\Update.cshtml"
                }
                else
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Role\Update.cshtml"
                     foreach (IdentityRole role in Model.NonMembers)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <td>\r\n                                <input type=\"checkbox\" name=\"AddRole\"");
                BeginWriteAttribute("value", " value=\"", 1084, "\"", 1100, 1);
#nullable restore
#line 36 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Role\Update.cshtml"
WriteAttributeValue("", 1092, role.Id, 1092, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 39 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Role\Update.cshtml"
                           Write(role.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 42 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Role\Update.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Role\Update.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"            </table>
        </section>
        </div>

        <br/>
        <hr/>
        <br/>
        
        <div class=""col-md-4"">
            <section>
                <h2>Remove roles from user</h2>
                <table class=""table"" id=""RemovePermissions"">
");
#nullable restore
#line 56 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Role\Update.cshtml"
                     if (Model.Members.Count() == 0)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <td style=\"color: #f39c12;\">\r\n                                This user doesn\'t have any permissions\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 63 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Role\Update.cshtml"
                    }
                    else
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Role\Update.cshtml"
                         foreach (IdentityRole role in Model.Members)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    <input type=\"checkbox\" name=\"DeleteRole\"");
                BeginWriteAttribute("value", " value=\"", 2227, "\"", 2243, 1);
#nullable restore
#line 70 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Role\Update.cshtml"
WriteAttributeValue("", 2235, role.Id, 2235, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 73 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Role\Update.cshtml"
                               Write(role.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 76 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Role\Update.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 76 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Role\Update.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </table>\r\n\r\n                <input type=\"hidden\" name=\"userName\"");
                BeginWriteAttribute("value", " value=\"", 2576, "\"", 2604, 1);
#nullable restore
#line 80 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Role\Update.cshtml"
WriteAttributeValue("", 2584, Model.User.UserName, 2584, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                <input type=\"hidden\" name=\"userId\"");
                BeginWriteAttribute("value", " value=\"", 2660, "\"", 2682, 1);
#nullable restore
#line 81 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Role\Update.cshtml"
WriteAttributeValue("", 2668, Model.User.Id, 2668, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                <button type=\"submit\" class=\"btn btn-primary\">Save</button>\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4a1bbfb902cb804708c8d6a7ddd26cb283accaca11289", async() => {
                    WriteLiteral("Back");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            </section>\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("action", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div> \r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        $(document).ready( function () {\r\n            $(\'#AddPermissions\').DataTable();\r\n            $(\'#RemovePermissions\').DataTable();\r\n        } );\r\n    </script>   \r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RoleEdit> Html { get; private set; }
    }
}
#pragma warning restore 1591
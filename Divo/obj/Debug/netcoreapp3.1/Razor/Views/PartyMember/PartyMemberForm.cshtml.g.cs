#pragma checksum "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\PartyMember\PartyMemberForm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fa78f18efe8d257817dcc8fe2bcdebb987011ac5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PartyMember_PartyMemberForm), @"mvc.1.0.view", @"/Views/PartyMember/PartyMemberForm.cshtml")]
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
#line 1 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\_ViewImports.cshtml"
using Divo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\_ViewImports.cshtml"
using Divo.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\PartyMember\PartyMemberForm.cshtml"
using Microsoft.AspNetCore.Mvc.ModelBinding;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\PartyMember\PartyMemberForm.cshtml"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa78f18efe8d257817dcc8fe2bcdebb987011ac5", @"/Views/PartyMember/PartyMemberForm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b50f9051de3ab96c51d0232e73bf05c93b0c99e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_PartyMember_PartyMemberForm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Divo.ViewModels.PartyMemberFormViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 7 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\PartyMember\PartyMemberForm.cshtml"
  
    ViewData["Title"] = "Maak Partij - Divo";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 11 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\PartyMember\PartyMemberForm.cshtml"
 using (Html.BeginForm("Save", "PartyMember"))
    {
        if (Model.PartyMember != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h4>Pas een persoon aan</h4>\r\n");
#nullable restore
#line 16 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\PartyMember\PartyMemberForm.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h4>Voeg een persoon toe</h4> \r\n");
#nullable restore
#line 20 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\PartyMember\PartyMemberForm.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <section>\r\n\r\n            <hr />\r\n            <div class=\"col-md-4\">\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 26 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\PartyMember\PartyMemberForm.cshtml"
               Write(Html.LabelFor(m => m.PartyMember.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 27 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\PartyMember\PartyMemberForm.cshtml"
               Write(Html.TextBoxFor(m => m.PartyMember.Name, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 28 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\PartyMember\PartyMemberForm.cshtml"
               Write(Html.ValidationMessageFor(m => m.PartyMember.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 31 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\PartyMember\PartyMemberForm.cshtml"
               Write(Html.LabelFor(m => m.PartyMember.Role));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 32 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\PartyMember\PartyMemberForm.cshtml"
               Write(Html.TextBoxFor(m => m.PartyMember.Role, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 33 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\PartyMember\PartyMemberForm.cshtml"
               Write(Html.ValidationMessageFor(m => m.PartyMember.Role));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 36 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\PartyMember\PartyMemberForm.cshtml"
               Write(Html.LabelFor(m => m.PartyMember.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 37 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\PartyMember\PartyMemberForm.cshtml"
               Write(Html.TextBoxFor(m => m.PartyMember.Description, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 38 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\PartyMember\PartyMemberForm.cshtml"
               Write(Html.ValidationMessageFor(m => m.PartyMember.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 41 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\PartyMember\PartyMemberForm.cshtml"
               Write(Html.LabelFor(m => m.PartyMember.PartyId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <br />\r\n                    ");
#nullable restore
#line 43 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\PartyMember\PartyMemberForm.cshtml"
               Write(Html.DropDownListFor(m => m.PartyMember.PartyId, new SelectList(Model.Parties, "Id", "Name"), "Selecteer Partij", new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 44 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\PartyMember\PartyMemberForm.cshtml"
               Write(Html.ValidationMessageFor(m => m.PartyMember.PartyId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <br/>\r\n                    <h14>* Kan je de juiste partij niet vinden? Zorg dat de partij niet gearchiveerd is.</h14>\r\n                </div>\r\n            </div>\r\n            \r\n            <br/>\r\n\r\n            ");
#nullable restore
#line 52 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\PartyMember\PartyMemberForm.cshtml"
       Write(Html.HiddenFor(m => m.PartyMember.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 53 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\PartyMember\PartyMemberForm.cshtml"
       Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            <div class=\"row\">\r\n                <div class=\"col-md-4\">\r\n                    <br />\r\n                    <h4>Actions</h4>\r\n                    <hr />\r\n                    <div>\r\n");
#nullable restore
#line 61 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\PartyMember\PartyMemberForm.cshtml"
                         if (Model.PartyMember.Id != 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fa78f18efe8d257817dcc8fe2bcdebb987011ac510810", async() => {
                WriteLiteral("Terug");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 63 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\PartyMember\PartyMemberForm.cshtml"
                                                                                WriteLiteral(Model.PartyMember.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 64 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\PartyMember\PartyMemberForm.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fa78f18efe8d257817dcc8fe2bcdebb987011ac513398", async() => {
                WriteLiteral("Terug");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 68 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\PartyMember\PartyMemberForm.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <button type=\"submit\" class=\"btn btn-primary\">Save</button>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </section>\r\n");
#nullable restore
#line 74 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\PartyMember\PartyMemberForm.cshtml"
    }

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Divo.ViewModels.PartyMemberFormViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

#pragma checksum "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Voting\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "26a30559e47a85d88dc6f0824b84dd649dee57e4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Voting_Delete), @"mvc.1.0.view", @"/Views/Voting/Delete.cshtml")]
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
#line 1 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Voting\Delete.cshtml"
using Divo.Views.Shared;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"26a30559e47a85d88dc6f0824b84dd649dee57e4", @"/Views/Voting/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b50f9051de3ab96c51d0232e73bf05c93b0c99e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Voting_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Divo.ViewModels.VotingDeleteViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Voting\Delete.cshtml"
  
    ViewData["ActivePage"] = ManageNavPages.Index;
    ViewData["Title"] = "Stembussen";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<h4>");
#nullable restore
#line 9 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Voting\Delete.cshtml"
Write(Model.Voting.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
<br />

<div class=""alert alert-danger"" role=""alert"">
    <p>
        <strong>Je staat op het punt om deze stembus permanent te verwijderen! Deze actie kan niet ongedaan gemaakt worden!</strong>
    </p>
</div>

<div>
    <h4>Stembus informatie</h4>
    <hr />
    <dl class=""row"">
        <dt class=""col-sm-2"">
            Naam:
        </dt>
        <dd class=""col-sm-10"">
            ");
#nullable restore
#line 26 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Voting\Delete.cshtml"
       Write(Model.Voting.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Beschrijving:\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 32 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Voting\Delete.cshtml"
       Write(Model.Voting.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Deelnemers:\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 38 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Voting\Delete.cshtml"
       Write(Model.Participants.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n\r\n\r\n");
#nullable restore
#line 44 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Voting\Delete.cshtml"
 using (Html.BeginForm("Delete", "Voting"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <section>\r\n        <div class=\"row\">\r\n            <div class=\"col-md-4\">\r\n                ");
#nullable restore
#line 49 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Voting\Delete.cshtml"
           Write(Html.HiddenFor(m => m.Voting.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 50 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Voting\Delete.cshtml"
           Write(Html.HiddenFor(m => m.Voting.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 51 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Voting\Delete.cshtml"
           Write(Html.HiddenFor(m => m.Voting.Active));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 52 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Voting\Delete.cshtml"
           Write(Html.HiddenFor(m => m.Voting.Finished));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 53 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Voting\Delete.cshtml"
           Write(Html.HiddenFor(m => m.Voting.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 54 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Voting\Delete.cshtml"
           Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    <br/>\r\n                    <h4>Actions</h4>\r\n                    <hr/>\r\n                    <div>\r\n                        <button type=\"submit\" class=\"btn btn-danger\">Verwijder</button>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "26a30559e47a85d88dc6f0824b84dd649dee57e47899", async() => {
                WriteLiteral("Cancel");
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
#line 61 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Voting\Delete.cshtml"
                                                                            WriteLiteral(Model.Voting.Id);

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
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n    </section>\r\n");
#nullable restore
#line 66 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Voting\Delete.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Divo.ViewModels.VotingDeleteViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

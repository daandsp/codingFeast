#pragma checksum "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Party\Participating.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24399153d3530a1577df6b44e358d7b1377a1375"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Party_Participating), @"mvc.1.0.view", @"/Views/Party/Participating.cshtml")]
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
#line 1 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Party\Participating.cshtml"
using Divo.Views.Shared;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24399153d3530a1577df6b44e358d7b1377a1375", @"/Views/Party/Participating.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b50f9051de3ab96c51d0232e73bf05c93b0c99e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Party_Participating : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Divo.ViewModels.PartyParticipatingViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-default"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Voting", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Party\Participating.cshtml"
  
    if (Model.Party.Active == true)
    {
        ViewData["ActivePage"] = ManageNavPages.Index;
    }
    else
    {
        ViewData["ActivePage"] = ManageNavPages.HistoryIndex;
    }
    ViewData["Title"] = "Partijen";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h4>");
#nullable restore
#line 16 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Party\Participating.cshtml"
Write(Model.Party.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n<br />\r\n\r\n<div>\r\n    <h4>Deelnemend in stembussen</h4>\r\n    <dl class=\"row\">\r\n");
#nullable restore
#line 22 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Party\Participating.cshtml"
         if (Model.Participants.Any())
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Party\Participating.cshtml"
             foreach (var voting in Model.Participants)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <dt class=\"col-sm-2\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "24399153d3530a1577df6b44e358d7b1377a13755892", async() => {
                WriteLiteral("<strong>");
#nullable restore
#line 27 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Party\Participating.cshtml"
                                                                                                                               Write(voting.Voting.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</strong>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 27 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Party\Participating.cshtml"
                                                                                              WriteLiteral(voting.VotingId);

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
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 30 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Party\Participating.cshtml"
               Write(voting.Voting.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n");
#nullable restore
#line 32 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Party\Participating.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Party\Participating.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </dl>\r\n");
#nullable restore
#line 35 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Party\Participating.cshtml"
     if (!Model.Participants.Any())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h6>");
#nullable restore
#line 37 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Party\Participating.cshtml"
       Write(Model.Party.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" doet nog aan geen enkele stembus mee!</h6>\r\n");
#nullable restore
#line 38 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Party\Participating.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-4\">\r\n        <br />\r\n        <h4>Actions</h4>\r\n        <hr />\r\n        <div>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "24399153d3530a1577df6b44e358d7b1377a137510335", async() => {
                WriteLiteral("Terug");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 48 "D:\School\AO\Leerjaar 2\Cyclus 2\Divo\Views\Party\Participating.cshtml"
                                                                WriteLiteral(Model.Party.Id);

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
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Divo.ViewModels.PartyParticipatingViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

#pragma checksum "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d7799a3f029598d28de609163abf066e1fdfb1f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movie_MovieForm), @"mvc.1.0.view", @"/Views/Movie/MovieForm.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d7799a3f029598d28de609163abf066e1fdfb1f", @"/Views/Movie/MovieForm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e5f1cd008877cdb7a8309a52d389048c655f591a", @"/Views/_ViewImports.cshtml")]
    public class Views_Movie_MovieForm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Vidly.ViewModels.MovieFormViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ValidationScriptsPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
  
    if (Model.Movie == null)
    {
        ViewData["Title"] = "Movie - Add";
    }
    else
    {
        ViewData["Title"] = "Movie - Edit";
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Movie</h2>\r\n\r\n");
#nullable restore
#line 18 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
 using (Html.BeginForm("Save", "Movie"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<section>\r\n");
#nullable restore
#line 21 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
     if (Model.Movie != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h4>Edit movie.</h4>\r\n");
#nullable restore
#line 24 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h4>Add movie.</h4>\r\n");
#nullable restore
#line 28 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <hr />\r\n    <div class=\"col-md-4\">\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 32 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
       Write(Html.LabelFor(m => m.Movie.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 33 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
       Write(Html.TextBoxFor(m => m.Movie.Name, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 34 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
       Write(Html.ValidationMessageFor(m => m.Movie.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <div class=\"dropdown\">\r\n                ");
#nullable restore
#line 38 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
           Write(Html.LabelFor(m => m.Movie.ReleaseDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 39 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
           Write(Html.EditorFor(m => m.Movie.ReleaseDate, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 40 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
           Write(Html.ValidationMessageFor(m => m.Movie.ReleaseDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 43 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
         if (Model.Movie.Id == 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-group\">\r\n                <div class=\"dropdown\">\r\n                    ");
#nullable restore
#line 47 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
               Write(Html.LabelFor(m => m.Movie.DateAdded));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 48 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
               Write(Html.EditorFor(m => m.Movie.DateAdded, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 49 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
               Write(Html.ValidationMessageFor(m => m.Movie.DateAdded));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 52 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 54 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
       Write(Html.LabelFor(m => m.Movie.NumberInStock));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 55 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
       Write(Html.TextBoxFor(m => m.Movie.NumberInStock, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 56 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
       Write(Html.ValidationMessageFor(m => m.Movie.NumberInStock));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 59 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
       Write(Html.LabelFor(m => m.Movie.GenreId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <br />\r\n            ");
#nullable restore
#line 61 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
       Write(Html.DropDownListFor(m => m.Movie.GenreId, new SelectList(Model.Genres, "Id", "Name"), "Select Genre", new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 62 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
       Write(Html.ValidationMessageFor(m => m.Movie.GenreId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <br />\r\n        ");
#nullable restore
#line 65 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
   Write(Html.HiddenFor(m => m.Movie.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 66 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 68 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
         if (Model.Movie != null)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
       Write(Html.HiddenFor(m => m.Movie.DateAdded));

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
                                                   
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <br />\r\n");
#nullable restore
#line 73 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
         if (Model.Movie.Id == 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d7799a3f029598d28de609163abf066e1fdfb1f12364", async() => {
                WriteLiteral("Cancel");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 76 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d7799a3f029598d28de609163abf066e1fdfb1f13837", async() => {
                WriteLiteral("Back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 79 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
                                                                WriteLiteral(Model.Movie.Id);

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
#line 80 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <button type=\"submit\" class=\"btn btn-primary\">Save</button>\r\n        <hr /><br />\r\n");
#nullable restore
#line 83 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
         if (Model.Movie == null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d7799a3f029598d28de609163abf066e1fdfb1f16634", async() => {
                WriteLiteral("Return to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 86 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</section>\r\n");
#nullable restore
#line 89 "D:\School\AO\Leerjaar 2\Cyclus 1\Vidly\Vidly\Views\Movie\MovieForm.cshtml"
}

#line default
#line hidden
#nullable disable
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5d7799a3f029598d28de609163abf066e1fdfb1f18362", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Vidly.ViewModels.MovieFormViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

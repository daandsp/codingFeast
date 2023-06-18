using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Divo.Views.Shared
{
    public static class ManageNavPages
    {
        public static string Index => "Index";

        public static string Form => "Form";
        public static string HistoryIndex => "HistoryIndex";

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);

        public static string FormNavClass(ViewContext viewContext) => PageNavClass(viewContext, Form);
        public static string HistoryIndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, HistoryIndex);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}

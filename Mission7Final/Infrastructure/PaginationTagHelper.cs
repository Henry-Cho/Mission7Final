using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission7Final.Models.ViewModels;

namespace Mission7Final.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-list")]

    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory uhf;

        public PaginationTagHelper(IUrlHelperFactory temp)
        {
            uhf = temp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }

        // Different tahn the View Context
        public PageInfo PageList { get; set; }
        public string PageAction { get; set; }
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext thc, TagHelperOutput tho)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            TagBuilder final = new TagBuilder("div");

            for (int i = 1; i <= PageList.TotalPages; i++)
            {
                TagBuilder tb = new TagBuilder("a");
                tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
                tb.InnerHtml.Append(i.ToString());
                if (PageClassesEnabled)
                {
                    tb.AddCssClass(PageClass);
                    tb.AddCssClass(i == PageList.CurrentPage
                    ? PageClassSelected : PageClassNormal);
                }
                if (i != PageList.TotalPages)
                {
                    final.InnerHtml.AppendHtml(tb);
                    final.InnerHtml.AppendHtml(" ");
                }
                else
                {
                    final.InnerHtml.AppendHtml(tb);
                }

            }

            tho.Content.AppendHtml(final.InnerHtml);
        }
    }
}

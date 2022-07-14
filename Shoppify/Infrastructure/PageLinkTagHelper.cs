using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Shoppify.Models.ViewModels;

namespace Shoppify.Infrastructure
{
    //To generate the pagination of the pages to show the products
    [HtmlTargetElement("div",Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory urlHelper)
        {
            urlHelperFactory = urlHelper;
        }
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")] 
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output) 
        { 
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext); 
            TagBuilder result = new TagBuilder("div");
            TagBuilder t = new TagBuilder("ul");
            t.Attributes["class"] = "pagination";
            for (int i = 1; i <= PageModel.TotalPages; i++) 
            {
                TagBuilder li = new TagBuilder("li");
                if(PageModel.CurrentPage == i)
                {
                    li.Attributes["class"] = "page-item active";
                }
                else
                {
                    li.Attributes["class"] = "page-item";
                }
                TagBuilder tag = new TagBuilder("a");
                PageUrlValues["page"] = i;
                tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
                tag.Attributes["class"] = "page-link";
                tag.InnerHtml.Append(i.ToString());
                li.InnerHtml.AppendHtml(tag);
                t.InnerHtml.AppendHtml(li);
                //result.InnerHtml.AppendHtml(tag); 
            }
            result.InnerHtml.AppendHtml(t);
            output.Content.AppendHtml(result.InnerHtml);
        }
        
    }
}

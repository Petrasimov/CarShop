using CarStore.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CarStore.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper: TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory _urlHelperFactory)
        {
            urlHelperFactory = _urlHelperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();
        public bool PageClassesEnabled { get; set; }
        public string Class {  get; set; }
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div"); // <div></div>

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder button = new TagBuilder("a"); //<a></a>
                PageUrlValues["category"] = PageModel.CurrentCategory;
                PageUrlValues["page"] = i;
                button.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);//<a href="page=1"></a>
                if (PageClassesEnabled)
                {
                    button.AddCssClass(PageClass);      //<a href="page=1" class="btn"></a>
                    button.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);//<a href="page=1" class="btn btn-primary"></a>
                }
                button.InnerHtml.Append(i.ToString());  //<a href="page=1" class="btn btn-primary">1</a>
                result.InnerHtml.AppendHtml(button);    // <div><a href="page=1" class="btn btn-primary">1</a></div>
            }
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
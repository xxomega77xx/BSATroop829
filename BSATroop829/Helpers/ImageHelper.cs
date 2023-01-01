using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace BSATroop829.Helpers
{
    public static class ImageExtensions
    {
        public static string Image(this HtmlHelper helper, string name, string url)
        {
            return Image(helper, name, url, null);
        }

        public static string Image(this HtmlHelper helper, string name, string url, object htmlAttributes)
        {
            var tagBuilder = new TagBuilder("img");
            tagBuilder.GenerateId(name,null);

            tagBuilder.Attributes["src"] = new UrlHelper(helper.ViewContext).Content(url);
            tagBuilder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            return tagBuilder.ToString();
        }
    }

}

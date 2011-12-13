using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JLY.Hotel.Web.Infrastucture
{
    public static class MyHelpers
    {
        public static MvcHtmlString Image(this HtmlHelper html, string imageName, object htmlAttributes)
        {
            var tag = new TagBuilder("img");
            UrlHelper myUrl = new UrlHelper(html.ViewContext.RequestContext);
            string route = myUrl.Content("~/Content/images/" + imageName);
            tag.MergeAttribute("src", route);
            tag.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }
    }
}
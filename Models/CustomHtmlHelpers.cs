using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BlowOut.Models
{
    public static class ImageHelper
    {
        public static MvcHtmlString ImageActionLink(this HtmlHelper htmlHelper, 
            string linkText, string action, string controller,
            String routeValues, object htmlAttributes, string imageSrc)

        {
            
            UrlHelper urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);

            TagBuilder img = new TagBuilder("img");

            img.Attributes.Add("src", VirtualPathUtility.ToAbsolute(imageSrc));

            TagBuilder anchor = new TagBuilder("a")
            {
                InnerHtml = img.ToString(TagRenderMode.SelfClosing)
            };

            anchor.Attributes["href"] = urlHelper.Action(action, controller, routeValues);

            anchor.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            
            return MvcHtmlString.Create(anchor.ToString());
        }
    }

    //this is another example of a custom image helper
    public static class ImageHelper2
    {
        public static string Image(this HtmlHelper helper, string id, string url, string alternateText)
        {
            return Image(helper, id, url, alternateText, null);
        }

        public static string Image(this HtmlHelper helper, string id, string url, string alternateText, object htmlAttributes)
        {
            // Create tag builder
            var builder = new TagBuilder("img");

            // Create valid id
            builder.GenerateId(id);

            // Add attributes
            builder.MergeAttribute("src", url);
            builder.MergeAttribute("alt", alternateText);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            // Render tag
            return builder.ToString(TagRenderMode.SelfClosing);
        }

    }
}
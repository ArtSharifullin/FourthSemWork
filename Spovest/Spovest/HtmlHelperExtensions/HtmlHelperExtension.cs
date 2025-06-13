using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Mvc.IUrlHelper;

namespace Spovest.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlContent HeaderLi(this IHtmlHelper htmlHelper, string controller, string action, string text, string class_li, string class_a)
        {
            var routeData = htmlHelper.ViewContext.RouteData;
            var currentController = routeData.Values["controller"]?.ToString();
            var currentAction = routeData.Values["action"]?.ToString();

            // Используем IUrlHelper для генерации URL
            var url = $"/{controller}/{action}";

            var link = $@"<li class=""{class_li}""><a class=""{class_a}"" href=""{url}"">{text}</a></li>";

            return new HtmlString(link);
        }

        public static IHtmlContent HeaderA(this IHtmlHelper htmlHelper, string controller, string action, string text, string class_a)
        {
            var routeData = htmlHelper.ViewContext.RouteData;
            var currentController = routeData.Values["controller"]?.ToString();
            var currentAction = routeData.Values["action"]?.ToString();

            // Используем IUrlHelper для генерации URL
            var url = $"/{controller}/{action}";

            var link = $@"<a class=""{class_a}"" href=""{url}"">{text}</a>";

            return new HtmlString(link);
        }
        public static IHtmlContent HeaderUser(this IHtmlHelper htmlHelper, string controller, string action, string text, string img)
        {
            var routeData = htmlHelper.ViewContext.RouteData;
            var currentController = routeData.Values["controller"]?.ToString();
            var currentAction = routeData.Values["action"]?.ToString();

            // Используем IUrlHelper для генерации URL
            var url = $"/{controller}/{action}";

            var link = $@"<a style=""text-decoration: none; color: black; font-weight: 800;"" href=""{url}""><img src=""{img}"">   {text}</a>";

            return new HtmlString(link);
        }

        public static IHtmlContent ImageLink(this IHtmlHelper htmlHelper, string controller, string action, string alttext, string class_a, string id, string img)
        {
            var routeData = htmlHelper.ViewContext.RouteData;
            var currentController = routeData.Values["controller"]?.ToString();
            var currentAction = routeData.Values["action"]?.ToString();

            // Используем IUrlHelper для генерации URL
            var url = $"/{controller}/{action}";

            var link = $@"<a class=""{class_a}"" href=""{url}""><img src=""{img}"" alt=""{alttext}"" id=""{id}""></a>";

            return new HtmlString(link);
        }
    }
}

using System.Web.Mvc;
using System.Web.Routing;

namespace Backend
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapRoute(
            //    name: "Configurations",
            //    url: "Configurations/{controller}/{action}/{id}",
            //    defaults: new { controller = "Configurations/{controller}", action = "Index", id = UrlParameter.Optional }
                
            //);
            //routes.MapRoute(
            //    name: "Animals",
            //    url: "farm/animals/{action}",
            //    defaults: new { controller = "Farm" }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Projekat
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Error404", "errors/404", new { controller = "Errors", action = "NotFound" });
            routes.MapRoute("ErrorInternal", "errors/internalError", new { controller = "Errors", action = "InternalError" });
            routes.MapRoute("Home", "home/index", new {controller = "Home", action = "Index"});


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

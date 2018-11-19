using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Homework7
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            // Forgot to add the map route
            routes.MapRoute
            (
                name: "SearchGiphy",
                url: "Search/{id}",
                defaults: new { controller = "Search", action = "SearchGiphy", id = UrlParameter.Optional }
            );
        }
    }
}

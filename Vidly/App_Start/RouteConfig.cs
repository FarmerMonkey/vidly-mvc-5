using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Section 2: Lecture 12 - Defining a custom route
            // Problems with this approach
            // 1. This file eventually fills up with a lot of custom routes
            // 2. Have to go back and forth between actions and custom routes
            // 3. Automatic refactoring/renaming in Controller does not work in route -- code becomes fragile
            /*
            routes.MapRoute(
                name: "MoviesByReleaseDate", 
                url: "movies/released/{year}/{month}",
                defaults: new { controller = "Movies", action = "ByReleaseDate" },
                constraints: new { year = @"\d{4}", month = @"\d{2}" }
            );
            */

            //Section 2: Lection 13 - Attribute Routing
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

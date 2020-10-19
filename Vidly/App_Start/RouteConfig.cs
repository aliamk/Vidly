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

            //ATTRIBUTE ROUTING - NEW WAY TO ADD CUSTOM ROUTES - configure in Controller + Random.cshtml
            routes.MapMvcAttributeRoutes();

            // OLD WAY TO MAKE CUSTOM ROUTES - REPLACED BY ATTRIBUTE ROUTING: Custom Route (must position BEFORE/ABOVE the default route & remember to create the Action in Controller)
            /* routes.MapRoute(
                "MoviesByReleaseDate",
                "movies/released/{year}/{month}",
                new { controller = "Movies", action = "ByReleaseDate"},
                // Add constraints: verbatim string using @ because of the slash, digit is represented by d, repetitions repped by 4:  2015/04
                new { year = @"\d{4}", month = @"\d{2}"}
                // new { year = @"2015¦2016", month = @"\d{2}" }  movie list is contrained to the years 2015-2016
                );
            */

            // Default Route
             routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

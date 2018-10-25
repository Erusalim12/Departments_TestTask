using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Departments", action = "Index", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Department",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Departments", Action = "Details", id = UrlParameter.Optional }
                );


            routes.MapRoute(
                name: "Employee",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Employee", Action = "Details", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Employee/Create",
                 url: "{controller}/{action}/{id}",
                defaults: new { controller = "Employee", Action = "Create", id = UrlParameter.Optional }
                );

            routes.MapRoute(
    name: "Employee/Edit",
     url: "{controller}/{action}/{id}",
    defaults: new { controller = "Employee", Action = "Edit", id = UrlParameter.Optional }
    );

        }
    }
}

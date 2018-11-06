using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OtakuStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name:"Home",
                url: "",
                defaults: new { Controller = "Admin", Action = "AdminIndex" });

            routes.MapRoute(
               name: "Product",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Admin",
               url: "{controller}/{action}/{userId}",
               defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "ResetPassword",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Account", action = "ResetPassword", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}

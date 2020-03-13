using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shipment.Api
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { action = "Index", id = UrlParameter.Optional, controller = "Home" }
            );
            //routes.MapRoute(
            //    name: "qwerty",
            //    url: "shipment",
            //    defaults: new { controller = "Shipment", action = "Orders" });


            //routes.MapRoute(
            //    name: "Orders",
            //    url: "orders",
            //    defaults: new { controller = "Shipment", action = "Group" });

            //routes.MapRoute(
            //    name: "Shipment",
            //    url: "shipment",
            //    defaults: new { controller = "Home", action = "Orders" });


            //routes.MapRoute(
            //    name: "shipments",
            //    url: "shipments",
            //    defaults: new { controller = "Home", action = "Orders" });


            //routes.MapRoute(
            //    name: "orders",
            //    url: "orders",
            //    defaults: new { controller = "Shipment", action = "Group" });


            //routes.MapRoute(
            //    name: "Default",
            //    url: "orders",
            //    defaults: new { controller = "Shipment", action = "Group" });
        }
    }
}

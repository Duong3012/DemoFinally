using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NWEB.Practice.T01.Core.Models;

namespace NWEB.Practice.T01.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "SaleOff",
            //    url: "Flower/{categoryName}/{flowerName}/{saleOff}",
            //    new {controller = "Flower", action = "SaleOff"},
            //    new {saleOff = @"\d"}
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Flowers", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CoffeeShopWebsite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Bỏ qua các file .axd
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Route tìm kiếm sản phẩm
            routes.MapRoute(
                name: "Search",
                url: "tim-kiem",
                defaults: new { controller = "Home", action = "Search" }
            );

            // Route xem danh mục sản phẩm
            routes.MapRoute(
                name: "Category",
                url: "danh-muc/{id}",
                defaults: new { controller = "Home", action = "Category", id = UrlParameter.Optional }
            );

            // Route xem chi tiết sản phẩm
            routes.MapRoute(
                name: "ProductDetail",
                url: "san-pham/{id}",
                defaults: new { controller = "Product", action = "Details", id = UrlParameter.Optional }
            );

            // Route mặc định
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}

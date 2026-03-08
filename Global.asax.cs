using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CoffeeShopWebsite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Đăng ký tất cả các Area
            AreaRegistration.RegisterAllAreas();

            // Đăng ký Route
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}

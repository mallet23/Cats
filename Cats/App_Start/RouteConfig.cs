using System.Web.Mvc;
using System.Web.Routing;

namespace ReturnOnIntelligenceTask
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new
                {
                    controller = "Cats",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}
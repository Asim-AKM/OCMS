using System.Web.Mvc;
using System.Web.Routing;

namespace OCMS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    area = "Users",
                    controller = "Auth",
                    action = "Login",
                    id = UrlParameter.Optional
                }
            ).DataTokens["area"] = "Users"; 
        }
    }

}

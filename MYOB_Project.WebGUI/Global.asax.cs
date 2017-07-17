using MYOB_Project.WebGUI.App_Start;
using System.Web.Mvc;
using System.Web.Routing;

namespace MYOB_Project.WebGUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutoMapperConfiguration.Config();
        }
    }
}

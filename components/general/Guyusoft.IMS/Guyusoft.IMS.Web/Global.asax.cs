using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Guyusoft.IMS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IUnityContainer _container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            RegisterComponent.Register();
        }

        public static IUnityContainer Container
        {
            get
            {
                if (_container == null)
                {
                    _container = new UnityContainer();
                }

                return _container;
            }
        }
    }
}
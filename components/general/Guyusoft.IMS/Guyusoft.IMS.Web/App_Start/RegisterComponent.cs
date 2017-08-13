using SqlGeneratorBootstrap = Guyusoft.IMS.SqlGenerator.Bootstrap;
using DbServiceBootstrap = Guyusoft.IMS.DatabaseService.Bootstrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;

namespace Guyusoft.IMS.Web
{
    public class RegisterComponent
    {
        public static void Register()
        {
            IUnityContainer container = MvcApplication.Container;

            var sqlGeneratorComponent = new SqlGeneratorBootstrap.Component(container);
            sqlGeneratorComponent.Register();

            var dbServiceComponent = new DbServiceBootstrap.Component(container);
            dbServiceComponent.Register();
        }
    }
}
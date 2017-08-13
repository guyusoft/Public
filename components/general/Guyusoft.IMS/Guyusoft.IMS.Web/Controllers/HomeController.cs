﻿using Guyusoft.IMS.DatabaseService.DataContract;
using Guyusoft.IMS.DataContract;
using System.Web.Mvc;

namespace Guyusoft.IMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private IServiceExtension<NavigationMenu> _serviceExtension = null;

        public HomeController()
        {
            _serviceExtension = (IServiceExtension<NavigationMenu>)MvcApplication.Container.Resolve(typeof(IServiceExtension<NavigationMenu>), "");
        }

        public ActionResult Index()
        {
            var model = _serviceExtension.GetAll();

            return View(model);
        }
    }
}

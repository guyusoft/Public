using System.Web.Mvc;
using Guyusoft.IMS.DatabaseService.DataContract;
using Guyusoft.IMS.DataContract;
using Guyusoft.IMS.DatabaseService;

namespace Guyusoft.IMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private IServiceExtension<NavigationMenu> _serviceExtension = null;
        private IService<NavigationMenu> _service = null;

        public HomeController()
        {
            _serviceExtension = (IServiceExtension<NavigationMenu>)MvcApplication.Container.Resolve(typeof(IServiceExtension<NavigationMenu>), "");
            _service = (IService<NavigationMenu>)_serviceExtension;
        }

        public ActionResult Index()
        {
            var model = _serviceExtension.GetAll();

            return View(model);
        }
    }
}

using Guyusoft.IMS.DatabaseService.DataContract;
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

        [HttpGet]
        public ActionResult Index()
        {
            var model = _serviceExtension.GetAll();

            return View(model);
        }

        [HttpPost]
        public JsonResult Edit(NavigationMenu menuItem)
        {
            if (menuItem.Id > 0)
            {
                menuItem = _serviceExtension.Update(menuItem);
            }
            else
            {
                menuItem = _serviceExtension.Create(menuItem);
            }

            var result = new JsonResult();

            result.Data = menuItem;

            return result;
        }

        [HttpPost]
        public JsonResult Delete(NavigationMenu menuItem)
        {
            var deleteRes = _serviceExtension.Delete(menuItem.Id);

            var result = new JsonResult();

            result.Data = deleteRes;

            return result;
        }
    }
}

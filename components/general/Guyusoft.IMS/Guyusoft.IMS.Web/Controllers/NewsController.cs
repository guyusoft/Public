using Guyusoft.IMS.DatabaseService.DataContract;
using Guyusoft.IMS.DataContract;
using System.Web.Mvc;

namespace Guyusoft.IMS.Web.Controllers
{
    public class NewsController : Controller
    {
        private IServiceExtension<News> _serviceExtension = null;

        public NewsController()
        {
            _serviceExtension = (IServiceExtension<News>)MvcApplication.Container.Resolve(typeof(IServiceExtension<News>), "");
        }

        public ActionResult Index()
        {
            var model = _serviceExtension.GetAll();

            return View(model);
        }

        public ActionResult Edit()
        {
            return View();
        }
    }
}

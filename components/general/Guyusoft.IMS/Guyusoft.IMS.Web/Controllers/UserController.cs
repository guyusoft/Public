using Guyusoft.IMS.DatabaseService.DataContract;
using Guyusoft.IMS.DataContract;
using System.Web.Mvc;

namespace Guyusoft.IMS.Web.Controllers
{
    public class UserController : Controller
    {
        private IServiceExtension<UserDetail> _serviceExtension = null;

        public UserController()
        {
            _serviceExtension = (IServiceExtension<UserDetail>)MvcApplication.Container.Resolve(typeof(IServiceExtension<UserDetail>), "");
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _serviceExtension.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id > 0 )
            {
                var model = _serviceExtension.Get(id);

                return View(model);
            }
            
            return View();
        }

        [HttpPost]
        public JsonResult Edit(UserDetail item)
        {
            if (item.Id > 0)
            {
                item = _serviceExtension.Update(item);
            }
            else
            {
                item = _serviceExtension.Create(item);
            }

            var result = new JsonResult();

            result.Data = item;

            return result;
        }

        [HttpPost]
        public JsonResult Delete(UserDetail item)
        {
            var deleteRes = _serviceExtension.Delete(item.Id);

            var result = new JsonResult();

            result.Data = deleteRes;

            return result;
        }
    }
}

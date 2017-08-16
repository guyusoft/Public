using Guyusoft.IMS.DatabaseService.DataContract;
using Guyusoft.IMS.DataContract;
using System.Web.Mvc;

namespace Guyusoft.IMS.Web.Controllers
{
    public class ProductCategoryController : Controller
    {
        private IServiceExtension<ProductCategory> _serviceExtension = null;

        public ProductCategoryController()
        {
            _serviceExtension = (IServiceExtension<ProductCategory>)MvcApplication.Container.Resolve(typeof(IServiceExtension<ProductCategory>), "");
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _serviceExtension.GetAll();

            return View(model);
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var result = new JsonResult();

            result.Data = _serviceExtension.GetAll();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return result;
        }

        [HttpPost]
        public JsonResult Edit(ProductCategory item)
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
        public JsonResult Delete(ProductCategory item)
        {
            var deleteRes = _serviceExtension.Delete(item.Id);

            var result = new JsonResult();

            result.Data = deleteRes;

            return result;
        }
    }
}

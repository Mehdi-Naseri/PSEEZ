using System.Web.Mvc;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.Extentions.MapperConfigure.Extention.Sts;
using Pseez.ServiceLayer.Interfaces.Sts.Basic;

namespace Pseez.UI.HumanResource.Areas.Personnel.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private IUnitOfWorkSts _uow;

        public CityController(IUnitOfWorkSts uow, ICityService bloodTypeService)
        {
            _cityService = bloodTypeService;
            _uow = uow;
        }

        // GET: /Personnel/City/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Read()
        {
            //StsContext db = new StsContext();
            ////جهت غیر فعال کردن لود فرزندان در در نتیجه جلوگیری از ایجاد حلقه
            //db.Configuration.ProxyCreationEnabled = false;
            //var a = db.Cities.ToArray();
            var a = _cityService.GetAll().MapModelToViewModel();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}
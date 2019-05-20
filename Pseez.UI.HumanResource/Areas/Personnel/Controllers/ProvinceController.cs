using System.Web.Mvc;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.Extentions.MapperConfigure.Extention.Sts;
using Pseez.ServiceLayer.Interfaces.Sts.Basic;

namespace Pseez.UI.HumanResource.Areas.Personnel.Controllers
{
    public class ProvinceController : Controller
    {
        private readonly IProvinceService _provinceService;
        private IUnitOfWorkSts _uow;

        public ProvinceController(IUnitOfWorkSts uow, IProvinceService provinceService)
        {
            _provinceService = provinceService;
            _uow = uow;
        }

        //
        // GET: /Personnel/Province/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Read()
        {
            //StsContext db = new StsContext();
            ////جهت غیر فعال کردن لود فرزندان و در نتیجه جلوگیری از ایجاد حلقه
            //db.Configuration.ProxyCreationEnabled = false;
            //var a = db.Provinces.ToArray();
            var a = _provinceService.GetAll().MapModelToViewModel();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}
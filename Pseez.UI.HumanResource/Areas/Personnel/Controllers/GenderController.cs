using System.Web.Mvc;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.Extentions.MapperConfigure.Extention.Sts;
using Pseez.ServiceLayer.Interfaces.Sts.Basic;

namespace Pseez.UI.HumanResource.Areas.Personnel.Controllers
{
    public class GenderController : Controller
    {
        private readonly IGenderService _genderService;
        private IUnitOfWorkSts _uow;

        public GenderController(IUnitOfWorkSts uow, IGenderService genderService)
        {
            _genderService = genderService;
            _uow = uow;
        }

        //
        // GET: /Personnel/Gender/
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
            //var a = db.Genders.ToArray();
            var a = _genderService.GetAll().MapModelToViewModel();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}
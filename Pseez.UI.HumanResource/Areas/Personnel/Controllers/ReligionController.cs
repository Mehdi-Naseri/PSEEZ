using System.Web.Mvc;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.Extentions.MapperConfigure.Extention.Sts;
using Pseez.ServiceLayer.Interfaces.Sts.Staff;

namespace Pseez.UI.HumanResource.Areas.Personnel.Controllers
{
    public class ReligionController : Controller
    {
        private readonly IReligionService _religionService;
        private IUnitOfWorkSts _uow;

        public ReligionController(IUnitOfWorkSts uow, IReligionService religionService)
        {
            _religionService = religionService;
            _uow = uow;
        }

        //
        // GET: /Personnel/Religion/
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
            //var a = db.Religions.ToArray();
            var a = _religionService.GetAll().MapModelToViewModel();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}
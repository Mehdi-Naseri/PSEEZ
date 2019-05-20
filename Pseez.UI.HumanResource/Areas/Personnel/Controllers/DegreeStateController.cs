using System.Web.Mvc;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.Extentions.MapperConfigure.Extention.Sts;
using Pseez.ServiceLayer.Interfaces.Sts.Staff;

namespace Pseez.UI.HumanResource.Areas.Personnel.Controllers
{
    public class DegreeStateController : Controller
    {
        private readonly IDegreeStateService _degreeStateService;
        private IUnitOfWorkSts _uow;

        public DegreeStateController(IUnitOfWorkSts uow, IDegreeStateService degreeStateService)
        {
            _degreeStateService = degreeStateService;
            _uow = uow;
        }

        //
        // GET: /Personnel/DegreeState/
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
            //var a = db.DegreeStates.ToArray();
            var a = _degreeStateService.GetAll().MapModelToViewModel();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}
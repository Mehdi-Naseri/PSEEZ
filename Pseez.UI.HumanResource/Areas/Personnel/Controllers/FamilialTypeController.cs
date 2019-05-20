using System.Web.Mvc;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.Extentions.MapperConfigure.Extention.Sts;
using Pseez.ServiceLayer.Interfaces.Sts.Staff;

namespace Pseez.UI.HumanResource.Areas.Personnel.Controllers
{
    public class FamilialTypeController : Controller
    {
        private readonly IFamilialTypeService _familialTypeService;
        private IUnitOfWorkSts _uow;

        public FamilialTypeController(IUnitOfWorkSts uow, IFamilialTypeService familialTypeService)
        {
            _familialTypeService = familialTypeService;
            _uow = uow;
        }

        //
        // GET: /Personnel/FamilialType/
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
            //var a = db.FamilialTypes.ToArray();
            var a = _familialTypeService.GetAll().MapModelToViewModel();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}
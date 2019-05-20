using System.Web.Mvc;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.Extentions.MapperConfigure.Extention.Sts;
using Pseez.ServiceLayer.Interfaces.Sts.Staff;

namespace Pseez.UI.HumanResource.Areas.Personnel.Controllers
{
    public class EmployeeFamilialTypeController : Controller
    {
        private readonly IEmployeeFamilialTypeService _employeeFamilialTypeService;
        private IUnitOfWorkSts _uow;

        public EmployeeFamilialTypeController(IUnitOfWorkSts uow,
            IEmployeeFamilialTypeService employeeFamilialTypeService)
        {
            _employeeFamilialTypeService = employeeFamilialTypeService;
            _uow = uow;
        }

        //
        // GET: /Personnel/EmployeeFamilialType/
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
            //var a = db.EmployeeFamilialTypes.ToArray();
            var a = _employeeFamilialTypeService.GetAll().MapModelToViewModel();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}
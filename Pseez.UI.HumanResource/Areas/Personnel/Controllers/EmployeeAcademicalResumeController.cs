using System.Web.Mvc;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.Extentions.MapperConfigure.Extention.Sts;
using Pseez.ServiceLayer.Interfaces.Sts.Staff;

namespace Pseez.UI.HumanResource.Areas.Personnel.Controllers
{
    public class EmployeeAcademicalResumeController : Controller
    {
        private readonly IEmployeeAcademicalResumeService _employeeAcademicalResumeService;
        private IUnitOfWorkSts _uow;

        public EmployeeAcademicalResumeController(IUnitOfWorkSts uow,
            IEmployeeAcademicalResumeService employeeAcademicalResumeService)
        {
            _employeeAcademicalResumeService = employeeAcademicalResumeService;
            _uow = uow;
        }

        //
        // GET: /Personnel/EmployeeAcademicalResume/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Read()
        {
            //StsContext db = new StsContext();
            //جهت غیر فعال کردن لود فرزندان و در نتیجه جلوگیری از ایجاد حلقه
            //db.Configuration.ProxyCreationEnabled = false;
            //var a = db.EmployeeAcademicalResumes.ToArray();
            var a = _employeeAcademicalResumeService.GetAll().MapModelToViewModel();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}
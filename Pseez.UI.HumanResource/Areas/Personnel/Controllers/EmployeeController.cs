using System.Web.Mvc;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.Extentions.MapperConfigure.Extention.Sts;
using Pseez.ServiceLayer.Interfaces.Sts.Staff;

namespace Pseez.UI.HumanResource.Areas.Personnel.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private IUnitOfWorkSts _uow;

        public EmployeeController(IUnitOfWorkSts uow, IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            _uow = uow;
        }

        //
        // GET: /Personnel/Employee/
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
            //var a = db.Employees.Select(r => new
            //{
            //    Id = r.Id,
            //    Code = r.Code,
            //    CardId = r.CardId,
            //    CreationFileDate = r.CreationFileDate,
            //    PrimaryEmploymentDate = r.PrimaryEmploymentDate,
            //    Native_Id = r.Native_Id,
            //    Religion_Id = r.Religion_Id,
            //    EMail = r.EMail,
            //    BloodType_Id = r.BloodType_Id,
            //    CompanyType_Id = r.CompanyType_Id,
            //    FamilyCardId = r.FamilyCardId
            //});
            var a = _employeeService.GetAll().MapModelToViewModel();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}
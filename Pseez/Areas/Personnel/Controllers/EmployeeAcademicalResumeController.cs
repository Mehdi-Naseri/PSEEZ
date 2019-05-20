using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//using Pseez.DataLayer.DataContext;
using Pseez.DataLayer.IUnitOfWork;
using Pseez.ServiceLayer.Interfaces.Sts.Staff;
//using Pseez.DomainClasses.Models.Sts;
using Pseez.Model.ViewModels.Sts.Staff;
using Pseez.Model.MapperConfigure.Extention.Sts;

namespace Pseez.Areas.Personnel.Controllers
{
    public class EmployeeAcademicalResumeController : Controller
    {
        private IEmployeeAcademicalResumeService _employeeAcademicalResumeService;
        private IUnitOfWorkSts _uow;

        public EmployeeAcademicalResumeController(IUnitOfWorkSts uow, IEmployeeAcademicalResumeService employeeAcademicalResumeService)
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
            IEnumerable<EmployeeAcademicalResumeViewModel> a = _employeeAcademicalResumeService.GetAll().MapModelToViewModel();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
	}
}
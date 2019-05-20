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
    public class EmployeeFamilialTypeController : Controller
    {
        private IEmployeeFamilialTypeService _employeeFamilialTypeService;
        private IUnitOfWorkSts _uow;

        public EmployeeFamilialTypeController(IUnitOfWorkSts uow, IEmployeeFamilialTypeService employeeFamilialTypeService)
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
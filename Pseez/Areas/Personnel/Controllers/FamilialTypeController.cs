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
    public class FamilialTypeController : Controller
    {
        private IFamilialTypeService _familialTypeService;
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
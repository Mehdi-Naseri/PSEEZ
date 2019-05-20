using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//using Pseez.DataLayer.DataContext;
using Pseez.DataLayer.IUnitOfWork;
using Pseez.ServiceLayer.Interfaces.Sts.Basic;
//using Pseez.DomainClasses.Models.Sts;
using Pseez.Model.ViewModels.Sts.Basic;
using Pseez.Model.MapperConfigure.Extention.Sts;

namespace Pseez.Areas.Personnel.Controllers
{
    public class GenderController : Controller
    {
        private IGenderService _genderService;
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
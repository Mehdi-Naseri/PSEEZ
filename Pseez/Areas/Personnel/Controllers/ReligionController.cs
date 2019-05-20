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
    public class ReligionController : Controller
    {
        private IReligionService _religionService;
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
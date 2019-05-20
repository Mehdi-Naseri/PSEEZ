using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//using Pseez.DataLayer.DataContext;
using Pseez.DataLayer.IUnitOfWork;
using Pseez.ServiceLayer.Interfaces.Sts.Basic;
//using Pseez.DomainClasses.Models.Sts.Basic;
//using Pseez.Model.ViewModels.Sts.Basic;
using Pseez.Model.MapperConfigure.Extention.Sts;

namespace Pseez.Areas.Personnel.Controllers
{
    public class CityController : Controller
    {
        private ICityService _cityService;
        private IUnitOfWorkSts _uow;

        public CityController(IUnitOfWorkSts uow, ICityService bloodTypeService)
        {
            _cityService = bloodTypeService;
            _uow = uow;
        }

        // GET: /Personnel/City/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Read()
        {
            //StsContext db = new StsContext();
            ////جهت غیر فعال کردن لود فرزندان در در نتیجه جلوگیری از ایجاد حلقه
            //db.Configuration.ProxyCreationEnabled = false;
            //var a = db.Cities.ToArray();
            var a = _cityService.GetAll().MapModelToViewModel();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
	}
}
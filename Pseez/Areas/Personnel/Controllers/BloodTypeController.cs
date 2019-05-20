using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


//using Pseez.DataLayer.DataContext;
using Pseez.DataLayer.IUnitOfWork;
using Pseez.ServiceLayer.Interfaces.Sts.Staff;
//using Pseez.DomainClasses.Models.Sts;
//using Pseez.Model.ViewModels.Sts.Basic;
using Pseez.Model.MapperConfigure.Extention.Sts;

namespace Pseez.Areas.Personnel.Controllers
{
    public class BloodTypeController : Controller
    {
        private IBloodTypeService _bloodTypeService;
        private IUnitOfWorkSts _uow;

        public BloodTypeController(IUnitOfWorkSts uow, IBloodTypeService bloodTypeService)
        {
            _bloodTypeService = bloodTypeService;
            _uow = uow;
        }

        // GET: /Personnel/BloodType/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Read()
        {
            //StsContext db = new StsContext();
            //db.Configuration.ProxyCreationEnabled = false;
            //var a = db.BloodTypes.ToArray();
            var r =  _bloodTypeService.GetAll().MapModelToViewModel();
            return Json(r, JsonRequestBehavior.AllowGet);
        }

    }
}

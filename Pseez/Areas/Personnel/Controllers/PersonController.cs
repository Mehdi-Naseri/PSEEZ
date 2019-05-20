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
    public class PersonController : Controller
    {

        private IPersonService _personService;
        private IUnitOfWorkSts _uow;

        public PersonController(IUnitOfWorkSts uow, IPersonService personService)
        {
            _personService = personService;
            _uow = uow;
        }
        //
        // GET: /Personnel/Person/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Read()
        {
            //StsContext db = new StsContext();
            //db.Configuration.ProxyCreationEnabled = false;
            //var a = db.People.ToArray();
            var a = _personService.GetAll().MapModelToViewModel();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
	}
}
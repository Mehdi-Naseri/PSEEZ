using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.Extentions.MapperConfigure.Extention.PseezEnt;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Cmms;
using Pseez.ViewModels.ViewModels.PseezEnt.Cmms;

namespace Pseez.UI.Cmms.Areas.Request.Controllers
{
    public class TechnitionController : Controller
    {
        private IUnitOfWorkPseezEnt _uow;
        private IRepairRequestService _repairRequestService;

        public TechnitionController(IUnitOfWorkPseezEnt uow, IRepairRequestService repairRequestService)
        {
            _uow = uow;
            _repairRequestService = repairRequestService;
        }

        // GET: Request/Technition
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Read()
        {
            IEnumerable<RequestTechnitionViewModel> requestUserViewModel = _repairRequestService.GetAll().MapModelToViewModelRequestTechnition();
            return Json(requestUserViewModel, JsonRequestBehavior.AllowGet);
            //return View(db.RepairRequest.ToList());
        }

        public ActionResult TodoList()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ReadTodoList()
        {
            IEnumerable<RequestTechnitionViewModel> requestUserViewModel = _repairRequestService.GetAll(r => r.TechnitionTodo = true).MapModelToViewModelRequestTechnition();
            return Json(requestUserViewModel, JsonRequestBehavior.AllowGet);
            //return View(db.RepairRequest.ToList());
        }

        public ActionResult Analyze()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Analyze([Bind(Include = "RequestByName,MainSite,SiteSecondary,RequestType,Description")] RequestTechnitionViewModel requestTechnitionViewModel)
        {
            return View();
        }
    }
}
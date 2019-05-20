using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.PseezEnt.Cmms;
using Pseez.Extentions.MapperConfigure.Extention.PseezEnt;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Cmms;
using Pseez.ViewModels.ViewModels.PseezEnt.Cmms;

namespace Pseez.UI.Cmms.Areas.Request.Controllers
{
    public class PlanningController : Controller
    {
        private IUnitOfWorkPseezEnt _uow;
        private IRepairRequestService _repairRequestService;

        public PlanningController(IUnitOfWorkPseezEnt uow, IRepairRequestService repairRequestService)
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
            IEnumerable<RequestPlanningViewModel> requestUserViewModel = _repairRequestService.GetAll().MapModelToViewModelRequestPlanning();
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
            IEnumerable<RequestPlanningViewModel> requestUserViewModel = _repairRequestService.GetAll(r => r.PlanningTodo == true).MapModelToViewModelRequestPlanning();
            return Json(requestUserViewModel, JsonRequestBehavior.AllowGet);
            //return View(db.RepairRequest.ToList());
        }

        public ActionResult Analyze(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestPlanningViewModel requestPlanningViewModel = _repairRequestService.FindById((int)id).MapModelToViewModelRequestPlanning();
            if (requestPlanningViewModel == null)
            {
                return HttpNotFound();
            }

            var mainSiteList = new SelectList(new[] { "سایت 1 - مرکزی",
                                                        "سایت 2 - اداری 2",
                                                        "سایت 3 - بازارچه",
                                                        "سایت 4 - کمپ 4",
                                                        "سایت 5 - پایانه بار",
                                                        "سایت 6 - اسکله و بندر",
                                                        "سایت 7 - شیرینو",
                                                        "سایت 8 - کمپ EPC",
            });
            ViewBag.MainSiteList = mainSiteList;
            var requestType = new SelectList(new[] { "تعميرات", "نصب تجهيزات جديد" });
            ViewBag.RequestType = requestType;
            var taskType = new SelectList(new[] { "برق و دیزل" , "تاسیسات و مکانیک عمومی" , "برودت و تهویه" , "ابنیه"});
            ViewBag.TaskType = taskType;



            return View(requestPlanningViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Analyze([Bind(Include = "Id,RequestByName,RequestDate,MainSite,SiteSecondary,RequestType,Description,TaskType,Supervisor,SeniorSupervisor,MaxDurationTime")] RequestPlanningViewModel requestPlanningViewModel)
        {
            if (ModelState.IsValid)
            {
                var mainSiteList = new SelectList(new[] { "سایت 1 - مرکزی",
                                                        "سایت 2 - اداری 2",
                                                        "سایت 3 - بازارچه",
                                                        "سایت 4 - کمپ 4",
                                                        "سایت 5 - پایانه بار",
                                                        "سایت 6 - اسکله و بندر",
                                                        "سایت 7 - شیرینو",
                                                        "سایت 8 - کمپ EPC",
            });
                ViewBag.MainSiteList = mainSiteList;
                var requestType = new SelectList(new[] { "تعميرات", "نصب تجهيزات جديد" });
                ViewBag.RequestType = requestType;
                var taskType = new SelectList(new[] { "برق و دیزل", "تاسیسات و مکانیک عمومی", "برودت و تهویه", "ابنیه" });
                ViewBag.TaskType = taskType;

                RepairRequest repairRequest = _repairRequestService.FindById(requestPlanningViewModel.Id);
                repairRequest.RequestByName = requestPlanningViewModel.RequestByName;
                repairRequest.RequestDate = requestPlanningViewModel.RequestDate;
                repairRequest.MainSite = requestPlanningViewModel.MainSite;
                repairRequest.SiteSecondary = requestPlanningViewModel.SiteSecondary;
                repairRequest.RequestType = requestPlanningViewModel.RequestType;
                repairRequest.Description = requestPlanningViewModel.Description;
                repairRequest.TaskType = requestPlanningViewModel.TaskType;
                repairRequest.Supervisor = requestPlanningViewModel.Supervisor;
                repairRequest.SeniorSupervisor = requestPlanningViewModel.SeniorSupervisor;
                repairRequest.MaxDurationTime = requestPlanningViewModel.MaxDurationTime;
                repairRequest.PlanningTodo = false;
                repairRequest.TechnitionTodo = true;
                
                _uow.SaveChanges();
                return RedirectToAction("TodoList");
            }
            return View(requestPlanningViewModel);
        }

        // GET: Request/RepairRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestPlanningViewModel requestplanningViewModel = _repairRequestService.FindById((int)id).MapModelToViewModelRequestPlanning();
            if (requestplanningViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Details", requestplanningViewModel);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pseez.DataAccessLayer.DataContext;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.PseezEnt.Cmms;
using Pseez.ViewModels.ViewModels.PseezEnt.Cmms;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Cmms;
using Pseez.ServiceLayer.Interfaces.PseezEnt.VisitRegistration;
using Pseez.Extentions.MapperConfigure.Extention.PseezEnt;
using Pseez.CommonLibrary;

namespace Pseez.UI.Cmms.Areas.Request.Controllers
{
    public class RepairRequestsController : Controller
    {
        private IUnitOfWorkPseezEnt _uow;
        private IRepairRequestService _repairRequestService;
        //private PseezEntDbContext db = new PseezEntDbContext();

        public RepairRequestsController(IUnitOfWorkPseezEnt uow, IRepairRequestService repairRequestService)
        {
            _uow = uow;
            _repairRequestService = repairRequestService;
        }

        // GET: Request/RepairRequests
        public ActionResult Index()
        {
            //IEnumerable<RequestUserViewModel> requestUserViewModel = _repairRequestService.GetAll().MapModelToViewModelRequestUser();
            //return View(requestUserViewModel);
            //return View(db.RepairRequest.ToList());
            return View();
        }

        [HttpGet]
        public ActionResult Read()
        {
            IEnumerable<RequestUserViewModel> requestUserViewModel = _repairRequestService.GetAll().MapModelToViewModelRequestUser();
            return Json(requestUserViewModel, JsonRequestBehavior.AllowGet);
            //return View(db.RepairRequest.ToList());
        }

        // GET: Request/RepairRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestUserViewModel requestUserViewModel = _repairRequestService.FindById((int)id).MapModelToViewModelRequestUser();
            if (requestUserViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Details", requestUserViewModel);
        }

        // GET: Request/RepairRequests/Create
        public ActionResult Create()
        {
            //var MainSiteList = new List<SelectListItem>();
            //MainSiteList.Add(new SelectListItem() {Text = "سایت 1"});
            //MainSiteList.Add(new SelectListItem() { Text = "سایت 2" });
            //MainSiteList.Add(new SelectListItem() { Text = "سایت 3" });
            //ViewBag.MainSiteList = MainSiteList;


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

            return View();
        }

        // POST: Request/RepairRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestByName,MainSite,SiteSecondary,RequestType,Description")] RequestUserViewModel requestUserViewModel)
        {
            if (ModelState.IsValid)
            {
                PersianDateTime persianDateTime = new PersianDateTime();
                requestUserViewModel.RequestDate = persianDateTime.GregorianToShamsi(DateTime.Now);
                RepairRequest repairRequest = requestUserViewModel.MapViewModelToModel();
                repairRequest.PlanningTodo = true;
                _repairRequestService.Add(repairRequest);
                _uow.SaveChanges();
                return RedirectToAction("Index");
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

            return View(requestUserViewModel);
        }

        //// GET: Request/RepairRequests/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    RepairRequest repairRequest = db.RepairRequest.Find(id);
        //    if (repairRequest == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(repairRequest);
        //}

        //// POST: Request/RepairRequests/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,RequestByName,RequestById,RequestDate,TimeStamp")] RepairRequest repairRequest)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(repairRequest).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(repairRequest);
        //}

        // GET: Request/RepairRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestUserViewModel requestUserViewModel = _repairRequestService.FindById((int)id).MapModelToViewModelRequestUser();
            if (requestUserViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", requestUserViewModel);
        }

        // POST: Request/RepairRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repairRequestService.DeleteById(id);
            _uow.SaveChanges();
            return Json(new { success = true });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

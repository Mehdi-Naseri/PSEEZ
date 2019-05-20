using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


using Pseez.DataLayer.IUnitOfWork;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Datacenter;
using Pseez.DomainClasses.Models.PseezEnt.Datacenter;
using Pseez.Model.ViewModels.PseezEnt.Datacenter;
using Pseez.Model.MapperConfigure.Extention.PseezEnt;

//این خط باید حذف گردد
//using Pseez.DataLayer.DataContext;

namespace Pseez.Areas.DataCenter.Controllers
{
    public class ServersController : Controller
    {
        private IServerService _serverService;
        private IUnitOfWorkPseezEnt _uow;

        public ServersController(IUnitOfWorkPseezEnt uow, IServerService serverService)
        {
            _serverService = serverService;
            _uow = uow;
        }

        // GET: /DataCenter/Servers/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Read()
        {
            IEnumerable<ServerViewModel> a = _serverService.GetAll().MapModelToViewModel();
            return Json(a, JsonRequestBehavior.AllowGet);
        }


        // GET: /DataCenter/Servers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Server server = _serverService.FindById((int)id);
            if (server == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Details", server.MapModelToViewModel());
        }

        // GET: /DataCenter/Servers/Create
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        // POST: /DataCenter/Default1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServerName,IP")] ServerViewModel serverViewModel)
        {
            _serverService.GetAll().MapModelToViewModel();
            if (ModelState.IsValid)
            {
                _serverService.Add(serverViewModel.MapViewModelToModel());
                _uow.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("_Create", serverViewModel);
        }

        // GET: /DataCenter/Servers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Server server = _serverService.FindById((int)id);
            if (server == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Edit", server.MapModelToViewModel());
        }

        // POST: /DataCenter/Servers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ServerName,IP")] ServerViewModel serverViewNodel)
        {
            if (ModelState.IsValid)
            {
                Server item = _serverService.FindById(serverViewNodel.Id);
                item.ServerName = serverViewNodel.ServerName;
                item.IP = serverViewNodel.IP;
                _uow.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("_Edit", serverViewNodel);
        }

        // GET: /DataCenter/Servers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Server server = _serverService.FindById((int)id);
            if (server == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", server.MapModelToViewModel());
        }

        // POST: /DataCenter/Servers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _serverService.DeleteById(id);
            _uow.SaveChanges();
            return Json(new { success = true });
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //serverRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}

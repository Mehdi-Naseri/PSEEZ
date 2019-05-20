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


namespace Pseez.Areas.DataCenter.Controllers
{
    public class BackupController : Controller
    {
        private IBackupService _backupService;
        private IUnitOfWorkPseezEnt _uow;

        public BackupController(IUnitOfWorkPseezEnt uow, IBackupService backupService)
        {
            _backupService = backupService;
            _uow = uow;
        }

        // GET: /DataCenter/Backup/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Read()
        {
            //جهت غیر فعال کردن لود فرزندان در در نتیجه جلوگیری از ایجاد حلقه
            //db.Configuration.ProxyCreationEnabled = false;
            IEnumerable<BackupViewModel> a = _backupService.GetAll().MapModelToViewModel();
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        // GET: /DataCenter/Backup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Backup backup = _backupService.FindById((int)id);
            if (backup == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Details", backup.MapModelToViewModel());
        }

        // GET: /DataCenter/Backup/Create
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        // POST: /DataCenter/Backup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SystemName,IP,FullBackupAddress,DifferentialBackupAddress,IncrementalBackupAddress")] BackupViewModel backupViewModel)
        {
            if (ModelState.IsValid)
            {
                _backupService.Add(backupViewModel.MapViewModelToModel());
                _uow.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("_Create", backupViewModel);
        }

        // GET: /DataCenter/Backup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Backup backup = _backupService.FindById((int)id);
            if (backup == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Edit", backup.MapModelToViewModel());
        }

        // POST: /DataCenter/Backup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,SystemName,IP,FullBackupAddress,DifferentialBackupAddress,IncrementalBackupAddress")] BackupViewModel backupViewModel)
        {
            if (ModelState.IsValid)
            {
                Backup backup = _backupService.FindById(backupViewModel.Id);
                backup.SystemName = backupViewModel.SystemName;
                backup.IP = backupViewModel.IP;
                backup.FullBackupAddress = backupViewModel.FullBackupAddress;
                backup.DifferentialBackupAddress = backupViewModel.DifferentialBackupAddress;
                backup.IncrementalBackupAddress = backupViewModel.IncrementalBackupAddress;
                _uow.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("_Edit", backupViewModel);
        }

        // GET: /DataCenter/Backup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Backup backup = _backupService.FindById((int)id);
            if (backup == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", backup.MapModelToViewModel());
        }

        // POST: /DataCenter/Backup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _backupService.DeleteById(id);
            _uow.SaveChanges();
            return Json(new { success = true });
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            base.Dispose(disposing);
        }
    }
}

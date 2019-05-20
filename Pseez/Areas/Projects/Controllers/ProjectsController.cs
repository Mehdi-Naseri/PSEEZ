using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using Pseez.DataLayer.DataContext;

using Pseez.DataLayer.IUnitOfWork;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Project;
using Pseez.DomainClasses.Models.PseezEnt.Project;
using Pseez.Model.ViewModels.PseezEnt.Project;
using Pseez.Model.MapperConfigure.Extention.PseezEnt;

namespace Pseez.Areas.Projects.Controllers
{
    public class ProjectsController : Controller
    {

        private IProjectService _projectService;
        private IUnitOfWorkPseezEnt _uow;

        public ProjectsController(IUnitOfWorkPseezEnt uow, IProjectService projectService)
        {
            _projectService = projectService;
            _uow = uow;
        }


        private PseezEntContext db = new PseezEntContext();

        // GET: /Projects/Projects/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Read()
        {
            IEnumerable<Project> b = _projectService.GetAll();
            //IEnumerable<ProjectViewModel> a = _projectService.GetAll().MapModelToViewModel();
            return Json(b, JsonRequestBehavior.AllowGet);
        }

        // GET: /Projects/Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = _projectService.FindById((int)id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Details", project.MapModelToViewModel());
        }

        // GET: /Projects/Projects/Create
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        // POST: /Projects/Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] ProjectViewModel projectViewModel)
        {
            if (ModelState.IsValid)
            {
                _projectService.Add(projectViewModel.MapViewModelToModel());
                _uow.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("_Create", projectViewModel);
        }

        // GET: /Projects/Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = _projectService.FindById((int)id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Edit", project.MapModelToViewModel());
        }

        // POST: /Projects/Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] ProjectViewModel projectViewModel)
        {
            if (ModelState.IsValid)
            {
                Project project = _projectService.FindById(projectViewModel.Id);
                project.Name = projectViewModel.Name;
                _uow.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("_Edit", projectViewModel);
        }

        // GET: /Projects/Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = _projectService.FindById((int)id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", project.MapModelToViewModel());
        }

        // POST: /Projects/Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _projectService.DeleteById(id);
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

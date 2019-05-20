using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.PseezEnt.Pmbok;
using Pseez.Extentions.MapperConfigure.Extention.PseezEnt;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Pmbok;
using Pseez.ViewModels.ViewModels.PseezEnt.Pmbok;

namespace Pseez.UI.Pmbok.Areas.Projects.Controllers
{
    public class ProjectsController : Controller
    {
        private IUnitOfWorkPseezEnt _uow;
        private IProjectService _projectService;
        public ProjectsController(IUnitOfWorkPseezEnt uow, IProjectService projectService)
        {
            _uow = uow;
            _projectService = projectService;
        }

        // GET: Projects/Projects
        public ActionResult Index()
        {
            IEnumerable<Project> AllProjects = _projectService.GetAll();
            ViewBag.ProjectNames = new SelectList(AllProjects, "Name", "Name");
            ViewBag.ProjectNamesList = AllProjects.Select(r => r.Name);
            return View();
        }

        [HttpGet]
        public ActionResult Read()
        {
            IEnumerable<ProjectViewModel> a = _projectService.GetAll().MapModelToViewModel();
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        // GET: Projects/Projects/Details/5
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
            return PartialView("_Details",project.MapModelToViewModel());
        }

        // GET: Projects/Projects/Create
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        // POST: Projects/Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,StartDate,EndDate")] ProjectViewModel projectViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_projectService.Exist(projectViewModel.Name))
                {
                    _projectService.Add(projectViewModel.MapViewModelToModel());
                    _uow.SaveChanges();
                    return Json(new { success = true });
                }
                else
                {
                    ModelState.AddModelError("DuplicateRecord", "This project name has already exist.");
                }
            }
            return PartialView("_Create",projectViewModel);
        }

        // GET: Projects/Projects/Edit/5
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
            return PartialView("_Edit",project.MapModelToViewModel());
        }

        // POST: Projects/Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,StartDate,EndDate")] ProjectViewModel projectViewModel)
        {
            if (ModelState.IsValid)
            {
                if (_projectService.FindById(projectViewModel.Id).Name == projectViewModel.Name ||
                        !_projectService.Exist(projectViewModel.Name))
                {
                    Project project = _projectService.FindById(projectViewModel.Id);
                    project.Name = projectViewModel.Name;
                    project.StartDate = projectViewModel.StartDate;
                    project.EndDate = projectViewModel.EndDate;
                    _uow.SaveChanges();
                    return Json(new { success = true });
                }
                else
                {
                    ModelState.AddModelError("DuplicateRecord", "This project name has already exist.");
                }
            }
            return PartialView("_Edit",projectViewModel);
        }

        // GET: Projects/Projects/Delete/5
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
            return PartialView("_Delete",project.MapModelToViewModel());
        }

        // POST: Projects/Projects/Delete/5
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
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            base.Dispose(disposing);
        }
    }
}

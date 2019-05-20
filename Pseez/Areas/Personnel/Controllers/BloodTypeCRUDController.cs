using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

//using Pseez.DomainClasses.Models.Sts.Staff;
//using Pseez.DataLayer.DataContext;

using Pseez.DataLayer.IUnitOfWork;
using Pseez.ServiceLayer.Interfaces.Sts.Staff;
using Pseez.DomainClasses.Models.Sts.Staff;
using Pseez.Model.ViewModels.Sts.Staff;
using Pseez.Model.MapperConfigure.Extention.Sts;

namespace Pseez.Areas.Personnel.Controllers
{
    public class BloodTypeCRUDController : Controller
    {
        //private StsContext PersonnelContext = new StsContext();
        private IBloodTypeService _bloodTypeService;
        private IUnitOfWorkSts _uow;
        public BloodTypeCRUDController(IUnitOfWorkSts uow, IBloodTypeService bloodTypeService)
        {
            _bloodTypeService = bloodTypeService;
            _uow = uow;
        }

        // GET: /Personnel/BloodType/
        public ActionResult Index()
        {
            //var a = PersonnelContext.BloodTypes.ToList();
            var r = _bloodTypeService.GetAll().MapModelToViewModel();
            return View(r);
        }

        // GET: /Personnel/BloodType/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodType bloodType = _bloodTypeService.FindById((int)id); ;
            if (bloodType == null)
            {
                return HttpNotFound();
            }
            return View(bloodType);
        }

        // GET: /Personnel/BloodType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Personnel/BloodType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="Id,Title,TimeStamp,Describer")] BloodType bloodtype)
        //public ActionResult Create([Bind(Include = "Title")] BloodType bloodtype)
        public ActionResult Create([Bind(Include = "Title")] BloodTypeViewModel bloodTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                //BloodType BloodTypeNew = new BloodType();
                //BloodTypeNew.Title = "Test";
                //BloodTypeNew.Id = 100;

                //PersonnelContext.BloodTypes.Add(BloodTypeNew);
                //PersonnelContext.SaveChanges();

                _bloodTypeService.Add(bloodTypeViewModel.MapViewModelToModel());
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bloodTypeViewModel);
        }

        // GET: /Personnel/BloodType/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodType bloodtype = _bloodTypeService.FindById((int) id);
            if (bloodtype == null)
            {
                return HttpNotFound();
            }
            return View(bloodtype.MapModelToViewModel());
        }

        // POST: /Personnel/BloodType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title")] BloodTypeViewModel bloodTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                //BloodType bloodtypeNew = PersonnelContext.BloodTypes.FirstOrDefault(r => r.Id == bloodtype.Id);
                //bloodtypeNew.Title = bloodtype.Title;

                //PersonnelContext.Entry(bloodtypeNew).State = EntityState.Modified;
                //PersonnelContext.SaveChanges();

                BloodType item =  _bloodTypeService.FindById((int) bloodTypeViewModel.Id);
                item.Id = bloodTypeViewModel.Id;
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bloodTypeViewModel);
        }

        // GET: /Personnel/BloodType/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodType bloodtype = _bloodTypeService.FindById((int)id); 
            if (bloodtype == null)
            {
                return HttpNotFound();
            }
            return View(bloodtype);
        }

        // POST: /Personnel/BloodType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            //BloodType bloodtype = PersonnelContext.BloodTypes.Find(id);
            //PersonnelContext.BloodTypes.Remove(bloodtype);
            //PersonnelContext.SaveChanges();
            _bloodTypeService.DeleteById((int) id);
            _uow.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    PersonnelContext.Dispose();
            //}
            base.Dispose(disposing);
        }
    }
}

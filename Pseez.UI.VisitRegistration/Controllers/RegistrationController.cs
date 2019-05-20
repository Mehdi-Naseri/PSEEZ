using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pseez.CommonLibrary;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.PseezEnt.VisitRegistration;
using Pseez.Extentions.MapperConfigure.Extention.PseezEnt;
using Pseez.ServiceLayer.Interfaces.PseezEnt.VisitRegistration;
using Pseez.ViewModels.ViewModels.PseezEnt.VisitRegistration;

namespace Pseez.UI.VisitRegistration.Controllers
{
    [Authorize(Roles = "AdminEnt, VisitRegistration-Admin , VisitRegistration-AdminRegistration")]
    public class RegistrationController : Controller
    {
        private IUnitOfWorkPseezEnt _uow;
        private IRegistrationService _registrationService;
        public RegistrationController(IUnitOfWorkPseezEnt uow, IRegistrationService registrationService)
        {
            _uow = uow;
            _registrationService = registrationService;
        }

        // GET: Registrations
        //public ActionResult Index()
        //{
        //    return View(_registrationService.GetAll().MapModelToViewModel());
        //    //return View(db.Registrations.ToList());
        //}
        [Authorize(Roles = "AdminEnt, VisitRegistration-Admin , VisitRegistration-AdminRegistration,VisitRegistration-ReadRegistration")]
        // GET: Registrations
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "AdminEnt, VisitRegistration-Admin , VisitRegistration-AdminRegistration,VisitRegistration-ReadRegistration")]
        [HttpGet]
        public ActionResult Read()
        {
            IEnumerable<RegistrationViewModel> a = _registrationService.GetAll().MapModelToViewModel();
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "AdminEnt, VisitRegistration-Admin , VisitRegistration-AdminRegistration,VisitRegistration-ReadRegistration")]
        // GET: Registrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrationViewModel registrationViewModel = _registrationService.FindById((int)id).MapModelToViewModel();
            if (registrationViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Details", registrationViewModel);
        }

        [AllowAnonymous]
        // GET: Registrations/Create
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        // POST: Registrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Title,FirstName,LastName,IPECUsername,Email,TelephoneNumber,Mobile,FaxNumber,Address,CompanyName,CompanyPhone,CompanyAddress")] RegistrationViewModel registrationViewModel)
        {
            if (ModelState.IsValid)
            {
                _registrationService.Add(registrationViewModel.MapViewModelToModel());
                _uow.SaveChanges();
                //db.Registrations.Add(registrationViewModel);
                //db.SaveChanges();

                try
                {
                    SendMail(registrationViewModel);
                }
                catch
                { }

                return RedirectToAction("Success");
            }
            return View(registrationViewModel);
        }

        //Add Async
        private void SendMail(RegistrationViewModel registrationViewModel)
        {
            string EmailBody = "<br/>Title: " + registrationViewModel.Title +
                "<br/>First Name: " + registrationViewModel.FirstName +
                "<br/>Last Name: " + registrationViewModel.LastName +
                "<br/>IPEC Username: " + registrationViewModel.IPECUsername +
                "<br/>Email: " + registrationViewModel.Email +
                "<br/>Telephone Number: " + registrationViewModel.TelephoneNumber +
                "<br/>Mobile: " + registrationViewModel.Mobile +
                "<br/>Fax Number: " + registrationViewModel.FaxNumber +
                "<br/>Address: " + registrationViewModel.Address +
                "<br/>Company Name: " + registrationViewModel.CompanyName +
                "<br/>Company Phone: " + registrationViewModel.CompanyPhone +
                "<br/>Company Address: " + registrationViewModel.CompanyAddress
                ;
            Email email = new Email();
            email.SendMail(fromMail: "itdevelopment@pseez.ir",
                fromName: "PSEEZ",
                toMail: "info@ipeccongress.com",
                toName: "IPECCongress",
                //toMail: "info@ipeccongress.com",
                //toName: "info@ipeccongress.com",
                subject: "PSEEZ South Pars Visit Registration",
                body: EmailBody
                );
        }

        [AllowAnonymous]
        // GET: Registrations/Create
        public ActionResult Success()
        {
            return View();
        }

        [Authorize(Roles = "AdminEnt, VisitRegistration-Admin , VisitRegistration-AdminRegistration,VisitRegistration-ReadRegistration")]
        // GET: Registrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrationViewModel registrationViewModel = _registrationService.FindById((int)id).MapModelToViewModel();
            if (registrationViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Edit", registrationViewModel);
        }

        [Authorize(Roles = "AdminEnt, VisitRegistration-Admin , VisitRegistration-AdminRegistration")]
        // POST: Registrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,FirstName,LastName,IPECUsername,Email,TelephoneNumber,Mobile,FaxNumber,Address,CompanyName,CompanyPhone,CompanyAddress")] RegistrationViewModel registrationViewModel)
        {
            if (ModelState.IsValid)
            {
                Registration registration = _registrationService.FindById(registrationViewModel.Id);
                registration.Id = registrationViewModel.Id;
                registration.Title = registrationViewModel.Title;
                registration.FirstName = registrationViewModel.FirstName;
                registration.LastName = registrationViewModel.LastName;
                registration.IPECUsername = registrationViewModel.IPECUsername;
                registration.Email = registrationViewModel.Email;
                registration.TelephoneNumber = registrationViewModel.TelephoneNumber;
                registration.Mobile = registrationViewModel.Mobile;
                registration.Address = registrationViewModel.Address;
                registration.CompanyName = registrationViewModel.CompanyName;
                registration.CompanyPhone = registrationViewModel.CompanyPhone;
                registration.CompanyAddress = registrationViewModel.CompanyAddress;
                _uow.SaveChanges();
                return Json(new { success = true });

                //db.Entry(registration).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return PartialView("_Edit", registrationViewModel);
        }

        [Authorize(Roles = "AdminEnt, VisitRegistration-Admin , VisitRegistration-AdminRegistration")]
        // GET: Registrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = _registrationService.FindById((int)id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", registration.MapModelToViewModel());
        }

        [Authorize(Roles = "AdminEnt, VisitRegistration-Admin , VisitRegistration-AdminRegistration")]
        // POST: Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Registration registration = db.Registrations.Find(id);
            //db.Registrations.Remove(registration);
            //db.SaveChanges();
            _registrationService.DeleteById(id);
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

        //[AllowAnonymous]
        //[HttpGet]
        //public ActionResult Test()
        //{
        //    Email email = new Email();
        //    email.SendMailWithYahoo();
        //    return View();
        //}
        //[AllowAnonymous]
        //[HttpPost]
        //public ActionResult Test(int id)
        //{
        //    Email email = new Email();
        //    email.SendMailWithYahoo();
        //    return View();
        //}
    }
}

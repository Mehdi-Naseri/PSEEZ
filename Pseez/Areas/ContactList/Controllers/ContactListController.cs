using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Common;
using Pseez.DomainClasses.Models.PseezEnt.Common;
using Pseez.ViewModels.ViewModels.PseezEnt.Common;
using Pseez.Extentions.MapperConfigure.Extention.PseezEnt;
using System.Net;

using Microsoft.AspNet.Identity;
using Identity.ServiceLayer.Interfaces;
//using Pseez.ServiceLayer.EFServices.Identity;

namespace Pseez.Areas.ContactList.Controllers
{
    [Authorize(Roles = "Admin , ContactListAdmin")]
    public class ContactListController : Controller
    {
        private IUnitOfWorkPseezEnt _uow;
        private IIdentityUserService _identityUserService;
        private IContactListService _contactListService;

        private IContactGroupService _contactGroupService;
        private IContactService _contactService;
        private IUserContactListService _userContactListService;
        public ContactListController(IUnitOfWorkPseezEnt uow, IContactListService contactListService, IIdentityUserService identityUserService,
            IContactGroupService contactGroupService, IContactService contactService, IUserContactListService userContactListService)
        {
            _uow = uow;
            _identityUserService = identityUserService;
            _contactListService = contactListService;

            _contactGroupService = contactGroupService;
            _contactService = contactService;
            _userContactListService = userContactListService;
        }
        //
        // GET: /ContactList/ContactList/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Read()
        {
            IEnumerable<ContactListViewModel> a = from r in _contactListService.GetAll()
                                                  select new ContactListViewModel
                                                  {
                                                      Id = r.Id,
                                                      Name = r.Name,
                                                      Description = r.Description,
                                                      CreatedBy = _identityUserService.FindUserNameById(r.UserId)
                                                  };
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        // GET: /ContactList/ContactList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactList contactList = _contactListService.FindById((int)id);
            if (contactList == null)
            {
                return HttpNotFound();
            }
            ContactListViewModel contactListViewModel = contactList.MapModelToViewModel();
            contactListViewModel.CreatedBy = _identityUserService.FindUserNameById(contactList.UserId);
            return PartialView("_Details", contactListViewModel);
        }

        // GET: /ContactList/ContactList/Create
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        // POST: /ContactList/ContactList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description")] ContactListViewModel contactListViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_contactListService.Exist(contactListViewModel.Name))
                {
                    Pseez.DomainClasses.Models.PseezEnt.Contact.ContactList contactList = contactListViewModel.MapViewModelToModel();
                    contactList.UserId = User.Identity.GetUserId();
                    _contactListService.Add(contactList);
                    _uow.SaveChanges();
                    return Json(new { success = true });
                }
                else
                {
                    ModelState.AddModelError("DuplicateRecord", "دفترچه تلفن با این نام قبلا ثبت شده است.");
                }

            }

            return PartialView("_Create", contactListViewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pseez.DomainClasses.Models.PseezEnt.Contact.ContactList contactList = _contactListService.FindById((int)id);
            if (contactList == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Edit", contactList.MapModelToViewModel());
        }

        // POST: /ContactList/ContactList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] ContactListViewModel contactListViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_contactListService.Exist(contactListViewModel.Name))
                {
                    Pseez.DomainClasses.Models.PseezEnt.Contact.ContactList contactList = _contactListService.FindById(contactListViewModel.Id);
                    contactList.Name = contactListViewModel.Name;
                    contactList.Description = contactListViewModel.Description;
                    _uow.SaveChanges();
                    return Json(new { success = true });
                }
                else
                {
                    ModelState.AddModelError("DuplicateRecord", "دفترچه تلفن با این نام قبلا ثبت شده است.");
                }
            }
            return PartialView("_Edit", contactListViewModel);
        }

        // GET: /ContactList/ContactList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactList contactList = _contactListService.FindById((int)id);
            if (contactList == null)
            {
                return HttpNotFound();
            }
            ContactListViewModel contactListViewModel = contactList.MapModelToViewModel();
            contactListViewModel.CreatedBy = _identityUserService.FindUserNameById(contactList.UserId);
            return PartialView("_Delete", contactListViewModel);
        }

        // POST: /ContactList/ContactList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            foreach (var a in _contactGroupService.GetAll(r => r.ContactListId == id))
            {
                _contactGroupService.DeleteById(a.Id);
            }
            foreach (var a in _contactService.GetAll(r => r.ContactListId == id))
            {
                _contactService.DeleteById(a.Id);
            }
            foreach (var a in _userContactListService.GetAll(r => r.ContactListId == id))
            {
                _userContactListService.DeleteById(a.Id);
            }
            _contactListService.DeleteById(id);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pseez.DataLayer.IUnitOfWork;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Contact;
using Pseez.DomainClasses.Models.PseezEnt.Contact;
using Pseez.Model.ViewModels.PseezEnt.Contact;
using Pseez.Model.MapperConfigure.Extention.PseezEnt;
using System.Net;

//using Microsoft.AspNet.Identity;
//using Pseez.ServiceLayer.Interfaces.Identity;
//using Pseez.ServiceLayer.EFServices.Identity;
using Pseez.ServiceLayer.EFServices.PseezEnt.Contact;

using Identity.ServiceLayer.Interfaces;


namespace Pseez.Areas.ContactList.Controllers
{
    [Authorize(Roles = "Admin , ContactListAdmin")]
    public class UserContactListController : Controller
    {
        private IUnitOfWorkPseezEnt _uow;
        private IIdentityUserService _identityUserService;
        private IUserContactListService _userContactListService;
        private IContactListService _contactListService;
        public UserContactListController(IUnitOfWorkPseezEnt uow, IIdentityUserService identityUserService, IUserContactListService userContactListService,
            IContactListService contactListService)
        {
            _uow = uow;
            _identityUserService = identityUserService;
            _userContactListService = userContactListService;

            _contactListService = contactListService;
        }
        //
        // GET: /ContactList/UserContactList/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Read()
        {
            IEnumerable<UserContactListViewModel> a = from r in _userContactListService.GetAll()
                                                      select new UserContactListViewModel
                                                      {
                                                          Id = r.Id,
                                                          UserName = _identityUserService.FindUserNameById(r.UserId),
                                                          ContactListName = r.ContactList.Name
                                                      };
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        // GET: /ContactList/UserContactList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserContactList userContactList = _userContactListService.FindById((int)id);
            if (userContactList == null)
            {
                return HttpNotFound();
            }
            UserContactListViewModel userContactListViewModel = userContactList.MapModelToViewModel();
            userContactListViewModel.UserName = _identityUserService.FindUserNameById(userContactList.UserId);
            return PartialView("_Details", userContactListViewModel);
        }

        // GET: /ContactList/UserContactList/Create
        public ActionResult Create()
        {

            ViewBag.ContactListNames = new SelectList(_contactListService.GetAll(), "Name", "Name");
            IEnumerable<string> UserNames = _identityUserService.GetAllUserNames();
            ViewBag.UserNames = new SelectList(UserNames);
            //_identityUserService
            return PartialView("_Create");
        }

        // POST: /ContactList/ContactList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserName,ContactListName")] UserContactListViewModel userContactListViewModel)
        {
            IContactListService _contactListService = new EfContactListService(_uow);
            if (ModelState.IsValid)
            {
                //ContactList contactList = contactListViewModel.MapViewModelToModel();
                UserContactList userContactList = new UserContactList();
                userContactList.UserId = _identityUserService.FindUserIdByName(userContactListViewModel.UserName);

                userContactList.ContactListId = _contactListService.Find(r => r.Name == userContactListViewModel.ContactListName).Id;
                if (!_userContactListService.Exist(userContactList.UserId, userContactList.ContactListId))
                {
                    _userContactListService.Add(userContactList);
                    _uow.SaveChanges();
                    return Json(new { success = true });
                }
                else
                {
                    ModelState.AddModelError("DuplicateRecord", "این کاربر به دفترچه تلفن دسترسی دارد");
                }
            }
            ViewBag.ContactListNames = new SelectList(_contactListService.GetAll(), "Name", "Name");
            IEnumerable<string> UserNames = _identityUserService.GetAllUserNames();
            ViewBag.UserNames = new SelectList(UserNames);
            return PartialView("_Create", userContactListViewModel);
        }

        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    UserContactList userContactList = _userContactListService.FindById((int)id);
        //    if (userContactList == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return PartialView("_Edit", userContactList.MapModelToViewModel());
        //}

        //// POST: /ContactList/UserContactList/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,UserName,ContactListName")] UserContactListViewModel userContactListViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        UserContactList userContactList = _userContactListService.FindById(userContactListViewModel.Id);
        //        userContactList.UserId = _identityUserService.FindUserIdByName(userContactListViewModel.UserName);

        //        IContactListService _contactListService = new EfContactListService(_uow);
        //        userContactList.ContactListId = _contactListService.Find(r => r.Name == userContactListViewModel.ContactListName).Id;
        //        _uow.SaveChanges();
        //        return Json(new { success = true });
        //    }
        //    return PartialView("_Edit", userContactListViewModel);
        //}

        // GET: /ContactList/UserContactList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserContactList userContactList = _userContactListService.FindById((int)id);
            if (userContactList == null)
            {
                return HttpNotFound();
            }
            //UserContactListViewModel contactListViewModel = contactList.MapModelToViewModel();
            UserContactListViewModel contactListViewModel = new UserContactListViewModel();
            contactListViewModel.ContactListName = _contactListService.FindById(userContactList.ContactListId).Name;
            contactListViewModel.UserName = _identityUserService.FindUserNameById(userContactList.UserId);
            return PartialView("_Delete", contactListViewModel);
        }

        // POST: /ContactList/UserContactList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _userContactListService.DeleteById(id);
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
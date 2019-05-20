using System.Linq;
using System.Net;
using System.Web.Mvc;
using Identity.ServiceLayer.Interfaces;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.PseezEnt.Common;
using Pseez.Extentions.MapperConfigure.Extention.PseezEnt;
using Pseez.ServiceLayer.EFServices.PseezEnt.Common;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Common;
using Pseez.ViewModels.ViewModels.PseezEnt.Common;
//using Microsoft.AspNet.Identity;
//using Pseez.ServiceLayer.Interfaces.Identity;
//using Pseez.ServiceLayer.EFServices.Identity;


namespace Pseez.UI.Common.Areas.ContactList.Controllers
{
    [Authorize(Roles = "AdminEnt , AdminContacts , AdminContactsUser")]
    public class UserContactListController : Controller
    {
        private readonly IContactListService _contactListService;
        private readonly IIdentityUserService _identityUserService;
        private readonly IUnitOfWorkPseezEnt _uow;
        private readonly IUserContactListService _userContactListService;

        public UserContactListController(IUnitOfWorkPseezEnt uow, IIdentityUserService identityUserService,
            IUserContactListService userContactListService,
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
            var a = from r in _userContactListService.GetAll()
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
            var userContactList = _userContactListService.FindById((int) id);
            if (userContactList == null)
            {
                return HttpNotFound();
            }
            var userContactListViewModel = userContactList.MapModelToViewModel();
            userContactListViewModel.UserName = _identityUserService.FindUserNameById(userContactList.UserId);
            return PartialView("_Details", userContactListViewModel);
        }

        // GET: /ContactList/UserContactList/Create
        public ActionResult Create()
        {
            ViewBag.ContactListNames = new SelectList(_contactListService.GetAll(), "Name", "Name");
            var UserNames = _identityUserService.GetAllUserNames();
            ViewBag.UserNames = new SelectList(UserNames);
            //_identityUserService
            return PartialView("_Create");
        }

        // POST: /ContactList/ContactList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "UserName,ContactListName")] UserContactListViewModel userContactListViewModel)
        {
            IContactListService _contactListService = new EfContactListService(_uow);
            if (ModelState.IsValid)
            {
                //ContactList contactList = contactListViewModel.MapViewModelToModel();
                var userContactList = new UserContactList();
                userContactList.UserId = _identityUserService.FindUserIdByName(userContactListViewModel.UserName);

                userContactList.ContactListId =
                    _contactListService.Find(r => r.Name == userContactListViewModel.ContactListName).Id;
                if (!_userContactListService.Exist(userContactList.UserId, userContactList.ContactListId))
                {
                    _userContactListService.Add(userContactList);
                    _uow.SaveChanges();
                    return Json(new {success = true});
                }
                ModelState.AddModelError("DuplicateRecord", "این کاربر به دفترچه تلفن دسترسی دارد");
            }
            ViewBag.ContactListNames = new SelectList(_contactListService.GetAll(), "Name", "Name");
            var UserNames = _identityUserService.GetAllUserNames();
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
            var userContactList = _userContactListService.FindById((int) id);
            if (userContactList == null)
            {
                return HttpNotFound();
            }
            //UserContactListViewModel contactListViewModel = contactList.MapModelToViewModel();
            var contactListViewModel = new UserContactListViewModel();
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
            return Json(new {success = true});
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
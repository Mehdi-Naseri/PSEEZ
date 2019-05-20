using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Identity.ServiceLayer.Interfaces;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.PseezEnt.Common;
using Pseez.Extentions.MapperConfigure.Extention.PseezEnt;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Common;
using Pseez.ViewModels.ViewModels.PseezEnt.Common;
//using Pseez.DomainClasses.Models.PseezErp.Tools;
//using Pseez.DataLayer.DataContext;


namespace Pseez.UI.Common.Areas.ContactList.Controllers
{
    [Authorize(Roles = "AdminEnt , AdminContacts , AdminContactsUser")]
    public class ContactsController : Controller
    {
        private readonly IContactGroupService _contactGroupService;

        private readonly IContactListService _contactListService;
        private readonly IContactService _contactService;
        private readonly IIdentityUserService _identityUserService;
        private readonly IUnitOfWorkPseezEnt _uow;
        private readonly IUserContactListService _userContactListService;

        public ContactsController(IUnitOfWorkPseezEnt uow, IContactService contactService,
            IIdentityUserService identityUserService,
            IContactListService contactListService,
            IContactGroupService contactGroupService, IUserContactListService userContactListService)
        {
            _uow = uow;
            _contactService = contactService;

            _contactListService = contactListService;
            _contactGroupService = contactGroupService;
            _userContactListService = userContactListService;
            _identityUserService = identityUserService;
        }

        //private PseezErpContext db = new PseezErpContext();

        // GET: /DataCenter/Contacts/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Read()
        {
            IEnumerable<Contact> contacts;
            if (User.IsInRole("Admin") || User.IsInRole("ContactListAdmin"))
            {
                contacts = _contactService.GetAll();
            }
            else
            {
                var userId = _identityUserService.FindUserIdByName(User.Identity.Name);
                var userContactLists =
                    _userContactListService.GetAll(r => r.UserId == userId).Select(r => r.ContactListId);
                contacts = _contactService.GetAll(r => userContactLists.Contains(r.ContactListId));
            }
            var a = contacts.MapModelToViewModel();
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        // GET: /DataCenter/Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var contact = _contactService.FindById((int) id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Details", contact.MapModelToViewModel());
        }

        // GET: /DataCenter/Contacts/Create
        public ActionResult Create()
        {
            //پر کردن دراپ دون لیستها
            IEnumerable<DomainClasses.Models.PseezEnt.Common.ContactList> ContactLists;
            if (User.IsInRole("Admin") || User.IsInRole("ContactListAdmin"))
            {
                ContactLists = _contactListService.GetAll();
            }
            else
            {
                var userId = _identityUserService.FindUserIdByName(User.Identity.Name);
                var userContactLists =
                    _userContactListService.GetAll(r => r.UserId == userId).Select(r => r.ContactListId);
                ContactLists = _contactListService.GetAll(r => userContactLists.Contains(r.Id));
            }
            ViewBag.ContactListNames = new SelectList(ContactLists, "Name", "Name");

            if (ContactLists.Count() != 0)
            {
                var firstContactListId = ContactLists.FirstOrDefault().Id;
                string ContactGroupNamesSelect = null;
                //ContactGroupNamesSelect = null;
                foreach (
                    var contactGroupName in
                        _contactGroupService.GetAll(r => r.ContactListId == firstContactListId).Select(r => r.Name))
                {
                    ContactGroupNamesSelect += "<option value=\"" + contactGroupName + "\">" + contactGroupName +
                                               "</option>";
                }
                ViewBag.ContactGroupNames = ContactGroupNamesSelect;
            }
            return PartialView("_Create");
        }

        // POST: /DataCenter/Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "Name,Tell,Comment,ContactGroupName,ContactListName")] ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                var a = contactViewModel.MapViewModelToModel();
                a.ContactListId = _contactListService.Find(r => r.Name == contactViewModel.ContactListName).Id;
                if (contactViewModel.ContactGroupName != null)
                {
                    a.ContactGroupId = _contactGroupService.Find(r => r.Name == contactViewModel.ContactGroupName).Id;
                }
                _contactService.Add(a);
                _uow.SaveChanges();
                return Json(new {success = true});
            }
            //ViewBag.ContactGroupNames = new SelectList(_contactGroupService.GetAll(), "Name", "Name");
            //ViewBag.ContactListNames = new SelectList(_contactListService.GetAll(), "Name", "Name");
            //پر کردن دراپ دون لیستها
            IEnumerable<DomainClasses.Models.PseezEnt.Common.ContactList> ContactLists;
            if (User.IsInRole("Admin") || User.IsInRole("ContactListAdmin"))
            {
                ContactLists = _contactListService.GetAll();
            }
            else
            {
                var userId = _identityUserService.FindUserIdByName(User.Identity.Name);
                var userContactLists =
                    _userContactListService.GetAll(r => r.UserId == userId).Select(r => r.ContactListId);
                ContactLists = _contactListService.GetAll(r => userContactLists.Contains(r.Id));
            }
            ViewBag.ContactListNames = new SelectList(ContactLists, "Name", "Name", contactViewModel.ContactListName);

            if (ContactLists.Count() != 0)
            {
                var firstContactListId = ContactLists.FirstOrDefault().Id;
                string ContactGroupNamesSelect = null;
                //ContactGroupNamesSelect = null;
                foreach (
                    var contactGroupName in
                        _contactGroupService.GetAll(r => r.ContactListId == firstContactListId).Select(r => r.Name))
                {
                    if (contactGroupName == contactViewModel.ContactGroupName)
                        ContactGroupNamesSelect += "<option value=" + contactGroupName + " selected>" + contactGroupName +
                                                   "</option>";
                    else
                        ContactGroupNamesSelect += "<option value=" + contactGroupName + ">" + contactGroupName +
                                                   "</option>";
                }
                ViewBag.ContactGroupNames = ContactGroupNamesSelect;
            }
            return PartialView("_Create", contactViewModel);
        }

        // GET: /DataCenter/Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var contact = _contactService.FindById((int) id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            //پر کردن دراپ دون لیستها
            IEnumerable<DomainClasses.Models.PseezEnt.Common.ContactList> ContactLists = _contactListService.GetAll();
            ViewBag.ContactListNames = new SelectList(ContactLists, "Name", "Name", contact.ContactList.Name);

            var firstContactListId = ContactLists.FirstOrDefault().Id;
            string ContactGroupNamesSelect = null;
            //ContactGroupNamesSelect = null;
            foreach (
                var contactGroupName in
                    _contactGroupService.GetAll(r => r.ContactListId == firstContactListId).Select(r => r.Name))
            {
                if (contactGroupName == contact.ContactGroup.Name)
                    ContactGroupNamesSelect += "<option value=" + contactGroupName + " selected>" + contactGroupName +
                                               "</option>";
                else
                    ContactGroupNamesSelect += "<option value=" + contactGroupName + ">" + contactGroupName +
                                               "</option>";
            }
            ViewBag.ContactGroupNames = ContactGroupNamesSelect;
            return PartialView("_Edit", contact.MapModelToViewModel());
        }

        // POST: /DataCenter/Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id,Name,Tell,Comment,ContactGroupName,ContactListName")] ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                var contact = _contactService.FindById(contactViewModel.Id);
                contact.Name = contactViewModel.Name;
                contact.Tell = contactViewModel.Tell;
                contact.Comment = contactViewModel.Comment;
                contact.ContactListId = _contactListService.Find(r => r.Name == contactViewModel.ContactListName).Id;
                if (contactViewModel.ContactGroupName != null)
                {
                    contact.ContactGroupId =
                        _contactGroupService.Find(r => r.Name == contactViewModel.ContactGroupName).Id;
                }
                _uow.SaveChanges();
                return Json(new {success = true});
            }
            //پر کردن دراپ دون لیستها
            IEnumerable<DomainClasses.Models.PseezEnt.Common.ContactList> ContactLists = _contactListService.GetAll();
            ViewBag.ContactListNames = new SelectList(ContactLists, "Name", "Name", contactViewModel.ContactListName);

            var firstContactListId = ContactLists.FirstOrDefault().Id;
            string ContactGroupNamesSelect = null;
            //ContactGroupNamesSelect = null;
            foreach (
                var contactGroupName in
                    _contactGroupService.GetAll(r => r.ContactListId == firstContactListId).Select(r => r.Name))
            {
                if (contactGroupName == contactViewModel.ContactGroupName)
                    ContactGroupNamesSelect += "<option value=" + contactGroupName + " selected>" + contactGroupName +
                                               "</option>";
                else
                    ContactGroupNamesSelect += "<option value=" + contactGroupName + ">" + contactGroupName +
                                               "</option>";
            }
            ViewBag.ContactGroupNames = ContactGroupNamesSelect;
            return PartialView("_Edit", contactViewModel);
        }

        // GET: /DataCenter/Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var contact = _contactService.FindById((int) id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", contact.MapModelToViewModel());
        }

        // POST: /DataCenter/Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _contactService.DeleteById(id);
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

        //خواندن کامبوباکس دوم
        public ActionResult ReadContactGroups(string contactListName)
        {
            IEnumerable<string> a = null;
            if (contactListName != null && contactListName != "undefined")
            {
                var ContactListId = _contactListService.Find(r => r.Name == contactListName).Id;
                a = _contactGroupService.GetAll(r => r.ContactListId == ContactListId).Select(r => r.Name);
            }
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

//using Pseez.DomainClasses.Models.PseezEnt.Tools;
//using Pseez.DataLayer.DataContext;


using Pseez.DataLayer.IUnitOfWork;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Contact;
using Pseez.DomainClasses.Models.PseezEnt.Contact;
using Pseez.Model.ViewModels.PseezEnt.Contact;
using Pseez.Model.MapperConfigure.Extention.PseezEnt;
using Identity.ServiceLayer.Interfaces;


namespace Pseez.Areas.ContactList.Controllers
{
    [Authorize(Roles = "Admin , ContactListAdmin , ContactListUser")]
    public class ContactsController : Controller
    {
        private IUnitOfWorkPseezEnt _uow;
        private IContactService _contactService;
        private IIdentityUserService _identityUserService;

        private IContactListService _contactListService;
        private IContactGroupService _contactGroupService;
        private IUserContactListService _userContactListService;

        public ContactsController(IUnitOfWorkPseezEnt uow, IContactService contactService, IIdentityUserService identityUserService,
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
        //private PseezEntContext db = new PseezEntContext();

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
                string userId = _identityUserService.FindUserIdByName(User.Identity.Name);
                IEnumerable<int> userContactLists = _userContactListService.GetAll(r => r.UserId == userId).Select(r => r.ContactListId);
                contacts = (IEnumerable<Contact>)_contactService.GetAll(r => userContactLists.Contains(r.ContactListId));
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
            Contact contact = _contactService.FindById((int)id);
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
            IEnumerable<Pseez.DomainClasses.Models.PseezEnt.Contact.ContactList> ContactLists;
            if (User.IsInRole("Admin") || User.IsInRole("ContactListAdmin"))
            {
                ContactLists = _contactListService.GetAll();
            }
            else
            {
                string userId = _identityUserService.FindUserIdByName(User.Identity.Name);
                IEnumerable<int> userContactLists = _userContactListService.GetAll(r => r.UserId == userId).Select(r => r.ContactListId);
                ContactLists = (IEnumerable<Pseez.DomainClasses.Models.PseezEnt.Contact.ContactList>)_contactListService.GetAll(r => userContactLists.Contains(r.Id));
            }
            ViewBag.ContactListNames = new SelectList(ContactLists, "Name", "Name");

            if (ContactLists.Count() != 0)
            {
                int firstContactListId = ContactLists.FirstOrDefault().Id;
                string ContactGroupNamesSelect = null;
                //ContactGroupNamesSelect = null;
                foreach (string contactGroupName in _contactGroupService.GetAll(r => r.ContactListId == firstContactListId).Select(r => r.Name))
                {
                    ContactGroupNamesSelect += "<option value=\"" + contactGroupName + "\">" + contactGroupName + "</option>";
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
        public ActionResult Create([Bind(Include = "Name,Tell,Comment,ContactGroupName,ContactListName")] ContactViewModel contactViewModel)
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
                return Json(new { success = true });
            }
            //ViewBag.ContactGroupNames = new SelectList(_contactGroupService.GetAll(), "Name", "Name");
            //ViewBag.ContactListNames = new SelectList(_contactListService.GetAll(), "Name", "Name");
            //پر کردن دراپ دون لیستها
            IEnumerable<Pseez.DomainClasses.Models.PseezEnt.Contact.ContactList> ContactLists;
            if (User.IsInRole("Admin") || User.IsInRole("ContactListAdmin"))
            {
                ContactLists = _contactListService.GetAll();
            }
            else
            {
                string userId = _identityUserService.FindUserIdByName(User.Identity.Name);
                IEnumerable<int> userContactLists = _userContactListService.GetAll(r => r.UserId == userId).Select(r => r.ContactListId);
                ContactLists = (IEnumerable<Pseez.DomainClasses.Models.PseezEnt.Contact.ContactList>)_contactListService.GetAll(r => userContactLists.Contains(r.Id));
            }
            ViewBag.ContactListNames = new SelectList(ContactLists, "Name", "Name",contactViewModel.ContactListName);

            if (ContactLists.Count() != 0)
            {
                int firstContactListId = ContactLists.FirstOrDefault().Id;
                string ContactGroupNamesSelect = null;
                //ContactGroupNamesSelect = null;
                foreach (string contactGroupName in _contactGroupService.GetAll(r => r.ContactListId == firstContactListId).Select(r => r.Name))
                {
                    if (contactGroupName == contactViewModel.ContactGroupName)
                        ContactGroupNamesSelect += "<option value=" + contactGroupName + " selected>" + contactGroupName + "</option>";
                    else
                        ContactGroupNamesSelect += "<option value=" + contactGroupName + ">" + contactGroupName + "</option>";
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
            Contact contact = _contactService.FindById((int)id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            //پر کردن دراپ دون لیستها
            IEnumerable<Pseez.DomainClasses.Models.PseezEnt.Contact.ContactList> ContactLists = _contactListService.GetAll();
            ViewBag.ContactListNames = new SelectList(ContactLists, "Name", "Name", contact.ContactList.Name);

            int firstContactListId = ContactLists.FirstOrDefault().Id;
            string ContactGroupNamesSelect = null;
            //ContactGroupNamesSelect = null;
            foreach (string contactGroupName in _contactGroupService.GetAll(r => r.ContactListId == firstContactListId).Select(r => r.Name))
            {
                if (contactGroupName == contact.ContactGroup.Name)
                    ContactGroupNamesSelect += "<option value=" + contactGroupName + " selected>" + contactGroupName + "</option>";
                else
                    ContactGroupNamesSelect += "<option value=" + contactGroupName + ">" + contactGroupName + "</option>";
            }
            ViewBag.ContactGroupNames = ContactGroupNamesSelect.ToString();
            return PartialView("_Edit", contact.MapModelToViewModel());
        }

        // POST: /DataCenter/Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Tell,Comment,ContactGroupName,ContactListName")] ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                Contact contact = _contactService.FindById(contactViewModel.Id);
                contact.Name = contactViewModel.Name;
                contact.Tell = contactViewModel.Tell;
                contact.Comment = contactViewModel.Comment;
                contact.ContactListId = _contactListService.Find(r => r.Name == contactViewModel.ContactListName).Id;
                if (contactViewModel.ContactGroupName != null)
                {
                    contact.ContactGroupId = _contactGroupService.Find(r => r.Name == contactViewModel.ContactGroupName).Id;
                }
                _uow.SaveChanges();
                return Json(new { success = true });
            }
            //پر کردن دراپ دون لیستها
            IEnumerable<Pseez.DomainClasses.Models.PseezEnt.Contact.ContactList> ContactLists = _contactListService.GetAll();
            ViewBag.ContactListNames = new SelectList(ContactLists, "Name", "Name", contactViewModel.ContactListName);

            int firstContactListId = ContactLists.FirstOrDefault().Id;
            string ContactGroupNamesSelect = null;
            //ContactGroupNamesSelect = null;
            foreach (string contactGroupName in _contactGroupService.GetAll(r => r.ContactListId == firstContactListId).Select(r => r.Name))
            {
                if (contactGroupName == contactViewModel.ContactGroupName)
                    ContactGroupNamesSelect += "<option value=" + contactGroupName + " selected>" + contactGroupName + "</option>";
                else
                    ContactGroupNamesSelect += "<option value=" + contactGroupName + ">" + contactGroupName + "</option>";
            }
            ViewBag.ContactGroupNames = ContactGroupNamesSelect.ToString();
            return PartialView("_Edit", contactViewModel);
        }

        // GET: /DataCenter/Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = _contactService.FindById((int)id);
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

        //خواندن کامبوباکس دوم
        public ActionResult ReadContactGroups(string contactListName)
        {
            IEnumerable<string> a = null;
            if (contactListName != null && contactListName != "undefined")
            {
                int ContactListId = _contactListService.Find(r => r.Name == contactListName).Id;
                a = _contactGroupService.GetAll(r => r.ContactListId == ContactListId).Select(r => r.Name);
            }
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}

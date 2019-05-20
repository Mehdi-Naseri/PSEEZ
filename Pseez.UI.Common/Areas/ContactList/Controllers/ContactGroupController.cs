using System.Net;
using System.Web.Mvc;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.Extentions.MapperConfigure.Extention.PseezEnt;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Common;
using Pseez.ViewModels.ViewModels.PseezEnt.Common;

namespace Pseez.UI.Common.Areas.ContactList.Controllers
{
    [Authorize(Roles = "AdminEnt , AdminContacts , AdminContactsUser")]
    public class ContactGroupController : Controller
    {
        private readonly IContactGroupService _contactGroupService;
        private readonly IContactListService _contactListService;
        private readonly IUnitOfWorkPseezEnt _uow;

        public ContactGroupController(IUnitOfWorkPseezEnt uow, IContactGroupService contactGroupService,
            IContactListService contactListService)
        {
            _uow = uow;
            _contactGroupService = contactGroupService;
            _contactListService = contactListService;
        }

        //
        // GET: /ContactList/ContactGroup/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Read()
        {
            var a = _contactGroupService.GetAll().MapModelToViewModel();
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        // GET: /ContactList/ContactGroup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var contactGroup = _contactGroupService.FindById((int) id);
            if (contactGroup == null)
            {
                return HttpNotFound();
            }
            var contactGroupViewModel = contactGroup.MapModelToViewModel();
            return PartialView("_Details", contactGroupViewModel);
        }

        // GET: /ContactList/ContactGroup/Create
        public ActionResult Create()
        {
            //IContactListService _contactListService = new EfContactListService(_uow);
            ViewBag.ContactListNames = new SelectList(_contactListService.GetAll(), "Name", "Name");
            //IEnumerable<SelectListItem> list =  _contactListService.GetAll();
            //ViewBag.ContactListNames = new SelectList(list, "Name", "Name");
            return PartialView("_Create");
        }

        // POST: /ContactList/ContactGroup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "Name,Description,ContactListName")] ContactGroupViewModel contactGroupViewModel)
        {
            if (ModelState.IsValid)
            {
                var contactGroup = contactGroupViewModel.MapViewModelToModel();
                //IContactListService _contactListService = new EfContactListService(_uow);
                contactGroup.ContactListId =
                    _contactListService.Find(r => r.Name == contactGroupViewModel.ContactListName).Id;
                _contactGroupService.Add(contactGroup);
                _uow.SaveChanges();
                return Json(new {success = true});
            }

            ViewBag.ContactListNames = new SelectList(_contactListService.GetAll(), "Name", "Name");
            return PartialView("_Create", contactGroupViewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var contactGroup = _contactGroupService.FindById((int) id);
            if (contactGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Edit", contactGroup.MapModelToViewModel());
        }

        // POST: /ContactList/ContactGroup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] ContactGroupViewModel contactGroupViewModel)
        {
            if (ModelState.ContainsKey("ContactListName"))
            {
                ModelState["ContactListName"].Errors.Clear();
            }
            if (ModelState.IsValid)
            {
                var contactGroup = _contactGroupService.FindById(contactGroupViewModel.Id);
                contactGroup.Name = contactGroupViewModel.Name;
                contactGroup.Description = contactGroupViewModel.Description;
                _uow.SaveChanges();
                return Json(new {success = true});
            }
            return PartialView("_Edit", contactGroupViewModel);
        }

        // GET: /ContactList/ContactGroup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var contactGroup = _contactGroupService.FindById((int) id);
            if (contactGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", contactGroup.MapModelToViewModel());
        }

        // POST: /ContactList/ContactGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _contactGroupService.DeleteById(id);
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
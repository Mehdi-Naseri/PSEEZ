using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pseez.DataLayer.DataContext;
using Pseez.DomainClasses.Models.PseezEnt.Management;
using System.Net;

namespace Pseez.Areas.Admin.Controllers
{
     [Authorize(Roles = "Admin")]
    public class WebsiteVisitorsController : Controller
    {
        //
        // GET: /Admin/WebsiteVisitors/
         private PseezEntContext db = new PseezEntContext();

        // GET: /WebsiteVisitors/
        public ActionResult Index(string SortPropertyName = null)
        {
            List<WebsiteVisitor> WebsiteVisitorsSorted = db.WebsiteVisitors.ToList();
            if (!String.IsNullOrEmpty(SortPropertyName))
            {
                WebsiteVisitorsSorted = WebsiteVisitorsSorted.OrderBy(i => i.GetType().GetProperty(SortPropertyName).GetValue(i, null)).ToList();
            }
            //db.WebsiteVisitors.ToList().OrderBy();
            return View(WebsiteVisitorsSorted);
            //return View(db.WebsiteVisitors.ToList());
        }

        // GET: /WebsiteVisitors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebsiteVisitor websitevisitor = db.WebsiteVisitors.Find(id);
            if (websitevisitor == null)
            {
                return HttpNotFound();
            }
            return View(websitevisitor);
        }

        // GET: /WebsiteVisitors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebsiteVisitor websitevisitor = db.WebsiteVisitors.Find(id);
            if (websitevisitor == null)
            {
                return HttpNotFound();
            }
            return View(websitevisitor);
        }

        // POST: /WebsiteVisitors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,HostAddress,HostName,Browser,Url,UrlReferrer,ResolutionX,ResolutionY")] WebsiteVisitor websitevisitor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(websitevisitor).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(websitevisitor);
        }

        // GET: /WebsiteVisitors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebsiteVisitor websitevisitor = db.WebsiteVisitors.Find(id);
            if (websitevisitor == null)
            {
                return HttpNotFound();
            }
            return View(websitevisitor);
        }

        // POST: /WebsiteVisitors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WebsiteVisitor websitevisitor = db.WebsiteVisitors.Find(id);
            db.WebsiteVisitors.Remove(websitevisitor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAll()
        {
            db.WebsiteVisitors.RemoveRange(db.WebsiteVisitors.ToList() );
            //WebsiteVisitor websitevisitor = db.WebsiteVisitors.Find(id);
            //db.WebsiteVisitors.Remove(websitevisitor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
	}
}
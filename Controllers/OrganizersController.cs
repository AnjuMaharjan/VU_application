using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VU.Models;

namespace VU.Controllers
{
    public class OrganizersController : Controller
    {
        private VU_DB db = new VU_DB();

        // GET: Organizers
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.OrganizerNameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.ContactPersonSort = sortOrder == "contact_asc" ? "contact_desc": "contact_asc";
            ViewBag.EmailSort = sortOrder == "email_asc" ? "email_desc" : "email_asc";
            var organizers = db.Organizers.Include(e => e.Events);
            organizers = from o in organizers select o;
            
            if(!String.IsNullOrEmpty(searchString))
            {
                organizers = organizers.Where(o =>
                  o.OrganizerName.ToUpper().Contains(searchString.ToUpper()));
            }
            switch(sortOrder)
            {
                case "name_desc":
                    organizers = organizers.OrderByDescending(o => o.OrganizerName);
                    break;
                case "contact_asc":
                    organizers = organizers.OrderBy(o => o.ContactPerson);
                    break;
                case "contact_desc":
                    organizers = organizers.OrderByDescending(o => o.ContactPerson);
                    break;
                case "email_asc":
                    organizers = organizers.OrderBy(o => o.OrganizerEmail);
                    break;
                case "email_desc":
                    organizers = organizers.OrderByDescending(o => o.OrganizerEmail);
                    break;
                default:
                    organizers = organizers.OrderBy(o => o.OrganizerName);
                    break;
            }
            return View(organizers.ToList());
        }

        // GET: Organizers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizer organizer = db.Organizers.Find(id);
            if (organizer == null)
            {
                return HttpNotFound();
            }
            return View(organizer);
        }

        // GET: Organizers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organizers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrganizerID,OrganizerName,ContactPerson,OrganizerEmail,OrganizerPhone,OrganizerAddress")] Organizer organizer)
        {
            if (ModelState.IsValid)
            {
                db.Organizers.Add(organizer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organizer);
        }

        // GET: Organizers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizer organizer = db.Organizers.Find(id);
            if (organizer == null)
            {
                return HttpNotFound();
            }
            return View(organizer);
        }

        // POST: Organizers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrganizerID,OrganizerName,ContactPerson,OrganizerEmail,OrganizerPhone,OrganizerAddress")] Organizer organizer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organizer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organizer);
        }

        // GET: Organizers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizer organizer = db.Organizers.Find(id);
            if (organizer == null)
            {
                return HttpNotFound();
            }
            return View(organizer);
        }

        // POST: Organizers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organizer organizer = db.Organizers.Find(id);
            db.Organizers.Remove(organizer);
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

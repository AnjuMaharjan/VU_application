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
    public class RegistrationsController : Controller
    {
        private VU_DB db = new VU_DB();

        // GET: Registrations
        public ActionResult Index(string sortOrder)
        {
            var registrations = db.Registrations.Include(r => r.Attendee).Include(r => r.Event);
            ViewBag.EventNameSort = String.IsNullOrEmpty(sortOrder) ? "event_desc" : "";
            ViewBag.AttendeeNameSort = sortOrder == "name" ? "name_desc" : "name";
            ViewBag.RegFeeSort = sortOrder == "reg_fee" ? "reg_desc" : "reg_fee";

            switch (sortOrder)
            {
                case "event_desc":
                    registrations = registrations.OrderByDescending(o => o.Event.EventName);
                    break;
                case "name":
                    registrations = registrations.OrderBy(o => o.Attendee.AttendeeFirstName).ThenBy(o=> o.Attendee.AttendeeFirstName);
                    break;
                case "name_desc":
                    registrations = registrations.OrderByDescending(o => o.Attendee.AttendeeFirstName).ThenBy(o=> o.Attendee.AttendeeFirstName);
                    break;
                case "reg_fee":
                    registrations = registrations.OrderBy(o => o.RegistrationFee);
                    break;
                case "reg_desc":
                    registrations = registrations.OrderByDescending(o => o.RegistrationFee);
                    break;
                default:
                    registrations = registrations.OrderBy(o => o.Event.EventName);
                    break;
            }
            return View(registrations.ToList());
        }

        // GET: Registrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // GET: Registrations/Create
        public ActionResult Create()
        {
            ViewBag.AttendeeID = new SelectList(db.Attendees, "AttendeeID", "AttendeeFirstName");
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName");
            return View();
        }

        // POST: Registrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegistrationID,EventID,AttendeeID,RegistrationFee")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Registrations.Add(registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AttendeeID = new SelectList(db.Attendees, "AttendeeID", "AttendeeFirstName", registration.AttendeeID);
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", registration.EventID);
            return View(registration);
        }

        // GET: Registrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.AttendeeID = new SelectList(db.Attendees, "AttendeeID", "AttendeeFirstName", registration.AttendeeID);
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", registration.EventID);
            return View(registration);
        }

        // POST: Registrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegistrationID,EventID,AttendeeID,RegistrationFee")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AttendeeID = new SelectList(db.Attendees, "AttendeeID", "AttendeeFirstName", registration.AttendeeID);
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", registration.EventID);
            return View(registration);
        }

        // GET: Registrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // POST: Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registration registration = db.Registrations.Find(id);
            db.Registrations.Remove(registration);
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

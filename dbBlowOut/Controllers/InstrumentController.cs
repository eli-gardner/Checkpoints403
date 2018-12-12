using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dbBlowOut.DAL;
using dbBlowOut.Models;

namespace dbBlowOut.Controllers
{
    public class InstrumentController : Controller
    {
        private BlowOutContext db = new BlowOutContext();

        // GET: Instrument
        public ActionResult Index()
        {
            var instruments = db.Instruments.Include(i => i.Client);
            return View(instruments.ToList());
        }

        // GET: Instrument/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            instrument instrument = db.Instruments.Find(id);
            if (instrument == null)
            {
                return HttpNotFound();
            }
            return View(instrument);
        }

        // GET: Instrument/Create
        public ActionResult Create()
        {
            ViewBag.clientID = new SelectList(db.Clients, "clientID", "firstName");
            return View();
        }

        // POST: Instrument/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "instrumentID,description,condition,price,clientID")] instrument instrument)
        {
            if (ModelState.IsValid)
            {
                db.Instruments.Add(instrument);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.clientID = new SelectList(db.Clients, "clientID", "firstName", instrument.clientID);
            return View(instrument);
        }

        // GET: Instrument/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            instrument instrument = db.Instruments.Find(id);
            if (instrument == null)
            {
                return HttpNotFound();
            }
            ViewBag.clientID = new SelectList(db.Clients, "clientID", "firstName", instrument.clientID);
            return View(instrument);
        }

        // POST: Instrument/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "instrumentID,description,condition,price,clientID")] instrument instrument)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instrument).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.clientID = new SelectList(db.Clients, "clientID", "firstName", instrument.clientID);
            return View(instrument);
        }

        // GET: Instrument/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            instrument instrument = db.Instruments.Find(id);
            if (instrument == null)
            {
                return HttpNotFound();
            }
            return View(instrument);
        }

        // POST: Instrument/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            instrument instrument = db.Instruments.Find(id);
            db.Instruments.Remove(instrument);
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

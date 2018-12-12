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
    public class ClientController : Controller
    {
        private BlowOutContext db = new BlowOutContext();

        //Selection View
        public ActionResult Select(int? id)
        {
            instrument instrument = db.Instruments.Find(id);
            ViewBag.Select = instrument.instrumentID;
            return View();
        }

        //Select existing client
        public ActionResult Existing(int? id)
        {
            //instrument instrument = db.Instruments.Find(id);
            //ViewBag.Select = instrument.instrumentID;
            ViewBag.Select = id;
            return View(db.Clients);
        }

        //Assign existing client
        public ActionResult Assign(int clientid, int? instid)
        {
            int cid = clientid;
            instrument instrument = db.Instruments.Find(instid);
            instrument.clientID = cid;
            db.SaveChanges();

            return RedirectToAction("Summary", new { ClientID = instrument.clientID, InstrumentID = instrument.instrumentID });
        }

        // GET: Client
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        // GET: Client/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Client/Create
        public ActionResult Create(int id)
        {
            ViewBag.Inst = db.Instruments.Find(id);

            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "clientID,firstName,lastName,address,city,state,zip,email,phone")] Client client, int id)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();

                instrument instrument = db.Instruments.Find(id);
                instrument.clientID = client.clientID;
                db.SaveChanges();

                return RedirectToAction("Summary", new { ClientID = client.clientID, InstrumentID = instrument.instrumentID });
            }

            return View(client);
        }

        public ActionResult Summary(int ClientID, int InstrumentID)
        {
            Client client = db.Clients.Find(ClientID);
            instrument instrument = db.Instruments.Find(InstrumentID);

            ViewBag.Client = client;
            ViewBag.Instrument = instrument;
            ViewBag.YearPrice = instrument.price * 18;
            ViewBag.img = instrument.description + ".jpg";

            return View();
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "clientID,firstName,lastName,address,city,state,zip,email,phone")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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

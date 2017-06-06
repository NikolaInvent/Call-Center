using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kolcen.Models;

namespace Kolcen.Controllers
{
    public class ZahtevisController : Controller
    {
        private Model1 db = new Model1();

        // GET: Zahtevis
        public ActionResult Index()
        {
            var zahtevis = db.Zahtevis.Include(z => z.Zaposleni);
            return View(zahtevis.ToList());
        }

        // GET: Zahtevis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zahtevi zahtevi = db.Zahtevis.Find(id);
            if (zahtevi == null)
            {
                return HttpNotFound();
            }
            return View(zahtevi);
        }

        // GET: Zahtevis/Create
        public ActionResult Create()
        {
            ViewBag.ZaposleniID = new SelectList(db.Zaposlenis, "ZaposleniID", "Ime");
            return View();
        }

        // POST: Zahtevis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZahteviID,ZaposleniID,OpisProblema,BrojKlijenta,ResenjeProblema")] Zahtevi zahtevi)
        {
            if (ModelState.IsValid)
            {
                db.Zahtevis.Add(zahtevi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ZaposleniID = new SelectList(db.Zaposlenis, "ZaposleniID", "Ime", zahtevi.ZaposleniID);
            return View(zahtevi);
        }

        // GET: Zahtevis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zahtevi zahtevi = db.Zahtevis.Find(id);
            if (zahtevi == null)
            {
                return HttpNotFound();
            }
            ViewBag.ZaposleniID = new SelectList(db.Zaposlenis, "ZaposleniID", "Ime", zahtevi.ZaposleniID);
            return View(zahtevi);
        }

        // POST: Zahtevis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZahteviID,ZaposleniID,OpisProblema,BrojKlijenta,ResenjeProblema")] Zahtevi zahtevi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zahtevi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ZaposleniID = new SelectList(db.Zaposlenis, "ZaposleniID", "Ime", zahtevi.ZaposleniID);
            return View(zahtevi);
        }

        // GET: Zahtevis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zahtevi zahtevi = db.Zahtevis.Find(id);
            if (zahtevi == null)
            {
                return HttpNotFound();
            }
            return View(zahtevi);
        }

        // POST: Zahtevis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zahtevi zahtevi = db.Zahtevis.Find(id);
            db.Zahtevis.Remove(zahtevi);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SkiGes_v2.Models;

namespace SkiGes_v2.Controllers
{
    public class PensiunesController : Controller
    {
        private Model1 db = new Model1();

        // GET: Pensiunes
        public ActionResult Index()
        {
            var pensiune = db.Pensiune.Include(p => p.Adresa).Include(p => p.Partie);
            return View(pensiune.ToList());
        }

        // GET: Pensiunes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pensiune pensiune = db.Pensiune.Find(id);
            if (pensiune == null)
            {
                return HttpNotFound();
            }
            return View(pensiune);
        }

        // GET: Pensiunes/Create
        public ActionResult Create()
        {
            ViewBag.idAdresa = new SelectList(db.Adresa, "idAdresa", "oras");
            ViewBag.idPartie = new SelectList(db.Partie, "idPartie", "nume");
            return View();
        }

        // POST: Pensiunes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPensiune,idPartie,nume,email,telefon,camere,latitudine,logitudine,idAdresa")] Pensiune pensiune)
        {
            if (ModelState.IsValid)
            {
                db.Pensiune.Add(pensiune);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAdresa = new SelectList(db.Adresa, "idAdresa", "oras", pensiune.idAdresa);
            ViewBag.idPartie = new SelectList(db.Partie, "idPartie", "nume", pensiune.idPartie);
            return View(pensiune);
        }

        // GET: Pensiunes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pensiune pensiune = db.Pensiune.Find(id);
            if (pensiune == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAdresa = new SelectList(db.Adresa, "idAdresa", "oras", pensiune.idAdresa);
            ViewBag.idPartie = new SelectList(db.Partie, "idPartie", "nume", pensiune.idPartie);
            return View(pensiune);
        }

        // POST: Pensiunes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPensiune,idPartie,nume,email,telefon,camere,latitudine,logitudine,idAdresa")] Pensiune pensiune)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pensiune).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAdresa = new SelectList(db.Adresa, "idAdresa", "oras", pensiune.idAdresa);
            ViewBag.idPartie = new SelectList(db.Partie, "idPartie", "nume", pensiune.idPartie);
            return View(pensiune);
        }

        // GET: Pensiunes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pensiune pensiune = db.Pensiune.Find(id);
            if (pensiune == null)
            {
                return HttpNotFound();
            }
            return View(pensiune);
        }

        // POST: Pensiunes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pensiune pensiune = db.Pensiune.Find(id);
            db.Pensiune.Remove(pensiune);
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

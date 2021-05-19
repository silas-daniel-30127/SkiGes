using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SkiGes_v1._0.Models;

namespace SkiGes_v1._0.Controllers
{
    public class AdresasController : Controller
    {
        private Model1 db = new Model1();

        // GET: Adresas
        public ActionResult Index()
        {
            return View(db.Adresa.ToList());
        }

        // GET: Adresas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresa adresa = db.Adresa.Find(id);
            if (adresa == null)
            {
                return HttpNotFound();
            }
            return View(adresa);
        }

        // GET: Adresas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adresas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAdresa,oras,strada,numar")] Adresa adresa)
        {
            if (ModelState.IsValid)
            {
                db.Adresa.Add(adresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adresa);
        }

        // GET: Adresas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresa adresa = db.Adresa.Find(id);
            if (adresa == null)
            {
                return HttpNotFound();
            }
            return View(adresa);
        }

        // POST: Adresas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAdresa,oras,strada,numar")] Adresa adresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adresa);
        }

        // GET: Adresas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresa adresa = db.Adresa.Find(id);
            if (adresa == null)
            {
                return HttpNotFound();
            }
            return View(adresa);
        }

        // POST: Adresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adresa adresa = db.Adresa.Find(id);
            db.Adresa.Remove(adresa);
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

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
    public class RezervaresController : Controller
    {
        private Model1 db = new Model1();

        // GET: Rezervares
        public ActionResult Index()
        {
            return View(db.Rezervares.ToList());
        }

        // GET: Rezervares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezervare rezervare = db.Rezervares.Find(id);
            if (rezervare == null)
            {
                return HttpNotFound();
            }
            return View(rezervare);
        }

        // GET: Rezervares/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rezervares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRezervare,idPartie,idUtilizator,numarCamere")] Rezervare rezervare)
        {
            if (ModelState.IsValid)
            {
                db.Rezervares.Add(rezervare);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rezervare);
        }

        // GET: Rezervares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezervare rezervare = db.Rezervares.Find(id);
            if (rezervare == null)
            {
                return HttpNotFound();
            }
            return View(rezervare);
        }

        // POST: Rezervares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRezervare,idPartie,idUtilizator,numarCamere")] Rezervare rezervare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rezervare).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rezervare);
        }

        // GET: Rezervares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rezervare rezervare = db.Rezervares.Find(id);
            if (rezervare == null)
            {
                return HttpNotFound();
            }
            return View(rezervare);
        }

        // POST: Rezervares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rezervare rezervare = db.Rezervares.Find(id);
            db.Rezervares.Remove(rezervare);
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

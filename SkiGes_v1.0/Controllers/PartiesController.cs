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
    public class PartiesController : Controller
    {
        private Model1 db = new Model1();

        // GET: Parties
        public ActionResult Index()
        {
            return View(db.Partie.ToList());
        }

        // GET: Parties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partie partie = db.Partie.Find(id);
            if (partie == null)
            {
                return HttpNotFound();
            }
            return View(partie);
        }

        // GET: Parties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPartie,nume,orar,link,latitudine,longitudine,stare_partie,dificultate,strat_zapada")] Partie partie)
        {
            if (ModelState.IsValid)
            {
                db.Partie.Add(partie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(partie);
        }

        // GET: Parties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partie partie = db.Partie.Find(id);
            if (partie == null)
            {
                return HttpNotFound();
            }
            return View(partie);
        }

        // POST: Parties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPartie,nume,orar,link,latitudine,longitudine,stare_partie,dificultate,strat_zapada")] Partie partie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(partie);
        }

        // GET: Parties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partie partie = db.Partie.Find(id);
            if (partie == null)
            {
                return HttpNotFound();
            }
            return View(partie);
        }

        // POST: Parties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Partie partie = db.Partie.Find(id);
            db.Partie.Remove(partie);
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

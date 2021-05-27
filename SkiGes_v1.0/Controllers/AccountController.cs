using SkiGes_v1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SkiGes_v1._0.Controllers
{
    public class AccountController : Controller
    {
        private Model1 model1 = new Model1();

        // GET: Account
         public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Utilizator ut)
        {

            ut.type = "USER";


            try
            {
                model1.Utilizator.Add(ut);
                model1.SaveChanges();
                Session["NewUser"] = ut.nume;
                
            }
            catch (Exception)
            {
                Session["NewUser"] = "fail";
            }
           

            return View();
        }

        public ActionResult Login(Utilizator ut)
        {

            using (Model1 db = new Model1())
            {
                var obj = db.Utilizator.Where(a => (a.nume.Equals(ut.nume) || a.email.Equals(ut.nume)) && a.password.Equals(ut.password)).FirstOrDefault();
                if (obj != null)
                {
                    string name = obj.nume.ToString();
                    Session["UserName"] = name.ToUpper();
                    Session["UserType"] = obj.type.ToString();
                    return RedirectToAction("UserDashBoard");
                }
            }

            return View();
        }

        public ActionResult UserDashBoard()
        {
            return View();
        }

        public ActionResult PartiesInZoneAction(Class1 cs)
        {
            // return View() // pagina cu search si butoane

            FinderController finder = new FinderController();
            List<Partie> res = finder.findAllPartiesInZone(cs.range);
            return View("PartiesInZone", res);
        }

        public ActionResult PartiesInZone(List<Partie> res)
        {
            if(res == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(res);
        }

        // GET: Parties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partie partie = model1.Partie.Find(id);
            if (partie == null)
            {
                return HttpNotFound();
            }
            return View(partie);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
        public ActionResult searchMotel(int id)
        {
            FinderController finder = new FinderController();
            List < Pensiune > res= finder.findMotels(id);
            return View(res);
        }

        public ActionResult searchPartyByName(Class1 p)
        {
            string s = p.searchName;
            var query = from pt in model1.Partie where pt.nume.Contains (s) select pt;
            List<Partie> res = new List<Partie>();
            foreach (Partie pt in query)
            {
                res.Add(pt);
            }

            return View("PartiesInZone", res);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                model1.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
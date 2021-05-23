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
            model1.Utilizator.Add(ut); 
            return View();
        }

        public ActionResult Login(Utilizator ut)
        {

            using (Model1 db = new Model1())
            {
                var obj = db.Utilizator.Where(a => (a.nume.Equals(ut.nume) || a.email.Equals(ut.nume)) && a.password.Equals(ut.password)).FirstOrDefault();
                if (obj != null)
                {
                    Session["UserID"] = obj.idUtilizator.ToString();
                    Session["UserName"] = obj.nume.ToString();
                    Session["UserType"] = obj.type.ToString();
                    return RedirectToAction("UserDashBoard");
                }
            }

            return View();
        }
        public ActionResult UserDashBoard()
        {
            FinderController finder = new FinderController();
            List<Partie> res = finder.findAllPartiesInZone(100);
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
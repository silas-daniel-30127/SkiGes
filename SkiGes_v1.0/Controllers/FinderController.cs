using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using SkiGes_v1._0.Models;

namespace SkiGes_v1._0.Controllers
{
    public class FinderController : Controller
    {
        private Model1 model1 = new Model1();
        // GET: Finder
        public ActionResult NearestParty()
        {
            Session["PartyName"] = findFirstParty().nume;
            return View();
        }



        private string readFromUrl(string ip)
        {
            ip = ip.Remove(ip.Length - 1); 
            using (WebClient client = new WebClient())
            {
                return client.DownloadString("http://ip-api.com/csv/" + ip + "?fields=lat,lon").ToString();
            }
        }

        private string getIp()
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString("http://checkip.amazonaws.com").ToString();
            }
        }

        public Location getCurrentLocation()
        {
            string myIp;
            string url = "";
                myIp = getIp();
                url = readFromUrl(myIp);
            string[] lats = url.Split(',');
            lats[0].Trim();
            lats[1].Trim();
            double latitude = Double.Parse(lats[0], CultureInfo.InvariantCulture);
            double longitude = Double.Parse(lats[1], CultureInfo.InvariantCulture);
            
            return new Location((float)latitude, (float)longitude);
        }

        public List<Partie> findAllPartiesInZone(float range)
        {
            List<Partie> partyList = model1.Partie.ToList();

            Location currentLocation = getCurrentLocation();
            List<Partie> res = new List<Partie>();
        
            foreach (Partie partie in partyList) {
                if (currentLocation.distance(new Location((float)partie.latitudine, (float)partie.longitudine)) <= range)
                {
                    res.Add(partie);
                }
            }
            return res;
        }

        public Partie findFirstParty()
        {
            List<Partie> parties = model1.Partie.ToList();
            Location currentLocation = getCurrentLocation();
            Partie res = new Partie();
            float best_range;

            best_range = currentLocation.distance(new Location((float)parties[0].latitudine, (float)parties[0].longitudine));

            foreach (Partie partie in parties)
            {
                if (currentLocation.distance(new Location((float)partie.latitudine, (float)partie.longitudine)) < best_range)
                {
                    best_range = currentLocation.distance(new Location((float)parties[0].latitudine, (float)parties[0].longitudine));
                    res = partie;
                }
            }

            return res;
        }

        public List<Pensiune> findMotels(int id)
        {
            List<Pensiune> motels = model1.Pensiune.ToList();
            Partie partie = model1.Partie.Find(id);
            Location partieLocation = new Location((float)partie.latitudine,(float)partie.longitudine);
            List<Pensiune> hotels = new List<Pensiune>();
            foreach(Pensiune pensiune in motels)
            {
                if(partieLocation.distance(new Location((float)pensiune.latitudine, (float)pensiune.logitudine)) <= 20.0)
                {
                    hotels.Add(pensiune);
                }
            }
            
            return hotels;
        }
        
    }
}
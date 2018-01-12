using DataContextNamespace;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTerm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Log.Write("Home controller - Index");

            using (var context = new DataContextNamespace.DataContext())
            {
                int k = context.Users.Count();
            }

                return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            Log.Write("Home controller - About");
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            Log.Write("Home controller - Contact");
            return View();
        }
    }
}
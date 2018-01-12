using DataContextNamespace;
using MyTermMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTerm.Controllers
{
    public class TermController : Controller
    {
        // GET: Term
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RemoveTerm(int termId)
        {
            using (var context = new DataContext())
            {
                context.Terms.Remove(context.Terms.FirstOrDefault(c => c.ID == termId));
                context.SaveChanges();
                return View();
            }
        }

        public ActionResult EditTerm(TermViewModel model)
        {
            using (var context = new DataContext())
            {
                context.Terms.AddOrUpdate(model.ToDbModel());
                context.SaveChanges();
                return View();
            }
        }

        public ActionResult CreateTerm(TermViewModel model)
        {
            using (var context = new DataContext())
            {
                context.Terms.Add(model.ToDbModel());
                context.SaveChanges();
                return View();
            }
        }
    }
}
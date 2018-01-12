using DataContextNamespace;
using MyTermMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTermMVC.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddPerson(PersonView model)
        {
            using (var context = new DataContext())
            {
                context.Persons.Add(model.ToDataModel());
                context.SaveChanges();

                return View();
            }
        }

        public ActionResult RemovePerson(PersonView model)
        {
            using (var context = new DataContext())
            {
                context.Persons.Remove(context.Persons.FirstOrDefault(c => c.ID == model.ID));
                context.SaveChanges();

                return View();
            }
        }

        public ActionResult RemovePerson(int id)
        {
            using (var context = new DataContext())
            {
                context.Persons.Remove(context.Persons.FirstOrDefault(c => c.ID == id));
                context.SaveChanges();

                return View();
            }
        }
    }
}
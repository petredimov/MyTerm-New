using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTermMVC.Controllers
{
    public class ManagementController : Controller
    {
        // GET: Management
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateCategory()
        {
            return View();
        }

        public ActionResult CreateLine()
        {
            return View();
        }

        public ActionResult CreateSubCategory()
        {
            return View();
        }

        public ActionResult CreateCompany()
        {
            return View();
        }

        public ActionResult CreatePerson()
        {
            return View();
        }
    }
}
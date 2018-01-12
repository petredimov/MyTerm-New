using DataContextNamespace;
using MyTermMVC.Models;
using DataContextNamespace.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTermMVC.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReadCompanies()
        {
            IEnumerable<CompanyView> companies = new List<CompanyView>();
            using (var context = new DataContext())
            {
                context.Companies.Select(c => new CompanyView()
                {
                    EDB = c.EDB,
                    FaxNumber = c.FaxNumber,
                    Name = c.Name,
                    Address = c.Address,
                    AreaCode = c.AreaCode,
                    Country = c.Country,
                    Minicipality = c.Minicipality,
                    PhoneNumber = c.PhoneNumber,
                    Town = c.Town
                });

                return Json(companies);
            }
        }

        public ActionResult EditCompany(CompanyView model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new DataContext())
                {
                    Company company = context.Companies.FirstOrDefault(c => c.EDB == model.EDB);
                    if (company != null)
                    {
                        company = model.ToDataModel();
                        context.Companies.AddOrUpdate(company);
                        context.SaveChanges();
                    }
                }
            }

            return View();
        }

        public ActionResult AddCompany(CompanyView companyModel)
        {
            using (var context = new DataContext())
            {
                context.Companies.Add(companyModel.ToDataModel());
                context.SaveChanges();

                return View();
            }
        }

        public ActionResult RemoveCompany(string edb)
        {
            using (var context = new DataContext())
            {
                context.Companies.Remove(context.Companies.FirstOrDefault(c => c.EDB == edb));
                context.SaveChanges();
                return View();
            }
        }
    }
}
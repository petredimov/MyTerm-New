using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContextNamespace.Models;
using DataContextNamespace;
using System.Data.Entity;

namespace DataServices
{
    public class CompanyService : ICompanyService
    {
        public List<Company> GetCompanies()
        {
            using (var context = new DataContext())
            {
                return context.Companies.ToList();
            }
        }

        public Company GetCompany(int id)
        {
            using (var context = new DataContext())
            {
                return context.Companies.FirstOrDefault(c => c.ID == id);
            }
        }

        public Company InsertCompany(Company company)
        {
            using (var context = new DataContext())
            {
                Company newCompany = context.Companies.Add(company);
                context.SaveChanges();
                return newCompany;
            }
        }

        public void RemoveCompany(int id)
        {
            using (var context = new DataContext())
            {
                Company company = context.Companies.FirstOrDefault(c => c.ID == id);
                if (company != null)
                {
                    context.Companies.Remove(company);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateClient(Company company)
        {
            using (var context = new DataContext())
            {
                context.Entry(company).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

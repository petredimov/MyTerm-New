using DataContextNamespace;
using DataContextNamespace.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    public class CompanyCategoryService : ICompanyCategoryService
    {
        public List<CompanyCategory> GetCompanyCategories()
        {
            using (var context = new DataContext())
            {
                return context.CompanyCategories.ToList();
            }
        }

        public CompanyCategory GetCompanyCategory(int id)
        {
            using (var context = new DataContext())
            {
                return context.CompanyCategories.FirstOrDefault(c => c.ID == id);
            }
        }

        public CompanyCategory InsertCompanyCategory(CompanyCategory companyCategory)
        {
            using (var context = new DataContext())
            {
                CompanyCategory newCompanyCategory = context.CompanyCategories.Add(companyCategory);
                context.SaveChanges();
                return newCompanyCategory;
            }
        }

        public void RemoveCompanyCategory(int id)
        {
            using (var context = new DataContext())
            {
                CompanyCategory companyCategory = context.CompanyCategories.FirstOrDefault(c=> c.ID == id);
                if (companyCategory != null)
                {
                    context.CompanyCategories.Remove(companyCategory);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateCompanyCategory(CompanyCategory companyCategory)
        {
            using (var context = new DataContext())
            {
                context.Entry(companyCategory).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

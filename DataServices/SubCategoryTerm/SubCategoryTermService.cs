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
    public class SubCategoryTermService : ISubCategoryTermService
    {
        public SubCategoryTerm GetSubCategoryTerm(int id)
        {
            using (var context = new DataContext())
            {
                return context.SubCategoryTerms.FirstOrDefault(c => c.ID == id);
            }
        }

        public List<SubCategoryTerm> GetSubCategoryTerms()
        {
            using (var context = new DataContext())
            {
                return context.SubCategoryTerms.ToList();
            }
        }

        public SubCategoryTerm InsertSubCategoryTerm(SubCategoryTerm subCategoryTerm)
        {
            using (var context = new DataContext())
            {
                SubCategoryTerm newSubCategoryTemp = context.SubCategoryTerms.Add(subCategoryTerm);
                context.SaveChanges();
                return newSubCategoryTemp;
            }
        }

        public void RemoveSubCategoryTerm(int id)
        {
            using (var context = new DataContext())
            {
                SubCategoryTerm subCategoryTerm = context.SubCategoryTerms.FirstOrDefault(c => c.ID == id);
                if (subCategoryTerm != null)
                {
                    context.SubCategoryTerms.Remove(subCategoryTerm);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateSubCategoryTerm(SubCategoryTerm subCategoryTerm)
        {
            using (var context = new DataContext())
            {
                context.Entry(subCategoryTerm).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

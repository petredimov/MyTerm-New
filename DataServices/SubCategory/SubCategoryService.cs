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
    public class SubCategoryService : ISubCategoryService
    {
        public List<SubCategory> GetSubCategories()
        {
            using (var context = new DataContext())
            {
                return context.SubCategories.ToList();
            }
        }

        public SubCategory GetSubCategory(int id)
        {
            using (var context = new DataContext())
            {
                return context.SubCategories.FirstOrDefault(c=>c.ID == id);
            }
        }

        public SubCategory InsertSubCategory(SubCategory subCategory)
        {
            using (var context = new DataContext())
            {
                SubCategory newSubCategory = context.SubCategories.Add(subCategory);
                context.SaveChanges();
                return newSubCategory;
            }
        }

        public void RemoveSubCategory(int id)
        {
            using (var context = new DataContext())
            {
                SubCategory subCategory = context.SubCategories.FirstOrDefault(c=> c.ID == id);
                if (subCategory != null)
                {
                    context.SubCategories.Remove(subCategory);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateSubCategory(SubCategory subCategory)
        {
            using (var context = new DataContext())
            {
                context.Entry(subCategory).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

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
    public class CategoryService : ICategoryService
    {
        public List<Category> GetCategories()
        {
            using (var context = new DataContext())
            {
                return context.Categories.ToList();
            }
        }

        public Category GetCategory(int id)
        {
            using (var context = new DataContext())
            {
                return context.Categories.FirstOrDefault(c => c.ID == id);
            }
        }

        public Category InsertCategory(Category category)
        {
            using (var context = new DataContext())
            {
                Category newCategory = context.Categories.Add(category);
                context.SaveChanges();
                return newCategory;
            }
        }

        public void RemoveCategory(int id)
        {
            using (var context = new DataContext())
            {
                Category category = context.Categories.FirstOrDefault(c => c.ID == id);
                context.Categories.Remove(category);
            }
        }

        public void UpdateCategory(Category category)
        {
            using (var context = new DataContext())
            {
                context.Entry(category).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

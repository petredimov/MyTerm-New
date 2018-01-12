using DataContextNamespace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    public interface ICategoryService
    {
        Category InsertCategory(Category category);
        void UpdateCategory(Category category);
        void RemoveCategory(int id);
        Category GetCategory(int id);
        List<Category> GetCategories();
    }
}

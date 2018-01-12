using DataContextNamespace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    public interface ISubCategoryService
    {
        SubCategory InsertSubCategory(SubCategory subCategory);
        void UpdateSubCategory(SubCategory subCategory);
        void RemoveSubCategory(int id);
        SubCategory GetSubCategory(int id);
        List<SubCategory> GetSubCategories();
    }
}

using DataContextNamespace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    public interface ISubCategoryTermService
    {
        SubCategoryTerm InsertSubCategoryTerm(SubCategoryTerm subCategoryTerm);
        void UpdateSubCategoryTerm(SubCategoryTerm subCategoryTerm);
        void RemoveSubCategoryTerm(int id);
        SubCategoryTerm GetSubCategoryTerm(int id);
        List<SubCategoryTerm> GetSubCategoryTerms();
    }
}

using DataContextNamespace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    public interface ICompanyCategoryService
    {
        CompanyCategory InsertCompanyCategory(CompanyCategory companyCategory);
        void UpdateCompanyCategory(CompanyCategory companyCategory);
        void RemoveCompanyCategory(int id);
        CompanyCategory GetCompanyCategory(int id);
        List<CompanyCategory> GetCompanyCategories();

    }
}

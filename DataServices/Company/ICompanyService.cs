using DataContextNamespace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    public interface ICompanyService
    {
        Company InsertCompany(Company company);
        void UpdateClient(Company company);
        void RemoveCompany(int id);
        Company GetCompany(int id);
        List<Company> GetCompanies();
    }
}

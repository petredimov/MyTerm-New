using MyTerm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    public interface ICountryService
    {
        Country InsertCountry(Country companyCategory);
        void UpdateCountry(Country companyCategory);
        void RemoveCountry(int id);
        Country GetCountry(int id);
        List<Country> GetCountries();
    }
}

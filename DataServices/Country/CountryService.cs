using DataContextNamespace;
using MyTerm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using DataContextNamespace.Models;

namespace DataServices
{
    public class CountryService : ICountryService
    {
        public List<Country> GetCountries()
        {
            using (var context = new DataContext())
            {
                return context.Countries.ToList();
            }
        }

        public List<City> GetCitiesForCountry(string countryName)
        {
            using (var context = new DataContext())
            {
                Country country = context.Countries.FirstOrDefault(c => c.Name == countryName);
                if (country != null)
                {
                    return country.Cities.ToList();
                }
                else
                {
                    return null;
                }
            }
        }

        public Country GetCountry(int id)
        {
            using (var context = new DataContext())
            {
                return context.Countries.FirstOrDefault(c => c.Id == id);
            }
        }

        public Country InsertCountry(Country companyCategory)
        {
            using (var context = new DataContext())
            {
                Country newCountry = context.Countries.Add(companyCategory);
                context.SaveChanges();

                return newCountry;
            }
        }

        public void RemoveCountry(int id)
        {
            using (var context = new DataContext())
            {
                Country country = context.Countries.FirstOrDefault(c => c.Id == id);

                if (country != null)
                {
                    context.Countries.Remove(country);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateCountry(Country country)
        {
            using (var context = new DataContext())
            {
                context.Entry(country).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

using DataContextNamespace.Models;
using DataServices;
using MyTerm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyTermMVC.Controllers_API
{
    public class CountryController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IHttpActionResult result = null;

            CountryService service = new CountryService();
            List <Country> countries = service.GetCountries();

            if (countries.Count > 0)
            {
                result = Ok(countries);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            CountryService service = new CountryService();
            Country country = service.GetCountry(id);
            List<City> obj = country?.Cities?.ToList();
            if (obj != null)
            {
                return Ok(obj);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }
        
        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
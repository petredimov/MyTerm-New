using DataContextNamespace.Models;
using DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyTerm.Api.Controllers
{
    public class CompanyController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            IHttpActionResult result = null;

            CompanyService service = new CompanyService();

            Company company = service.GetCompany(id);

            if (company != null)
            {
                result = Ok(company);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        // POST api/<controller>
        [HttpPost()]
        public IHttpActionResult Post(Company company)
        {
            IHttpActionResult result = null;
            CompanyService service = new CompanyService();
            Company newCompany = service.InsertCompany(company);

            if (newCompany != null)
            {
                result = Created<Company>(Request.RequestUri + newCompany.ID.ToString(), newCompany);
            }
            else
            {
                result = NotFound();
            }

            return result;

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            IHttpActionResult result = null;

            return result;

        }
    }
}
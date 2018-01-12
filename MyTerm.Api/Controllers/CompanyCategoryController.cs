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
    public class CompanyCategoryController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IHttpActionResult result = null;
            CompanyCategoryService service = new CompanyCategoryService();
            IEnumerable<CompanyCategory> companyCategories = service.GetCompanyCategories();
            if (companyCategories.Count() > 0)
            {
                result = Ok(companyCategories);
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
            IHttpActionResult result = null;

            CompanyCategoryService service = new CompanyCategoryService();

            CompanyCategory companyCategory = service.GetCompanyCategory(id);

            if (companyCategory != null)
            {
                result = Ok(companyCategory);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        // POST api/<controller>
        public IHttpActionResult Post(CompanyCategory companyCategory)
        {
            IHttpActionResult result = null;
            CompanyCategoryService service = new CompanyCategoryService();
            CompanyCategory newCompanyCategory = service.InsertCompanyCategory(companyCategory);

            if (newCompanyCategory != null)
            {
                result = Created<CompanyCategory>(Request.RequestUri + newCompanyCategory.ID.ToString(), newCompanyCategory);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(CompanyCategory companyCategory)
        {
            IHttpActionResult result = null;
            CompanyCategoryService service = new CompanyCategoryService();

            if (service.GetCompanyCategory(companyCategory.ID) != null)
            {
                service.UpdateCompanyCategory(companyCategory);
                result = Ok(companyCategory);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            IHttpActionResult result = null;
            CompanyCategoryService service = new CompanyCategoryService();

            CompanyCategory companyCategory = service.GetCompanyCategory(id);
            if (companyCategory != null)
            {
                service.RemoveCompanyCategory(id);

                result = Ok(true);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }
    }
}

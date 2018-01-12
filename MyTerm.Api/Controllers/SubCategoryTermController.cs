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
    public class SubCategoryTermController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IHttpActionResult result = null;
            SubCategoryTermService service = new SubCategoryTermService();
            IEnumerable<SubCategoryTerm> subCategoryTerm = service.GetSubCategoryTerms();
            if (subCategoryTerm.Count() > 0)
            {
                result = Ok(subCategoryTerm);
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

            SubCategoryTermService service = new SubCategoryTermService();

            SubCategoryTerm subCategoryTerm = service.GetSubCategoryTerm(id);

            if (subCategoryTerm != null)
            {
                result = Ok(subCategoryTerm);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        // POST api/<controller>
        [HttpPost()]
        public IHttpActionResult Post(SubCategoryTerm subCategoryTerm)
        {
            IHttpActionResult result = null;
            SubCategoryTermService service = new SubCategoryTermService();
            SubCategoryTerm newSubCategoryTerm = service.InsertSubCategoryTerm(subCategoryTerm);

            if (newSubCategoryTerm != null)
            {
                result = Created<SubCategoryTerm>(Request.RequestUri + newSubCategoryTerm.ID.ToString(), newSubCategoryTerm);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(SubCategoryTerm subCategoryTerm)
        {
            IHttpActionResult result = null;
            SubCategoryTermService service = new SubCategoryTermService();

            if (service.GetSubCategoryTerm(subCategoryTerm.ID) != null)
            {
                service.UpdateSubCategoryTerm(subCategoryTerm);
                result = Ok(subCategoryTerm);
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
            SubCategoryTermService service = new SubCategoryTermService();

            SubCategoryTerm subCategoryTerm = service.GetSubCategoryTerm(id);
            if (subCategoryTerm != null)
            {
                service.RemoveSubCategoryTerm(id);

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

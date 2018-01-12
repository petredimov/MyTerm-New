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
    public class TermController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IHttpActionResult result = null;
            TermService service = new TermService();
            IEnumerable<Term> terms = service.GetTerms();
            if (terms.Count() > 0)
            {
                result = Ok(terms);
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

            TermService service = new TermService();

            Term term = service.GetTerm(id);

            if (term != null)
            {
                result = Ok(term);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        // POST api/<controller>
        [HttpPost()]
        public IHttpActionResult Post(Term term)
        {
            IHttpActionResult result = null;
            TermService service = new TermService();
            Term newTerm = service.InsertTerm(term);

            if (newTerm != null)
            {
                result = Created<Term>(Request.RequestUri + newTerm.ID.ToString(), newTerm);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(Term term)
        {
            IHttpActionResult result = null;
            TermService service = new TermService();

            if (service.GetTerm(term.ID) != null)
            {
                service.UpdateTerm(term);
                result = Ok(term);
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
            TermService service = new TermService();

            Term term = service.GetTerm(id);
            if (term != null)
            {
                service.RemoveTerm(id);

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

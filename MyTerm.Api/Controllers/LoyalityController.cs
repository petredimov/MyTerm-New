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
    public class LoyalityController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IHttpActionResult result = null;
            LoyalityService service = new LoyalityService();
            IEnumerable<Loyality> loyalities = service.GetLoyality();
            if (loyalities.Count() > 0)
            {
                result = Ok(loyalities);
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

            LoyalityService service = new LoyalityService();

            Loyality loyality = service.GetLoyality(id);

            if (loyality != null)
            {
                result = Ok(loyality);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        // POST api/<controller>
        [HttpPost()]
        public IHttpActionResult Post(Loyality loyality)
        {
            IHttpActionResult result = null;
            LoyalityService service = new LoyalityService();
            Loyality newLoyality = service.InsertLoyality(loyality);

            if (newLoyality != null)
            {
                result = Created<Loyality>(Request.RequestUri + newLoyality.ID.ToString(), newLoyality);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(Loyality loyality)
        {
            IHttpActionResult result = null;
            LoyalityService service = new LoyalityService();

            if (service.GetLoyality(loyality.ID) != null)
            {
                service.UpdateLoyality(loyality);
                result = Ok(loyality);
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
            LoyalityService service = new LoyalityService();

            Loyality loyality = service.GetLoyality(id);
            if (loyality != null)
            {
                service.RemoveLoyality(id);

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

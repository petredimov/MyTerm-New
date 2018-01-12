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
    public class RatingController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IHttpActionResult result = null;
            RatingService service = new RatingService();
            IEnumerable<Rating> ratings = service.GetRatings();
            if (ratings.Count() > 0)
            {
                result = Ok(ratings);
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

            RatingService service = new RatingService();

            Rating rating = service.GetRating(id);

            if (rating != null)
            {
                result = Ok(rating);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        // POST api/<controller>
        [HttpPost()]
        public IHttpActionResult Post(Rating rating)
        {
            IHttpActionResult result = null;
            RatingService service = new RatingService();
            Rating newRating = service.InsertRating(rating);

            if (newRating != null)
            {
                result = Created<Rating>(Request.RequestUri + newRating.ID.ToString(), newRating);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(Rating rating)
        {
            IHttpActionResult result = null;
            RatingService service = new RatingService();

            if (service.GetRating(rating.ID) != null)
            {
                service.UpdateRating(rating);
                result = Ok(rating);
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
            RatingService service = new RatingService();

            Rating rating = service.GetRating(id);
            if (rating != null)
            {
                service.RemoveRating(id);

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

using DataContextNamespace.Models;
using DataServices;
using System.Collections.Generic;
using System.Web.Http;

namespace MyTerm.Api.Controllers
{
    public class PersonController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet()]
        public IHttpActionResult Get(int id)
        {
            IHttpActionResult result = null;

            PersonService personService = new PersonService();
            Person person = personService.GetPerson(id);

            if (person != null)
            {
                result = Ok(person);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        // POST api/<controller>
        [HttpPost()]
        public IHttpActionResult Post(Person person)
        {
            IHttpActionResult result = null;

            PersonService service = new PersonService();

            Person newPerson = service.InsertPerson(person);
            if (person != null)
            {
                result = Created<Person>(Request.RequestUri + newPerson.ID.ToString(), newPerson);
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
        public void Delete(int id)
        {
        }
    }
}
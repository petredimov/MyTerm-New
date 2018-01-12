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
    public class LineController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IHttpActionResult result = null;
            LineService service = new LineService();
            IEnumerable<Line> lines = service.GetLine();
            if (lines.Count() > 0)
            {
                result = Ok(lines);
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

            LineService service = new LineService();

            Line line = service.GetLine(id);

            if (line != null)
            {
                result = Ok(line);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        // POST api/<controller>
        [HttpPost()]
        public IHttpActionResult Post(Line line)
        {
            IHttpActionResult result = null;
            LineService service = new LineService();
            Line newLine = service.InsertLine(line);

            if (newLine != null)
            {
                result = Created<Line>(Request.RequestUri + newLine.Id.ToString(), newLine);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(Line line)
        {
            IHttpActionResult result = null;
            LineService service = new LineService();

            if (service.GetLine(line.Id) != null)
            {
                service.UpdateLine(line);
                result = Ok(line);
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
            LineService service = new LineService();

            Line line = service.GetLine(id);
            if (line != null)
            {
                service.RemoveLine(id);

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

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
    public class ScheduleController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IHttpActionResult result = null;
            ScheduleService service = new ScheduleService();
            IEnumerable<Schedule> schedules = service.GetSchedules();
            if (schedules.Count() > 0)
            {
                result = Ok(schedules);
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

            ScheduleService service = new ScheduleService();

            Schedule schedule = service.GetSchedule(id);

            if (schedule != null)
            {
                result = Ok(schedule);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        // POST api/<controller>
        [HttpPost()]
        public IHttpActionResult Post(Schedule schedule)
        {
            IHttpActionResult result = null;
            ScheduleService service = new ScheduleService();
            Schedule newSchedule = service.InsertSchedule(schedule);

            if (newSchedule != null)
            {
                result = Created<Schedule>(Request.RequestUri + newSchedule.ID.ToString(), newSchedule);
            }
            else
            {
                result = NotFound();
            }

            return result;
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(Schedule schedule)
        {
            IHttpActionResult result = null;
            ScheduleService service = new ScheduleService();

            if (service.GetSchedule(schedule.ID) != null)
            {
                service.UpdateSchedule(schedule);
                result = Ok(schedule);
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
            ScheduleService service = new ScheduleService();

            Schedule schedule = service.GetSchedule(id);
            if (schedule != null)
            {
                service.RemoveSchedule(id);

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

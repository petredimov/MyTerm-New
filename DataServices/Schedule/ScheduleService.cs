using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContextNamespace.Models;
using DataContextNamespace;
using System.Data.Entity;

namespace DataServices
{
    public class ScheduleService : IScheduleService
    {
        public Schedule GetSchedule(int id)
        {
            using (var context = new DataContext())
            {
                return context.Schedules.FirstOrDefault(c => c.ID == id);
            }
        }

        public List<Schedule> GetSchedules()
        {
            using (var context = new DataContext())
            {
                return context.Schedules.ToList();
            }
        }

        public Schedule InsertSchedule(Schedule schedule)
        {
            using (var context = new DataContext())
            {
                Schedule newSchedule = context.Schedules.Add(schedule);
                context.SaveChanges();
                return newSchedule;
            }
        }

        public void RemoveSchedule(int id)
        {
            using (var context = new DataContext())
            {
                Schedule schedule = context.Schedules.FirstOrDefault(c => c.ID == id);
                if (schedule != null)
                {
                    context.Schedules.Remove(schedule);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateSchedule(Schedule schedule)
        {
            using (var context = new DataContext())
            {
                context.Entry(schedule).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

using DataContextNamespace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    public interface IScheduleService
    {
        Schedule InsertSchedule(Schedule schedule);
        void UpdateSchedule(Schedule schedule);
        void RemoveSchedule(int id);
        Schedule GetSchedule(int id);
        List<Schedule> GetSchedules();
    }
}

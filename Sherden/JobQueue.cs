using Sherden.Schedules;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sherden
{
    public class JobQueue
    {
        private IEnumerable<Schedule> schedules;

        public JobQueue(Schedule schedule)
        {
            schedules = new List<Schedule> { schedule };
        }

        public JobQueue(IEnumerable<Schedule> shedules)
        {
            schedules = shedules;
        }

        public Task Run()
        {
            return Task.Run(() =>
            {
                foreach (var schedule in schedules)
                    schedule.Execute();
            });
        }
    }
}
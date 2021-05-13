using Sherden.Schedules;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sherden
{
    public class Shedules
    {
        private IEnumerable<Schedule> schedules;

        public Shedules(Schedule schedule)
        {
            schedules = new List<Schedule> { schedule };
        }

        public Shedules(IEnumerable<Schedule> shedules)
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
using Sherden.Schedules;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sherden
{
    public class Plan
    {
        private IEnumerable<Schedule> schedules;

        public Plan(Schedule schedule)
        {
            schedules = new List<Schedule> { schedule };
        }

        public Plan(IEnumerable<Schedule> shedules)
        {
            schedules = shedules;
        }

        public Task Execute()
        {
            return Task.Run(() =>
            {
                foreach (var schedule in schedules)
                    schedule.Execute();
            });
        }
    }
}
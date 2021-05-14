using Sherden.Plans;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sherden
{
    public class Schedule
    {
        private IEnumerable<Plan> schedules;

        public Schedule(Plan plan)
        {
            schedules = new List<Plan> { plan };
        }

        public Schedule(IEnumerable<Plan> plans)
        {
            schedules = plans;
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
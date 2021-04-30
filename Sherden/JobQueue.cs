using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sherden
{
    public class JobQueue
    {
        public IEnumerable<Shedule> Shedules { get; }

        public JobQueue(Shedule shedule)
        {
            Shedules = new List<Shedule>{ shedule };
        }

        public JobQueue(IEnumerable<Shedule> shedules)
        {
            Shedules = shedules;
        }

        public Task Run()
        {
            return Task.Run(() =>
            {
                foreach (var shedule in Shedules)
                {
                    shedule.Start();
                }
            });
        }
    }
}
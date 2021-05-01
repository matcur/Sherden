using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sherden.Obstacles
{
    public class Start : Obstacle
    {
        private DateTime time;

        public Start(Job job, DateTime time)
        {
            this.job = job;
            this.time = time;
        }

        public Start(Obstacle next, DateTime time)
        {
            this.next = next;
            this.time = time;
        }

        public override void Activate()
        {
            var time = (this.time - DateTime.Now).TotalMilliseconds;
            var delay = Math.Max(time, 0);

            Thread.Sleep((int)delay);

            job.Execute();
            next.Activate();
        }
    }
}

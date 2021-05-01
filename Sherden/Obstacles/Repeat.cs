using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sherden.Obstacles
{
    public class Repeat : Obstacle
    {
        private readonly TimeSpan timeout;

        public Repeat(Job job, TimeSpan timeout)
        {
            this.job = job;
            this.timeout = timeout;
        }

        public Repeat(Obstacle next, TimeSpan timeout)
        {
            this.next = next;
            this.timeout = timeout;
        }

        public override void Activate()
        {
            while (true)
            {
                Thread.Sleep(timeout);

                job.Execute();
                next.Activate();
            }
        }
    }
}

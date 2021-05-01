using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sherden.Obstacles
{
    public class Repeat : Obstacle
    {
        private readonly int timeoutSeconds;

        public Repeat(Job job, int timeoutSeconds)
        {
            this.job = job;
            this.timeoutSeconds = timeoutSeconds;
        }

        public Repeat(Obstacle next, int timeoutSeconds)
        {
            this.next = next;
            this.timeoutSeconds = timeoutSeconds;
        }

        public override void Activate()
        {
            while (true)
            {
                Thread.Sleep(timeoutSeconds * 1000);

                job.Execute();
                next.Activate();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sherden.Obstacles
{
    public class Delay : Obstacle
    {
        private readonly int milliseconds;

        public Delay(Obstacle next, int milliseconds)
        {
            this.next = next;
            this.milliseconds = milliseconds;
        }

        public Delay(Job job, int milliseconds)
        {
            this.job = job;
            this.milliseconds = milliseconds;
        }

        public override void Activate()
        {
            Thread.Sleep(milliseconds);

            job.Execute();
            next.Activate();
        }
    }
}

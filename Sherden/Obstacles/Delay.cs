using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sherden.Obstacles
{
    public class Delay : Obstacle
    {
        private readonly int seconds;

        public Delay(Obstacle next, int seconds)
        {
            this.next = next;
            this.seconds = seconds;
        }

        public Delay(Job job, int seconds)
        {
            this.job = job;
            this.seconds = seconds;
        }

        public override void Activate()
        {
            Thread.Sleep(seconds * 1000);

            job.Execute();
            next.Activate();
        }
    }
}

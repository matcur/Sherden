using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sherden.Obstacles
{
    class Try : Obstacle
    {
        private readonly int count;

        private readonly int timeoutSeconds;

        public Try(Obstacle next, int count, int timeoutSeconds = 0)
        {
            this.next = next;
            this.count = count;
            this.timeoutSeconds = timeoutSeconds;
        }

        public Try(Job job, int count, int timeoutSeconds = 0)
        {
            this.job = job;
            this.count = count;
            this.timeoutSeconds = timeoutSeconds;
        }

        public override void Activate()
        {
            var @try = 0;
            while (@try <= count)
            {
                try
                {
                    job.Execute();
                    next.Activate();

                    return;
                }
                catch(Exception e)
                {
                    Thread.Sleep(timeoutSeconds * 1000);

                    if (@try == count)
                        throw e;

                    @try++;
                }
            }
        }
    }
}

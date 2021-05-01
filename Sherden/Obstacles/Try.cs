using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sherden.Obstacles
{
    class Try : Obstacle
    {
        private readonly int count;

        private readonly int timeout;

        public Try(Obstacle next, int count, int timeout = 0)
        {
            this.next = next;
            this.count = count;
            this.timeout = timeout;
        }

        public Try(Job job, int count, int timeout = 0)
        {
            this.job = job;
            this.count = count;
            this.timeout = timeout;
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
                }
                catch(Exception e)
                {
                    Console.WriteLine("handle error");
                    Thread.Sleep(timeout);

                    if (@try == count)
                        throw e;

                    @try++;
                }
            }
        }
    }
}

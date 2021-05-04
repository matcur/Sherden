using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sherden.Obstacles.Cronning
{
    public class Cron : Obstacle
    {
        private readonly CronExpression expression;

        public Cron(Obstacle next, string rule)
        {
            this.next = next;
            this.expression = new CronExpression(rule);
        }

        public Cron(Job job, string rule)
        {
            this.job = job;
            this.expression = new CronExpression(rule);
        }

        public override void Activate()
        {
            while (true)
            {
                var milliseconds = expression.ActivateTime.TotalMilliseconds;
                Console.WriteLine(milliseconds);
                Thread.Sleep(Math.Max((int)milliseconds, 0));

                job.Execute();
                next.Activate();
            }
        }
    }
}

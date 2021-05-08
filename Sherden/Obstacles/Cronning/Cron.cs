using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public async override void Activate()
        {
            while (true)
            {
                var milliseconds = expression.ActivateTime.TotalMilliseconds;
                Console.WriteLine(milliseconds);
                await Task.Delay((int)milliseconds);

                job.Execute();
                next.Activate();
            }
        }
    }
}

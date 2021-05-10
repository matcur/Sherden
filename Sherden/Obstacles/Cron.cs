using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Sherden.Obstacles.Cronning;

namespace Sherden.Obstacles
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

        public override async void Activate()
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

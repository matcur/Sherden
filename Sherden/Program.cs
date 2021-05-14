using Sherden.Obstacles;
using Sherden.Obstacles.Cronning;
using Sherden.Plans;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Sherden
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);

            var s = DateTime.Now.AddSeconds(10).Second;
            var m = DateTime.Now.Minute;
            // s m h dow M dom y
            var cron = $"{s} {m} 1 ? * *";
            Console.WriteLine(cron);
            var schedule = new SimplePlan(
                new Cron(
                    new Message("hi"),
                    cron
                )
            );

            new Schedule(
                new List<SimplePlan> { schedule }   
            ).Execute();

            Console.ReadKey();
        }
    }

    class Message : Job
    {
        private readonly string value;

        public Message(string value)
        {
            this.value = value;
        }

        public void Execute()
        {
            Console.WriteLine(value);
        }
    }

    class ActionJob : Job
    {
        private readonly Action action;

        public ActionJob(Action action)
        {
            this.action = action;
        }

        public void Execute()
        {
            action?.Invoke();
        }
    }
}

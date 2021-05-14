using Sherden.Obstacles;
using Sherden.Obstacles.Cronning;
using Sherden;
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
            var source = new CancellationTokenSource();
            Console.WriteLine(cron);
            var schedule = new SimplePlan(
                new Repeat(
                    new Cancellation(
                        new Message("hi"),
                        source.Token
                    ),
                    2
                )
            );
    
            new Schedule(
                new List<SimplePlan> { schedule }   
            ).Execute();

            Console.WriteLine("press key to cancel job");
            Console.ReadKey();
            source.Cancel();
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
            if (new Random().Next() > 10)
                Cancel();
            Console.WriteLine(value);
        }

        protected void Cancel()
        {
            
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

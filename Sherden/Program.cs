using Sherden.Obstacles;
using Sherden.Obstacles.Cronning;
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
            Console.WriteLine("start");
            var shedule1 = new Shedule(
                new Cron(
                    new Message("hi"),
                    // s m h dow M dom y
                    "* 49 * ? * *"
                )
            );

            new JobQueue(
                new List<Shedule> { shedule1 }   
            ).Run();

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

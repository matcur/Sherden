using Sherden.Obstacles;
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
                new Start(
                    new Repeat(
                        new Try(
                            new Message("hi"),
                            3
                        ), 1
                    ), DateTime.Now.AddSeconds(1)
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
            if (new Random().Next(3) == 0)
                throw new Exception("fuck");

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

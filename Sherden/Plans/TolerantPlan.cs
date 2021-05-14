using System;
using System.Threading.Tasks;

namespace Sherden
{
    public class TolerantPlan : Plan
    {
        public Obstacle Obstacle { get; }

        public TolerantPlan(Obstacle obstacle)
        {
            Obstacle = obstacle;
        }
        
        public void Execute()
        {
            Task.Run(() =>
            {
                try
                {
                    Task.Run(Obstacle.Activate);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
        }
    }
}
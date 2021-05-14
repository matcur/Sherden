using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sherden
{
    public class SimplePlan : Plan
    {
        public Obstacle Obstacle { get; }

        public SimplePlan(Obstacle obstacle)
        {
            Obstacle = obstacle;
        }

        public void Execute()
        {
            Task.Run(Obstacle.Activate);
        }
    }
}

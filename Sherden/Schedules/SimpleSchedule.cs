using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sherden.Schedules
{
    public class SimpleSchedule : Schedule
    {
        public Obstacle Obstacle { get; }

        public SimpleSchedule(Obstacle obstacle)
        {
            Obstacle = obstacle;
        }

        public void Execute()
        {
            Task.Run(Obstacle.Activate);
        }
    }
}

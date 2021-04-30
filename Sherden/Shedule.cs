using Sherden.Obstacles;
using System.Threading.Tasks;

namespace Sherden
{
    public sealed class Shedule
    {
        public Obstacle Obstacle { get; }

        public Shedule(Obstacle obstacle)
        {
            Obstacle = obstacle;
        }

        public void Start()
        {
            Task.Run(Obstacle.Activate);
        }
    }
}
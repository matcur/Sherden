using System;
using System.Collections.Generic;
using System.Text;

namespace Sherden
{
    public abstract class Obstacle
    {
        public readonly static Obstacle Null = new NullObstacle();

        protected Job job = new Job.Null();

        protected Obstacle next = Null;

        public abstract void Activate();

        private class NullObstacle : Obstacle
        {
            public override void Activate() { }
        }
    }
}

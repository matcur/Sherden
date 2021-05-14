using System.Threading;

namespace Sherden.Obstacles
{
    public class Cancellation : Obstacle
    {
        private readonly CancellationToken token;

        public Cancellation(Job job, CancellationToken token)
        {
            this.job = job;
            this.token = token;
        }

        public Cancellation(Obstacle next, CancellationToken token)
        {
            this.next = next;
            this.token = token;
        }
        
        public override void Activate()
        {
            if (token.IsCancellationRequested)
                throw new JobCanceledException();
            
            job.Execute();
            next.Activate();
        }
    }
}
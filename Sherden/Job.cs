namespace Sherden
{
    public interface Job
    {
        public void Execute();

        public class Null : Job
        {
            public void Execute() { }
        }
    }
}
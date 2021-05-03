using System;
using System.Collections.Generic;
using System.Text;

namespace Sherden.Obstacles.Cronning.Date
{
    class Hour : CronDate
    {
        public const int RulePosition = 2;

        public override int Value
        {
            get
            {
                var stringHour = SplittedRule[RulePosition];
                if (stringHour == "*")
                    return PrepeareResult(Now.Hour);

                int hour;
                if (!int.TryParse(stringHour, out hour))
                    throw new ArgumentException($"Hour must be number or *, [{stringHour}] given");

                return PrepeareResult(hour);
            }
        }

        public Hour(string rule) : base(rule) { }

        public bool IsMinuteOver(int hour)
        {
            return new Minute(rule).Value < DateTime.Now.Minute
                && Now.Hour >= hour;
        }

        private int PrepeareResult(int hour)
        {
            if (hour > 24 || hour < 1)
                throw new ArgumentException($"Hour must be between [1, 24], [{hour}] given");

            if (IsMinuteOver(hour))
                hour++;

            return hour;
        }
    }
}
